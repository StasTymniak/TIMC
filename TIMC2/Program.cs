using System;
using System.Collections.Generic;
using System.Linq;

namespace TIMC
{
    class Program
    {
        static void Main(string[] args)
        {

            /*double[] temp = new double[] { 8.2,9.7,5.8 ,7.4, 8.0, 6.4, 6.6, 6.8, 8.4, 7.1, 9.0, 6.9, 7.6, 8.1, 11.7,
5.8, 9.3, 7.3, 8.2, 7.2, 7.2, 6.4, 7.7, 9.0, 8.1, 7.1, 7.1, 8.8, 7.5, 9.2, 7.5 ,6.8,
7.0 ,6.4, 7.4 ,8.2, 6.3, 7.0 ,8.1 ,10.0, 7.0, 7.1, 8.7, 6.3, 8.6, 7.7, 7.3, 8.0 ,8.4,
9.3 ,7.3, 6.0, 7.7, 6.1, 9.6, 7.4, 7.2, 7.2, 8.7, 7.5, 9.1, 6.4, 8.3, 6.5, 8.2 ,7.2,
6.9 ,6.9 ,8.2, 9.0, 7.4, 8.0, 8.4, 7.0, 7.1, 7.4, 6.6, 6.4, 8.3, 7.9, 8.3, 7.2, 7.2,
6.6, 6.6, 7.7, 8.7, 5.8 ,7.5, 5.7, 6.9, 7.4, 7.2, 6.2, 6.9, 6.8, 9.2, 9.2, 7.1 ,6.5 };*/

            double[] temp = new double[] { 8.2,9.7,5.8 ,7.4, 8.0, 6.4, 6.6, 6.8, 8.4, 7.1, 9.0, 6.9, 7.6, 8.1, 11.7,
5.8, 9.3, 7.3, 8.2, 7.2, 7.2, 6.4, 7.7, 9.0, 8.1, 7.1, 7.1, 8.8, 7.5, 9.2, 7.5 ,6.8,
7.0 ,6.4, 7.4 ,8.2, 6.3, 7.0 ,8.1 ,10.0, 7.0, 7.1, 8.7, 6.3, 8.6, 7.7, 7.3, 8.0 ,8.4,
9.3 ,7.3, 6.0, 7.7, 6.1, 9.6, 7.4, 7.2, 7.2, 8.7, 7.5, 9.1, 6.4, 8.3, 6.5, 8.2 ,7.2,
6.9 ,6.9 ,8.2, 9.0, 7.4, 8.0, 8.4, 7.0, 7.1, 7.4, 6.6, 6.4, 8.3, 7.9, 8.3, 7.2, 7.2,
6.6, 6.6, 7.7, 8.7, 5.8 ,7.5, 5.7, 6.9, 7.4, 7.2, 6.2, 6.9, 6.8, 9.2, 9.2, 7.1 ,6.5 };

            List<double> sorted_temp = new List<double>();
            for (int i = 0; i < temp.Length; i++)
            {
                sorted_temp.Add(temp[i]);
            }
            sorted_temp.Sort();
            for (int i = 0; i < temp.Length; i++)
            {
                Console.Write($"{sorted_temp[i]}, ");
            }
            Console.WriteLine();
            List<dynamic> itemsArray = new List<dynamic>();
            List<double> arrayX = new List<double>();
            List<double> arrayM = new List<double>();
            List<double> arrayW = new List<double>();


            IEnumerable<dynamic> result = from c in temp
                                          group c by c;


            result = temp.GroupBy(c => c).Where(grp => grp.Count() > 0).Select(grp => new { Key = grp.Key, Count = grp.Count() });


            foreach (dynamic item in result)
            {
                //Console.WriteLine(string.Format("key: {0}, count: {1}", item.Key, item.Count));
                itemsArray.Add(item);
            }



            for (int i = 0; i < itemsArray.Count(); i++)
            {

                arrayM.Add(itemsArray[i].Key);
            }

            arrayM.Sort();
            for (int i = 0; i < arrayM.Count; i++)
            {
                for (int j = 0; j < itemsArray.Count; j++)
                {
                    if (arrayM[i] == itemsArray[j].Key)
                    {
                        arrayX.Add(itemsArray[j].Count);

                    }
                }
            }
            Console.Write("\nX|");
            for (int i = 0; i < itemsArray.Count(); i++)
            {
                // Console.WriteLine($"Goals:{goalsArray[i]} Frequency: {goalsFrequency[i]}");
                Console.Write($"{arrayM[i]}|");
            }

            double count = 0;
            Console.Write("\nMi|");
            for (int i = 0; i < itemsArray.Count(); i++)
            {

                Console.Write($"{arrayX[i]}|");
                count += arrayX[i];
            }
            Console.WriteLine($"\nN: {count}");
            

            for (int i = 0; i < itemsArray.Count(); i++)
            {
                double temp_relativeFrequency = (arrayX[i]) / (double)count;
                arrayW.Add(temp_relativeFrequency);
            }
            Console.WriteLine("\nWi");
            for (int i = 0; i < itemsArray.Count(); i++)
            {

                Console.Write($"{arrayW[i]}|");
            }
            double medianIndex = Math.Round(count / 2F);
            double median = 0;
            if ((count % 2) == 0)
            {
                median = (sorted_temp[(int)medianIndex] + sorted_temp[(int)medianIndex + 1]) / 2;
            }
            if ((count % 2) == 1)
            {
                median = sorted_temp[(int)medianIndex + 1];
            }

          /*  double temp_freq = 0;
            Console.WriteLine("F(x)");
            Console.WriteLine($"{temp_freq} , x<={arrayM[0]}");
            Console.WriteLine($"{temp_freq = temp_freq + arrayW[0]}\t{arrayM[0]}<x<={arrayM[1]}");
            Console.WriteLine($"{temp_freq = temp_freq + arrayW[1]}\t{arrayM[1]}<x<={arrayM[2]}");
            Console.WriteLine($"{temp_freq = temp_freq + arrayW[2]}\t{arrayM[2]}<x<={arrayM[3]}");
            Console.WriteLine($"{temp_freq = temp_freq + arrayW[3]}\t{arrayM[3]}<x<={arrayM[4]}");
            Console.WriteLine($"{temp_freq = temp_freq + arrayW[4]}\t{arrayM[4]}<x<={arrayM[5]}");
            Console.WriteLine($"{temp_freq = temp_freq + arrayW[5]}\t{arrayM[5]}<x<={arrayM[6]}");
            Console.WriteLine($"{temp_freq = temp_freq + arrayW[6]}\t{arrayM[6]}<x");*/




            Console.WriteLine($@"
X max: {arrayM.Max()} 
X min: {arrayM.Min()}
Swing: R = {arrayM.Max() - arrayM.Min()}
Moda: Value:{arrayM[arrayX.IndexOf(arrayX.Max())]} Frequency: {arrayX.Max()}
Median:  Value:{median}
");
            double XB = 0;
            for (int i = 0; i < itemsArray.Count; i++)
            {
                XB += (arrayM[i] * arrayX[i]);
            }
            XB = XB / count;

            double variance = 0;

            for (int i = 0; i < itemsArray.Count; i++)
            {
                variance += (Math.Pow((arrayM[i] - XB), 2) * arrayX[i]);
            }
            variance = variance / (double)count;
            double average_statistical_deviation = Math.Sqrt(variance);
            double coef = 100 / 99F;

            double corrected_variance = coef * average_statistical_deviation;
            double px = 0;
            for (int i = 0; i < itemsArray.Count; i++)
            {
                px += (Math.Abs((arrayM[i] - XB)) * arrayX[i]);
            }

            px = px / (double)count;

            double Vpx = (px / XB) * 100;
            double Vs = (average_statistical_deviation / XB) * 100;

            double M1 = 0, M2 = 0, M3 = 0, M4 = 0;
            for (int i = 0; i < itemsArray.Count; i++)
            {
                M1 += arrayM[i] * arrayX[i];
                M2 += Math.Pow(arrayM[i], 2) * arrayX[i];
                M3 += Math.Pow(arrayM[i], 3) * arrayX[i];
                M4 += Math.Pow(arrayM[i], 4) * arrayX[i];
            }

            M1 = M1 / count;
            M2 = M2 / count;
            M3 = M3 / count;
            M4 = M4 / count;

            double µ3 = 0;
            double µ4 = 0;
            µ3 = M3 - 2 * M2 * M1 + 2 * Math.Pow(M1, 2);
            µ4 = M4 - (4 * M3 * M1) + (6 * M2 * Math.Pow(M1, 2)) - (3 * Math.Pow(M1, 4));

            double asymmetry = 0, excess = 0;
            asymmetry = µ3 / (Math.Pow(average_statistical_deviation, 3));
            excess = (µ4 / (Math.Pow(average_statistical_deviation, 4))) - 3;
            Console.WriteLine($@"
The arithmetic mean of the sample:{XB}
Statistical variance: {variance}
The average statistical deviation: {average_statistical_deviation}
Corrected variance: {corrected_variance}
Average linear deviation: {px}
Coefficient of variation on the average linear deviation: {Vpx}%
Coefficient of variation over the standard deviation: {Vs}%
The initial statistical moment of the sampling of the s-th order: M1 = {M1} M2 = {M2} M3 = {M3} M4 = {M4} 
Central statistical point s-th order: µ0 = 1 µ1 = 0 µ2 = {variance} µ3 = {µ3} µ4 = {µ4} 
Asymmetry : {asymmetry}
Excess: {excess}
");

            Console.ReadKey();

        }

    }
}


