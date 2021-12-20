using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace PdfEncrypter
{ 
    class ArgsHelper
    {
        public static bool FromWindowsExplorer = false;

        public static bool ExamineArgs(string[] args)
        {
            if (args.Length == 0) return true;

            //MessageBox.Show(args[0]);
            Module.args = args;

            try
            {
                if (args[0].ToLower().Trim().StartsWith("-tempfile:"))
                {

                    string tempfile = GetParameter(args[0]);

                    //MessageBox.Show(tempfile);

                    using (StreamReader sr = new StreamReader(tempfile, Encoding.Unicode))
                    {
                        string scont = sr.ReadToEnd();

                        //args = scont.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        args = SplitArguments(scont);
                        Module.args = args;

                        // MessageBox.Show(scont);
                    }
                }
                else if (Module.IsFromWindowsExplorer)
                {

                }
                else
                {
                    Module.IsCommandLine = true;

                    for (int k = 0; k < Module.args.Length; k++)
                    {
                        if (System.IO.File.Exists(Module.args[k]))
                        {
                            frmMain.Instance.AddFile(Module.args[k]);
                        }
                        else if (System.IO.Directory.Exists(Module.args[k]))
                        {
                            frmMain.Instance.AddFolder(Module.args[k]);
                        }
                        else if ((Module.args[k].ToLower().Trim()[0] == '-' || Module.args[k].ToLower().Trim()[0] == '/') && Module.args[k].ToLower().Trim().Length > 1)
                        {
                            string parval = Module.args[k].ToLower().Trim().Substring(1);

                            //Console.WriteLine(parval);

                            if (parval == "enc128")
                            {
                                Module.Cmdenc128 = true;
                            }
                            else if (parval == "enc40")
                            {
                                Module.Cmdenc40 = true;
                            }
                            else if (parval.ToUpper() == "DISALLOW_COPYING")
                            {
                                Module.CmdDISALLOW_COPYING = true;
                            }
                            else if (parval.ToUpper() == "DISALLOW_MODIFYING")
                            {
                                Module.CmdDISALLOW_MODIFYING = true;
                            }
                            else if (parval.ToUpper() == "DISALLOW_FORM_FILL")
                            {
                                Module.CmdDISALLOW_FORM_FILL = true;
                            }
                            else if (parval.ToUpper() == "DISALLOW_SCREEN_READERS")
                            {
                                Module.CmdDISALLOW_SCREEN_READERS = true;
                            }
                            else if (parval.ToUpper() == "DISALLOW_HIRES_PRINTING")
                            {
                                Module.CmdDISALLOW_HIRES_PRINTING = true;
                            }
                            else if (parval.ToUpper() == "DISALLOW_LOWRES_PRINTING")
                            {
                                Module.CmdDISALLOW_LOWRES_PRINTING = true;
                            }
                            else if (parval.ToUpper() == "DISALLOW_DOC_ASSEMBLY")
                            {
                                Module.CmdDISALLOW_DOC_ASSEMBLY = true;
                            }
                            else if (parval.ToUpper() == "DISALLOW_ANOTATIONS")
                            {
                                Module.CmdDISALLOW_ANOTATIONS = true;
                            }
                            else if (parval.StartsWith("l:"))
                            {
                                Module.CmdImportListFile = GetParameter(Module.args[k]);
                            }
                            else if (parval.StartsWith("log:"))
                            {
                                Module.CmdLogFile = GetParameter(Module.args[k]);
                            }
                            else if (parval == "overwrite")
                            {
                                Module.CmdOverwritePDF = true;
                            }
                            else if (parval == "subdirs")
                            {
                                Module.CmdAddSubdirectories = true;
                            }
                            else if (parval == "backup")
                            {
                                Module.CmdKeepBackup = true;
                            }
                            else if (parval.StartsWith("outfilename:"))
                            {
                                Module.CmdOutputFile = GetParameter(Module.args[k]);
                            }
                            else if (parval.StartsWith("outfolder:"))
                            {
                                Module.CmdOutputFolder = GetParameter(Module.args[k]);
                            }
                            else if (parval.StartsWith("outputfolder:"))
                            {
                                Module.CmdOutputFolder = GetParameter(Module.args[k]);
                            }
                            else if (parval.StartsWith("userpassword:"))
                            {
                                Module.CmdUserPassword = GetParameter(Module.args[k]);
                            }
                            else if (parval.StartsWith("newuserpassword:"))
                            {                                
                                Module.Cmdnewuserpassword = GetParameter(Module.args[k]);

                                //Console.WriteLine("parsed" + Module.Cmdnewuserpassword);
                            }
                            else if (parval.StartsWith("newownerpassword:"))
                            {
                                Module.Cmdnewownerpassword = GetParameter(Module.args[k]);
                            }
                            else if (parval.StartsWith("author:"))
                            {
                                Module.Cmdauthor = GetParameter(Module.args[k]);
                            }
                            else if (parval.StartsWith("creator:"))
                            {
                                Module.Cmdcreator = GetParameter(Module.args[k]);
                            }
                            else if (parval.StartsWith("keywords:"))
                            {
                                Module.Cmdkeywords = GetParameter(Module.args[k]);
                            }
                            else if (parval.StartsWith("creationdate:"))
                            {
                                Module.CmdcreationDate = GetParameter(Module.args[k]);
                            }
                            else if (parval.StartsWith("title:"))
                            {
                                Module.Cmdtitle = GetParameter(Module.args[k]);
                            }
                            else if (parval.StartsWith("subject:"))
                            {
                                Module.Cmdsubject = GetParameter(Module.args[k]);
                            }
                            else if (parval.StartsWith("modificationdate:"))
                            {
                                Module.CmdmodificationDate = GetParameter(Module.args[k]);

                            }
                            else if (parval == "h" || parval == "?")
                            {
                                ShowCommandUsage();
                                return true;
                            }

                        }
                    }

                    if (Module.CmdOutputFolder != String.Empty)
                    {
                        Module.CmdOutputFolder = System.IO.Path.GetFullPath(Module.CmdOutputFolder);

                        if (!System.IO.Directory.Exists(Module.CmdOutputFolder))
                        {
                            Module.ShowMessage("Please specify an existing output folder !");
                            ShowCommandUsage();
                            return false;
                        }
                    }

                    if (Module.CmdUserPassword != string.Empty)
                    {
                        for (int m = 0; m < frmMain.Instance.dt.Rows.Count; m++)
                        {
                            frmMain.Instance.dt.Rows[m]["userpassword"] = Module.CmdUserPassword;
                        }
                    }

                    if (Module.CmdImportListFile != string.Empty)
                    {
                        Module.CmdImportListFile = System.IO.Path.GetFullPath(Module.CmdImportListFile);

                        //MessageBox.Show(Module.CmdImportListFile);

                        if (!System.IO.File.Exists(Module.CmdImportListFile))
                        {
                            Module.ShowMessage("Import List File does not exist !");
                            ShowCommandUsage();
                            return false;
                        }
                    }

                    if (Module.CmdLogFile != string.Empty)
                    {
                        Module.CmdLogFile = System.IO.Path.GetFullPath(Module.CmdLogFile);

                        if (!Module.IsLegalFilename(Module.CmdLogFile))
                        {
                            Module.ShowMessage("Please enter a legal log filename !");
                            ShowCommandUsage();
                            return false;
                        }
                    }

                    if (Module.CmdmodificationDate != string.Empty)
                    {
                        try
                        {
                            EncryptHelper.ModificationDate = Module.ParseDateTimeFromString(Module.CmdmodificationDate);
                        }
                        catch
                        {
                            Module.ShowMessage("Invalid Modification Date Format !");
                            ShowCommandUsage();
                            return false;
                        }
                    }

                    if (Module.CmdcreationDate != string.Empty)
                    {
                        try
                        {
                            EncryptHelper.CreationDate = Module.ParseDateTimeFromString(Module.CmdcreationDate);
                        }
                        catch
                        {
                            Module.ShowMessage("Invalid Creation Date Format !");
                            ShowCommandUsage();
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Module.ShowError("Error could not parse Arguments !", ex.ToString());
                return false;
            }


            return true;
        }

        private static string GetParameter(string arg)
        {
            int spos = arg.IndexOf(":");
            if (spos == arg.Length - 1) return "";
            else
            {
                string str=arg.Substring(spos + 1);

                if ((str.StartsWith("\"") && str.EndsWith("\"")) ||
                    (str.StartsWith("'") && str.EndsWith("'")))
                {
                    if (str.Length > 2)
                    {
                        str = str.Substring(1, str.Length - 2);
                    }
                    else
                    {
                        str = "";
                    }
                }

                return str;
            }
        }

        public static string[] SplitArguments(string commandLine)
        {
            char[] parmChars = commandLine.ToCharArray();
            bool inSingleQuote = false;
            bool inDoubleQuote = false;
            for (int index = 0; index < parmChars.Length; index++)
            {
                if (parmChars[index] == '"' && !inSingleQuote)
                {
                    inDoubleQuote = !inDoubleQuote;
                    parmChars[index] = '\n';
                }
                if (parmChars[index] == '\'' && !inDoubleQuote)
                {
                    inSingleQuote = !inSingleQuote;
                    parmChars[index] = '\n';
                }
                if (!inSingleQuote && !inDoubleQuote && parmChars[index] == ' ')
                    parmChars[index] = '\n';
            }
            return (new string(parmChars)).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }
        public static void ShowCommandUsage()
        {
            string msg = GetCommandUsage();

            Module.ShowMessage(msg);

            Environment.Exit(0);
        }

        public static string GetCommandUsage()
        {
            string msg = "Protect PDF Documents with a Password.\n\n" +
            "PdfEncrypter.exe [[file|directory]]" +
            "[/newuserpassword:NEW_USER_PASSWORD_VALUE] " +
            "[/newownerpassword:NEW_OWNER_PASSWORD_VALUE] " +
            "[/enc128] " +
            "[/enc40] " +
            "[/DISALLOW_COPYING]" +
            "[/DISALLOW_MODIFYING]" +
            "[/DISALLOW_FORM_FILL]" +
            "[/DISALLOW_SCREEN_READERS]" +
            "[/DISALLOW_HIRES_PRINTING]" +
            "[/DISALLOW_LOWRES_PRINTING]" +
            "[/DISALLOW_DOC_ASSEMBLY]" +
            "[/DISALLOW_ANOTATIONS]" +
            "[/userpassword:USER_PASSWORD_VALUE] " +
            "[/author:METADATA_VALUE] " +
            "[/creator:METADATA_VALUE] " +
            "[/keywords:METADATA_VALUE] " +
            "[/creationDate:METADATA_VALUE] " +
            "[/title:METADATA_VALUE] " +
            "[/subject:METADATA_VALUE] " +
            "[/modificationDate:METADATA_VALUE] " +
            "[/subdirs] " +
            "[/overwrite]" +
            "[/backup]" +
            "[outfilename:OUTPUT_FILE_VALUE] " +
            "[/l:IMPORT_LIST_FILE_VALUE]" +
            "[/log:LOG_FILE_VALUE]" +
            "[/outputfolder:OUTPUT_FOLDER_VALUE] " +
            "[/?]\n\n\n" +
            "file : one or more pdf or image files to be processed.\n" +
            "directory : one or more directories containing pdf or images files to be processed.\n" +
            "newuserpassword: New user password of the document (password for opening the document).\n" +
            "newownerpassword: New owner password of the document (password for restrictions).\n" +
            "enc128 : Encryption strength 128bits (Default).\n" +
            "enc40 : Encryption strength 40bits.\n" +
            "DISALLOW_COPYING : Disallow Content Copying.\n" +
            "DISALLOW_MODIFYING : Disallow Modifying Contents.\n" +
            "DISALLOW_FORM_FILL : Disallow Form-Field Fill-in or Signing.\n" +
            "DISALLOW_SCREEN_READERS : Disallow Screen Readers.\n" +
            "DISALLOW_HIRES_PRINTING : Disallow High Resolution Printing.\n" +
            "DISALLOW_LOWRES_PRINTING : Disallow Low Resolution Printing Only.\n" +
            "DISALLOW_DOC_ASSEMBLY : Disallow Document Assembly or Changing.\n" +
            "DISALLOW_ANOTATIONS : Disallow Annotations.\n" +
            "userpassword: Existing user password of document.\n" +
            "author: Author metadata.\n" +
            "creator: Creator metadata.\n " +
            "keywords: Keywords metadata.\n" +
            "creationDate: Creation Date Metadata. Format : dd/MM/yyyy hh:mm:ss .\n" +
            "title: Title metadata.\n " +
            "subject: Subject metadata.\n" +
            "modificationDate : Modification Date Metadata. Format : dd/MM/yyyy hh:mm:ss .\n" +
            "subdirs : process also subdirectories of specified directories\n" +
            "overwrite : overwrite existing PDF document\n" +
            "backup : keep backup in case of overwrite\n" +
            "outfilename : Output filename. If not specified the file will have the same filename but will end with \"_protected\".\n" +
            "Enter [FILENAME] for document's filename without extension and [EXT] for document's extension.\n" +
            "l : Import list of files to be processed from a text file. One file or folder on each line. In case the document has a password it's line should be comma separated.\n" +
            "log : Logfile where output messages should be logged.\n" +

            "outputfolder: Output folder value (if different than the folder of the first file)\n" +
            "? : show help\n";

            return msg;
        }

        public static bool IsFromWindowsExplorer
        {
            get
            {
                if (Module.IsFromWindowsExplorer) return true;

                // new
                if (Module.args.Length > 0 && (
                    Module.args[0].ToLower().Trim().Contains("-tempfile:")
                    || 
                    (Module.args.Length==1 && (System.IO.File.Exists(Module.args[0]) || System.IO.Directory.Exists(Module.args[0])))
                    )
                    )
                {
                    Module.IsFromWindowsExplorer = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool IsFromCommandLine
        {
            get
            {
                if (Module.args == null || Module.args.Length == 0)
                {
                    return false;
                }

                if (ArgsHelper.IsFromWindowsExplorer)
                {
                    Module.IsCommandLine = false;
                    return false;
                }
                else
                {
                    Module.IsCommandLine = true;
                    return true;
                }
            }
        }

        public static void ExecuteCommandLine()
        {
            string err = "";
            bool finished = false;

            try
            {
                if (Module.CmdLogFile != string.Empty)
                {
                    try
                    {
                        Module.CmdLogFileWriter = new StreamWriter(Module.CmdLogFile, true);
                        Module.CmdLogFileWriter.AutoFlush = true;
                        Module.CmdLogFileWriter.WriteLine("[" + DateTime.Now.ToString() + "] Started protecting PDF files !");
                    }
                    catch (Exception exl)
                    {
                        Module.ShowMessage("Error could not start log writer !");
                        ShowCommandUsage();
                        Environment.Exit(0);
                        return;
                    }
                }

                if (Module.CmdImportListFile != string.Empty)
                {
                    frmMain.Instance.ImportList(Module.CmdImportListFile);

                    err += frmMain.Instance.SilentAddErr;

                }

                if (frmMain.Instance.dt.Rows.Count == 0)
                {
                    err += "Please specify PDF Files to protect !";
                    ShowCommandUsage();
                    Environment.Exit(0);
                    return;
                }

                try
                {
                    err += EncryptHelper.EncryptMultiplePDFCmd(frmMain.Instance.dt);
                    finished = true;
                }
                catch (Exception ex)
                {
                    err += ex.Message + "\r\n";
                }
            }
            finally
            {
                if (Module.CmdLogFile == string.Empty)
                {
                    if (err == string.Empty && finished)
                    {
                        Module.ShowMessage("Operation completed successfully !");
                    }
                    else
                    {
                        Module.ShowMessage("An error occured !\n" + err);
                    }
                }
                else
                {
                    if (err == string.Empty && finished)
                    {
                        Module.CmdLogFileWriter.WriteLine("[" + DateTime.Now.ToString() + "] Operation completed successfully !");
                    }
                    else
                    {
                        Module.CmdLogFileWriter.WriteLine("[" + DateTime.Now.ToString() + "] An error occured !\n" + err);
                    }
                }

                if (Module.CmdLogFileWriter != null)
                {
                    Module.CmdLogFileWriter.Flush();
                    Module.CmdLogFileWriter.Close();
                }
            }
            Environment.Exit(0);
        }
        
                
                
    }

    public class ReadListsResult
    {
        public bool Success = true;
        public string err = "";
    }
}
