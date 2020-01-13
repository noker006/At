using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace At
{
    class Gift
    {
        List<Candy> Candies = new List<Candy>();
        List<Fruit> Fruits = new List<Fruit>();
        List<Waffle> Waffles = new List<Waffle>();
        private List<Sweetness> Sweetnesses = new List<Sweetness>();

        public List<Sweetness> SweetnessesList
        {
            get
            {
                return Sweetnesses;
            }
        }


        public Gift()
        {
            Candy candy = new Candy();
            Fruit fruit = new Fruit();
            Waffle waffle = new Waffle();
            string Path = @"C:\!C#\At\Input.txt";
            using (StreamReader stream = new StreamReader(Path, System.Text.Encoding.Default))
            {
                while (!stream.EndOfStream)
                {
                    string Buffer = stream.ReadLine();
                    string[] SweetnessInformation = Buffer.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (SweetnessInformation[0] == "C") { InitializationCandy(SweetnessInformation, candy); candy = new Candy(); }
                    if (SweetnessInformation[0] == "W") { InitializationWaffle(SweetnessInformation, waffle); waffle = new Waffle(); }
                    if (SweetnessInformation[0] == "F") { InitializationFruit(SweetnessInformation, fruit); fruit = new Fruit(); }
                    waffle = new Waffle();
                }
            };
            IsFruit();
        }

        public void OutPut()
        {
            //string Path = @"C:\!C#\At\Output.txt";
            //for (int i = 0; i < Sweetnesses.Count; i++)
            //{
            //    var formatter = new BinaryFormatter();
            //    using (FileStream stream = new FileStream(Path, FileMode.Create))
            //    {
            //        formatter.Serialize(stream, Sweetnesses);
            //    }
            //}
            string Path = @"C:\!C#\At\Output.txt";
            using (StreamWriter stream = new StreamWriter(Path,false, System.Text.Encoding.Default))
            {
                for (int i = 0; i < Sweetnesses.Count; i++)
                {
                    stream.WriteLine(Sweetnesses[i].ReturnString());
                }
                stream.WriteLine("Total weight: " + WeightCalculate());
                stream.WriteLine("Cost: " + Cost());
            };
        } 
        private void InitializationCandy(string[] CandyInformation, Candy candy)
        {
            InitializationSweetness(CandyInformation, candy);
            candy.PercentageCocoa = Convert.ToInt32(CandyInformation[5]);
            candy.Filling = CandyInformation[6];
            //Candies.Add(candy);
            Sweetnesses.Add(candy);
            candy = new Candy();
        }
        private void InitializationWaffle(string[] WaffleInformation, Waffle waffle)
        {
            InitializationSweetness(WaffleInformation, waffle);
            waffle.Taste = WaffleInformation[5];
            waffle.Glaze = Convert.ToBoolean(WaffleInformation[6]);
            //Waffles.Add(waffle);
            Sweetnesses.Add(waffle);
            waffle = new Waffle();

        }
        private void InitializationFruit(string[] FruitInformation, Fruit fruit)
        {
            InitializationSweetness(FruitInformation, fruit);
            fruit.VitaminC = Convert.ToBoolean( FruitInformation[5]);
            fruit.VitaminA = Convert.ToBoolean(FruitInformation[6]);
            Sweetnesses.Add(fruit);
            Fruits.Add(fruit);
            fruit = new Fruit();
        }
        private void InitializationSweetness(string[] SweetnessInformation, Sweetness sweetness)
        {
            sweetness.Name = SweetnessInformation[1];
            sweetness.Weight =Convert.ToDouble(SweetnessInformation[2]);
            sweetness.Caloric =Convert.ToInt32( SweetnessInformation[3]);
            sweetness.PriceFor1kg = Convert.ToDouble(SweetnessInformation[4]);
        }
    
        private void AddFruit()
        {
            Sweetnesses.Add(new Fruit { VitaminA = true, VitaminC = true, Name = "Apple", Caloric = 12, PriceFor1kg = 5000, Weight = 100 });
            Sweetnesses.Add(new Fruit { VitaminA = true, VitaminC = true, Name = "Pineapple", Caloric = 12, PriceFor1kg = 10000, Weight = 200 });
            Fruits.Add(new Fruit { VitaminA = true, VitaminC = true, Name = "Apple", Caloric = 12, PriceFor1kg = 5000, Weight = 100 });
            Fruits.Add(new Fruit { VitaminA = true, VitaminC = true, Name = "Pineapple", Caloric = 12, PriceFor1kg = 10000, Weight = 200 });
        }

        private void IsFruit()
        {
            if (Fruits == null)
            {
                AddFruit();
            }
        }
        
        public double WeightCalculate()
        {
            Candy candy = new Candy();
            double CounterWeight = 0;
            for (int i = 0; i < Sweetnesses.Count; i++)
            {
                CounterWeight += Sweetnesses[i].Weight;
                if (CounterWeight >= 1000)
                {
                    SortMaxWeightSweetness();
                    for (int j = 0; j <Sweetnesses.Count; j++)
                    {

                        if (Sweetnesses[j].GetType() == candy.GetType())
                        {
                            Sweetnesses.Remove(Sweetnesses[j]);
                            i--;
                            break;
                        }
                    }
                }
            }
            return CounterWeight;
        }

        private void SortMaxWeightSweetness()
        {
            ComparerWeightSweetness compar = new ComparerWeightSweetness();
            Sweetnesses.Sort(compar);
        }

        public void SortCaloric()
        {
            ComparerCaloricSweetness comparerCaloric = new ComparerCaloricSweetness();
            Sweetnesses.Sort(comparerCaloric);
        }

        public double Cost()
        {
            double CostCount=0;
            for (int i = 0; i < Sweetnesses.Count; i++)
            {
                CostCount+=(Sweetnesses[i].PriceFor1kg / 1000) * Sweetnesses[i].Weight;
            }
            return CostCount;
        }


    }
}
