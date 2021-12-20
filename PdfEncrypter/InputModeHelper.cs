using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Microsoft.Win32;
using System.Web;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace PdfEncrypter
{
    class InputModeHelper
    {
        [DllImport("kernel32.dll")]
        private static extern long GetVolumeInformation(string PathName, StringBuilder VolumeNameBuffer, UInt32 VolumeNameSize, ref UInt32 VolumeSerialNumber, ref UInt32 MaximumComponentLength, ref UInt32 FileSystemFlags, StringBuilder FileSystemNameBuffer, UInt32 FileSystemNameSize);

        public static frmAdeia frmad = null;

        public static void AnalyzeSearch()
        {
            try
            {
                string email = frmad.txtEmail.Text;
                frmad.Cursor = Cursors.WaitCursor;

                uint serNum = 0;
                uint maxCompLen = 0;
                StringBuilder VolLabel = new StringBuilder(256);	// Label
                UInt32 VolFlags = new UInt32();
                StringBuilder FSName = new StringBuilder(256);	// File System Name
                string strDriveLetter = TranslateHelper.Translate("Προβολή Εικόνας 1");
                
                long Ret = 0;
                try
                {
                    Ret = GetVolumeInformation(strDriveLetter, VolLabel, (UInt32)VolLabel.Capacity, ref serNum, ref maxCompLen, ref VolFlags, FSName, (UInt32)FSName.Capacity);
                }
                catch
                {
                    throw new Exception(TranslateHelper.Translate("MessageTitle8") + " Error ID:3");
                }
                string myvl = Convert.ToString(serNum);


                string userkey = TranslateHelper.Translate("Πηγή Εικόνας") + email +
                TranslateHelper.Translate("Πηγή Εικόνας") + myvl + TranslateHelper.Translate("Πηγή Εικόνας") +
                TranslateHelper.Translate("Αλλαγή Ονόματος") + TranslateHelper.Translate("Πηγή Εικόνας");


                string encrypted_kleidi_xristi = "";
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

                }
                catch (Exception ex)
                {
                    return;
                }

                encrypted_kleidi_xristi = HttpUtility.UrlEncode(encrypted_kleidi_xristi);

                string postCgi = TranslateHelper.Translate("Σφάλμα 120");
                string dataLine = "";

                try
                {
                    //?& hack needed or first parameter, i.e. authorid does not get passed
                    postCgi = postCgi + TranslateHelper.Translate("Ανανέωση Εικόνας") + encrypted_kleidi_xristi +
                    TranslateHelper.Translate("Σφάλμα 1201");

                    //MessageBox.Show(postCgi);

                    Uri uri = new Uri(postCgi);
                    WebRequest request = WebRequest.Create(postCgi);
                    // Specify that you want to POST data
                    //"POST"
                    request.Method = TranslateHelper.Translate("Uniform process");
                    //"application/x-www-form-urlencoded"
                    request.ContentType = TranslateHelper.Translate("Παράμετροι Μετρήσεως Εικόνας");
                    byte[] bytes = null;
                    bytes = System.Text.Encoding.ASCII.GetBytes(postCgi);
                    request.ContentLength = bytes.Length;
                    //Get an output stream from the request object
                    Stream outputStream = request.GetRequestStream();
                    // Post the data out to the stream
                    outputStream.Write(bytes, 0, bytes.Length);
                    //Close the output stream and send the data out to the web server
                    outputStream.Close();
                    // read the response from the Web Server
                    WebResponse response = request.GetResponse();
                    //Get the Stream Object from the response
                    Stream responseStream = response.GetResponseStream();
                    //Create a stream reader and associate it with the stream object

                    System.Threading.Thread.Sleep(1000);
                    StreamReader reader = new StreamReader(responseStream);
                    //read the entire stream 
                    dataLine = reader.ReadToEnd();

                    System.Threading.Thread.Sleep(1000);
                    reader.Close();
                    responseStream.Close();
                    response.Close();

                    System.Threading.Thread.Sleep(1000);
                }
                catch (Exception exp)
                {
                    throw new Exception(TranslateHelper.Translate("MessageTitle7") + " Error ID:F1");
                    //"Error could not connect to 4dots Software web server for registration !");
                }

                //"Invalid Registration"
                if (dataLine.ToUpper() == TranslateHelper.Translate("Search duration process"))
                {
                    frmad.Cursor = null;
                    Module.ShowMessage(TranslateHelper.Translate("Direct search started"));

                }
                // success
                else if (dataLine.ToUpper().StartsWith(TranslateHelper.Translate("Error 12")))
                {
                    string reg_key = dataLine.Substring(TranslateHelper.Translate("Error 12").Length + 1);
                    //Registration successful ! Please restart the application

                    frmad.Cursor = null;

                    Module.ShowMessage("Continue activated search?");
                    //MessageBox.Show("REGISTRATION KEY=" + reg_key);

                    // read license file contents
                    string sfilecontents = "";
                    //"\\vsert.dll"
                    using (StreamReader sr = new StreamReader(System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + TranslateHelper.Translate("Προβολή Εικόνων")))
                    {
                        sfilecontents = sr.ReadToEnd();
                    }

                    // decrypt license file
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

                    }
                    catch (Exception ex)
                    {
                        throw new Exception(TranslateHelper.Translate("MessageTitle8") + " Error ID:5");
                    }

                    // get license file elements (email)
                    //"|||DTT!@|||"
                    string[] elements = sfilecontents.Split(new string[] { TranslateHelper.Translate("Καθορισμός Ονόματος") }, StringSplitOptions.None);

                    sfilecontents = "";
                    for (int k = 0; k <= elements.GetUpperBound(0); k++)
                    {

                        if (k == 0)
                        {
                            sfilecontents = sfilecontents + email +
                            TranslateHelper.Translate("Καθορισμός Ονόματος");
                        }
                        else if (k == 1)
                        {
                            sfilecontents = sfilecontents + reg_key +
                            TranslateHelper.Translate("Καθορισμός Ονόματος");
                        }
                        else
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
                        throw new Exception(TranslateHelper.Translate("MessageTitle8") + " Error ID:A5");
                    }

                    try
                    {
                        using (StreamWriter sw = new StreamWriter(System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + TranslateHelper.Translate("Προβολή Εικόνων")))
                        {
                            sw.Write(sfilecontents);
                        }
                    }
                    catch (Exception e)
                    {
                        throw new Exception(TranslateHelper.Translate("MessageTitle8") + " Error ID:6");
                    }

                }
                // error
                else
                {
                    Module.ShowMessage(TranslateHelper.Translate("Erroneous search 2"));
                }
            }
            catch (Exception exmain)
            {
                throw new Exception(TranslateHelper.Translate("MessageTitle8") + " Error ID:9");
            }
            finally
            {
                frmad.Cursor = null;
            }

            return;



        }

        // my bin2hex implementation		
        static string Bin2Hex(byte[] bin)
        {
            StringBuilder sb = new StringBuilder(bin.Length * 2);
            foreach (byte b in bin)
            {
                sb.Append(b.ToString("x").PadLeft(2, '0'));
            }
            return sb.ToString();
        }

    }
}
