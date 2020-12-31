using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyar.Shared.interfaces
{
    public interface IPositioned
    {
        public int CurrentX { get; }
        public int CurrentY { get; }

        public void MoveX(int distance = 0);

        public void MoveY(int distance = 0);
    }
}
