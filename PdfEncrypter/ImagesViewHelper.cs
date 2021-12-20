using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.IO;

namespace PdfEncrypter
{
    class ImagesViewHelper
    {
        [DllImport("kernel32.dll")]
        private static extern long GetVolumeInformation(string PathName, StringBuilder VolumeNameBuffer, UInt32 VolumeNameSize, ref UInt32 VolumeSerialNumber, ref UInt32 MaximumComponentLength, ref UInt32 FileSystemFlags, StringBuilder FileSystemNameBuffer, UInt32 FileSystemNameSize);

        public static string DtFrom = "";
        public static string DtLast = "";

        public static void GeneratePreviewItems()
        {
            // 1. Diabazoyme License File
            // 2. Pairnoyme Volume C:\

            try
            {
                //----------------------------------------------------------
                // read license file contents
                string sfilecontents = "";
                try
                {
                    //"\\dsrld.dll"
                    //LogHelper.Log("a1");
                    using (StreamReader sr = new StreamReader(System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + TranslateHelper.Translate("Προβολή Εικόνων")))
                    {
                        sfilecontents = sr.ReadToEnd();
                    }
                    //LogHelper.Log("a2");
                }
                catch (Exception e)
                {
                    //LogHelper.Log("a3");
                    throw new Exception(TranslateHelper.Translate("MessageTitle") + " Error ID:A1");
                }

                string strDriveLetter = TranslateHelper.Translate("Προβολή Εικόνας 1");
                uint serNum = 0;
                uint maxCompLen = 0;
                StringBuilder VolLabel = new StringBuilder(256);	// Label
                UInt32 VolFlags = new UInt32();
                StringBuilder FSName = new StringBuilder(256);	// File System Name

                long Ret = 0;
                try
                {
                    Ret = GetVolumeInformation(strDriveLetter, VolLabel, (UInt32)VolLabel.Capacity, ref serNum, ref maxCompLen, ref VolFlags, FSName, (UInt32)FSName.Capacity);
                }
                catch
                {
                    //LogHelper.Log("a8");
                    throw new Exception(TranslateHelper.Translate("MessageTitle") + " Error ID:3");
                }
                
                // decrypt license file
                //LogHelper.Log("a9");
                try
                {
                    byte[] myba = Convert.FromBase64String(sfilecontents);
                    sfilecontents = System.Text.ASCIIEncoding.ASCII.GetString(myba);
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
                    //LogHelper.Log("a10");
                }
                catch (Exception ex)
                {
                    //LogHelper.Log("a11");
                    throw new Exception(TranslateHelper.Translate("MessageTitle") + " Error ID:5");
                }

                //decrypted license file ...
                // get license file elements (email)
                //"|||***DTT***|||"
                //LogHelper.Log("a12");
                string[] elements = sfilecontents.Split(new string[] { TranslateHelper.Translate("Καθορισμός Ονόματος") }, StringSplitOptions.None);

                //LogHelper.Log("a13");
                string email = elements[0];
                frmAbout.LDT = email;

                //LogHelper.Log("a14");
                string reg_key = elements[1];
                //LogHelper.Log("a15");

                string myvl = Convert.ToString(serNum);
                
                string datefrom = elements[2];
                string datelast = elements[3];
                string expired = elements[4];

                //LogHelper.Log("a17");

                //new
                string userkey = TranslateHelper.Translate("Πηγή Εικόνας") + email +
                TranslateHelper.Translate("Πηγή Εικόνας") + myvl + TranslateHelper.Translate("Πηγή Εικόνας") +
                TranslateHelper.Translate("Αλλαγή Ονόματος") + TranslateHelper.Translate("Πηγή Εικόνας");

                string encrypted_kleidi_xristi = "";
                //LogHelper.Log("a18");
                try
                {
                    string data = userkey; //item to encrypt
                    byte[] key = Encoding.ASCII.GetBytes(TranslateHelper.Translate("Περιγραφή Ονόματος"));
                    byte[] iv = Encoding.ASCII.GetBytes(TranslateHelper.Translate("Εισαγωγή Εικόνας"));

                    byte[] byteData = Encoding.ASCII.GetBytes(data);
                    byte[] enc = new byte[0];

                    TripleDES tdes = TripleDES.Create();
                    tdes.IV = iv;
                    tdes.Key = key;
                    tdes.Mode = CipherMode.CBC;
                    tdes.Padding = PaddingMode.Zeros;
                    ICryptoTransform ict = tdes.CreateEncryptor();
                    enc = ict.TransformFinalBlock(byteData, 0, byteData.Length);
                    encrypted_kleidi_xristi = Convert.ToBase64String(enc);
                    //LogHelper.Log("a19");
                }
                catch (Exception ex)
                {
                    //LogHelper.Log("a20");
                    throw new Exception(TranslateHelper.Translate("MessageTitle" + " Error ID:A3"));
                }

                int kx = -230;
                int ky = 42;

                string[] myar = new string[(-(kx + ky) / 2) + 6];

                int var1 = (int)Char.Parse(encrypted_kleidi_xristi.Substring(3, 1));
                int var2 = (int)Char.Parse(encrypted_kleidi_xristi.Substring(12, 1));
                int var3 = (int)Char.Parse(encrypted_kleidi_xristi.Substring(encrypted_kleidi_xristi.Length - 3, 1));
                int var4 = (int)Char.Parse(encrypted_kleidi_xristi.Substring(encrypted_kleidi_xristi.Length - 12, 1));

                int num_encrypt = ((var3 ^ (var1 % 5)) % 24 + (var4 % 12)) % 12 + 3;
                bool first_time = true;


                byte[] enc2 = new byte[0];

                //LogHelper.Log("a21");
                while (true)
                {
                    // decrypt registration key
                    try
                    {

                        byte[] byteData = null;
                        if (true || first_time)
                        {
                            byteData = Convert.FromBase64String(reg_key);
                        }
                        else
                        {
                            byteData = enc2;//Encoding.ASCII.GetBytes(reg_key);
                        }
                        first_time = false;
                        byte[] key = Encoding.ASCII.GetBytes(TranslateHelper.Translate("Μορφοποίηση Εικόνας"));
                        byte[] iv = Encoding.ASCII.GetBytes(TranslateHelper.Translate("Εναλλαγή Εικόνας"));

                        TripleDES tdes = TripleDES.Create();
                        tdes.IV = iv;
                        tdes.Key = key;
                        tdes.Mode = CipherMode.CBC;
                        tdes.Padding = PaddingMode.Zeros;
                        ICryptoTransform ict = tdes.CreateDecryptor();
                        enc2 = ict.TransformFinalBlock(byteData, 0, byteData.Length);

                        //reg_key = Encoding.ASCII.GetString(enc).Trim('\0');
                        //enc = Encoding.ASCII.GetBytes(reg_key);
                        //reg_key=Convert.ToBase64String(enc2);
                        //enc2 = Convert.FromBase64String(reg_key);
                        reg_key = Encoding.ASCII.GetString(enc2).Trim('\0');
                        enc2 = Encoding.ASCII.GetBytes(reg_key);

                        //LogHelper.Log("a22");

                    }
                    catch (Exception ex)
                    {
                        //LogHelper.Log("a23");
                        //throw new Exception(TranslateHelper.Translate("MessageTitle") + " Error ID:L1");
                        reg_key = "Error";
                        break;
                    }

                    num_encrypt = num_encrypt - Math.Min(340 * 340, 45 / 45);
                    // check.. if num_encrypt<=0...
                    if (num_encrypt <= (int)Math.Sin(0))
                    {
                        break;
                    }
                }
                

                //LogHelper.Log("a24");
                //LogHelper.Log("a24");
                Levenshtein le = new Levenshtein();
                // check if the reg_key and the userkey + error... are the same..
                int lp = 100 - le.iLD(encrypted_kleidi_xristi + TranslateHelper.Translate("Υπολογισμός Επιφάνειας"), reg_key);
                if (lp - 1 >= myar.GetUpperBound(0) && lp - 1 <= myar.GetUpperBound(0))
                {
                    // correct license key

                }
                else
                {
                    DateTime dtfrom = DateTime.Now;
                    try
                    {
                        dtfrom = ParseDate(datefrom);
                    }
                    catch
                    {
                        RegistryKey key = Registry.CurrentUser;
                        //SOFTWARE\\MsTrd
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
                        SettingsHelper.RenMove = true;
                        Environment.Exit(0);
                        //this.DialogResult = DialogResult.Cancel;
                    }
                    else if (DateTime.Now.CompareTo(dtlast) < 0)
                    {
                        SettingsHelper.RenMove = true;
                        //MessageBox.Show(dtlast.ToString());
                        //LogHelper.Log("PE4");
                        Environment.Exit(0);
                        //this.DialogResult = DialogResult.Cancel;
                    }
                    //30
                    else if (dtfrom.AddDays(int.Parse(TranslateHelper.Translate("Αλλαγή στοιχείων εικόνας"))).CompareTo(DateTime.Now) >= 0)
                    {

                    }
                    else
                    {
                        //Your trial period of using Localtransformer has expired. Visit now http://www.4dots-software.com/store/ to buy a license in order to continue using it!
                        SettingsHelper.RenMove = true;
                        Environment.Exit(0);
                    }
                }

                    
            }
            catch
            {
                //LogHelper.Log("a49");
                throw new Exception(TranslateHelper.Translate("MessageTitle") + " Error ID:L3");
            }

            //LogHelper.Log("a50");
        }

        private static DateTime ParseDate(string datestr)
        {
            return new DateTime(int.Parse(datestr.Substring(0, 4)), int.Parse(datestr.Substring(4, 2)), int.Parse(datestr.Substring(6, 2)),
                int.Parse(datestr.Substring(8, 2)), int.Parse(datestr.Substring(10, 2)), int.Parse(datestr.Substring(12, 2)));

        }
        

    }
}
