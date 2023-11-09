using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //запись в файл
            using (StreamWriter sw = new StreamWriter("result.txt", true))
            {
                //чтение из файла
                using (StreamReader sr = new StreamReader("supplier_b_import.txt", Encoding.UTF8))
                {
                    string line;
                    string[] result = new string[5];
                    while ((line = sr.ReadLine()) != null)
                    {
                        StringBuilder ratingResult = new StringBuilder();
                        string[] array = line.Trim().Split(',');
                        string description = array[0].Trim();
                        string typeofsupplier = array[1].Trim();
                        string INN = array[2].Trim();
                        string rating = array[3].Trim();
                        string date = array[4].Trim();
                        foreach (var item in rating)
                        {
                            if (Char.IsDigit(item))
                            {
                                ratingResult.Append(item);
                            }
                  
                        }
                        DateTime dateResult = Convert.ToDateTime(date);   
                        result[0] = description;
                        result[1] = typeofsupplier;
                        result[2] = INN;
                        result[3] = ratingResult.ToString();
                        result[4] = dateResult.ToString("yyyy\\-MM\\-dd");
                        sw.WriteLine($"{String.Join(",", result)}");
                    }
                }
            }
            Console.ReadKey();
        }
    }
}

