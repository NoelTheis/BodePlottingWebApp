using System;

namespace BodePlotting.Drawing.Charts.Logarithmic
{
    public class LogarithmicPartition
    {
        public int Factor { get; }
        public double Length { get; }

        public LogarithmicPartition(int factor, double length)
        {
            Factor = factor;
            Length = length;
        }

        public double[] GetSeparationLineDistances()
        {
            int numberOfLines = Math.Max(0, Factor - 2);
            double[] distances = new double[numberOfLines];

            for (int i = 0; i < numberOfLines; i++)
            {
                distances[i] = Math.Log(i + 2) / Math.Log(Factor) * Length;
            }

            return distances;
        }
    }
}
