using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;

namespace PdfEncrypter
{
    class FuzzyMatch
    {

        private static int ExtractPreviousFuzzyMatch(string helpcolumn)
        {
            try
            {
                string shelp = helpcolumn;
                if (shelp == String.Empty) return -1;
                int istart = shelp.IndexOf("|FUZZY MATCH:");
                if (istart < 0) return -1;
                istart = istart + "|FUZZY MATCH:".Length;
                int iend = shelp.IndexOf("|", istart);
                if (iend < 0) return -1;
                return int.Parse(shelp.Substring(istart, iend - istart));
            }
            catch
            {
                return -1;
            }
        }

        private static string SetFuzzyHelpColumnText(int fuzzypercent, string helpcolumn)
        {
            try
            {
                string shelp = helpcolumn;
                if (shelp == String.Empty)
                {
                    return "|FUZZY MATCH:" + fuzzypercent.ToString() + "|";

                }
                int istart = shelp.IndexOf("|FUZZY MATCH:");
                if (istart < 0)
                {
                    return helpcolumn += "|FUZZY MATCH:" + fuzzypercent.ToString() + "|";
                }
                istart = istart + "|FUZZY MATCH:".Length;
                int iend = shelp.IndexOf("|", istart);
                if (iend < 0)
                {
                    return helpcolumn += "|FUZZY MATCH:" + fuzzypercent.ToString() + "|";
                }

                int ishelp = shelp.Length;
                return shelp.Substring(0, istart) + fuzzypercent.ToString()
                + shelp.Substring(iend, helpcolumn.Length - iend);

            }
            catch
            {
                return helpcolumn;
            }
        }

        public static bool IsFuzzyMatchForReport(string sNew, string sOld, int percent_fuzzy_from, int percent_fuzzy_to)
        {
            try
            {
                if (sNew == sOld)
                {
                    if (percent_fuzzy_from == 100)
                        return true;
                    else
                        return false;
                }
                else
                {
                    Levenshtein l = new Levenshtein();
                    int lp = 100 - l.iLD(sNew, sOld);
                    if (lp > percent_fuzzy_from && lp <= percent_fuzzy_to)
                    {
                        return true;
                    }
                }
            }
            catch { return false; }
            return false;
        }

        public static FuzzyMatchResult IsFuzzyMatch(string sNew, string sOld, string helpcolumn)
        {

            try
            {
                Levenshtein l = new Levenshtein();
                int lp = 100 - l.iLD(sNew, sOld);
                if (lp >= 90)
                {
                    int iprevious = ExtractPreviousFuzzyMatch(helpcolumn);
                    if (iprevious == -1)
                    {
                        string shelp = SetFuzzyHelpColumnText(lp, helpcolumn);
                        FuzzyMatchResult f = new FuzzyMatchResult();
                        f.IsFuzzy = true;
                        f.helpcolumn = shelp;
                        return f;
                    }
                    else
                        if (iprevious < lp)
                        {
                            // SetFuzzyHelpColumnText(lp,ref dr);
                            string shelp = SetFuzzyHelpColumnText(lp, helpcolumn);
                            FuzzyMatchResult f = new FuzzyMatchResult();
                            f.IsFuzzy = true;
                            f.helpcolumn = shelp;
                            return f;
                        }
                }




            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.ToString());

            }

            FuzzyMatchResult ff = new FuzzyMatchResult();
            ff.IsFuzzy = false;
            return ff;
        }
    }

    public class FuzzyMatchResult
    {
        public bool IsFuzzy = false;
        public string helpcolumn = "";
    }

    public class Levenshtein
    {


        ///*****************************
        /// Compute Levenshtein distance 
        /// Memory efficient version
        ///*****************************
        public int iLD(String sRow, String sCol)
        {
            int RowLen = sRow.Length;  // length of sRow
            int ColLen = sCol.Length;  // length of sCol
            int RowIdx;                // iterates through sRow
            int ColIdx;                // iterates through sCol
            char Row_i;                // ith character of sRow
            char Col_j;                // jth character of sCol
            int cost;                   // cost

            /// Test string length
            if (Math.Max(sRow.Length, sCol.Length) > Math.Pow(2, 31))
                throw (new Exception("\nMaximum string length in Levenshtein.iLD is " + Math.Pow(2, 31) + ".\nYours is " + Math.Max(sRow.Length, sCol.Length) + "."));

            // Step 1

            if (RowLen == 0)
            {
                return ColLen;
            }

            if (ColLen == 0)
            {
                return RowLen;
            }

            /// Create the two vectors
            int[] v0 = new int[RowLen + 1];
            int[] v1 = new int[RowLen + 1];
            int[] vTmp;



            /// Step 2
            /// Initialize the first vector
            for (RowIdx = 1; RowIdx <= RowLen; RowIdx++)
            {
                v0[RowIdx] = RowIdx;
            }

            // Step 3

            /// Fore each column
            for (ColIdx = 1; ColIdx <= ColLen; ColIdx++)
            {
                /// Set the 0'th element to the column number
                v1[0] = ColIdx;

                Col_j = sCol[ColIdx - 1];


                // Step 4

                /// Fore each row
                for (RowIdx = 1; RowIdx <= RowLen; RowIdx++)
                {
                    Row_i = sRow[RowIdx - 1];


                    // Step 5

                    if (Row_i == Col_j)
                    {
                        cost = 0;
                    }
                    else
                    {
                        cost = 1;
                    }

                    // Step 6

                    /// Find minimum
                    int m_min = v0[RowIdx] + 1;
                    int b = v1[RowIdx - 1] + 1;
                    int c = v0[RowIdx - 1] + cost;

                    if (b < m_min)
                    {
                        m_min = b;
                    }
                    if (c < m_min)
                    {
                        m_min = c;
                    }

                    v1[RowIdx] = m_min;
                }

                /// Swap the vectors
                vTmp = v0;
                v0 = v1;
                v1 = vTmp;

            }


            // Step 7

            /// Value between 0 - 100
            /// 0==perfect match 100==totaly different
            /// 
            /// The vectors where swaped one last time at the end of the last loop,
            /// that is why the result is now in v0 rather than in v1
            //System.Console.WriteLine("iDist=" + v0[RowLen]);
            int max = System.Math.Max(RowLen, ColLen);
            return ((100 * v0[RowLen]) / max);
        }





        ///*****************************
        /// Compute the min
        ///*****************************

        private int Minimum(int a, int b, int c)
        {
            int mi = a;

            if (b < mi)
            {
                mi = b;
            }
            if (c < mi)
            {
                mi = c;
            }

            return mi;
        }

        ///*****************************
        /// Compute Levenshtein distance         
        ///*****************************

        public int LD(String sNew, String sOld)
        {
            int[,] matrix;              // matrix
            int sNewLen = sNew.Length;  // length of sNew
            int sOldLen = sOld.Length;  // length of sOld
            int sNewIdx; // iterates through sNew
            int sOldIdx; // iterates through sOld
            char sNew_i; // ith character of sNew
            char sOld_j; // jth character of sOld
            int cost; // cost

            /// Test string length
            if (Math.Max(sNew.Length, sOld.Length) > Math.Pow(2, 31))
                throw (new Exception("\nMaximum string length in Levenshtein.LD is " + Math.Pow(2, 31) + ".\nYours is " + Math.Max(sNew.Length, sOld.Length) + "."));

            // Step 1

            if (sNewLen == 0)
            {
                return sOldLen;
            }

            if (sOldLen == 0)
            {
                return sNewLen;
            }

            matrix = new int[sNewLen + 1, sOldLen + 1];

            // Step 2

            for (sNewIdx = 0; sNewIdx <= sNewLen; sNewIdx++)
            {
                matrix[sNewIdx, 0] = sNewIdx;
            }

            for (sOldIdx = 0; sOldIdx <= sOldLen; sOldIdx++)
            {
                matrix[0, sOldIdx] = sOldIdx;
            }

            // Step 3

            for (sNewIdx = 1; sNewIdx <= sNewLen; sNewIdx++)
            {
                sNew_i = sNew[sNewIdx - 1];

                // Step 4

                for (sOldIdx = 1; sOldIdx <= sOldLen; sOldIdx++)
                {
                    sOld_j = sOld[sOldIdx - 1];

                    // Step 5

                    if (sNew_i == sOld_j)
                    {
                        cost = 0;
                    }
                    else
                    {
                        cost = 1;
                    }

                    // Step 6

                    matrix[sNewIdx, sOldIdx] = Minimum(matrix[sNewIdx - 1, sOldIdx] + 1, matrix[sNewIdx, sOldIdx - 1] + 1, matrix[sNewIdx - 1, sOldIdx - 1] + cost);

                }
            }

            // Step 7

            /// Value between 0 - 100
            /// 0==perfect match 100==totaly different
            System.Console.WriteLine("Dist=" + matrix[sNewLen, sOldLen]);
            int max = System.Math.Max(sNewLen, sOldLen);
            return (100 * matrix[sNewLen, sOldLen]) / max;
        }
    }


}


