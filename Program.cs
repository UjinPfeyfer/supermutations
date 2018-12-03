using System;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static List<string> mainList = new List<string>();
        static void Main(string[] args)
        {

            List<int> mas = new List<int> { 1, 2, 3, 4, 5, 6 };
            PrintList(mas, "");


            //string sdf = "12345612345162345126345123645132645136245136425136452136451234651234156234152634152364152346152341652341256341253641253461253416253412653412356412354612354162354126354123654132654312645316243516243156243165243162543162453164253146253142653142563142536142531645231465231456231452631452361452316453216453126435126431526431256432156423154623154263154236154231654231564213564215362415362145362154362153462135462134562134652134625134621536421563421653421635421634521634251634215643251643256143256413256431265432165432615342613542613452613425613426513426153246513246531246351246315246312546321546325146325416325461325463124563214563241563245163245613245631246532146532416532461532641532614532615432651436251436521435621435261435216435214635214365124361524361254361245361243561243651423561423516423514623514263514236514326541362541365241356241352641352461352416352413654213654123";
            //while (sdf.Length > 5)
            //{
            //    string s = sdf.Substring(0, 6);
            //    var e = mainList.Remove(s);
            //    sdf = sdf.Remove(0, 1);
            //}
            //Console.WriteLine(mainList.Count);


            string mainString = mainList[0];
            mainList.Remove(mainString);
            foreach (var s in mainList)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();
            int n = mainString.Length;
            while (mainList.Count > 0)
            {
                int k = n - 1;
                while (true)
                {
                    string pattern = mainString.Substring(mainString.Length - k);
                    string qq = IsMainListMatch(pattern);
                    if (qq != null)
                    {
                        mainString += qq.Substring(qq.Length - n + k);
                        mainList.Remove(qq);
                        break;
                    }
                    k--;
                }
            }
            Console.WriteLine(mainString);
            Console.WriteLine(mainString.Length);

        }

        static string IsMainListMatch(string s)
        {
            string str = null;
            Regex reg = new Regex($"^{s}");
            foreach(string st in mainList)
            {
                if (reg.IsMatch(st))
                {
                    str = st;
                    break;
                }
            }
            return str;
        }

        public static void PrintList(List<int> list, string str)
        {

            foreach (int i in list)
            {
                str += i;
                if (list.Count == 1)
                {
                    //Console.Write($"{str} ");
                    mainList.Add(str);
                }
                else
                {
                    List<int> list1 = list.GetRange(0, list.Count);
                    list1.Remove(i);
                    PrintList(list1, str);
                }
                str = str.Remove(str.Length-1);
            }
        }
    }
}

