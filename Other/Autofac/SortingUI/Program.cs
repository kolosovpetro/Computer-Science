using Autofac;
using IDLibrary.Implementations;
using IDLibrary.Interfaces;

namespace SortingUI
{
    internal static class Program
    {
        private static IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>();
            builder.RegisterType<InsertionSort>().As<ISortMethod>();
            return builder.Build();
        }


        private static void Main()
        {
            CompositionRoot().Resolve<Application>().Execute();
        }
    }
}