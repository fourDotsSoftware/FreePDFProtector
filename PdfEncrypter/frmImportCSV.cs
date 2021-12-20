using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LumenWorks.Framework.IO.Csv;
using System.IO;

namespace PdfEncrypter
{
    public partial class frmImportCSV : PdfEncrypter.CustomForm
    {        
        public frmImportCSV()
        {
            InitializeComponent();            
            
            lblColumnOutput.Visible = false;
            txtColumnOutput.Visible = false;

            txtColumn.Text = "1";            
        }        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtFilepath.Text.Trim() == string.Empty)
            {
                Module.ShowMessage("Please specify a CSV File !");
                return;
            }

            if (!System.IO.File.Exists(txtFilepath.Text))
            {
                Module.ShowMessage("Please specify a valid CSV FIle !");
                return;
            }

            if (cmbDelimiter.SelectedIndex==5 && txtDelimiterOther.Text.Trim()==string.Empty)
            {
                Module.ShowMessage("Please specify a valid Delimiter !");
                return;
            }

            int column;

            if (txtColumn.Text.Trim()==string.Empty || !int.TryParse(txtColumn.Text,out column))
            {
                Module.ShowMessage("Please specify a valid Videos to Join Column !");
                return;
            }            

            this.DialogResult = DialogResult.OK;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "CSV Files (*.csv)|*.csv";
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFilepath.Text = openFileDialog1.FileName;
            }
        }

        private void frmImportCSV_Load(object sender, EventArgs e)
        {
            cmbDelimiter.Items.Add(TranslateHelper.Translate("Comma (,)"));
            cmbDelimiter.Items.Add(TranslateHelper.Translate("Tab (     )"));
            cmbDelimiter.Items.Add(TranslateHelper.Translate("Semicolon (;)"));
            cmbDelimiter.Items.Add(TranslateHelper.Translate("Colon (:)"));
            cmbDelimiter.Items.Add(TranslateHelper.Translate("Space ( )"));
            cmbDelimiter.Items.Add(TranslateHelper.Translate("Other"));
            cmbDelimiter.SelectedIndex = 0;

            cmbTextDelimiter.Items.Add("\"");
            cmbTextDelimiter.Items.Add("'");
            cmbTextDelimiter.SelectedIndex = 0;

            txtEscape.Text="\\";

        }

        private void cmbDelimiter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDelimiter.SelectedIndex == 5)
            {
                txtDelimiterOther.Visible = true;
            }
            else
            {
                txtDelimiterOther.Visible = false;
            }
        }

        private char GetSelectedDelimiter()
        {
            switch (cmbDelimiter.SelectedIndex)
            {
                case 0:
                    return ',';
                    break;
                case 1:
                    return '\t';
                    break;
                case 2:
                    return ';';
                    break;
                case 3:
                    return ':';
                    break;
                case 4:
                    return ' ';
                    break;
                case 5:
                    return txtDelimiterOther.Text[0];
                    break;
                default:
                    return ',';
                    break;
            }
        }

        public bool ImportCSV(string filepath)
        {
            int column = int.Parse(txtColumn.Text);

            string curdir = Environment.CurrentDirectory;

            try
            {
                Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(filepath);

                //using (CsvReader csv = new CsvReader(new StreamReader(filepath), chkHasHeaders.Checked, GetSelectedDelimiter(), cmbTextDelimiter.SelectedItem.ToString()[0], txtEscape.Text[0], '#', ValueTrimmingOptions.All))

                using (CsvReader csv = new CsvReader(new StreamReader(filepath), chkHasHeaders.Checked, ',','\"',  '#', '#', ValueTrimmingOptions.All))
                {
                    int fieldCount = csv.FieldCount;
                    string[] headers = csv.GetFieldHeaders();


                    while (csv.ReadNextRecord())
                    {
                        string file = "";
                        string fullfilepath = "";

                        try
                        {
                            file = Module.RemoveQuotes(csv[0]);
                            fullfilepath = System.IO.Path.GetFullPath(file);
                        }
                        catch { }

                        string existingpwd = "";

                        try
                        {
                            existingpwd = Module.RemoveQuotes(csv[1]);
                        }
                        catch { }

                        string newuserpwd = "";

                        try
                        {
                            newuserpwd = Module.RemoveQuotes(csv[2]);
                        }
                        catch { }

                        string newownerpwd = "";

                        try
                        {
                            newownerpwd = Module.RemoveQuotes(csv[3]);
                        }
                        catch { }

                        if (System.IO.File.Exists(fullfilepath))
                        {
                            frmMain.Instance.AddFile(fullfilepath, existingpwd, "", newuserpwd, newownerpwd);
                        }
                        else if (System.IO.Directory.Exists(fullfilepath))
                        {
                            frmMain.Instance.AddFolder(fullfilepath, existingpwd, newuserpwd, newownerpwd);
                        }
                    }
                }
            }
            finally
            {
                Environment.CurrentDirectory = curdir;
            }
            return true;
        }                
    }
}
