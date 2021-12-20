using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PdfEncrypter
{
    public partial class frmProgress : CustomForm
    {
        public static frmProgress Instance = null;
        public frmProgress()
        {
            InitializeComponent();
            Instance = this;
            //this.TopMost = true;
        }

        private delegate void HideFormDelegate();

        public void HideForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((HideFormDelegate)HideForm, null);
            }
            else
            {
                this.Visible = false;
            }
        }

        private delegate void ShowFormDelegate();

        public void ShowForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((ShowFormDelegate)ShowForm, null);
            }
            else
            {
                this.Visible = false;
            }
        }

        public int Secs = 0;

        private void timTime_Tick(object sender, EventArgs e)
        {
            Secs++;

            TimeSpan ts = new TimeSpan(0, 0, Secs);

            lblTime.Text = ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EncryptHelper.CANCELLED = true;
            frmMain.Instance.backgroundWorker1.CancelAsync();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.DrawRectangle(Pens.Gray, new Rectangle(2, 2, this.Width - 4, this.Height - 4));
        }

    }
}

