using System;
using Blazor.Extensions.Canvas.Canvas2D;
using Nyar.Shared.interfaces.entities;

namespace Nyar.Shared
{
    public class Particle : IExplosionParticle
    {
        public Particle(int x, int y, string color, TimeSpan timeUntilDeath, int angle, double speed)
        {
            InitialX = x;
            InitialY = y;

            CurrentX = x;
            CurrentY = y;

            //init speed

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

        private readonly string _color;


        public double VelocityX { get; private set; }
        public double VelocityY { get; private set; }


        public void AccelerateX(double amount)
        {
            VelocityX += amount;
        }

        public void AccelerateY(double amount)
        {
            VelocityX += amount;
        }

        public async void Update(Canvas2DContext context)
        {
            //check do render
            if (!DoRender)
                return;

            //update do render if Disappeared

            if (DateTime.UtcNow > DisappearingAt)
                DoRender = false;

            //render
            await context.SetFillStyleAsync(_color);
            await context.FillRectAsync(CurrentX, CurrentY, Width, Height);

            //update position
            MoveY(VelocityY);

            MoveX(VelocityX);
        }

        public bool DoRender { get; private set; } = true;

        public int Width { get; set; }
        public int Height { get; set; }
    }
}
