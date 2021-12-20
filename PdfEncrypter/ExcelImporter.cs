using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Excel;
using System.Data;

namespace PdfEncrypter
{
    class ExcelImporter
    {
        public void ImportListExcel(string filepath)
        {
            using (FileStream stream = File.Open(filepath, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader excelReader = null;

                string curdir = Environment.CurrentDirectory;

                try
                {
                    Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(filepath);

                    if (filepath.ToLower().EndsWith(".xls") || filepath.ToLower().EndsWith(".xlt"))
                    {
                        excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (filepath.ToLower().EndsWith(".xlsx"))
                    {
                        excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }

                    //excelReader.IsFirstRowAsColumnNames = chkHasHeaders.Checked;

                    DataSet result = excelReader.AsDataSet(false);

                    if (result.Tables.Count > 0)
                    {
                        for (int m = 0; m < result.Tables.Count; m++)
                        {
                            for (int k = 0; k < result.Tables[m].Rows.Count; k++)
                            {
                                if (result.Tables[m].Columns.Count > 0)
                                {
                                    string file = "";

                                    try
                                    {
                                        file = result.Tables[m].Rows[k][0].ToString();

                                        file = GetPart(file);

                                        file = Path.GetFullPath(file);
                                    }
                                    catch { }

                                    string existingpwd = "";

                                    try
                                    {
                                        existingpwd= result.Tables[m].Rows[k][1].ToString();
                                    }
                                    catch { }

                                    string newuserpwd = "";

                                    try
                                    {
                                        newuserpwd = result.Tables[m].Rows[k][2].ToString();
                                    }
                                    catch { }

                                    string newownerpwd = "";

                                    try
                                    {
                                        newownerpwd = result.Tables[m].Rows[k][3].ToString();
                                    }
                                    catch { }


                                    if (System.IO.File.Exists(file))
                                    {
                                        frmMain.Instance.AddFile(file, existingpwd, "", newuserpwd, newownerpwd);
                                    }
                                    else if (System.IO.Directory.Exists(file))
                                    {
                                        frmMain.Instance.AddFolder(file, existingpwd, newuserpwd, newownerpwd);
                                    }                                                                       
                                }
                            }
                        }
                    }
                }
                finally
                {
                    Environment.CurrentDirectory = curdir;

                    if (excelReader != null)
                    {
                        excelReader.Close();
                        excelReader.Dispose();
                    }
                }
            }
        }

        private static string GetPart(string part)
        {
            if (part.StartsWith("\""))
            {
                int epos = part.IndexOf("\"", 1);

                if (epos > 0)
                {
                    part = part.Substring(1, epos - 1);
                }
            }
            else if (part.StartsWith("'"))
            {
                int epos = part.IndexOf("'", 1);

                if (epos > 0)
                {
                    part = part.Substring(1, epos - 1);
                }
            }

            return part;
        }
    }
}
