using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Extensions.Canvas.Canvas2D;
using Nyar.Shared.interfaces;

namespace Nyar.Shared.items
{
    public class Background : IRendered, ISized
    {
        public Background(int width, int height, string color)
        {
            Width = width;
            Height = height;

            Color = color;
        }


        public async void Update(Canvas2DContext context)
        {
            await context.SetFillStyleAsync(Color);
            await context.FillRectAsync(0, 0, Width, Height);
        }

        public bool DoRender { get; } = true;

        public int Width { get; set; }
        public int Height { get; set; }

        public string Color { get; set; }
    }
}
