using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace PdfEncrypter
{
    
    public partial class frmProsEggrafi : CustomForm
    {
        public static bool RenMove = false;

        private void SetLanguage()
        {
            //Program.SetLanguage();
        }

        public frmProsEggrafi(DisplayMessageType1 msgtype)
        {
            //SetLanguage();
            InitializeComponent();
            picLogo.Image = PdfEncrypter.Properties.Resources._4dots_logo_official;
            //LogHelper.Log("PE1");
            if (msgtype == DisplayMessageType1.License_Expired)
            {
                // "Your trial period of using 4dots Multiple Search and Replace has expired. Visit now http://www.4dots-software.com/search_replace/store/ to buy a license in order to continue using it!"
                lblcaption.Text = TranslateHelper.Translate("Edit 4dots Project");
            }

            this.Icon = Properties.Resources.pdf_encrypter_32;
                                    
        }
        public frmProsEggrafi(DisplayMessageType1 msgtype,string datefrom,string datelast)
        {
            //SetLanguage();

            // datefrom,datelast YYYYMMDDHHMISS
            InitializeComponent();
            //this.Icon = Properties.Resources.document_into;
            picLogo.Image = PdfEncrypter.Properties.Resources._4dots_logo_official;
            //LogHelper.Log("PE1");
            if (msgtype == DisplayMessageType1.License_Expired)
            {
                // "Your trial period of using 4dots Multiple Search and Replace has expired. Visit now http://www.4dots-software.com/search_replace/store/ to buy a license in order to continue using it!"
                lblcaption.Text = TranslateHelper.Translate("Edit 4dots Project");
            }
            else if (msgtype==DisplayMessageType1.License_N_Days_Remaining)
            {
                DateTime dtfrom = DateTime.Now;
                try { dtfrom = ParseDate(datefrom);                                                 
                }
                catch 
                {
                    RegistryKey key = Registry.CurrentUser;
                    //SOFTWARE\\MsTdm
                    key = key.OpenSubKey(TranslateHelper.Translate("Νέα Εικόνα"));
                    if (key != null)
                    {
                        Environment.Exit(0);
                    }                                
                }

                //LogHelper.Log("PE2");
                DateTime dtlast = DateTime.Now;
                try
                {
                    dtlast = ParseDate(datelast);
                }
                catch
                {
                    RegistryKey key = Registry.CurrentUser;
                    key = key.OpenSubKey(TranslateHelper.Translate("Νέα Εικόνα"));
                    if (key != null)
                    {
                        Environment.Exit(0);
                    }
                }

                //DateTime dtlast = ParseDate(datelast);
                if (DateTime.Now.CompareTo(dtfrom) < 0)
                {
                    //LogHelper.Log("PE3");
                   
                    Environment.Exit(0);
                    this.Dispose();
                    RenMove = true;
                    return;
                    //this.DialogResult = DialogResult.Cancel;
                }
                else if (DateTime.Now.CompareTo(dtlast)<0)
                {
                    //MessageBox.Show(dtlast.ToString());
                    //LogHelper.Log("PE4");
                    Environment.Exit(0);
                    this.Dispose();
                    RenMove = true;
                    return;
                    //this.DialogResult = DialogResult.Cancel;
                }
                    //30
                else if (dtfrom.AddDays(int.Parse(TranslateHelper.Translate("Αλλαγή στοιχείων εικόνας"))).CompareTo(DateTime.Now) >= 0)
                {
                    //LogHelper.Log("PE5");
                    //REMOVE THIS Form1.Instance.timer1.Enabled = true;
                    //This is a trial version of 4dots Multiple Search and Replace. Visit now http://www.4dots-software.com/search_replace/store/ in order to buy a license !
                    lblcaption.Text = TranslateHelper.Translate("Add new search item to project");
                    TimeSpan ts=DateTime.Now.Subtract(dtfrom);
                    //30
                    int days = int.Parse(TranslateHelper.Translate("Αλλαγή στοιχείων εικόνας")) - ts.Days;
                    //Days Left : 
                    lblcaption.Text = lblcaption.Text+"\n\n" + TranslateHelper.Translate("Error during search startup") + days.ToString();
                    btnTrial.Enabled = true;
                    //!
                    frmMain f = new frmMain();
                    frmMain.Instance = f;
                    frmMain.Instance.timer1.Enabled = true;
                }
                else
                {
                    //Your trial period of using Localtransformer has expired. Visit now http://www.4dots-software.com/store/ to buy a license in order to continue using it!
                    lblcaption.Text = TranslateHelper.Translate("Edit 4dots Project");
                }
            }
        }

        private void frmProsEggrafi_Load(object sender, EventArgs e)
        {
            if (RenMove)
            {
                Environment.Exit(0);
                this.DialogResult = DialogResult.Cancel;
                this.Dispose();
            }
        }

        public static DateTime ParseDate(string datestr)
        {
            return new DateTime(int.Parse(datestr.Substring(0, 4)), int.Parse(datestr.Substring(4, 2)), int.Parse(datestr.Substring(6, 2)),
                int.Parse(datestr.Substring(8, 2)), int.Parse(datestr.Substring(10, 2)), int.Parse(datestr.Substring(12, 2)));
        }

        private void btnTrial_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Module.StoreUrl);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmAdeia f = new frmAdeia();
            f.ShowDialog();
            if (f.DialogResult == DialogResult.Cancel)
            {
                this.Visible = true;
            }
        }

        

 
    }

    public enum DisplayMessageType1
    {
        License_Expired,
        License_N_Days_Remaining

    }

}