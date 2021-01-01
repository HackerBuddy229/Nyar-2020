using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyar.Shared.interfaces
{
    public interface IPositioned
    {
        public int InitialX { get; }
        public int InitialY { get; }

        public int CurrentX { get; }
        public int CurrentY { get; }

        public void MoveX(double distance);

        public void MoveY(double distance);
    }
}
