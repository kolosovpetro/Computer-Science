// TODO: Following classes have poor structural design. Fix it.

namespace Exercises.SingleResponsabilityPrinciple
{
	using System;
	using Exercises.Dependencies;

	public class Rectangle
    {
        public float CenterX { get; set; }
        public float CenterY { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public void Draw(Canvas canvas)
        {
            var halfWidth = Width * 0.5f;
            var halfHeight = Height * 0.5f;

            var left = CenterX - halfWidth;
            var right = CenterX + halfWidth;
            var top = CenterY + halfHeight;
            var bot = CenterY - halfHeight;

            canvas.DrawLine(left, top, right, top);
            canvas.DrawLine(right, top, right, bot);
            canvas.DrawLine(right, bot, left, bot);
            canvas.DrawLine(left, bot, left, top);
        }
    }

    public class Circle
    {
        public float CenterX { get; set; }
        public float CenterY { get; set; }
        public float Radius { get; set; }

        public void Draw(Canvas canvas)
        {
            const float step = (float)Math.PI * 2 * 0.02f;

            var startX = 0.0f;
            var startY = 0.0f;
            for (var i = 0.0f; i <= (float)Math.PI * 2 + step * 0.5f; i += step)
            {
                var stopX = (float)Math.Cos(i * Radius);
                var stopY = (float)Math.Sin(i * Radius);

                canvas.DrawLine(startX, startY, stopX, stopY);

                startX = stopX;
                startY = stopY;
            }
        }
    }

    public class E1
    {
        public static void Init(Canvas surface)
        {
            var posX = 0.0f;
            var posY = 0.0f;
            for (var i = 0; i < 10; ++i)
            {
                var rect = new Rectangle() { CenterX = posX, CenterY = posY, Width = 50, Height = 50 };
                var circle = new Circle() { CenterX = posX, CenterY = posY, Radius = 50 };
                
                rect.Draw(surface);
                circle.Draw(surface);

                posY += 50;
            }
        }
    }
}
