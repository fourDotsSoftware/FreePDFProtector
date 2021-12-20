using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PdfEncrypter
{
    public partial class frmAdeia : CustomForm
    {
        public frmAdeia()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //ucOptionButton.frmad = this;
            //ucOptionButton.DrawOptionButton();
            
            if (txtEmail.Text.StartsWith("\"") && txtEmail.Text.EndsWith("\""))
            {
                txtEmail.Text = txtEmail.Text.Substring(1, txtEmail.Text.Length - 2);
            }

            
            InputModeHelper.frmad = this;
            InputModeHelper.AnalyzeSearch();
            this.DialogResult = DialogResult.OK;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}