namespace NumericalIntegration
{
    interface IDiscreteIntegrable
    {
        double TrapezoidalMethod(int Precision);
        double SimpsonMethod(int Precision);
    }
}
