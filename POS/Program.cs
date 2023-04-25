using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System;

namespace DictionaryDemonstration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int[]> dic = new Dictionary<string, int[]>();
            List<string> list = new List<string>();
            string[] Totes = new string[] { };
            string line = "";
            Dictionary<string, int[]> Orders = new Dictionary<string, int[]>();
            bool cont = true;
            
            using(StreamReader sr = new StreamReader("menu.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    int[] val = new int[2];
                    Totes = line.Split(",");
                    val[0] = int.Parse(Totes[1]);
                    val[1] = int.Parse(Totes[2]);
                    dic.Add(Totes[0], val);                  
                }
            }
            int count = 1;
            Console.WriteLine("Here is the menu. just type the meal you want! type END to stop ordering!");
            foreach (KeyValuePair < string,int[]> kvp in dic)
            {
                Console.Write(count + "\t");
                Console.Write(kvp.Key + "\t");
                Console.Write(" = " + kvp.Value[1]);
                count++;
                Console.WriteLine();
            }
            while(cont)
            {
                string input = (Console.ReadLine());
                input.ToUpper();
                if(dic.ContainsKey(input))
                {
                    if(Orders.ContainsKey(input))
                    {
                        int[] temp = new int[2];
                        temp = Orders[input];
                        int[] temp2 = new int[2];
                        temp2 = dic[input];
                        for (int i = 0; i < 2; i++)
                        {                           
                            if (i == 0)
                            {
                                temp[i]++;
                            }
                            else if (i == 1)
                            {
                                int price = temp2[i];
                                temp[i] += price;
                            }
                            
                        }
                        Orders[input] = temp;
                    }
                    else
                    {
                        Orders[input] = dic[input];
                    }                   
                }
                else if (input == "END")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("That is not a valid product");
                }
                foreach(KeyValuePair<string, int[]> kpp in Orders)
                {
                    Console.Write(kpp.Key + "\t");
                    for (int k = 0; k < 2; k++)
                    {
                        Console.Write(kpp.Value[k] + "\t");
                    }
                }
            }
            Console.ReadKey();
        }
    }
}