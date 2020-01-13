using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;



namespace At
{
    class programm
    {
        static void Main(string[] args)
        {
          Gift gift = new Gift();
            int Choice = 1;
            while (Choice != 0)
            {
                Console.WriteLine("Enter your choice: ");
                Console.WriteLine("1-Calculate Weight");
                Console.WriteLine("2-Sort Caloric");
                Console.WriteLine("3-Calculate Cost");
                Console.WriteLine("4-Output");
                Choice = Convert.ToInt32(Console.ReadLine());
                switch (Choice)
                {
                    case 1:
                        {
                            Console.Clear();
                            for (int i = 0; i < gift.SweetnessesList.Count; i++)
                            {
                                Console.WriteLine($"\n{gift.SweetnessesList[i].ReturnString()}");
                            }
                            double Weight = gift.WeightCalculate();
                            Console.WriteLine($"Weght = {Weight}");
                            break;
                        }

                    case 2:
                        {
                            Console.Clear();
                            gift.SortCaloric();
                            for (int i = 0; i <gift.SweetnessesList.Count; i++)
                            {
                              Console.WriteLine($"\n{gift.SweetnessesList[i].ReturnString()}");
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            for (int i = 0; i < gift.SweetnessesList.Count; i++)
                            {
                                Console.WriteLine($"\n{gift.SweetnessesList[i].ReturnString()}");
                            }
                            Console.WriteLine($"\n{gift.Cost()}");
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            gift.OutPut();
                            for (int i = 0; i < gift.SweetnessesList.Count; i++)
                            {
                                Console.WriteLine($"\n{gift.SweetnessesList[i].ReturnString()}");
                            }
                            break;
                        }
                }
            }



        }
    }
}
