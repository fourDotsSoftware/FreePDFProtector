namespace PdfEncrypter
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exploreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnChangeFolder = new System.Windows.Forms.Button();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsdbAddFile = new System.Windows.Forms.ToolStripSplitButton();
            this.tsbRemove = new System.Windows.Forms.ToolStripButton();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsdbAddFolder = new System.Windows.Forms.ToolStripSplitButton();
            this.tsdbImportList = new System.Windows.Forms.ToolStripSplitButton();
            this.tsbDocumentInfo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbShare = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsiFacebook = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiTwitter = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiGooglePlus = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiLinkedIn = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbProtect = new System.Windows.Forms.ToolStripButton();
            this.dgFiles = new System.Windows.Forms.DataGridView();
            this.colFilename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNewUserPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNewOwnerPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFileDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullFilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkOverwritePasswords = new System.Windows.Forms.CheckBox();
            this.btnSetForAllOwnerPassword = new System.Windows.Forms.Button();
            this.btnSetForAllUserPassword = new System.Windows.Forms.Button();
            this.chkShowPasswords = new System.Windows.Forms.CheckBox();
            this.txtOwnerPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkModifyContents = new System.Windows.Forms.CheckBox();
            this.chkScreenReaders = new System.Windows.Forms.CheckBox();
            this.chkAnnotations = new System.Windows.Forms.CheckBox();
            this.chkLowPrinting = new System.Windows.Forms.CheckBox();
            this.chkHighPrinting = new System.Windows.Forms.CheckBox();
            this.chkFormFill = new System.Windows.Forms.CheckBox();
            this.chkAssembly = new System.Windows.Forms.CheckBox();
            this.chkCopy = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbOutputDir = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFile9sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.importListFromTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importListFromCSVFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importListFromExcelFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enterFileListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCurrentFileListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectNoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keepFolderStructureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.luminatiSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exploreOutputFolderWhenDoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keepCreationDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keepLastModificationDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMessageOnSucessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.protectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tryAlsoOnlineVersionAtOnlinepdfappscomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pleaseDonateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForNewVersionEachWeekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiHelpFeedback = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForNewVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.followUsOnTwitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visit4dotsSoftwareWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.youtubeChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rd40Bits = new System.Windows.Forms.RadioButton();
            this.rd128Bits = new System.Windows.Forms.RadioButton();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnUnselectAll = new System.Windows.Forms.Button();
            this.btnInvertSelection = new System.Windows.Forms.Button();
            this.commandLineArgumentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFiles)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exploreToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::PdfEncrypter.Properties.Resources.folder;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exploreToolStripMenuItem
            // 
            this.exploreToolStripMenuItem.Name = "exploreToolStripMenuItem";
            resources.ApplyResources(this.exploreToolStripMenuItem, "exploreToolStripMenuItem");
            this.exploreToolStripMenuItem.Click += new System.EventHandler(this.exploreToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            resources.ApplyResources(this.removeToolStripMenuItem, "removeToolStripMenuItem");
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // btnChangeFolder
            // 
            resources.ApplyResources(this.btnChangeFolder, "btnChangeFolder");
            this.btnChangeFolder.Name = "btnChangeFolder";
            this.toolTip1.SetToolTip(this.btnChangeFolder, resources.GetString("btnChangeFolder.ToolTip"));
            this.btnChangeFolder.UseVisualStyleBackColor = true;
            this.btnChangeFolder.Click += new System.EventHandler(this.btnChangeFolder_Click);
            // 
            // btnOpenFolder
            // 
            resources.ApplyResources(this.btnOpenFolder, "btnOpenFolder");
            this.btnOpenFolder.Image = global::PdfEncrypter.Properties.Resources.folder1;
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.toolTip1.SetToolTip(this.btnOpenFolder, resources.GetString("btnOpenFolder.ToolTip"));
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsdbAddFile,
            this.tsbRemove,
            this.tsbClear,
            this.toolStripSeparator2,
            this.tsdbAddFolder,
            this.tsdbImportList,
            this.tsbDocumentInfo,
            this.toolStripSeparator3,
            this.tsbShare,
            this.toolStripSeparator1,
            this.tsbProtect});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // tsdbAddFile
            // 
            resources.ApplyResources(this.tsdbAddFile, "tsdbAddFile");
            this.tsdbAddFile.Image = global::PdfEncrypter.Properties.Resources.add2;
            this.tsdbAddFile.Name = "tsdbAddFile";
            this.tsdbAddFile.ButtonClick += new System.EventHandler(this.tsdbAddFile_ButtonClick);
            this.tsdbAddFile.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsdbAddFile_DropDownItemClicked);
            // 
            // tsbRemove
            // 
            resources.ApplyResources(this.tsbRemove, "tsbRemove");
            this.tsbRemove.Image = global::PdfEncrypter.Properties.Resources.delete1;
            this.tsbRemove.Name = "tsbRemove";
            this.tsbRemove.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // tsbClear
            // 
            resources.ApplyResources(this.tsbClear, "tsbClear");
            this.tsbClear.Image = global::PdfEncrypter.Properties.Resources.brush2;
            this.tsbClear.Name = "tsbClear";
            this.tsbClear.Click += new System.EventHandler(this.btnClearMerge_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // tsdbAddFolder
            // 
            resources.ApplyResources(this.tsdbAddFolder, "tsdbAddFolder");
            this.tsdbAddFolder.Image = global::PdfEncrypter.Properties.Resources.folder_add1;
            this.tsdbAddFolder.Name = "tsdbAddFolder";
            this.tsdbAddFolder.ButtonClick += new System.EventHandler(this.tsdbAddFolder_ButtonClick);
            this.tsdbAddFolder.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsdbAddFolder_DropDownItemClicked);
            // 
            // tsdbImportList
            // 
            resources.ApplyResources(this.tsdbImportList, "tsdbImportList");
            this.tsdbImportList.Image = global::PdfEncrypter.Properties.Resources.import1;
            this.tsdbImportList.Name = "tsdbImportList";
            this.tsdbImportList.ButtonClick += new System.EventHandler(this.tsdbImportList_ButtonClick);
            this.tsdbImportList.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsdbImportList_DropDownItemClicked);
            // 
            // tsbDocumentInfo
            // 
            resources.ApplyResources(this.tsbDocumentInfo, "tsbDocumentInfo");
            this.tsbDocumentInfo.Image = global::PdfEncrypter.Properties.Resources.document_info1;
            this.tsbDocumentInfo.Name = "tsbDocumentInfo";
            this.tsbDocumentInfo.Click += new System.EventHandler(this.btnDocumentInfo_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // tsbShare
            // 
            resources.ApplyResources(this.tsbShare, "tsbShare");
            this.tsbShare.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiFacebook,
            this.tsiTwitter,
            this.tsiGooglePlus,
            this.tsiLinkedIn,
            this.tsiEmail});
            this.tsbShare.Image = global::PdfEncrypter.Properties.Resources.facebook_24;
            this.tsbShare.Name = "tsbShare";
            // 
            // tsiFacebook
            // 
            this.tsiFacebook.Image = global::PdfEncrypter.Properties.Resources.facebook_24;
            this.tsiFacebook.Name = "tsiFacebook";
            resources.ApplyResources(this.tsiFacebook, "tsiFacebook");
            this.tsiFacebook.Click += new System.EventHandler(this.tsiFacebook_Click);
            // 
            // tsiTwitter
            // 
            this.tsiTwitter.Image = global::PdfEncrypter.Properties.Resources.twitter_24;
            this.tsiTwitter.Name = "tsiTwitter";
            resources.ApplyResources(this.tsiTwitter, "tsiTwitter");
            this.tsiTwitter.Click += new System.EventHandler(this.tsiTwitter_Click);
            // 
            // tsiGooglePlus
            // 
            this.tsiGooglePlus.Image = global::PdfEncrypter.Properties.Resources.googleplus_24;
            this.tsiGooglePlus.Name = "tsiGooglePlus";
            resources.ApplyResources(this.tsiGooglePlus, "tsiGooglePlus");
            this.tsiGooglePlus.Click += new System.EventHandler(this.tsiGooglePlus_Click);
            // 
            // tsiLinkedIn
            // 
            this.tsiLinkedIn.Image = global::PdfEncrypter.Properties.Resources.linkedin_24;
            this.tsiLinkedIn.Name = "tsiLinkedIn";
            resources.ApplyResources(this.tsiLinkedIn, "tsiLinkedIn");
            this.tsiLinkedIn.Click += new System.EventHandler(this.tsiLinkedIn_Click);
            // 
            // tsiEmail
            // 
            this.tsiEmail.Image = global::PdfEncrypter.Properties.Resources.mail;
            this.tsiEmail.Name = "tsiEmail";
            resources.ApplyResources(this.tsiEmail, "tsiEmail");
            this.tsiEmail.Click += new System.EventHandler(this.tsiEmail_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // tsbProtect
            // 
            resources.ApplyResources(this.tsbProtect, "tsbProtect");
            this.tsbProtect.ForeColor = System.Drawing.Color.DarkBlue;
            this.tsbProtect.Image = global::PdfEncrypter.Properties.Resources.lock24;
            this.tsbProtect.Name = "tsbProtect";
            this.tsbProtect.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // dgFiles
            // 
            this.dgFiles.AllowDrop = true;
            this.dgFiles.AllowUserToAddRows = false;
            this.dgFiles.AllowUserToDeleteRows = false;
            this.dgFiles.AllowUserToResizeRows = false;
            resources.ApplyResources(this.dgFiles, "dgFiles");
            this.dgFiles.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(227)))));
            this.dgFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFilename,
            this.colUserPassword,
            this.colNewUserPassword,
            this.colNewOwnerPassword,
            this.colSize,
            this.colFileDate,
            this.colFullFilePath});
            this.dgFiles.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(231)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgFiles.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgFiles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgFiles.GridColor = System.Drawing.Color.Black;
            this.dgFiles.Name = "dgFiles";
            this.dgFiles.RowHeadersVisible = false;
            this.dgFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgFiles_DragDrop);
            this.dgFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgFiles_DragEnter);
            this.dgFiles.DragOver += new System.Windows.Forms.DragEventHandler(this.dgFiles_DragOver);
            // 
            // colFilename
            // 
            this.colFilename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFilename.DataPropertyName = "filename";
            resources.ApplyResources(this.colFilename, "colFilename");
            this.colFilename.Name = "colFilename";
            this.colFilename.ReadOnly = true;
            // 
            // colUserPassword
            // 
            this.colUserPassword.DataPropertyName = "userpassword";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.colUserPassword.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.colUserPassword, "colUserPassword");
            this.colUserPassword.Name = "colUserPassword";
            // 
            // colNewUserPassword
            // 
            this.colNewUserPassword.DataPropertyName = "newuserpassword";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.colNewUserPassword.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.colNewUserPassword, "colNewUserPassword");
            this.colNewUserPassword.Name = "colNewUserPassword";
            // 
            // colNewOwnerPassword
            // 
            this.colNewOwnerPassword.DataPropertyName = "newownerpassword";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.colNewOwnerPassword.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.colNewOwnerPassword, "colNewOwnerPassword");
            this.colNewOwnerPassword.Name = "colNewOwnerPassword";
            // 
            // colSize
            // 
            this.colSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colSize.DataPropertyName = "sizekb";
            resources.ApplyResources(this.colSize, "colSize");
            this.colSize.Name = "colSize";
            this.colSize.ReadOnly = true;
            // 
            // colFileDate
            // 
            this.colFileDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFileDate.DataPropertyName = "filedate";
            resources.ApplyResources(this.colFileDate, "colFileDate");
            this.colFileDate.Name = "colFileDate";
            this.colFileDate.ReadOnly = true;
            // 
            // colFullFilePath
            // 
            this.colFullFilePath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFullFilePath.DataPropertyName = "fullfilepath";
            resources.ApplyResources(this.colFullFilePath, "colFullFilePath");
            this.colFullFilePath.Name = "colFullFilePath";
            this.colFullFilePath.ReadOnly = true;
            // 
            // groupBox4
            // 
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.chkOverwritePasswords);
            this.groupBox4.Controls.Add(this.btnSetForAllOwnerPassword);
            this.groupBox4.Controls.Add(this.btnSetForAllUserPassword);
            this.groupBox4.Controls.Add(this.chkShowPasswords);
            this.groupBox4.Controls.Add(this.txtOwnerPassword);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtUserPassword);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // chkOverwritePasswords
            // 
            resources.ApplyResources(this.chkOverwritePasswords, "chkOverwritePasswords");
            this.chkOverwritePasswords.Name = "chkOverwritePasswords";
            this.chkOverwritePasswords.UseVisualStyleBackColor = true;
            // 
            // btnSetForAllOwnerPassword
            // 
            resources.ApplyResources(this.btnSetForAllOwnerPassword, "btnSetForAllOwnerPassword");
            this.btnSetForAllOwnerPassword.Name = "btnSetForAllOwnerPassword";
            this.btnSetForAllOwnerPassword.UseVisualStyleBackColor = true;
            this.btnSetForAllOwnerPassword.Click += new System.EventHandler(this.btnSetForAllOwnerPassword_Click);
            // 
            // btnSetForAllUserPassword
            // 
            resources.ApplyResources(this.btnSetForAllUserPassword, "btnSetForAllUserPassword");
            this.btnSetForAllUserPassword.Name = "btnSetForAllUserPassword";
            this.btnSetForAllUserPassword.UseVisualStyleBackColor = true;
            this.btnSetForAllUserPassword.Click += new System.EventHandler(this.btnSetForAllUserPassword_Click);
            // 
            // chkShowPasswords
            // 
            resources.ApplyResources(this.chkShowPasswords, "chkShowPasswords");
            this.chkShowPasswords.Name = "chkShowPasswords";
            this.chkShowPasswords.UseVisualStyleBackColor = true;
            this.chkShowPasswords.CheckedChanged += new System.EventHandler(this.chkShowPasswords_CheckedChanged);
            // 
            // txtOwnerPassword
            // 
            resources.ApplyResources(this.txtOwnerPassword, "txtOwnerPassword");
            this.txtOwnerPassword.Name = "txtOwnerPassword";
            this.txtOwnerPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtUserPassword
            // 
            resources.ApplyResources(this.txtUserPassword, "txtUserPassword");
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.chkModifyContents);
            this.groupBox3.Controls.Add(this.chkScreenReaders);
            this.groupBox3.Controls.Add(this.chkAnnotations);
            this.groupBox3.Controls.Add(this.chkLowPrinting);
            this.groupBox3.Controls.Add(this.chkHighPrinting);
            this.groupBox3.Controls.Add(this.chkFormFill);
            this.groupBox3.Controls.Add(this.chkAssembly);
            this.groupBox3.Controls.Add(this.chkCopy);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // chkModifyContents
            // 
            resources.ApplyResources(this.chkModifyContents, "chkModifyContents");
            this.chkModifyContents.BackColor = System.Drawing.Color.Transparent;
            this.chkModifyContents.Checked = true;
            this.chkModifyContents.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkModifyContents.Name = "chkModifyContents";
            this.chkModifyContents.UseVisualStyleBackColor = false;
            // 
            // chkScreenReaders
            // 
            resources.ApplyResources(this.chkScreenReaders, "chkScreenReaders");
            this.chkScreenReaders.BackColor = System.Drawing.Color.Transparent;
            this.chkScreenReaders.Checked = true;
            this.chkScreenReaders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkScreenReaders.Name = "chkScreenReaders";
            this.chkScreenReaders.UseVisualStyleBackColor = false;
            // 
            // chkAnnotations
            // 
            resources.ApplyResources(this.chkAnnotations, "chkAnnotations");
            this.chkAnnotations.BackColor = System.Drawing.Color.Transparent;
            this.chkAnnotations.Checked = true;
            this.chkAnnotations.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAnnotations.Name = "chkAnnotations";
            this.chkAnnotations.UseVisualStyleBackColor = false;
            // 
            // chkLowPrinting
            // 
            resources.ApplyResources(this.chkLowPrinting, "chkLowPrinting");
            this.chkLowPrinting.BackColor = System.Drawing.Color.Transparent;
            this.chkLowPrinting.Checked = true;
            this.chkLowPrinting.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLowPrinting.Name = "chkLowPrinting";
            this.chkLowPrinting.UseVisualStyleBackColor = false;
            // 
            // chkHighPrinting
            // 
            resources.ApplyResources(this.chkHighPrinting, "chkHighPrinting");
            this.chkHighPrinting.BackColor = System.Drawing.Color.Transparent;
            this.chkHighPrinting.Checked = true;
            this.chkHighPrinting.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHighPrinting.Name = "chkHighPrinting";
            this.chkHighPrinting.UseVisualStyleBackColor = false;
            // 
            // chkFormFill
            // 
            resources.ApplyResources(this.chkFormFill, "chkFormFill");
            this.chkFormFill.BackColor = System.Drawing.Color.Transparent;
            this.chkFormFill.Checked = true;
            this.chkFormFill.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFormFill.Name = "chkFormFill";
            this.chkFormFill.UseVisualStyleBackColor = false;
            // 
            // chkAssembly
            // 
            resources.ApplyResources(this.chkAssembly, "chkAssembly");
            this.chkAssembly.BackColor = System.Drawing.Color.Transparent;
            this.chkAssembly.Checked = true;
            this.chkAssembly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAssembly.Name = "chkAssembly";
            this.chkAssembly.UseVisualStyleBackColor = false;
            // 
            // chkCopy
            // 
            resources.ApplyResources(this.chkCopy, "chkCopy");
            this.chkCopy.BackColor = System.Drawing.Color.Transparent;
            this.chkCopy.Checked = true;
            this.chkCopy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopy.Name = "chkCopy";
            this.chkCopy.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cmbOutputDir);
            this.groupBox1.Controls.Add(this.btnChangeFolder);
            this.groupBox1.Controls.Add(this.btnOpenFolder);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // cmbOutputDir
            // 
            resources.ApplyResources(this.cmbOutputDir, "cmbOutputDir");
            this.cmbOutputDir.FormattingEnabled = true;
            this.cmbOutputDir.Name = "cmbOutputDir";
            this.cmbOutputDir.SelectedIndexChanged += new System.EventHandler(this.cmbOutputDir_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.downloadToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFile9sToolStripMenuItem,
            this.addFolderToolStripMenuItem,
            this.toolStripMenuItem3,
            this.importListFromTextFileToolStripMenuItem,
            this.importListFromCSVFileToolStripMenuItem,
            this.importListFromExcelFileToolStripMenuItem,
            this.enterFileListToolStripMenuItem,
            this.saveCurrentFileListToolStripMenuItem,
            this.toolStripMenuItem4,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // addFile9sToolStripMenuItem
            // 
            this.addFile9sToolStripMenuItem.Image = global::PdfEncrypter.Properties.Resources.add;
            this.addFile9sToolStripMenuItem.Name = "addFile9sToolStripMenuItem";
            resources.ApplyResources(this.addFile9sToolStripMenuItem, "addFile9sToolStripMenuItem");
            this.addFile9sToolStripMenuItem.Click += new System.EventHandler(this.tsdbAddFile_ButtonClick);
            // 
            // addFolderToolStripMenuItem
            // 
            this.addFolderToolStripMenuItem.Image = global::PdfEncrypter.Properties.Resources.folder_add;
            this.addFolderToolStripMenuItem.Name = "addFolderToolStripMenuItem";
            resources.ApplyResources(this.addFolderToolStripMenuItem, "addFolderToolStripMenuItem");
            this.addFolderToolStripMenuItem.Click += new System.EventHandler(this.tsdbAddFolder_ButtonClick);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // importListFromTextFileToolStripMenuItem
            // 
            this.importListFromTextFileToolStripMenuItem.Image = global::PdfEncrypter.Properties.Resources.import1;
            this.importListFromTextFileToolStripMenuItem.Name = "importListFromTextFileToolStripMenuItem";
            resources.ApplyResources(this.importListFromTextFileToolStripMenuItem, "importListFromTextFileToolStripMenuItem");
            this.importListFromTextFileToolStripMenuItem.Click += new System.EventHandler(this.tsdbImportList_ButtonClick);
            // 
            // importListFromCSVFileToolStripMenuItem
            // 
            this.importListFromCSVFileToolStripMenuItem.Image = global::PdfEncrypter.Properties.Resources.import1;
            this.importListFromCSVFileToolStripMenuItem.Name = "importListFromCSVFileToolStripMenuItem";
            resources.ApplyResources(this.importListFromCSVFileToolStripMenuItem, "importListFromCSVFileToolStripMenuItem");
            this.importListFromCSVFileToolStripMenuItem.Click += new System.EventHandler(this.importListFromCSVFileToolStripMenuItem_Click);
            // 
            // importListFromExcelFileToolStripMenuItem
            // 
            this.importListFromExcelFileToolStripMenuItem.Image = global::PdfEncrypter.Properties.Resources.import1;
            this.importListFromExcelFileToolStripMenuItem.Name = "importListFromExcelFileToolStripMenuItem";
            resources.ApplyResources(this.importListFromExcelFileToolStripMenuItem, "importListFromExcelFileToolStripMenuItem");
            this.importListFromExcelFileToolStripMenuItem.Click += new System.EventHandler(this.importListFromExcelFileToolStripMenuItem_Click);
            // 
            // enterFileListToolStripMenuItem
            // 
            this.enterFileListToolStripMenuItem.Name = "enterFileListToolStripMenuItem";
            resources.ApplyResources(this.enterFileListToolStripMenuItem, "enterFileListToolStripMenuItem");
            this.enterFileListToolStripMenuItem.Click += new System.EventHandler(this.enterFileListToolStripMenuItem_Click);
            // 
            // saveCurrentFileListToolStripMenuItem
            // 
            this.saveCurrentFileListToolStripMenuItem.Name = "saveCurrentFileListToolStripMenuItem";
            resources.ApplyResources(this.saveCurrentFileListToolStripMenuItem, "saveCurrentFileListToolStripMenuItem");
            this.saveCurrentFileListToolStripMenuItem.Click += new System.EventHandler(this.saveCurrentFileListToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::PdfEncrypter.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem1,
            this.clearToolStripMenuItem,
            this.toolStripMenuItem2,
            this.selectAllToolStripMenuItem,
            this.selectNoneToolStripMenuItem,
            this.invertSelectionToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            // 
            // removeToolStripMenuItem1
            // 
            this.removeToolStripMenuItem1.Image = global::PdfEncrypter.Properties.Resources.delete;
            this.removeToolStripMenuItem1.Name = "removeToolStripMenuItem1";
            resources.ApplyResources(this.removeToolStripMenuItem1, "removeToolStripMenuItem1");
            this.removeToolStripMenuItem1.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Image = global::PdfEncrypter.Properties.Resources.brush2;
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            resources.ApplyResources(this.clearToolStripMenuItem, "clearToolStripMenuItem");
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.btnClearMerge_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            resources.ApplyResources(this.selectAllToolStripMenuItem, "selectAllToolStripMenuItem");
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // selectNoneToolStripMenuItem
            // 
            this.selectNoneToolStripMenuItem.Name = "selectNoneToolStripMenuItem";
            resources.ApplyResources(this.selectNoneToolStripMenuItem, "selectNoneToolStripMenuItem");
            this.selectNoneToolStripMenuItem.Click += new System.EventHandler(this.selectNoneToolStripMenuItem_Click);
            // 
            // invertSelectionToolStripMenuItem
            // 
            this.invertSelectionToolStripMenuItem.Name = "invertSelectionToolStripMenuItem";
            resources.ApplyResources(this.invertSelectionToolStripMenuItem, "invertSelectionToolStripMenuItem");
            this.invertSelectionToolStripMenuItem.Click += new System.EventHandler(this.invertSelectionToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keepFolderStructureToolStripMenuItem,
            this.luminatiSettingsToolStripMenuItem,
            this.exploreOutputFolderWhenDoneToolStripMenuItem,
            this.keepCreationDateToolStripMenuItem,
            this.keepLastModificationDateToolStripMenuItem,
            this.showMessageOnSucessToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            // 
            // keepFolderStructureToolStripMenuItem
            // 
            this.keepFolderStructureToolStripMenuItem.Name = "keepFolderStructureToolStripMenuItem";
            resources.ApplyResources(this.keepFolderStructureToolStripMenuItem, "keepFolderStructureToolStripMenuItem");
            this.keepFolderStructureToolStripMenuItem.Click += new System.EventHandler(this.keepFolderStructureToolStripMenuItem_Click);
            // 
            // luminatiSettingsToolStripMenuItem
            // 
            this.luminatiSettingsToolStripMenuItem.Name = "luminatiSettingsToolStripMenuItem";
            resources.ApplyResources(this.luminatiSettingsToolStripMenuItem, "luminatiSettingsToolStripMenuItem");
            this.luminatiSettingsToolStripMenuItem.Click += new System.EventHandler(this.luminatiSettingsToolStripMenuItem_Click);
            // 
            // exploreOutputFolderWhenDoneToolStripMenuItem
            // 
            this.exploreOutputFolderWhenDoneToolStripMenuItem.CheckOnClick = true;
            this.exploreOutputFolderWhenDoneToolStripMenuItem.Name = "exploreOutputFolderWhenDoneToolStripMenuItem";
            resources.ApplyResources(this.exploreOutputFolderWhenDoneToolStripMenuItem, "exploreOutputFolderWhenDoneToolStripMenuItem");
            // 
            // keepCreationDateToolStripMenuItem
            // 
            this.keepCreationDateToolStripMenuItem.CheckOnClick = true;
            this.keepCreationDateToolStripMenuItem.Name = "keepCreationDateToolStripMenuItem";
            resources.ApplyResources(this.keepCreationDateToolStripMenuItem, "keepCreationDateToolStripMenuItem");
            // 
            // keepLastModificationDateToolStripMenuItem
            // 
            this.keepLastModificationDateToolStripMenuItem.CheckOnClick = true;
            this.keepLastModificationDateToolStripMenuItem.Name = "keepLastModificationDateToolStripMenuItem";
            resources.ApplyResources(this.keepLastModificationDateToolStripMenuItem, "keepLastModificationDateToolStripMenuItem");
            // 
            // showMessageOnSucessToolStripMenuItem
            // 
            this.showMessageOnSucessToolStripMenuItem.CheckOnClick = true;
            this.showMessageOnSucessToolStripMenuItem.Name = "showMessageOnSucessToolStripMenuItem";
            resources.ApplyResources(this.showMessageOnSucessToolStripMenuItem, "showMessageOnSucessToolStripMenuItem");
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.protectToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
            // 
            // protectToolStripMenuItem
            // 
            this.protectToolStripMenuItem.Image = global::PdfEncrypter.Properties.Resources._lock;
            this.protectToolStripMenuItem.Name = "protectToolStripMenuItem";
            resources.ApplyResources(this.protectToolStripMenuItem, "protectToolStripMenuItem");
            this.protectToolStripMenuItem.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            resources.ApplyResources(this.downloadToolStripMenuItem, "downloadToolStripMenuItem");
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpGuideToolStripMenuItem,
            this.tryAlsoOnlineVersionAtOnlinepdfappscomToolStripMenuItem,
            this.commandLineArgumentsToolStripMenuItem,
            this.pleaseDonateToolStripMenuItem1,
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem,
            this.checkForNewVersionEachWeekToolStripMenuItem,
            this.tiHelpFeedback,
            this.checkForNewVersionToolStripMenuItem,
            this.toolStripMenuItem1,
            this.followUsOnTwitterToolStripMenuItem,
            this.visit4dotsSoftwareWebsiteToolStripMenuItem,
            this.youtubeChannelToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // helpGuideToolStripMenuItem
            // 
            this.helpGuideToolStripMenuItem.Image = global::PdfEncrypter.Properties.Resources.help2;
            this.helpGuideToolStripMenuItem.Name = "helpGuideToolStripMenuItem";
            resources.ApplyResources(this.helpGuideToolStripMenuItem, "helpGuideToolStripMenuItem");
            this.helpGuideToolStripMenuItem.Click += new System.EventHandler(this.helpGuideToolStripMenuItem_Click);
            // 
            // tryAlsoOnlineVersionAtOnlinepdfappscomToolStripMenuItem
            // 
            resources.ApplyResources(this.tryAlsoOnlineVersionAtOnlinepdfappscomToolStripMenuItem, "tryAlsoOnlineVersionAtOnlinepdfappscomToolStripMenuItem");
            this.tryAlsoOnlineVersionAtOnlinepdfappscomToolStripMenuItem.Name = "tryAlsoOnlineVersionAtOnlinepdfappscomToolStripMenuItem";
            this.tryAlsoOnlineVersionAtOnlinepdfappscomToolStripMenuItem.Click += new System.EventHandler(this.tryAlsoOnlineVersionAtOnlinepdfappscomToolStripMenuItem_Click);
            // 
            // pleaseDonateToolStripMenuItem1
            // 
            this.pleaseDonateToolStripMenuItem1.BackColor = System.Drawing.Color.Gold;
            resources.ApplyResources(this.pleaseDonateToolStripMenuItem1, "pleaseDonateToolStripMenuItem1");
            this.pleaseDonateToolStripMenuItem1.Name = "pleaseDonateToolStripMenuItem1";
            this.pleaseDonateToolStripMenuItem1.Click += new System.EventHandler(this.pleaseDonateToolStripMenuItem1_Click);
            // 
            // dotsSoftwarePRODUCTCATALOGToolStripMenuItem
            // 
            resources.ApplyResources(this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem, "dotsSoftwarePRODUCTCATALOGToolStripMenuItem");
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem.ForeColor = System.Drawing.Color.DarkBlue;
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem.Name = "dotsSoftwarePRODUCTCATALOGToolStripMenuItem";
            this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem.Click += new System.EventHandler(this.dotsSoftwarePRODUCTCATALOGToolStripMenuItem_Click);
            // 
            // checkForNewVersionEachWeekToolStripMenuItem
            // 
            this.checkForNewVersionEachWeekToolStripMenuItem.CheckOnClick = true;
            this.checkForNewVersionEachWeekToolStripMenuItem.Name = "checkForNewVersionEachWeekToolStripMenuItem";
            resources.ApplyResources(this.checkForNewVersionEachWeekToolStripMenuItem, "checkForNewVersionEachWeekToolStripMenuItem");
            // 
            // tiHelpFeedback
            // 
            this.tiHelpFeedback.Image = global::PdfEncrypter.Properties.Resources.edit;
            this.tiHelpFeedback.Name = "tiHelpFeedback";
            resources.ApplyResources(this.tiHelpFeedback, "tiHelpFeedback");
            this.tiHelpFeedback.Click += new System.EventHandler(this.tiHelpFeedback_Click);
            // 
            // checkForNewVersionToolStripMenuItem
            // 
            this.checkForNewVersionToolStripMenuItem.Name = "checkForNewVersionToolStripMenuItem";
            resources.ApplyResources(this.checkForNewVersionToolStripMenuItem, "checkForNewVersionToolStripMenuItem");
            this.checkForNewVersionToolStripMenuItem.Click += new System.EventHandler(this.checkForNewVersionToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // followUsOnTwitterToolStripMenuItem
            // 
            this.followUsOnTwitterToolStripMenuItem.Image = global::PdfEncrypter.Properties.Resources.social_twitter_box_white_icon_32;
            this.followUsOnTwitterToolStripMenuItem.Name = "followUsOnTwitterToolStripMenuItem";
            resources.ApplyResources(this.followUsOnTwitterToolStripMenuItem, "followUsOnTwitterToolStripMenuItem");
            this.followUsOnTwitterToolStripMenuItem.Click += new System.EventHandler(this.followUsOnTwitterToolStripMenuItem_Click);
            // 
            // visit4dotsSoftwareWebsiteToolStripMenuItem
            // 
            this.visit4dotsSoftwareWebsiteToolStripMenuItem.Name = "visit4dotsSoftwareWebsiteToolStripMenuItem";
            resources.ApplyResources(this.visit4dotsSoftwareWebsiteToolStripMenuItem, "visit4dotsSoftwareWebsiteToolStripMenuItem");
            this.visit4dotsSoftwareWebsiteToolStripMenuItem.Click += new System.EventHandler(this.visit4dotsSoftwareWebsiteToolStripMenuItem_Click);
            // 
            // youtubeChannelToolStripMenuItem
            // 
            this.youtubeChannelToolStripMenuItem.Image = global::PdfEncrypter.Properties.Resources.youtube_32;
            this.youtubeChannelToolStripMenuItem.Name = "youtubeChannelToolStripMenuItem";
            resources.ApplyResources(this.youtubeChannelToolStripMenuItem, "youtubeChannelToolStripMenuItem");
            this.youtubeChannelToolStripMenuItem.Click += new System.EventHandler(this.youtubeChannelToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::PdfEncrypter.Properties.Resources.about;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.rd40Bits);
            this.groupBox2.Controls.Add(this.rd128Bits);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // rd40Bits
            // 
            resources.ApplyResources(this.rd40Bits, "rd40Bits");
            this.rd40Bits.BackColor = System.Drawing.Color.Transparent;
            this.rd40Bits.Name = "rd40Bits";
            this.rd40Bits.UseVisualStyleBackColor = false;
            // 
            // rd128Bits
            // 
            resources.ApplyResources(this.rd128Bits, "rd128Bits");
            this.rd128Bits.BackColor = System.Drawing.Color.Transparent;
            this.rd128Bits.Checked = true;
            this.rd128Bits.Name = "rd128Bits";
            this.rd128Bits.TabStop = true;
            this.rd128Bits.UseVisualStyleBackColor = false;
            // 
            // btnSelectAll
            // 
            resources.ApplyResources(this.btnSelectAll, "btnSelectAll");
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnUnselectAll
            // 
            resources.ApplyResources(this.btnUnselectAll, "btnUnselectAll");
            this.btnUnselectAll.Name = "btnUnselectAll";
            this.btnUnselectAll.UseVisualStyleBackColor = true;
            this.btnUnselectAll.Click += new System.EventHandler(this.btnUnselectAll_Click);
            // 
            // btnInvertSelection
            // 
            resources.ApplyResources(this.btnInvertSelection, "btnInvertSelection");
            this.btnInvertSelection.Name = "btnInvertSelection";
            this.btnInvertSelection.UseVisualStyleBackColor = true;
            this.btnInvertSelection.Click += new System.EventHandler(this.btnInvertSelection_Click);
            // 
            // commandLineArgumentsToolStripMenuItem
            // 
            this.commandLineArgumentsToolStripMenuItem.Name = "commandLineArgumentsToolStripMenuItem";
            resources.ApplyResources(this.commandLineArgumentsToolStripMenuItem, "commandLineArgumentsToolStripMenuItem");
            this.commandLineArgumentsToolStripMenuItem.Click += new System.EventHandler(this.commandLineArgumentsToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.btnInvertSelection);
            this.Controls.Add(this.btnUnselectAll);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgFiles);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.ShowInTaskbar = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFiles)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpGuideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem tiHelpFeedback;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.DataGridView dgFiles;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visit4dotsSoftwareWebsiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Button btnChangeFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.CheckBox chkModifyContents;
        public System.Windows.Forms.CheckBox chkScreenReaders;
        public System.Windows.Forms.CheckBox chkAnnotations;
        public System.Windows.Forms.CheckBox chkLowPrinting;
        public System.Windows.Forms.CheckBox chkHighPrinting;
        public System.Windows.Forms.CheckBox chkFormFill;
        public System.Windows.Forms.CheckBox chkAssembly;
        public System.Windows.Forms.CheckBox chkCopy;
        public System.Windows.Forms.RadioButton rd40Bits;
        public System.Windows.Forms.RadioButton rd128Bits;
        public System.Windows.Forms.TextBox txtOwnerPassword;
        public System.Windows.Forms.TextBox txtUserPassword;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbProtect;
        private System.Windows.Forms.ToolStripButton tsbDocumentInfo;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.ComboBox cmbOutputDir;
        private System.Windows.Forms.ToolStripMenuItem exploreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem followUsOnTwitterToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkShowPasswords;
        public System.Windows.Forms.ToolStripSplitButton tsdbAddFile;
        public System.Windows.Forms.ToolStripSplitButton tsdbAddFolder;
        public System.Windows.Forms.ToolStripSplitButton tsdbImportList;
        private System.Windows.Forms.ToolStripDropDownButton tsbShare;
        private System.Windows.Forms.ToolStripMenuItem tsiFacebook;
        private System.Windows.Forms.ToolStripMenuItem tsiTwitter;
        private System.Windows.Forms.ToolStripMenuItem tsiGooglePlus;
        private System.Windows.Forms.ToolStripMenuItem tsiLinkedIn;
        private System.Windows.Forms.ToolStripMenuItem tsiEmail;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem pleaseDonateToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dotsSoftwarePRODUCTCATALOGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForNewVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keepFolderStructureToolStripMenuItem;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnUnselectAll;
        private System.Windows.Forms.Button btnInvertSelection;
        private System.Windows.Forms.ToolStripMenuItem luminatiSettingsToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkOverwritePasswords;
        private System.Windows.Forms.Button btnSetForAllOwnerPassword;
        private System.Windows.Forms.Button btnSetForAllUserPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFilename;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNewUserPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNewOwnerPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullFilePath;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectNoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem youtubeChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFile9sToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem importListFromTextFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importListFromCSVFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importListFromExcelFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentFileListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem enterFileListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem protectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForNewVersionEachWeekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exploreOutputFolderWhenDoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keepCreationDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keepLastModificationDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMessageOnSucessToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbClear;
        private System.Windows.Forms.ToolStripMenuItem tryAlsoOnlineVersionAtOnlinepdfappscomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandLineArgumentsToolStripMenuItem;
    }
}
