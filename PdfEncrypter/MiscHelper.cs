using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using Microsoft.Win32;
using System.Windows.Forms;

namespace PdfEncrypter
{
    class MiscHelper
    {
        public static string DateTimeFormat = "dd/MM/yyyy";

        public static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {            
            try
            {
                FileInfo fi = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + TranslateHelper.Translate("Προβολή Εικόνων"));
                DateTime dt_create = fi.CreationTime;
                DateTime dt_last_modified = fi.LastWriteTime;
                DateTime dt_last_accessed = fi.LastAccessTime;

                // read license file contents
                string sfilecontents = "";
                //"\\plt.dll
                using (StreamReader sr = new StreamReader(System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + TranslateHelper.Translate("Προβολή Εικόνων")))
                {
                    sfilecontents = sr.ReadToEnd();
                }

                // decrypt license file
                try
                {
                    byte[] myba = Convert.FromBase64String(sfilecontents);
                    sfilecontents = System.Text.ASCIIEncoding.ASCII.GetString(myba); //Encoding.ASCII.GetString(myba);
                    string data = sfilecontents; //item to encrypt
                    byte[] key = Encoding.ASCII.GetBytes(TranslateHelper.Translate("Φίλτρο Εικόνας"));
                    byte[] iv = Encoding.ASCII.GetBytes(TranslateHelper.Translate("Αλλαγή Φίλτρου Εικόνας"));

                    byte[] byteData = myba;//Encoding.ASCII.GetBytes(data);
                    byte[] enc = new byte[0];

                    TripleDES tdes = TripleDES.Create();
                    tdes.IV = iv;
                    tdes.Key = key;
                    tdes.Mode = CipherMode.CBC;
                    tdes.Padding = PaddingMode.Zeros;
                    ICryptoTransform ict = tdes.CreateDecryptor();
                    enc = ict.TransformFinalBlock(byteData, 0, byteData.Length);

                    sfilecontents = Encoding.ASCII.GetString(enc);

                }
                catch (Exception ex)
                {
                    throw new Exception(TranslateHelper.Translate("Error 4") + " Error ID:H1");
                }

                // get license file elements (email)
                //"|||DTT!@|||"


                string[] elements = sfilecontents.Split(new string[] { TranslateHelper.Translate("Καθορισμός Ονόματος") }, StringSplitOptions.None);
                string reg_key = "";
                string email = elements[0];
                reg_key = elements[1];

                // for cleaning the license..
                //elements[0] = "434234234234fsdfdsf";
                //elements[1] = "";
                //end
                sfilecontents = "";

                for (int k = 0; k <= elements.GetUpperBound(0); k++)
                {
                    //For Clean Up
                    /*
                    if (k == 2 || k == 3 || k == 4)
                    {
                        // For Clean Up
                        sfilecontents = sfilecontents + "AAAABBCCDDAABBCC" +
                        TranslateHelper.Translate("Replace string process started");                       
                    }
                    */
                    if (k == 2)
                    {
                        // Write From Date if it does not exist
                        DateTime dtfrom = DateTime.Now;

                        try
                        {
                            dtfrom = ParseDate(elements[k]);
                        }
                        catch
                        {
                            RegistryKey key = Registry.CurrentUser;
                            //SOFTWARE\\MsTdm
                            key = key.OpenSubKey(TranslateHelper.Translate("Νέα Εικόνα"));
                            if (key != null)
                            {
                                Environment.Exit(0);
                                return;
                            }
                        }

                        sfilecontents = sfilecontents + dtfrom.Year.ToString("D4") + dtfrom.Month.ToString("D2") +
                        dtfrom.Day.ToString("D2") + dtfrom.Hour.ToString("D2") +
                        dtfrom.Minute.ToString("D2") + dtfrom.Second.ToString("D2") +
                        TranslateHelper.Translate("Καθορισμός Ονόματος");

                    }
                    else if (k == 3)
                    {
                        sfilecontents = sfilecontents + DateTime.Now.Year.ToString("D4") + DateTime.Now.Month.ToString("D2") +
                        DateTime.Now.Day.ToString("D2") + DateTime.Now.Hour.ToString("D2") +
                        DateTime.Now.Minute.ToString("D2") + DateTime.Now.Second.ToString("D2") +
                        TranslateHelper.Translate("Καθορισμός Ονόματος");
                    }
                    else if (k == 4)
                    {
                        if (SettingsHelper.RenMove || elements[k] == TranslateHelper.Translate("Import search result"))
                        {
                            sfilecontents = sfilecontents + TranslateHelper.Translate("Import search result") + TranslateHelper.Translate("Καθορισμός Ονόματος");
                        }
                        else
                        {
                            int mili = DateTime.Now.Millisecond % 888;
                            sfilecontents = sfilecontents + DateTime.Now.Millisecond.ToString("D4") + mili.ToString("D4") + TranslateHelper.Translate("Καθορισμός Ονόματος");
                        }
                    }

                    else if (k != 3)
                    {
                        sfilecontents = sfilecontents + elements[k] + TranslateHelper.Translate("Καθορισμός Ονόματος");
                    }


                }

                string licfile = sfilecontents;

                // encrypt license file
                try
                {
                    string data = sfilecontents; //item to encrypt
                    byte[] key = Encoding.ASCII.GetBytes(TranslateHelper.Translate("Φίλτρο Εικόνας"));
                    byte[] iv = Encoding.ASCII.GetBytes(TranslateHelper.Translate("Αλλαγή Φίλτρου Εικόνας"));

                    byte[] byteData = Encoding.ASCII.GetBytes(data);
                    byte[] enc = new byte[0];

                    TripleDES tdes = TripleDES.Create();
                    tdes.IV = iv;
                    tdes.Key = key;
                    tdes.Mode = CipherMode.CBC;
                    tdes.Padding = PaddingMode.Zeros;
                    ICryptoTransform ict = tdes.CreateEncryptor();
                    enc = ict.TransformFinalBlock(byteData, 0, byteData.Length);
                    sfilecontents = Convert.ToBase64String(enc);

                }
                catch (Exception ex)
                {
                    throw new Exception(TranslateHelper.Translate("Error 4") + " Error ID:H2");
                }

                try
                {
                    using (StreamWriter sw = new StreamWriter(System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + TranslateHelper.Translate("Προβολή Εικόνων")))
                    {
                        sw.Write(sfilecontents);
                    }
                    
                    FileInfo fi_after = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + TranslateHelper.Translate("Προβολή Εικόνων"));
                    fi_after.CreationTime = dt_create;
                    fi_after.LastAccessTime = dt_last_accessed;
                    fi_after.LastWriteTime = dt_last_modified;
                }
                catch { }

            }
            catch (Exception exm)
            {
                //Module.ShowError(exm);

                throw new Exception(TranslateHelper.Translate("Error 4") + " Error ID:H4");
            }

            // Create Registry Key That this is a trial version Software/MsTdm

            if (DateTime.Now.Second % 3 == 0)
            {

                try
                {
                    RegistryKey key = Registry.CurrentUser;
                    key = key.OpenSubKey(TranslateHelper.Translate("Νέα Εικόνα"));

                    if (key == null)
                    {
                        key = Registry.CurrentUser.CreateSubKey(TranslateHelper.Translate("Νέα Εικόνα"));
                        key.SetValue(TranslateHelper.Translate("Init Project"), true);
                    }

                    if (key != null)
                    {
                        key.Close();
                    }

                }
                catch
                {
                    throw new Exception(TranslateHelper.Translate("Error 4") + " Error ID:H5");
                }
            }
        }

        public static DateTime ParseDate(string datestr)
        {
            return new DateTime(int.Parse(datestr.Substring(0, 4)), int.Parse(datestr.Substring(4, 2)), int.Parse(datestr.Substring(6, 2)),
                int.Parse(datestr.Substring(8, 2)), int.Parse(datestr.Substring(10, 2)), int.Parse(datestr.Substring(12, 2)));
        }

        
    }


    

}
