using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockAI
{
    class Program
    {
        // array indexes are by days 1 - 5 (old -> recent)
        static double[] high = new double[] { 304.18, 302.53, 297.88, 286, 278.41 };
        static double[] low = new double[] { 289.23, 286.13, 286.50, 272.96, 256.37 };

        static void Main(string[] args)
        {
            Console.WriteLine("Stock high values by old to recent: ");
            foreach (var i in high)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine("\n");
            Console.WriteLine("Stock low values by old to recent: ");
            foreach (var i in low)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine("\n\n");
            Console.WriteLine("The average rate of change between day 1 and day 2: " + GetRateofChange(high, low, 0, 1));
            Console.WriteLine("The net change between day 1 and day 2: " + GetNetChange(high, low, 0) / GetNetChange(high, low, 1));

            Console.WriteLine("");
            Console.WriteLine("Peak values: ");
            foreach (var i in GetPeaks(Utils.CombineValuesByIterations(high, low, 5), 5))
            {
                Console.Write(i + " ");
            }

            Console.WriteLine("\n");
            Console.WriteLine("Valley values: ");
            foreach (var i in GetValleys(Utils.CombineValuesByIterations(high, low, 5), 5))
            {
                Console.Write(i + " ");
            }
            Console.ReadLine();
        }

        // Gets the rate of change from two different input arrays
        static double GetRateofChange(double[] arr1, double[] arr2, int index1, int index2)
        {
            return (arr1[index1] - arr2[index1]) / (arr1[index2] - arr2[index2]);
        }

        // Gets the net change from two different input arrays
        static double GetNetChange(double[] arr1, double[] arr2, int index)
        {
            return (arr1[index] - arr2[index]) / arr2[index];
        }

        // Get the highest amount of values from a input array
        static double[] GetPeaks(double[] arr, int amount)
        {
            double[] vals = new double[amount];
            for (int i = 0; i < amount; i++)
            {
                vals[i] = Utils.GetHighestValue(arr);
                arr = Utils.RemoveValue(arr, Utils.GetHighestValue(arr));
            }
            return vals;
        }

        // Get the lowest amount of values from a input array
        static double[] GetValleys(double[] arr, int amount)
        {
            double[] vals = new double[amount];
            for (int i = 0; i < amount; i++)
            {
                vals[i] = Utils.GetLowestValue(arr);
                arr = Utils.RemoveValue(arr, Utils.GetLowestValue(arr));
            }
            return vals;
        }
    }
}
