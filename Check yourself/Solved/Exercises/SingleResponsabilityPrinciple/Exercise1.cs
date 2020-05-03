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
    }

    public class RectDrawer
    {
        public Rectangle Rect { get; private set; }
        public Canvas Canv { get; private set; }

        public RectDrawer(Rectangle rect, Canvas canv)
        {
            Rect = rect;
            Canv = canv;
        }

        public void Draw()
        {
            float halfWidth = Rect.Width * 0.5f;
            float halfHeight = Rect.Height * 0.5f;

            float left = Rect.CenterX - halfWidth;
            float right = Rect.CenterX + halfWidth;
            float top = Rect.CenterY + halfHeight;
            float bot = Rect.CenterY - halfHeight;

            // drawning - breaking of SRP
            Canv.DrawLine(left, top, right, top);
            Canv.DrawLine(right, top, right, bot);
            Canv.DrawLine(right, bot, left, bot);
            Canv.DrawLine(left, bot, left, top);
        }
    }

    public class Circle
    {
        public float CenterX { get; set; }
        public float CenterY { get; set; }
        public float Radius { get; set; }
    }

    public class CircleDrawer
    {
        public Circle Circ { get; private set; }
        public Canvas Canv { get; private set; }

        public CircleDrawer(Circle circ, Canvas canv)
        {
            Circ = circ;
            Canv = canv;
        }

        public void Draw()
        {
            const float step = (float)Math.PI * 2 * 0.02f;

            float startX = 0.0f;
            float startY = 0.0f;
            for (var i = 0.0f; i <= (float)Math.PI * 2 + step * 0.5f; i += step)
            {
                float stopX = (float)Math.Cos(i * Circ.Radius);
                float stopY = (float)Math.Sin(i * Circ.Radius);

                Canv.DrawLine(startX, startY, stopX, stopY);

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
                var rectDrawer = new RectDrawer(rect, surface);
                var circle = new Circle() { CenterX = posX, CenterY = posY, Radius = 50 };
                var circDrawer = new CircleDrawer(circle, surface);

                rectDrawer.Draw();
                circDrawer.Draw();

                posY += 50;
            }
        }
    }
}
