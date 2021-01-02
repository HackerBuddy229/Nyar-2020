using System.Threading.Tasks;
using Blazor.Extensions.Canvas.Canvas2D;

namespace Nyar.Shared.interfaces
{
    public interface IRendered
    {
        public Task Update(Canvas2DContext context);

        public int Priority { get; }
        public bool DoRender { get; }
    }
}
