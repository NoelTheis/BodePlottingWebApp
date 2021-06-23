using BodePlotting.Drawing.Canvas;
using BodePlotting.Drawing.MyMath;
using System;

namespace BodePlotting.Drawing.Charts.Logarithmic
{
    /// <summary>
    /// Defines a logarithmic partition in a chart.
    /// </summary>
    /// <remarks>
    /// This class helps to find the positions of the separation lines <br/>
    /// within the partition by calculating them logarithmicly: <br/>
    /// Xn = Log10(n) * Length
    /// </remarks>
    internal class LogarithmicPartition : BaseGraphicalElement
    {
        private int numberOfHorizontalSeparationLines;
        private int numberOfVerticalSeparationLines;

        public int NumberOfHorizontalSeparationLines 
        { 
            get { return numberOfHorizontalSeparationLines; }
            set
            {
                if(value != numberOfHorizontalSeparationLines)
                {
                    numberOfHorizontalSeparationLines = Math.Max(0, value);
                    PositionsOfHorziontalSeparationLines
                        = CalculatePositionsOfSeparationLines(
                            NumberOfHorizontalSeparationLines,
                            Width);
                }              
            }
        }
        public int NumberOfVerticalSeparationLines
        {
            get { return numberOfVerticalSeparationLines; }
            set
            {
                if(value != numberOfVerticalSeparationLines)
                {
                    numberOfVerticalSeparationLines = Math.Max(0, value);
                    PositionsOfVerticalSeparationLines
                        = CalculatePositionsOfSeparationLines(
                            NumberOfVerticalSeparationLines,
                            Height);
                }
            }
        }

        public double[] PositionsOfHorziontalSeparationLines 
        { 
            get; 
            private set; 
        }
        public double[] PositionsOfVerticalSeparationLines
        {
            get;
            private set;
        }

        public LogarithmicPartition(
            ICanvas canvas,
            Vector position,
            double width,
            double height,
            int numberOfHorizontalSeparationLines,
            int numberOfVerticalSeparationLines
            ) 
            :base(canvas, position, width, height)
        {
            NumberOfHorizontalSeparationLines = numberOfHorizontalSeparationLines;
            NumberOfVerticalSeparationLines = numberOfVerticalSeparationLines;
        }

        private double[] CalculatePositionsOfSeparationLines(
            int numberOfSeparationLines,
            double length)
        {
            double[] positions = new double[numberOfSeparationLines];
            for (int i = 0; i < NumberOfHorizontalSeparationLines; i++)
            {
                // I´m using Log(i + 2) here since for example the first 
                // serapation line marks the position:
                // 2 * start value of the partition
                // or in other words:
                // start value + Log(2) * length
                positions[i] = Math.Log10(i + 2) * length;
            }
            return positions;
        }

        public void DrawSeparationLines()
        {
            DrawHorizontalSeparationLines();
            DrawVerticalSeparationLines();
        }
        private void DrawHorizontalSeparationLines()
        {
            for (int i = 0; i < NumberOfHorizontalSeparationLines; i++)
            {
                double xPosition =
                    PositionsOfHorziontalSeparationLines[i] + Position.X;
                Canvas.PlotLine(
                    new(xPosition, BottomBorder),
                    new(xPosition, TopBorder));
            }
        }
        private void DrawVerticalSeparationLines()
        {
            for (int i = 0; i < NumberOfVerticalSeparationLines; i++)
            {
                double yPosition 
                    = PositionsOfVerticalSeparationLines[i] + Position.Y;
                Canvas.PlotLine(
                    new(LeftBorder, yPosition),
                    new(RightBorder, yPosition));
            }
        }
    }
}
