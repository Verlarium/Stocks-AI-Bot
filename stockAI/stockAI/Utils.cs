using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockAI
{
    static class Utils
    {
        // gets lowest value from input array
        public static double GetLowestValue(double[] values)
        {
            double val = double.MaxValue;
            foreach (var i in values)
            {
                if (i < val) val = i;
            }
            return val;
        }

        // gets highest value from input array
        public static double GetHighestValue(double[] values)
        {
            double val = double.MinValue;
            foreach (var i in values)
            {
                if (i > val) val = i;
            }
            return val;
        }

        // copies array and removes the input value
        public static double[] RemoveValue(double[] values, double value)
        {
            double[] vals = new double[values.Length - 1];
            int k = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == value)
                {
                    continue;
                }
                vals[k] = values[i];
                k++;
            }
            return vals;
        }

        // copies two input values and concate it together (limited)
        public static double[] CombineValuesByIterations(double[] arr1, double[] arr2, int iterations)
        {
            double[] vals = new double[iterations * 2]; // arrays have to be exactly the same length
            for (int i = 0; i < iterations; i++)
            {
                vals[i] = arr1[i];
                vals[iterations + i] = arr2[i];
            }
            return vals;
        }

        // copies to input values and concate it together
        public static double[] CombineValues(double[] arr1, double[] arr2)
        {
            double[] vals = new double[arr1.Length + arr2.Length];
            for (int i = 0; i < arr1.Length; i++) vals[i] = arr1[i];
            for (int i = 0; i < arr2.Length; i++) vals[arr1.Length + i] = arr2[i];
            return vals;
        }
    }
}
