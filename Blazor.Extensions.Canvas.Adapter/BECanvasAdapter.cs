using Blazor.Extensions.Canvas.Canvas2D;
using BodePlotting.Drawing.Canvas;
using BodePlotting.Drawing.MyMath;

namespace Blazor.Extensions.Canvas.Adapter
{
    public class BECanvasAdapter : ICanvas
    {
        Canvas2DContext Context { get; }

        public BECanvasAdapter(Canvas2DContext context)
        {
            Context = context;
        }

        public async void PlotLine(Vector start, Vector end)
        {
            await Context.BeginPathAsync();
            await Context.MoveToAsync(start.X, start.Y);
            await Context.LineToAsync(end.X, end.Y);
            await Context.StrokeAsync();
        }

        public async void PlotRectangle(
            Vector position, 
            double width, 
            double height)
        {
            await Context.StrokeRectAsync(
                position.X,
                position.Y,
                width,
                height);
        }

        public async void SetLineWidth(double value)
        {
            await Context.SetLineWidthAsync((float)value);
        }

        public double GetLineWidth()
        {
            return Context.LineWidth;
        }
    }
}
