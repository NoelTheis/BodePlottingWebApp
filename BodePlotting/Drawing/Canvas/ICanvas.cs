using BodePlotting.Drawing.MyMath;
using System.Drawing;

namespace BodePlotting.Drawing.Canvas
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICanvas
    {
        /// <summary>
        /// 
        /// </summary>
        public void PlotLine(Vector start, Vector end);

        /// <summary>
        /// 
        /// </summary>
        public void PlotRectangle(Vector position, double width, double height);

        /// <summary>
        /// 
        /// </summary>
        public void SetLineWidth(double value);

        /// <summary>
        /// 
        /// </summary>
        public double GetLineWidth();
    }
}
