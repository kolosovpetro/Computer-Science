// TODO: NotifierService has poor structural design. Fix it.

namespace Exercises.DependencyInversionPrinciple
{
    using Exercises.Dependencies;

    public interface INotifieable
    {
        void Notify();
    }

    public interface IEable
    {
        void Init(INotifieable newNotifierService);
    }

    public class NotifierService : INotifieable
    {
        private readonly Logger _logger;
        private readonly Email _email;

        public NotifierService()
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

    public class E1 : IEable
    {
        private INotifieable notifierService;

        public void Init(INotifieable newNotifierService)
        {
            notifierService = newNotifierService;
            notifierService.Notify();
        }
    }


}
