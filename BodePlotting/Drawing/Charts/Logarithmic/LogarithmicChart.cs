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
        #region fields
        private int numberOfCollumns;
        private int numberOfRows;
        #endregion

        #region private properties
        private LogarithmicPartition RowDefinition { get; } 
        private LogarithmicPartition CollumnDefinition { get; }
        #endregion

        #region public properties
        public int NumberOfCollumns 
        { 
            get
            {
                return numberOfCollumns;
            }
            set
            {
                numberOfCollumns = Math.Max(1, value);
            }
        }
        public int NumberOfRows 
        {
            get
            {
                return numberOfRows;
            }
            set
            {
                numberOfRows = Math.Max(1, value);
            }
        }

        public int SeparationLinesPerCollumn
        {
            get
            {
                return CollumnDefinition.NumberOfHorizontalSeparationLines;
            }
            set
            {
                CollumnDefinition.NumberOfHorizontalSeparationLines = value;
            }
        }

        public int SeparationLinesPerRow
        {
            get
            {
                return RowDefinition.NumberOfHorizontalSeparationLines;
            }
            set
            {
                RowDefinition.NumberOfHorizontalSeparationLines = value;
            }
        }
        #endregion

        public LogarithmicChart(
            ICanvas canvas,
            Vector position, 
            double width,
            double height,
            int numberOfRows,
            int numberOfCollumns,
            int separationLinesPerRow,
            int separationLinesPerCollumn) 
            : base(canvas, position, width, height)
        {
            NumberOfRows = numberOfRows;
            NumberOfCollumns = numberOfCollumns;
            RowDefinition = new(
                canvas,
                position,
                width,
                height / NumberOfRows,
                0,
                separationLinesPerRow);
            CollumnDefinition = new(
                canvas,
                position,
                width / NumberOfCollumns,
                height,
                separationLinesPerCollumn,
                0);
        }

        #region overridden methods 
        protected override void OnWidthChanged()
        {
            if(CollumnDefinition != null)
                CollumnDefinition.Width =
                    Width / NumberOfCollumns;
            if (RowDefinition != null)
                RowDefinition.Width = Width;
            base.OnWidthChanged();
        }
        protected override void OnHeightChanged()
        {

            if (RowDefinition != null)
                RowDefinition.Height
                = Height / NumberOfRows;
            if (CollumnDefinition != null)
                CollumnDefinition.Height = Height;
            base.OnHeightChanged();
        }
        #endregion

        #region drawing methods
        public void Draw()
        {
            DrawCollumns();
            DrawRows();
            //Canvas.PlotLine(BottomLeftCorner, BottomRightCorner);
            //Canvas.PlotLine(BottomRightCorner, TopRightCorner);
        }

        private void DrawCollumns()
        {
            //Reset CollumnPosition
            CollumnDefinition.Position = new(Position.X, Position.Y);           
            for (int i = 0; i < NumberOfCollumns; i++)
            {
                DrawCollumnLine();
                CollumnDefinition.DrawSeparationLines();
                CollumnDefinition.Position.X += CollumnDefinition.Width;
            }
            DrawCollumnLine();
        }

        private void DrawCollumnLine()
        {
            Canvas.PlotLine(
                new(CollumnDefinition.Position.X, CollumnDefinition.BottomBorder),
                new(CollumnDefinition.Position.X, CollumnDefinition.TopBorder));
        }

        private void DrawRows()
        {
            //Reset RowPosition
            RowDefinition.Position = new(Position.X, Position.Y); ;
            for (int i = 0; i < NumberOfRows; i++)
            {
                DrawRowLine();
                RowDefinition.Position.Y += RowDefinition.Height;
            }
            DrawRowLine();
        }

        private void DrawRowLine()
        {
            Canvas.PlotLine(
                new(RowDefinition.LeftBorder, RowDefinition.Position.Y),
                new(RowDefinition.RightBorder, RowDefinition.Position.Y)
                );
        }
        #endregion
    }
}
