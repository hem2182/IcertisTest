using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
/* Don't change anything here.
 * Do not add any other imports. You need to write
 * this program using only these libraries 
 */

namespace IcertisTest
{
    class s
    {
        public int I;
    }
    public class Program
    {
        /* You may add helper classes here if necessary */
        static void Main(string[] args)
        {
            //try
            //{
            //    String line;
            //    var inputLines = new List<String>();
            //    while ((line = Console.ReadLine()) != null)
            //    {
            //        line = line.Trim();
            //        if (line != "")
            //            inputLines.Add(line);
            //    }
            //    var retVal = processData(inputLines);
            //    foreach (var res in retVal)
            //        Console.WriteLine(res);
            //}
            //catch (IOException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //var a = f2();
        }

        //static void f1(ref String s1, out String s2)
        //{
        //    s1 += "0";
        //    s2 = "45";
        //}
        //static String f2()
        //{
        //    String s1 = "42", s2;
        //    f1(ref s1, out s2);
        //    return s1 + s2;
        //}

        //static void f2()
        //{
        //    try
        //    {
        //        int[] array = new int[3];
        //        array[3] = 3;
        //        Console.Write("A");
        //    }
        //    catch (IndexOutOfRangeException)
        //    {
        //        Console.Write("B");
        //    }
        //    Console.Write("C");
        //}

        //static void f1(ref String s1, String s2)
        //{
        //    s1 += "0";
        //    s2 += "0";
        //}
        //static String f2()
        //{
        //    String s1 = "42", s2 = "43";
        //    f1(ref s1, s2);
        //    return s1 + s2;
        //}

        //static int f2()
        //{
        //    String s = "Hello\0world";
        //    return s.Length;
        //}

        //static String f2()
        //{
        //    String s1 = "42", s2 = "43";
        //    f1(out s1, ref s2);
        //    return s1 + s2;
        //}

        //static void f1(out String s1, ref String s2)
        //{
        //    s1 += "0";
        //    s2 += "0";
        //}



        public static List<String> processData(IEnumerable<string> lines)
        {
            /* 
             * Do not make any changes outside this method.
             *
             * Modify this method to process `array` as indicated
             * in the question. At the end, return a List containing
             * the appropriate values
             *
             * Do not print anything in this method
             *
             * Submit this entire program (not just this function)
             * as your answer
             */
            List<String> retVal = new List<String>();


            Dictionary<string, string> mappings = new Dictionary<string, string>();
            List<string> distinctProducts = new List<string>();

            foreach (var item in lines)
            {
                var splittedItems = item.Split(',');
                var key = splittedItems[1];
                var value = splittedItems[2];

                //Adding Distinct Products
                if (!distinctProducts.Contains(splittedItems[0]))
                {
                    distinctProducts.Add(splittedItems[0]);
                }

                // Creating mapping for library and its latest version
                if (mappings.Keys.Contains(key))
                {
                    var existingMapping = mappings.Where(x => x.Key == key).FirstOrDefault();
                    var versionValue = existingMapping.Value;
                    var versionNumber = int.Parse(versionValue.Substring(2));
                    var itemVersionNumber = int.Parse(value.Substring(2));
                    if (itemVersionNumber > versionNumber)
                    {
                        mappings[key] = value;
                    }
                }
                else
                {
                    mappings.Add(splittedItems[1], splittedItems[2]);
                }
            }

            foreach (var product in distinctProducts)
            {
                var productInputLines = lines.Where(x => x.Contains(product)).ToList();
                productInputLines.ForEach(x => {
                    var splitted = x.Split(',');
                    var latestVersionValue = mappings[splitted[1]];
                    if (latestVersionValue == splitted[2] && !retVal.Contains(product)) {
                        retVal.Add(product);
                    }

                });
            }

            
            return retVal;
        }
    }
}
