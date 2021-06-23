using BodePlotting.Drawing.Canvas;
using BodePlotting.Drawing.MyMath;
using System;

namespace BodePlotting.Drawing.Charts.Logarithmic
{
    /// <summary>
    /// Encapsulates a logarithmic chart.
    /// </summary>
    /// <remarks>
    /// Chart element of a <see cref="LabeledLogarithmicChart"/>.
    /// </remarks>
    public class LogarithmicChart : BaseGraphicalElement
    {
        #region public properties
        public int NumberOfCollumns { get; set; }
        public int NumberOfRows { get; set; }
        public int HorizontalFactor { get; set; }
        public int VerticalFactor { get; set; }
        public int HighlightEveryNRow { get; set; } = 1;
        public int HighlightEveryNCollumn { get; set; } = 1;
        #endregion

        public LogarithmicChart(
            ICanvas canvas,
            Vector position, 
            double width,
            double height,
            int numberOfRows,
            int numberOfCollumns,
            int horizontalFactor,
            int verticalFactor) 
            : base(canvas, position, width, height)
        {
            NumberOfRows = numberOfRows;
            NumberOfCollumns = numberOfCollumns;
            HorizontalFactor = horizontalFactor;
            VerticalFactor = verticalFactor;
        }

        #region drawing methods
        public void Draw()
        {
            DrawRows();
            DrawCollumns();        
        }
        private void DrawRows()
        {
            
            double rowHeight = Height / NumberOfRows;
            LogarithmicPartition partition = new(VerticalFactor, rowHeight);
            double[] distances = partition.GetSeparationLineDistances();

            double yPos = BottomBorder;
            for(int i = 0; i < NumberOfRows; i++)
            {
                if (i % HighlightEveryNRow == 0)
                    Highlight(() => { DrawRowLine(yPos); });
                else
                    DrawRowLine(yPos);

                DrawVerticalSeparationLines(yPos, distances);
                yPos -= rowHeight;
            }

            if (NumberOfRows % HighlightEveryNRow == 0)
                Highlight(() => { DrawRowLine(yPos); });
            else
                DrawRowLine(yPos);
        }
        private void DrawCollumns()
        {
            double collumWidth = Width / NumberOfCollumns;
            LogarithmicPartition partition = new(HorizontalFactor, collumWidth);
            double[] distances = partition.GetSeparationLineDistances();

            double xPos = LeftBorder;
            for (int i = 0; i < NumberOfCollumns; i++)
            {
                if (i % HighlightEveryNCollumn == 0)
                    Highlight(() => { DrawCollumnLine(xPos); });
                else
                    DrawCollumnLine(xPos);

                DrawHorizontalSeparationLines(xPos, distances);
                xPos += collumWidth;
            }
            if (NumberOfCollumns % HighlightEveryNCollumn == 0)
                Highlight(() => { DrawCollumnLine(xPos); });
            else
                DrawCollumnLine(xPos);

        }
        private void DrawRowLine(double yPos)
        {
            Canvas.PlotLine(
                new(LeftBorder, yPos),
                new(RightBorder, yPos)
                );
        }
        private void DrawCollumnLine(double xPos)
        {
            Canvas.PlotLine(
                new(xPos, TopBorder),
                new(xPos, BottomBorder)
                );
        }
        private void DrawHorizontalSeparationLines(
            double xPos,
            double[] distances)
        {
            foreach (double distance in distances)
                DrawCollumnLine(xPos + distance);
        }
        private void DrawVerticalSeparationLines(
            double yPos,
            double[] distances)
        {
            foreach (double distance in distances)
                DrawRowLine(yPos - distance);
        }
        #endregion
    }
}
