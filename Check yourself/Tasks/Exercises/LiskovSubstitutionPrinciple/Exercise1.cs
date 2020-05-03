// TODO: By using the following classes we're breaking an implicit contract. Fix it.

namespace Exercises.LiskovSubstitutionPrinciple
{
    public interface ISurface
    {
    }

    public class Rectangle : ISurface
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
    }

    public class Square : Rectangle
    {
        public override int Width
        {
            get
            {
                return base.Width;
            }
            set
            {
                base.Height = value;
                base.Width = value;
            }
        }
        public override int Height
        {

            get { return base.Height; }
            set
            {
                base.Height = value;
                base.Width = value;
            }
        }
    }

    public class Disk : ISurface
    {
        public int Radius { get; set; }
    }
}
