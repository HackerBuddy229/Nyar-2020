using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Extensions.Canvas.Canvas2D;
using Nyar.Shared.interfaces.entities;

namespace Nyar.Shared
{
    public class Body : IFireworkBody
    {
        private readonly string _color;

        public Body(int x, int y, string color, TimeSpan timeUntilDeath, int? speed = null)
        {
            InitialX = x;
            InitialY = y;

            CurrentX = x;
            CurrentY = y;

            VelocityY = speed ?? 5; //default

            _color = color;

            DisappearingAt = DateTime.UtcNow + timeUntilDeath;
        }

        public string Id { get; } = Guid.NewGuid().ToString();

        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public DateTime DisappearingAt { get; set; }


        public int InitialX { get; }
        public int InitialY { get; }

        public int CurrentX { get; private set; }
        public int CurrentY { get; private set; }

        public void MoveX(double distance)
        {
            CurrentX = distance + CurrentX >= 0 ? (int)(CurrentX + distance) : 0;
        }

        public void MoveY(double distance)
        {
            CurrentY = distance + CurrentY >= 0 ? (int)(CurrentY + distance) : 0;
        }

        public double VelocityX { get; private set; }
        public double VelocityY { get; private set; }

        public void AccelerateX(double amount)
        {
            VelocityX += amount;
        }

        public void AccelerateY(double amount)
        {
            VelocityY += amount;
        }

        public async Task Update(Canvas2DContext context)
        {
            //check do render
            if (!DoRender)
                return;

            //check weather to dissepear
            if (DateTime.UtcNow >= DisappearingAt)
            {
                DoRender = false;
                return;
            }

            //render
            await context.SetFillStyleAsync(_color);
            await context.FillRectAsync(CurrentX, CurrentY, Width, Height);


            //update object
            MoveY(VelocityY);
            MoveX(VelocityX);

        }

        public int Priority { get; } = 1;

        public bool DoRender { get; private set; } = true;

        public int Width { get; set; } = 25;
        public int Height { get; set; } = 25;
    }
}
