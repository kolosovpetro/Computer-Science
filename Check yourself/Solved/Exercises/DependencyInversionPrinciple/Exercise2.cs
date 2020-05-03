// TODO: NotifierModule has poor structural design. Fix it.

namespace Exercises.DependencyInversionPrinciple
{
    using Exercises.Dependencies;

    public class NotifierModule : INotifieable
    {
        private readonly Logger _logger;
        private readonly Email _email;

        public NotifierModule()
        {
            _logger = new Logger();
            _email = new Email();
        }
        public void Notify()
        {
            _logger.Log("OK");
            _email.Send("john@doe.com", "OK");
        }
    }

    public class E2
    {
        public void Init()
        {
            IFactoriable factory = new ModuleFactory();
            INotifieable module = factory.Create<NotifierModule>();
            module.Notify();
        }
    }
}
