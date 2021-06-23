using BodePlotting.Drawing.MyMath;
using System.Drawing;

namespace BodePlotting.Drawing.Charts.Logarithmic
{
    internal class LabeledLogarithmicChart
    {
        /// <summary>
        /// Total position in the graphical environment (top left corner).<br/>
        /// </summary>
        public Vector Position { get; }
        /// <summary>
        /// Size of the whole graphical element including the graph<br/>
        /// , labeling of the axis and related margins.
        /// </summary>
        public Size Size { get; }

        public LogarithmicChart Chart { get; }
    }
}
