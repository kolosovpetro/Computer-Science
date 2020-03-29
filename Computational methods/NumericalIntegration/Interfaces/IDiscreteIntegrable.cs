namespace NumericalIntegration.Interfaces
{
    internal interface IDiscreteIntegrable
    {
        double TrapezoidalMethod(int precision);
        double SimpsonMethod(int precision);
    }
}
