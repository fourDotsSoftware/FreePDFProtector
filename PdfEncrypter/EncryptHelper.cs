using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.factories;
 
using System.IO;
using System.Collections;
using System.Windows.Forms;
/*1
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Security;
*/

namespace PdfEncrypter
{
    class EncryptHelper
    {
        //PdfEncryptor.Encrypt(reader,myFileStream,PdfWriter.ENCRYPTION_RC4_128,sU 
        //Password,"test",PdfWriter.AllowPrinting|PdfWriter.AllowCopy); 

        public static string Title = "";
        public static string Author = "";
        public static string Subject = "";
        public static string Keywords = "";

        public static DateTime CreationDate = DateTime.Now;
        public static DateTime ModificationDate = DateTime.Now;
        public static string Creator = "";

        public static bool SetDocInfo = false;

        private static string DefaultPassword = "";

        public static bool CANCELLED = false;


        public static string EncryptMultiplePDF(DataTable dt,string sCmbOutputDir,EncryptArgs encryptargs,DocArgs docargs)
        {
            string err = "";
            CANCELLED = false;
            
            for (int k = 0; k < dt.Rows.Count; k++)
            {
                if (CANCELLED)
                {
                    return err;
                }

                string outfilepath="";
                string filepath=dt.Rows[k]["fullfilepath"].ToString();
                string password = dt.Rows[k]["userpassword"].ToString();
                string rootfolder = dt.Rows[k]["rootfolder"].ToString();

                string newuserpassword = dt.Rows[k]["newuserpassword"].ToString();
                string newownerpassword = dt.Rows[k]["newownerpassword"].ToString();

                if (sCmbOutputDir.Trim() == TranslateHelper.Translate("Same Folder of PDF Document"))
                {
                    string dirpath = System.IO.Path.GetDirectoryName(filepath);
                    outfilepath = System.IO.Path.Combine(dirpath, System.IO.Path.GetFileNameWithoutExtension(filepath) + "_protected.pdf");
                }
                else if (sCmbOutputDir.StartsWith(TranslateHelper.Translate("Subfolder") + " : "))
                {
                    int subfolderspos = (TranslateHelper.Translate("Subfolder") + " : ").Length;
                    string subfolder = sCmbOutputDir.Substring(subfolderspos);

                    outfilepath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(filepath) + "\\" + subfolder, System.IO.Path.GetFileName(filepath));
                }
                else if (sCmbOutputDir.Trim() == TranslateHelper.Translate("Overwrite PDF Document"))
                {
                    outfilepath = filepath;
                }
                else
                {
                    if (rootfolder != string.Empty && Properties.Settings.Default.KeepFolderStructure)
                    {
                        string dep = System.IO.Path.GetDirectoryName(filepath).Substring(rootfolder.Length);

                        string outdfp = sCmbOutputDir + dep;

                        outfilepath = System.IO.Path.Combine(outdfp, System.IO.Path.GetFileName(filepath));

                        if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(outfilepath)))
                        {
                            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(outfilepath));
                        }
                    }
                    else
                    {
                        outfilepath = System.IO.Path.Combine(sCmbOutputDir, System.IO.Path.GetFileName(filepath));
                    }
                }                                                

                try
                {
                    err += EncryptSinglePDF(filepath, outfilepath,password,newuserpassword,newownerpassword,encryptargs,docargs);
                }
                catch (Exception ex)
                {
                    err += ex.Message + "\r\n";
                }
            }

            return err;
        }

        public static string EncryptMultiplePDFCmd(DataTable dt)
        {
            string err = "";
            
            for (int k = 0; k < dt.Rows.Count; k++)
            {
                if (Module.CmdLogFileWriter != null)
                {
                    Module.CmdLogFileWriter.WriteLine("[" + DateTime.Now.ToString() + "] Protecting PDF file : " + dt.Rows[k]["fullfilepath"].ToString());
                }

                string outfilepath = "";
                string filepath = dt.Rows[k]["fullfilepath"].ToString();
                string password = dt.Rows[k]["userpassword"].ToString();
                string rootfolder = dt.Rows[k]["rootfolder"].ToString();

                if (Module.CmdOutputFolder == string.Empty)
                {
                    string dirpath = System.IO.Path.GetDirectoryName(filepath);

                    if (Module.CmdOutputFile == string.Empty)
                    {
                        outfilepath = System.IO.Path.Combine(dirpath, System.IO.Path.GetFileNameWithoutExtension(filepath) + "_protected.pdf");
                    }
                    else
                    {
                        outfilepath = System.IO.Path.Combine(dirpath, Module.CmdOutputFile.Replace("[FILENAME]", System.IO.Path.GetFileNameWithoutExtension(filepath)).Replace("[EXT]", System.IO.Path.GetExtension(filepath)));
                    }
                }

                if (Module.CmdOverwritePDF)
                {
                    outfilepath = filepath;
                }

                if (Module.CmdOutputFolder != string.Empty)
                {
                    if (rootfolder != string.Empty && Properties.Settings.Default.KeepFolderStructure)
                    {
                        string dep = System.IO.Path.GetDirectoryName(filepath).Substring(rootfolder.Length);

                        string outdfp = Module.CmdOutputFolder + dep;

                        outfilepath = System.IO.Path.Combine(outdfp, System.IO.Path.GetFileName(filepath));

                        if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(outfilepath)))
                        {
                            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(outfilepath));
                        }
                    }
                    else
                    {
                        outfilepath = System.IO.Path.Combine(Module.CmdOutputFolder, System.IO.Path.GetFileName(filepath));
                    }                    
                }

                try
                {
                    err += EncryptSinglePDFCmd(filepath, outfilepath, password);
                }
                catch (Exception ex)
                {
                    err += ex.Message + "\r\n";
                }
            }

            return err;
        }
        /*1
        public static string EncryptSinglePDF(string InputFile, string OutputFile)
        {
            string err = "";

            try
            {
                // Open an existing document. Providing an unrequired password is ignored.
                PdfDocument document = PdfReader.Open(InputFile, "spooky");

                PdfSecuritySettings securitySettings = document.SecuritySettings;

                // Setting one of the passwords automatically sets the security level to 
                // PdfDocumentSecurityLevel.Encrypted128Bit.

                if (frmMain.Instance.txtUserPassword.Text.Trim() != string.Empty)
                {
                    securitySettings.UserPassword = frmMain.Instance.txtUserPassword.Text;
                }

                if (frmMain.Instance.txtOwnerPassword.Text.Trim() != string.Empty)
                {
                    securitySettings.OwnerPassword = frmMain.Instance.txtOwnerPassword.Text;
                }

                // Don't use 40 bit encryption unless needed for compatibility
                if (frmMain.Instance.rd40Bits.Checked)
                {
                    securitySettings.DocumentSecurityLevel = PdfDocumentSecurityLevel.Encrypted40Bit;
                }

                // Restrict some rights.
                securitySettings.PermitAccessibilityExtractContent = frmMain.Instance.chkScreenReaders.Checked;
                securitySettings.PermitAnnotations = frmMain.Instance.chkAnnotations.Checked;
                securitySettings.PermitAssembleDocument = frmMain.Instance.chkAssembly.Checked;
                securitySettings.PermitExtractContent = frmMain.Instance.chkCopy.Checked;
                securitySettings.PermitFormsFill = frmMain.Instance.chkFormFill.Checked;
                securitySettings.PermitFullQualityPrint = frmMain.Instance.chkHighPrinting.Checked;
                securitySettings.PermitModifyDocument = frmMain.Instance.chkModifyContents.Checked;
                securitySettings.PermitPrint = frmMain.Instance.chkLowPrinting.Checked;

                if (frmDocumentInfo.Instance.chkAuthor.Checked)
                {
                    document.Info.Author = Author;
                }
                if (frmDocumentInfo.Instance.chkCreator.Checked)
                {
                    document.Info.Creator = Creator;
                }
                if (frmDocumentInfo.Instance.chkKeywords.Checked)
                {
                    document.Info.Keywords = Keywords;
                }

                if (frmDocumentInfo.Instance.chkModificationDate.Checked)
                {
                    document.Info.ModificationDate = ModificationDate;
                }

                if (frmDocumentInfo.Instance.chkCreationDate.Checked)
                {
                    document.Info.CreationDate = CreationDate;
                }

                if (frmDocumentInfo.Instance.chkTitle.Checked)
                {
                    document.Info.Title = Title;
                }

                if (frmDocumentInfo.Instance.chkSubject.Checked)
                {
                    document.Info.Subject = Subject;
                }                                

                // Save the document...
                document.Save(OutputFile);
                
                /*
                            if (SetDocInfo)
                            {
                                Dictionary<string, string> dict = new Dictionary<string, string>();
                                dict.Add("Author", Author);
                                dict.Add("Subject", Subject);
                                dict.Add("Keywords", Keywords);
                                dict.Add("Title", Title);

                                PdfEncryptor.Encrypt(reader, output, strength, userp, ownerp, permissions, dict);
                            }
                            else
                            {
                                PdfEncryptor.Encrypt(reader, output, strength, userp, ownerp, permissions);
                            }
                        }
                 */                             
        /*1
            }
            catch (Exception ex)
            {
                err += ex.Message;
            }

            return err;
        }
        */
        public static string EncryptSinglePDF(string InputFile, string OutputFile,string Password,string NewUserPassword,string NewOwnerPassword,EncryptArgs encryptargs,DocArgs docargs)
        {
            string err = "";

            try
            {
                FileInfo fi = new FileInfo(InputFile);
                DateTime dtcreated = fi.CreationTime;
                DateTime dtlastmod = fi.LastWriteTime;

                //                using (FileStream input = new FileStream(InputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                //{
                PdfReader reader = null;

                if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(OutputFile)))
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(OutputFile));
                    }
                    catch (Exception exd)
                    {
                        err += TranslateHelper.Translate("Error. Could not Create Directory for File") + " : " + InputFile+"\r\n"+exd.Message+"\r\n";
                        return err;
                    }
                }


                try
                {
                    //  reader = new PdfReader(input);

                    while (true)
                    {
                        using (Stream input = new FileStream(InputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            try
                            {
                                if (!String.IsNullOrEmpty(Password))
                                {
                                    reader = new PdfReader(input, Encoding.Default.GetBytes(Password));
                                    //reader = new PdfReader(input, Encoding.UTF8.GetBytes(Password));

                                }
                                else
                                {
                                    reader = new PdfReader(input);
                                }

                                break;
                            }
                            catch (iTextSharp.text.pdf.BadPasswordException ex)
                            {
                                if (reader != null)
                                {
                                    reader.Close();
                                }

                                if (input != null)
                                {
                                    input.Close();
                                }

                                //encryptargs.backgroundWorker1.CancelAsync();

                                //while (encryptargs.backgroundWorker1.IsBusy)
                                //{
                                //Application.DoEvents();
                                //}

                                if (string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(DefaultPassword))
                                {
                                    Password = DefaultPassword;
                                }
                                else
                                {
                                    frmProgress.Instance.HideForm();

                                    Module.ShowMessage("Please enter the correct User Password !");

                                    frmPassword f2 = new frmPassword(InputFile);

                                    

                                    DialogResult dres = f2.ShowDialog();

                                    frmProgress.Instance.ShowForm();

                                    //encryptargs.backgroundWorker1.RunWorkerAsync();

                                    if (dres == DialogResult.OK)
                                    {
                                        Password = f2.txtPassword.Text;

                                        if (f2.chkPassword.Checked)
                                        {
                                            DefaultPassword = Password;
                                        }

                                    }
                                    else
                                    {
                                        err += TranslateHelper.Translate("Error. Wrong User Password for File") + " : " + InputFile;
                                        return err;
                                    }
                                }
                            }
                        }
                    }

                    string userp = NewUserPassword;//encryptargs.txtUserPassword;
                    if (userp == "")
                    {
                        userp = null;
                    }

                    string ownerp = NewOwnerPassword;//encryptargs.txtOwnerPassword;
                    if (ownerp == "")
                    {
                        ownerp = null;
                    }

                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    //PdfDictionary dict = new PdfDictionary();

                    if (docargs.chkAuthor)
                    {
                        dict.Add("Author", Author);
                    }
                    if (docargs.chkCreator)
                    {
                        dict.Add("Creator", Creator);
                    }
                    if (docargs.chkKeywords)
                    {
                        dict.Add("Keywords", Keywords);
                    }

                    if (docargs.chkModificationDate)
                    {
                        //dict.Add("ModificationDate", ModificationDate.ToString());
                        //dict.Add("ModDate", new PdfDate(ModificationDate).ToString());
                        dict.Add(PdfName.MODDATE.ToString(), new PdfDate(ModificationDate).ToString());
                    }

                    if (docargs.chkCreationDate)
                    {
                        dict.Add("CreationDate", new PdfDate(CreationDate).ToString());
                    }

                    if (docargs.chkTitle)
                    {
                        dict.Add("Title", Title);
                    }

                    if (docargs.chkSubject)
                    {
                        dict.Add("Subject", Subject);
                    }

                    string TmpFile = "";

                    if (encryptargs.cmbOutputDir == TranslateHelper.Translate("Overwrite PDF Document"))
                    {
                        TmpFile = OutputFile;
                        OutputFile = System.IO.Path.GetTempFileName();
                    }

                    int permissions = 0;
                    if (encryptargs.chkAnnotations)
                    {
                        permissions |= PdfWriter.ALLOW_MODIFY_ANNOTATIONS;
                    }

                    if (encryptargs.chkAssembly)
                    {
                        permissions |= PdfWriter.ALLOW_ASSEMBLY;
                    }

                    if (encryptargs.chkCopy)
                    {
                        permissions |= PdfWriter.ALLOW_COPY;
                    }

                    if (encryptargs.chkFormFill)
                    {
                        permissions |= PdfWriter.ALLOW_FILL_IN;
                    }

                    if (encryptargs.chkHighPrinting)
                    {
                        permissions |= PdfWriter.ALLOW_PRINTING;
                    }

                    if (encryptargs.chkLowPrinting)
                    {
                        permissions |= PdfWriter.ALLOW_DEGRADED_PRINTING;
                    }

                    if (encryptargs.chkModifyContents)
                    {
                        permissions |= PdfWriter.ALLOW_MODIFY_CONTENTS;
                    }

                    if (encryptargs.chkScreenReaders)
                    {
                        permissions |= PdfWriter.ALLOW_SCREENREADERS;
                    }

                    bool strength = encryptargs.rd128Bits;

                    //Module.ShowMessage(strength.ToString());
                    //Module.ShowMessage("ow=" + ownerp.ToString() + " - up=" + userp.ToString());

                    //if (ownerp == null && userp == null)
                    //{
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            PdfStamper stamper = new PdfStamper(reader, memoryStream);
                            if (dict.Count > 0)
                            {
                                stamper.MoreInfo = dict;
                            }

                            if (ownerp != null || userp != null)
                            {
                                stamper.SetEncryption(userp!=null?Encoding.ASCII.GetBytes(userp):null, ownerp!=null?Encoding.ASCII.GetBytes(ownerp):null,
                                    permissions, strength);
                            }
                        

    /*
                            public byte[] EncryptPdf(byte[] src) {
      PdfReader reader = new PdfReader(src);
      using (MemoryStream ms = new MemoryStream()) {
        using (PdfStamper stamper = new PdfStamper(reader, ms)) {
          stamper.SetEncryption(
            USER, OWNER, 
            PdfWriter.ALLOW_PRINTING, 
            PdfWriter.ENCRYPTION_AES_128 | PdfWriter.DO_NOT_ENCRYPT_METADATA
          );
        }
        return ms.ToArray();
      }
    }*/
                            stamper.Close();
                            reader.Close();

                            File.WriteAllBytes(OutputFile, memoryStream.ToArray());
                        

                        if (TmpFile != string.Empty)
                        {
                            System.IO.File.Delete(TmpFile);
                            System.IO.File.Move(OutputFile, TmpFile);

                            FileInfo fi3 = new FileInfo(TmpFile);

                            if (Properties.Settings.Default.KeepCreationDate)
                            {
                                fi3.CreationTime = dtcreated;
                            }

                            if (Properties.Settings.Default.KeepLastModificationDate)
                            {
                                fi3.LastWriteTime = dtlastmod;
                            }
                        }
                        else
                        {
                            FileInfo fi4 = new FileInfo(OutputFile);

                            if (Properties.Settings.Default.KeepCreationDate)
                            {
                                fi4.CreationTime = dtcreated;
                            }

                            if (Properties.Settings.Default.KeepLastModificationDate)
                            {
                                fi4.LastWriteTime = dtlastmod;
                            }
                        }


                        return err;
                    }

                    /*
                    using (Stream output = new FileStream(OutputFile, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        int permissions = 0;
                        if (encryptargs.chkAnnotations.Checked)
                        {
                            permissions |= PdfWriter.ALLOW_MODIFY_ANNOTATIONS;
                        }

                        if (encryptargs.chkAssembly.Checked)
                        {
                            permissions |= PdfWriter.ALLOW_ASSEMBLY;
                        }

                        if (encryptargs.chkCopy.Checked)
                        {
                            permissions |= PdfWriter.ALLOW_COPY;
                        }

                        if (encryptargs.chkFormFill.Checked)
                        {
                            permissions |= PdfWriter.ALLOW_FILL_IN;
                        }

                        if (encryptargs.chkHighPrinting.Checked)
                        {
                            permissions |= PdfWriter.ALLOW_PRINTING;
                        }

                        if (encryptargs.chkLowPrinting.Checked)
                        {
                            permissions |= PdfWriter.ALLOW_DEGRADED_PRINTING;
                        }

                        if (encryptargs.chkModifyContents.Checked)
                        {
                            permissions |= PdfWriter.ALLOW_MODIFY_CONTENTS;
                        }

                        if (encryptargs.chkScreenReaders.Checked)
                        {
                            permissions |= PdfWriter.ALLOW_SCREENREADERS;
                        }

                        bool strength = encryptargs.rd128Bits.Checked;

                        //if (SetDocInfo)
                        //{                                               

                        if (dict.Count > 0)
                        {
                            //PdfEncryptor.Encrypt(reader, output, strength, userp, ownerp, permissions, dict);

                            PdfEncryptor.Encrypt(reader, output, Encoding.Default.GetBytes(userp), Encoding.Default.GetBytes(ownerp),
                                permissions, strength);
                        }
                        else
                        {
                            //PdfEncryptor.Encrypt(reader, output, strength, userp, ownerp, permissions);

                            PdfEncryptor.Encrypt(reader, output, Encoding.Default.GetBytes(userp), Encoding.Default.GetBytes(ownerp),
                                permissions, strength);
                        }
                    }
                    */

                    if (TmpFile != string.Empty)
                    {
                        System.IO.File.Delete(TmpFile);
                        System.IO.File.Move(OutputFile, TmpFile);
                    }
                }
                catch (Exception exm)
                {
                    err += TranslateHelper.Translate("An error occured while protecting PDF File") + " : " + InputFile + "\r\n" + exm.Message + "\r\n";
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }

                FileInfo fi2 = new FileInfo(OutputFile);

                if (Properties.Settings.Default.KeepCreationDate)
                {
                    fi2.CreationTime = dtcreated;
                }

                if (Properties.Settings.Default.KeepLastModificationDate)
                {
                    fi2.LastWriteTime = dtlastmod;
                }
            }
            catch (Exception ex)
            {
                err += TranslateHelper.Translate("An error occured while protecting PDF File") + " : " + InputFile + "\r\n" + ex.Message + "\r\n";
            }

            return err;
        }

        public static string EncryptSinglePDFCmd(string InputFile, string OutputFile, string Password)
        {
            string err = "";

            try
            {
                //                using (FileStream input = new FileStream(InputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                //{
                PdfReader reader = null;

                if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(OutputFile)))
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(OutputFile));
                    }
                    catch (Exception exd)
                    {
                        err += TranslateHelper.Translate("Error. Could not Create Directory for File") + " : " + InputFile + "\r\n" + exd.Message + "\r\n";
                        return err;
                    }
                }


                try
                {
                    //  reader = new PdfReader(input);


                    using (Stream input = new FileStream(InputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        try
                        {
                            if (!String.IsNullOrEmpty(Password))
                            {
                                reader = new PdfReader(input, Encoding.Default.GetBytes(Password));
                                //reader = new PdfReader(input, Encoding.UTF8.GetBytes(Password));

                            }
                            else
                            {
                                reader = new PdfReader(input);
                            }
                            
                        }
                        catch (iTextSharp.text.pdf.BadPasswordException ex)
                        {
                            if (reader != null)
                            {
                                reader.Close();
                            }

                            if (input != null)
                            {
                                input.Close();
                            }

                            err += TranslateHelper.Translate("Error. Wrong User Password for File") + " : " + InputFile;
                            return err;


                        }

                    }

                    //Console.WriteLine("userpassword="+Module.Cmdnewownerpassword);

                    string userp = Module.Cmdnewuserpassword;
                    if (userp == "")
                    {
                        userp = null;
                    }

                    string ownerp = Module.Cmdnewownerpassword;
                    if (ownerp == "")
                    {
                        ownerp = null;
                    }

                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    //PdfDictionary dict = new PdfDictionary();

                    if (Module.Cmdauthor!=string.Empty)
                    {
                        dict.Add("Author", Module.Cmdauthor);
                    }
                    if (Module.Cmdcreator != string.Empty)
                    {
                        dict.Add("Creator", Module.Cmdcreator);
                    }
                    if (Module.Cmdkeywords != string.Empty)
                    {
                        dict.Add("Keywords", Module.Cmdkeywords);
                    }

                    if (Module.CmdmodificationDate != string.Empty)
                    {
                        //dict.Add("ModificationDate", ModificationDate.ToString());
                        //dict.Add("ModDate", new PdfDate(ModificationDate).ToString());
                        dict.Add(PdfName.MODDATE.ToString(), new PdfDate(ModificationDate).ToString());
                    }

                    if (Module.CmdcreationDate != string.Empty)
                    {
                        dict.Add("CreationDate", new PdfDate(CreationDate).ToString());
                    }

                    if (Module.Cmdtitle != string.Empty)
                    {
                        dict.Add("Title", Module.Cmdtitle);
                    }

                    if (Module.Cmdsubject != string.Empty)
                    {
                        dict.Add("Subject", Module.Cmdsubject);
                    }

                    string TmpFile = "";

                    if (Module.CmdOverwritePDF)
                    {
                        TmpFile = OutputFile;
                        OutputFile = System.IO.Path.GetTempFileName();
                    }

                    if (ownerp == null && userp == null)
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            PdfStamper stamper = new PdfStamper(reader, memoryStream);
                            if (dict.Count > 0)
                            {
                                stamper.MoreInfo = dict;
                            }

                            stamper.Close();
                            reader.Close();

                            File.WriteAllBytes(OutputFile, memoryStream.ToArray());
                        }

                        if (TmpFile != string.Empty)
                        {
                            System.IO.File.Delete(TmpFile);
                            System.IO.File.Move(OutputFile, TmpFile);
                        }

                        return err;
                    }

                    using (Stream output = new FileStream(OutputFile, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        int permissions = 0;
                        if (!Module.CmdDISALLOW_ANOTATIONS)
                        {
                            permissions |= PdfWriter.ALLOW_MODIFY_ANNOTATIONS;
                        }

                        if (!Module.CmdDISALLOW_DOC_ASSEMBLY)
                        {
                            permissions |= PdfWriter.ALLOW_ASSEMBLY;
                        }

                        if (!Module.CmdDISALLOW_COPYING)
                        {
                            permissions |= PdfWriter.ALLOW_COPY;
                        }

                        if (!Module.CmdDISALLOW_FORM_FILL)
                        {
                            permissions |= PdfWriter.ALLOW_FILL_IN;
                        }

                        if (!Module.CmdDISALLOW_HIRES_PRINTING)
                        {
                            permissions |= PdfWriter.ALLOW_PRINTING;
                        }

                        if (!Module.CmdDISALLOW_LOWRES_PRINTING)
                        {
                            permissions |= PdfWriter.ALLOW_DEGRADED_PRINTING;
                        }

                        if (!Module.CmdDISALLOW_MODIFYING)
                        {
                            permissions |= PdfWriter.ALLOW_MODIFY_CONTENTS;
                        }

                        if (!Module.CmdDISALLOW_SCREEN_READERS)
                        {
                            permissions |= PdfWriter.ALLOW_SCREENREADERS;
                        }

                        bool strength = Module.Cmdenc128;

                        //if (SetDocInfo)
                        //{                                               

                        if (dict.Count > 0)
                        {
                            PdfEncryptor.Encrypt(reader, output, strength, userp, ownerp, permissions, dict);
                        }
                        else
                        {
                            PdfEncryptor.Encrypt(reader, output, strength, userp, ownerp, permissions);
                        }
                    }

                    if (TmpFile != string.Empty)
                    {
                        System.IO.File.Delete(TmpFile);
                        System.IO.File.Move(OutputFile, TmpFile);
                    }
                }
                catch (Exception exm)
                {
                    err += TranslateHelper.Translate("An error occured while protecting PDF File") + " : " + InputFile + "\r\n" + exm.Message + "\r\n";
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                err += TranslateHelper.Translate("An error occured while protecting PDF File") + " : " + InputFile + "\r\n" + ex.Message + "\r\n";
            }

            return err;
        }
    }

    public class EncryptArgs
    {
        public string cmbOutputDir = "";
        public bool chkCopy = false;
        public bool chkFormFill = false;
        public bool chkHighPrinting = false;
        public bool chkLowPrinting = false;
        public bool chkModifyContents = false;
        public bool chkScreenReaders = false;
        public bool chkAssembly = false;
        public bool chkAnnotations = false;
        public bool rd128Bits = false;
        public string txtUserPassword = "";
        public string txtOwnerPassword = "";

    }

    public class DocArgs
    {
        public bool chkAuthor = false;
        public bool chkCreator = false;
        public bool chkKeywords = false;
        public bool chkModificationDate = false;
        public bool chkCreationDate = false;
        public bool chkTitle = false;
        public bool chkSubject = false;


    }
}
