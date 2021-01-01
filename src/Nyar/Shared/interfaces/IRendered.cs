using Blazor.Extensions.Canvas.Canvas2D;

namespace Nyar.Shared.interfaces
{
    public interface IRendered
    {
        public void Update(Canvas2DContext context);

        public bool DoRender { get; }
    }
}
