using BodePlotting.Drawing.Canvas;
using BodePlotting.Drawing.MyMath;
using System;

namespace BodePlotting.Drawing
{
    public abstract class BaseGraphicalElement
    {
        public ICanvas Canvas { get; }

        public virtual Vector Position { get; set; }

        #region dimensions
        public double Width { get; set; }

        public double Height { get; set; }
        #endregion

        #region borders
        public double TopBorder 
        { 
            get { return Position.Y; } 
        }
        public double BottomBorder 
        { 
            get { return Position.Y + Height; } 
        }
        public double LeftBorder 
        { 
            get { return Position.X; } 
        }
        public double RightBorder 
        { 
            get { return Position.X + Width; } 
        }
        #endregion

        #region corners
        public Vector TopLeftCorner 
        { 
            get { return new(LeftBorder, TopBorder); } 
        }
        public Vector TopRightCorner
        {
            get { return new(RightBorder, TopBorder); }
        }
        public Vector BottomLeftCorner
        {
            get { return new(LeftBorder, BottomBorder); }
        }
        public Vector BottomRightCorner
        {
            get { return new(RightBorder, BottomBorder); }
        }
        #endregion

        #region highlighting
        public Action<Action> Highlight { get; set; }

        private void DoubleLineWidth(Action drawAction)
        {
            double lineWidth = Canvas.GetLineWidth();
            Canvas.SetLineWidth(lineWidth * 2);
            drawAction();
            Canvas.SetLineWidth(lineWidth);
        }
        #endregion

        protected BaseGraphicalElement(
            ICanvas canvas, 
            Vector position, 
            double width, 
            double height)
        {
            Canvas = canvas;
            Position = position;
            Width = width;
            Height = height;
            Highlight = DoubleLineWidth;
        }
        


    }
}
