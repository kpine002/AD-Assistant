using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Media;
using WMPLib;
using System.Collections;

namespace ADAssistant
{
    public partial class Form1 : Form
    {
        List<string> historyItems = new List<string>();

        public Form1()
        {           
            InitializeComponent();
            this.TopMost = false;
        }

        private void clearbutton_Click(object sender, EventArgs e)
        {
            pidBox.Text = "";
            usrBox.Text = "";
            resultBox.Text = "";
        }

        private void pantherUser_Click(object sender, EventArgs e)
        {
            if (usrBox.Text != "")
            {
                //historyBox.Items.Add(usrBox.Text);
                history_add(usrBox.Text);
            }
            else
            {
                //historyBox.Items.Add(pidBox.Text);
                history_add(pidBox.Text);
            }
            runSearch(pidBox.Text, usrBox.Text);
        }

        private void history_add(string newItem)
        {
            ArrayList historyItems = new ArrayList();
            historyItems.Add(newItem);
            for(int i = 0; i< historyBox.Items.Count; i++)
            {
                historyItems.Add(historyBox.Items[i].ToString());
            }
            
            historyBox.DataSource = historyItems;
            historyBox.SelectedItem = 0;
            historyItems.Clear();
        }

        private void runSearch(string pantherID, string fiuUsername)
        {
            String output = "", emplOutput = "", studentOutput = "", visitorOutput = "", macOutput = "";
            if (pantherID.Length == 7 || fiuUsername != "") // Panther ID
            {
                DirectorySearcher emplDS = new DirectorySearcher(new DirectoryEntry("LDAP://DC=ad,DC=fiu,DC=edu"));
                if (fiuUsername != "")
                {
                    emplDS.Filter = "(&((&(objectCategory=Person)))(sAMAccountName=" + fiuUsername + "))";
                }
                else
                {
                    emplDS.Filter = "(&((&(objectCategory=Person)))(EmployeeID=" + pantherID + "))";
                }
                SearchResult emplSR = emplDS.FindOne();
                if (emplSR != null)
                {
                    ResultPropertyCollection emplResult = emplSR.Properties;
                    foreach (string myKey in emplResult.PropertyNames)
                    {
                        emplOutput += myKey + " = ";
                        foreach (Object myCollection in emplResult[myKey])
                        {
                            emplOutput += myCollection + "   ";
                        }
                        emplOutput += Environment.NewLine;
                    }

                    try
                    {
                        output += "Name: " + emplSR.Properties["displayName"][0];
                    }
                    catch (Exception)
                    {
                        output += "Name: N/A";
                    }
                    output += Environment.NewLine + "-----------------------" + Environment.NewLine;

                    try
                    {
                        output += "Username: " + emplSR.Properties["sAMAccountName"][0] + Environment.NewLine;
                    }
                    catch (Exception)
                    {
                        output += "Username: N/A\n";
                    }

                    try
                    {
                        output += "Panther ID: " + emplSR.Properties["EmployeeID"][0] + Environment.NewLine;
                    }
                    catch (Exception)
                    {
                        output += "Panther ID: N/A" + Environment.NewLine;
                    }

                    try
                    {
                        int accountState = Convert.ToInt32(emplSR.Properties["userAccountControl"][0]);
                        if (accountState.Equals(544) | accountState.Equals(512))
                        {
                            output += "Status: Enabled" + Environment.NewLine;
                        }
                        else if (accountState.Equals(546))
                        {
                            output += "Status: Disabled" + Environment.NewLine;
                        }
                        else
                        {
                            output += "Status: Other" + Environment.NewLine;
                        }
                    }
                    catch (Exception e)
                    {
                        output += "Status: Unknown" + Environment.NewLine; ;
                    }

                    try
                    {
                        output += "Department: " + emplSR.Properties["department"][0].ToString() + Environment.NewLine + Environment.NewLine;
                    }
                    catch (Exception)
                    {
                        output += "Department: Unknown" + Environment.NewLine + Environment.NewLine;
                    }


                    output += "Demographic Information" + Environment.NewLine + "----------------------------" + Environment.NewLine;
                    try
                    {
                        output += "Date of Birth: " + emplSR.Properties["fiubirthdate"][0] + Environment.NewLine;
                    }
                    catch (Exception)
                    {
                        output += "Date of Birth: N/A" + Environment.NewLine;
                    }
                    try
                    {
                        output += "Last 4 SSN: " + emplSR.Properties["fiul4ssn"][0] + Environment.NewLine;
                    }
                    catch (Exception)
                    {
                        output += "Last 4 SSN: N/A" + Environment.NewLine;
                    }
                    try
                    {
                        output += "Zip Code: " + emplSR.Properties["fiucontactzip"][0] + Environment.NewLine + Environment.NewLine;
                    }
                    catch (Exception)
                    {
                        output += "Zip Code: N/A" + Environment.NewLine + Environment.NewLine;
                    }


                    output += "Extra Information" + Environment.NewLine + "-----------------------" + Environment.NewLine;
                    try
                    {
                        long expirationTime = (long)emplSR.Properties["accountExpires"][0];
                        if (expirationTime > 0)
                        {
                            output += "**ACCOUNT TO EXPIRE ON " + DateTime.FromFileTime(expirationTime) + "**" + Environment.NewLine;
                        }

                    }
                    catch (Exception e)
                    {
                        output += "";
                    }

                    try
                    {
                        output += "Lync Enabled: " + emplSR.Properties["msRTCSIP-UserEnabled"][0] + Environment.NewLine;
                    }
                    catch (Exception e)
                    {
                        output += "MS Lync Enabled: Unknown" + Environment.NewLine;
                    }

                    try
                    {
                        String mail = emplSR.Properties["mail"][0].ToString();
                    }
                    catch
                    {
                    }
                    String targetaddress = "";
                    try
                    {
                        targetaddress = emplSR.Properties["targetaddress"][0].ToString();
                    }
                    catch
                    {
                    }
                    String homemdb = "";
                    try
                    {
                        homemdb = emplSR.Properties["homemdb"][0].ToString();
                    }
                    catch
                    {
                    }

                    if (!(targetaddress.Equals("")) && !(homemdb.Equals("")))
                    {
                        output += "Mailbox Type: Unknown" + Environment.NewLine; // may be broken 
                    }
                    else if ((targetaddress.Equals("")) && !(homemdb.Equals("")))
                    {
                        output += "Mailbox Type: Exchange" + Environment.NewLine;
                    }
                    else if (!(targetaddress.Equals("")) && (homemdb.Equals("")))
                    {
                        output += "Mailbox Type: Office 365" + Environment.NewLine;
                    }
                    else if ((targetaddress.Equals("")) && (homemdb.Equals("")))
                    {
                        output += "Mailbox Type: None" + Environment.NewLine;
                    }
                    else
                    {
                        output += "Mailbox Type: Unknown" + Environment.NewLine;
                    }

                    try
                    {
                        if ((long)emplSR.Properties["LockOutTime"][0] == 0)
                        {
                            output += "Locked out: False" + Environment.NewLine;
                        }
                        else
                        {
                            output += "Locked out: True" + Environment.NewLine;
                        }
                    }
                    catch (Exception)
                    {
                        output += "Locked out: Unknown" + Environment.NewLine;
                    }

                    if ((long)emplSR.Properties["pwdLastSet"][0] == 0)
                    {
                        output += "Password Last Set : Not Set or May be Default" + Environment.NewLine;
                    }
                    else
                    {
                        output += "Password Last Set : " + DateTime.FromFileTime((long)emplSR.Properties["pwdLastSet"][0]).ToString() + Environment.NewLine;
                    }

                    DateTime d1 = DateTime.Now;
                    DateTime d2 = DateTime.FromFileTime((long)emplSR.Properties["pwdLastSet"][0]);
                    System.TimeSpan diff = d1.Subtract(d2);
                    int daysLeft = 182 - diff.Days;
                    // 6 months == 182.621 days
                    if (daysLeft <= 0) { output += "**PASSWORD IS EXPIRED**" + Environment.NewLine; }
                    else if (daysLeft <= 14) { output += String.Format("**PASSWORD WILL EXPIRE IN {0} DAY(S)**" + Environment.NewLine, daysLeft); }

                    try
                    {
                        output += "Last Logon: " + DateTime.FromFileTime((long)emplSR.Properties["lastLogon"][0]) + Environment.NewLine;
                    }
                    catch (Exception)
                    {
                        output += "Last Login: Unknown" + Environment.NewLine;
                    }
                    try
                    {
                        output += "Bad Password: " + DateTime.FromFileTime((long)emplSR.Properties["badPasswordTime"][0]) + Environment.NewLine;
                    }
                    catch (Exception)
                    {
                        output += "Bad Password: Unknown" + Environment.NewLine;
                    }
                    output += "When Created: " + emplSR.Properties["whenCreated"][0] + Environment.NewLine;

                }
                else
                {
                    output += "";
                }


                DirectorySearcher studentDS = new DirectorySearcher(new DirectoryEntry("LDAP://DC=panther, DC=ad,DC=fiu,DC=edu"));
                if (fiuUsername != "")
                {
                    studentDS.Filter = "(&((&(objectCategory=Person)))(sAMAccountName=" + fiuUsername + "))";
                }
                else
                {
                    studentDS.Filter = "(&((&(objectCategory=Person)))(EmployeeID=" + pantherID + "))";
                }
                SearchResult studentSR = studentDS.FindOne();
                if (studentSR != null)
                {
                    if (emplSR != null)
                    {
                        output += Environment.NewLine + "==============================" + Environment.NewLine;
                    }

                    ResultPropertyCollection studentResult = studentSR.Properties;
                    foreach (string myKey in studentResult.PropertyNames)
                    {
                        studentOutput += myKey + " = ";
                        foreach (Object myCollection in studentResult[myKey])
                        {
                            studentOutput += myCollection + "   ";
                        }
                        studentOutput += Environment.NewLine;
                    }
                    try
                    {
                        output += "Name: " + studentSR.Properties["displayName"][0];
                    }
                    catch (Exception)
                    {
                        output += "Name: Unknown";
                    }
                    output += Environment.NewLine + "-----------------------" + Environment.NewLine;
                    try
                    {
                        output += "Username: " + studentSR.Properties["sAMAccountName"][0] + Environment.NewLine;
                    }
                    catch (Exception)
                    {
                        output += "Username: Unknown" + Environment.NewLine;
                    }
                    try
                    {
                        output += "Panther ID: " + studentSR.Properties["EmployeeID"][0] + Environment.NewLine;
                    }
                    catch (Exception)
                    {
                        output += "Panther ID: Unknown" + Environment.NewLine;
                    }
                    try
                    {
                        String fiuStatus = studentSR.Properties["fiuStatus"][0].ToString();
                        output += "Status: " + fiuStatus + Environment.NewLine;
                    }
                    catch (Exception)
                    {
                        output += "Status: Unknown" + Environment.NewLine;
                    }

                    output += Environment.NewLine + "Demographic Information" + Environment.NewLine + "----------------------------" + Environment.NewLine;
                    try
                    {
                        output += "Date of Birth: " + studentSR.Properties["fiubirthdate"][0] + Environment.NewLine;
                    }
                    catch (Exception)
                    {
                        output += "Date of Birth: N/A" + Environment.NewLine;
                    }
                    try
                    {
                        output += "Last 4 SSN: " + studentSR.Properties["fiul4ssn"][0] + Environment.NewLine;
                    }
                    catch (Exception)
                    {
                        output += "Last 4 SSN: N/A" + Environment.NewLine;
                    }
                    try
                    {
                        output += "Zip Code: " + studentSR.Properties["fiucontactzip"][0] + Environment.NewLine + Environment.NewLine;
                    }
                    catch (Exception)
                    {
                        output += "Zip Code: N/A" + Environment.NewLine + Environment.NewLine;
                    }


                    output += "Extra Information" + Environment.NewLine + "-----------------------" + Environment.NewLine;
                    try
                    {
                        if ((long)studentSR.Properties["LockOutTime"][0] == 0)
                        {
                            output += "Locked out: False" + Environment.NewLine;
                        }
                        else
                        {
                            output += "Locked out: True" + Environment.NewLine;
                        }
                    }
                    catch (Exception)
                    {
                        output += "Locked out? UNKNOWN" + Environment.NewLine;
                    }
                    if ((long)studentSR.Properties["pwdLastSet"][0] == 0)
                    {
                        output += "Password Last Set : Not Set or May be Default" + Environment.NewLine;
                    }
                    else
                    {
                        output += "Password Last Set : " + DateTime.FromFileTime((long)studentSR.Properties["pwdLastSet"][0]).ToString() + Environment.NewLine;
                    }

                    DateTime d1 = DateTime.Now;
                    DateTime d2 = DateTime.FromFileTime((long)studentSR.Properties["pwdLastSet"][0]);
                    System.TimeSpan diff = d1.Subtract(d2);
                    int daysLeft = 182 - diff.Days;
                    // 6 months == 182.621 days
                    if (daysLeft <= 0) { output += "**PASSWORD IS EXPIRED**" + Environment.NewLine; }
                    else if (daysLeft <= 14) { output += String.Format("**PASSWORD WILL EXPIRE IN {0} DAY(S)**" + Environment.NewLine, daysLeft); }

                    try
                    {
                        output += "Last Logon: " + DateTime.FromFileTime((long)studentSR.Properties["lastLogon"][0]) + Environment.NewLine;
                    }
                    catch (Exception)
                    {
                        output += "Last Login: Unknown" + Environment.NewLine;
                    }
                    try
                    {
                        output += "Bad Password: " + DateTime.FromFileTime((long)studentSR.Properties["badPasswordTime"][0]) + Environment.NewLine;
                    }
                    catch (Exception)
                    {
                        output += "Bad Password: Unknown" + Environment.NewLine;
                    }

                    output += "When Created: " + studentSR.Properties["whenCreated"][0] + Environment.NewLine;
                }

                if (pantherID != "" && (emplSR != null|| studentSR !=null))
                {
                    DirectorySearcher devicesDS = new DirectorySearcher(new DirectoryEntry("LDAP://OU=Networking, DC=ad,DC=fiu,DC=edu"));
                    devicesDS.Filter = "(&((&(objectCategory=Person)))(fiunsseowner=" + pantherID + "))";
                    SearchResultCollection devicesSR = devicesDS.FindAll();
                    if (devicesSR != null)
                    {
                        output += Environment.NewLine + "==============================" + Environment.NewLine;
                        foreach (SearchResult deviceSR in devicesSR)
                        {
                            output += "MAC: " + deviceSR.Properties["GivenName"][0] + Environment.NewLine;
                            output += "Description: " + deviceSR.Properties["fiuNSSEdescription"][0] + Environment.NewLine + Environment.NewLine;
                        }
                    }
                }
                else if(emplSR == null && studentSR == null)
                {
                    output += "No Results Found" + Environment.NewLine;
                }

            }

            else if (pantherID.Length == 10)// Visitor Account
            {
                DirectorySearcher visitorDS = new DirectorySearcher(new DirectoryEntry("LDAP://DC=ad,DC=fiu,DC=edu"));
                visitorDS.Filter = "(&((&(objectCategory=Person)))(CN=" + pantherID + "))";
                SearchResult visitorSR = visitorDS.FindOne();
                if (visitorSR != null)
                {
                    ResultPropertyCollection visitorResult = visitorSR.Properties;
                    foreach (string myKey in visitorResult.PropertyNames)
                    {
                        visitorOutput += myKey + " = ";
                        foreach (Object myCollection in visitorResult[myKey])
                        {
                            visitorOutput += myCollection + "   ";
                        }
                        visitorOutput += Environment.NewLine;
                    }
                    try
                    {
                        output += "Username: " + visitorSR.Properties["samaccountname"][0].ToString() + Environment.NewLine;
                    }
                    catch
                    {
                        output += "" + Environment.NewLine;
                    }
                    output += "-----------------------" + Environment.NewLine;
                    try
                    {
                        output += "Description: " + visitorSR.Properties["fiuNSSEdescription"][0].ToString() + Environment.NewLine;
                    }
                    catch
                    {
                        output += "";
                    }
                    try
                    {
                        output += "Email: " + visitorSR.Properties["fiunsseowner"][0].ToString() + Environment.NewLine + Environment.NewLine;
                    }
                    catch (Exception)
                    {
                        output += "";
                    }

                    output += "Extra Information" + Environment.NewLine + "-----------------------" + Environment.NewLine;
                    output += "Registered on: " + DateTime.FromFileTime((long)visitorSR.Properties["pwdLastSet"][0]).ToString() + Environment.NewLine;
                    output += "Expires: " + DateTime.FromFileTime((long)visitorSR.Properties["accountExpires"][0]).ToString() + Environment.NewLine;
                }
                else
                {

                }
            }

            else if (fiuUsername.Length == 17 || fiuUsername.Length == 12) // MAC Registration
            {
                String macColon = "", macDash = "", macNone = "";
                if (fiuUsername.Contains(":"))
                {
                    macColon = fiuUsername;
                    macDash = fiuUsername.Replace(":", "-");
                    macNone = fiuUsername.Replace(":", "");
                }
                else if (fiuUsername.Contains("-"))
                {
                    macColon = fiuUsername.Replace("-", ":");
                    macDash = fiuUsername;
                    macNone = fiuUsername.Replace("-", "");
                }
                else
                {
                    macColon = fiuUsername.Substring(0, 2) + ":" + fiuUsername.Substring(2, 2) + ":" + fiuUsername.Substring(4, 2) + ":" + fiuUsername.Substring(6, 2) + ":" + fiuUsername.Substring(8, 2) + ":" + fiuUsername.Substring(10, 2);
                    macDash = fiuUsername.Substring(0, 2) + "-" + fiuUsername.Substring(2, 2) + "-" + fiuUsername.Substring(4, 2) + "-" + fiuUsername.Substring(6, 2) + "-" + fiuUsername.Substring(8, 2) + "-" + fiuUsername.Substring(10, 2);
                    macNone = fiuUsername;
                }
                resultBox.Text = output;

                DirectorySearcher dsColon = new DirectorySearcher(new DirectoryEntry("LDAP://DC=ad,DC=fiu,DC=edu"));
                dsColon.Filter = "(&((&(objectCategory=Person)))(CN=" + macColon + "))";
                SearchResult srColon = dsColon.FindOne();
                if (srColon != null)
                {
                    ResultPropertyCollection macResult = srColon.Properties;
                    foreach (string myKey in macResult.PropertyNames)
                    {
                        macOutput += myKey + " = ";
                        foreach (Object myCollection in macResult[myKey])
                        {
                            macOutput += myCollection + "   ";
                        }
                        macOutput += Environment.NewLine;
                    }

                    output += "Registration Information\n-----------------------\n";
                    try
                    {
                        output += "Device \"Name\": " + srColon.Properties["fiuNSSEdescription"][0] + "\n";
                    }
                    catch (Exception)
                    {
                        output += "Device \"Name\": N/A\n";
                    }
                    try
                    {
                        output += "Device MAC Address: " + srColon.Properties["GivenName"][0] + "\n";
                    }
                    catch (Exception)
                    {
                    }
                    output += "Registered to: " + srColon.Properties["fiuNSSEowner"][0] + "\n\n";

                    output += "Extra Information\n-----------------------\n";
                    output += "Registered on: " + DateTime.FromFileTime((long)srColon.Properties["pwdLastSet"][0]).ToString() + "\n";
                    output += "Registration Expires on: " + DateTime.FromFileTime((long)srColon.Properties["accountExpires"][0]).ToString() + "\n\n";

                    resultBox.Text = output;
                }

                DirectorySearcher dsDash = new DirectorySearcher(new DirectoryEntry("LDAP://DC=ad,DC=fiu,DC=edu"));
                dsDash.Filter = "(&((&(objectCategory=Person)))(CN=" + macDash + "))";
                SearchResult srDash = dsDash.FindOne();
                if (srDash != null)
                {
                    ResultPropertyCollection macResult = srDash.Properties;
                    foreach (string myKey in macResult.PropertyNames)
                    {
                        macOutput += myKey + " = ";
                        foreach (Object myCollection in macResult[myKey])
                        {
                            macOutput += myCollection + "   ";
                        }
                        macOutput += Environment.NewLine;
                    }

                    output += "Registration Information\n-----------------------\n";
                    output += "Device \"Name\": " + srDash.Properties["fiuNSSEdescription"][0] + "\n";
                    output += "Device MAC Address: " + srDash.Properties["GivenName"][0] + "\n";
                    output += "Registered to: " + srDash.Properties["fiuNSSEowner"][0] + "\n\n";

                    output += "Extra Information\n-----------------------\n";
                    output += "Registered on: " + DateTime.FromFileTime((long)srDash.Properties["pwdLastSet"][0]).ToString() + "\n";
                    output += "Registration Expires on: " + DateTime.FromFileTime((long)srDash.Properties["accountExpires"][0]).ToString() + "\n\n";
                    resultBox.Text = output;
                }

                DirectorySearcher dsNone = new DirectorySearcher(new DirectoryEntry("LDAP://DC=ad,DC=fiu,DC=edu"));
                dsNone.Filter = "(&((&(objectCategory=Person)))(CN=" + macNone + "))";
                SearchResult srNone = dsNone.FindOne();
                if (srNone != null)
                {
                    ResultPropertyCollection macResult = srNone.Properties;
                    foreach (string myKey in macResult.PropertyNames)
                    {
                        macOutput += myKey + " = ";
                        foreach (Object myCollection in macResult[myKey])
                        {
                            macOutput += myCollection + "   ";
                        }
                        macOutput += Environment.NewLine;
                    }

                    output += "Registration Information\n-----------------------\n";
                    output += "Device \"Name\": " + srNone.Properties["fiuNSSEdescription"][0] + "\n";
                    output += "Device MAC Address: " + srNone.Properties["GivenName"][0] + "\n";
                    output += "Registered to: " + srNone.Properties["fiuNSSEowner"][0] + "\n\n";

                    output += "Extra Information\n-----------------------\n";
                    output += "Registered on: " + DateTime.FromFileTime((long)srNone.Properties["pwdLastSet"][0]).ToString() + "\n";
                    output += "Registration Expires on: " + DateTime.FromFileTime((long)srNone.Properties["accountExpires"][0]).ToString() + "\n\n";
                }
            }

            else
            {
                output += "No Results Found For " + pantherID + " " + fiuUsername;
            }

            resultBox.Text = output;
            if (exportLogFileToolStripMenuItem.Checked == true)
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(Environment.GetFolderPath(System.Environment.SpecialFolder.Personal)))
                {
                    writer.WriteLine(emplOutput + Environment.NewLine + studentOutput + Environment.NewLine + visitorOutput + Environment.NewLine + macOutput);
                }
            }

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Silly shortcut
            if (keyData == (Keys.Control | Keys.F))
            {
                MessageBox.Show("What the Ctrl+F?");
                return true;
            }

            if (keyData == (Keys.Alt | Keys.D1))
            {
                pantherUser_Click(null, null);
                return true;
            }
            if (keyData == (Keys.Control | Keys.Delete))
            {
                clearbutton_Click(null, null);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //on top option
            if (this.TopMost.Equals(false))
            {
                this.TopMost = true;
                toolStripMenuItem1.Checked = true;
            }
            else
            {
                this.TopMost = false;
                toolStripMenuItem1.Checked = false;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.MessageLoop)
            {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            }
        }

        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String ver = "1.0.1.0"; String.Format("{0}.{1}.{2}.{3}", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major, System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor, System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Revision, System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Build);
            MessageBox.Show("Version: " + ver, "About AD Lookup", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void seeREADMEToolStripMenuItem_Click(object sender, EventArgs e)
        {

            String file = "N:\\Kpine\\Programs\\ADAssistant\\README.txt";
            Process.Start(file);
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            defaultSize();
            this.BackColor = System.Drawing.Color.LightGray;
            GroupBox1.ForeColor = System.Drawing.Color.Black;
            clearbutton.ForeColor = System.Drawing.Color.Black;
            clearbutton.BackColor = System.Drawing.Color.LightGray;
            searchButton.ForeColor = System.Drawing.Color.Black;
            searchButton.BackColor = System.Drawing.Color.LightGray;

            pidBox.ForeColor = System.Drawing.Color.Black;
            pidBox.BackColor = System.Drawing.Color.White;
            usrBox.ForeColor = System.Drawing.Color.Black;
            usrBox.BackColor = System.Drawing.Color.White;
            resultBox.ForeColor = System.Drawing.Color.Black;
            resultBox.BackColor = System.Drawing.Color.White;

        }

        private void darkKnightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            defaultSize();
            this.BackColor = System.Drawing.Color.Black;
            GroupBox1.ForeColor = System.Drawing.Color.White;
            clearbutton.ForeColor = System.Drawing.Color.White;
            clearbutton.BackColor = System.Drawing.Color.Black;
            searchButton.ForeColor = System.Drawing.Color.White;
            searchButton.BackColor = System.Drawing.Color.Black;

            pidBox.ForeColor = System.Drawing.Color.White;
            pidBox.BackColor = System.Drawing.Color.Black;
            usrBox.ForeColor = System.Drawing.Color.White;
            usrBox.BackColor = System.Drawing.Color.Black;
            resultBox.ForeColor = System.Drawing.Color.White;
            resultBox.BackColor = System.Drawing.Color.Black;
        }

        private void helloKittyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            defaultSize();
            this.BackColor = System.Drawing.Color.HotPink;
            GroupBox1.ForeColor = System.Drawing.Color.White;
            clearbutton.ForeColor = System.Drawing.Color.Black;
            clearbutton.BackColor = System.Drawing.Color.White;
            searchButton.ForeColor = System.Drawing.Color.Black;
            searchButton.BackColor = System.Drawing.Color.White;

            pidBox.ForeColor = System.Drawing.Color.Black;
            pidBox.BackColor = System.Drawing.Color.Red;
            usrBox.ForeColor = System.Drawing.Color.Black;
            usrBox.BackColor = System.Drawing.Color.Red;
            resultBox.ForeColor = System.Drawing.Color.Red;
            resultBox.BackColor = System.Drawing.Color.LightPink;
        }

        private void tardisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SoundPlayer player = new SoundPlayer("N:\\Kpine\\Code\\tardis.wav");
            //player.Play();
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.Size = new Size(592 + 200, 394 + 100);
            GroupBox1.ForeColor = System.Drawing.Color.Black;
            clearbutton.ForeColor = System.Drawing.Color.SteelBlue;
            clearbutton.BackColor = System.Drawing.Color.White;
            searchButton.ForeColor = System.Drawing.Color.SteelBlue;
            searchButton.BackColor = System.Drawing.Color.White;

            pidBox.ForeColor = System.Drawing.Color.SteelBlue;
            pidBox.BackColor = System.Drawing.Color.White;
            usrBox.ForeColor = System.Drawing.Color.SteelBlue;
            usrBox.BackColor = System.Drawing.Color.White;
            resultBox.Size = new Size(397 + 125, 328 + 75);
            resultBox.ForeColor = System.Drawing.Color.White;
            resultBox.BackColor = System.Drawing.Color.SteelBlue;
        }

        private void ironManToolStripMenuItem_Click(object sender, EventArgs e)
        {
            defaultSize();
            //SoundPlayer player = new SoundPlayer("N:\\Kpine\\Code\\repulsor.wav");
            //player.Play();
            this.BackColor = System.Drawing.Color.DarkRed;
            GroupBox1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            clearbutton.ForeColor = System.Drawing.Color.Black;
            clearbutton.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            searchButton.ForeColor = System.Drawing.Color.Black;
            searchButton.BackColor = System.Drawing.Color.LightGoldenrodYellow;

            pidBox.ForeColor = System.Drawing.Color.DeepSkyBlue;
            pidBox.BackColor = System.Drawing.Color.LightYellow;
            usrBox.ForeColor = System.Drawing.Color.DeepSkyBlue;
            usrBox.BackColor = System.Drawing.Color.LightYellow;
            resultBox.ForeColor = System.Drawing.Color.DeepSkyBlue;
            resultBox.BackColor = System.Drawing.Color.LightGoldenrodYellow;
        }

        private void jARVISToolStripMenuItem_Click(object sender, EventArgs e)
        {
            defaultSize();
            //SoundPlayer player = new SoundPlayer("N:\\Kpine\\Code\\jarvis.wav");
            //player.Play();
            this.BackColor = System.Drawing.Color.SteelBlue;
            GroupBox1.ForeColor = System.Drawing.Color.LightSkyBlue;
            clearbutton.ForeColor = System.Drawing.Color.LightSkyBlue;
            clearbutton.BackColor = System.Drawing.Color.DodgerBlue;
            searchButton.ForeColor = System.Drawing.Color.LightSkyBlue;
            searchButton.BackColor = System.Drawing.Color.DodgerBlue;

            pidBox.ForeColor = System.Drawing.Color.White;
            pidBox.BackColor = System.Drawing.Color.DodgerBlue;
            usrBox.ForeColor = System.Drawing.Color.White;
            usrBox.BackColor = System.Drawing.Color.DodgerBlue;
            resultBox.ForeColor = System.Drawing.Color.White;
            resultBox.BackColor = System.Drawing.Color.DodgerBlue;
        }

        private void defaultSize()
        {
            this.Size = new Size(592, 394);
            resultBox.Size = new Size(397, 328);
        }

        private void nEWADMINTOOLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://network.fiu.edu/admin");
        }

        private void exportLogFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (exportLogFileToolStripMenuItem.Checked == false)
            {
                exportLogFileToolStripMenuItem.Checked = true;
            }
            else
            {                
                exportLogFileToolStripMenuItem.Checked = false;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (historyBox.SelectedIndex != 0 || historyBox.SelectedIndex != -1)
            {
                /*String history = historyBox.Items[historyBox.SelectedIndex].ToString();
                usrBox.Text = history;
                pidBox.Text = history;*/
            }
        }

        private void historyBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            String history = historyBox.Items[historyBox.SelectedIndex].ToString();
            usrBox.Text = history;
            pidBox.Text = history;
        }


    }
}
