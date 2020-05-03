// TODO: NotifierService has poor structural design. Fix it.

namespace Exercises.DependencyInversionPrinciple
{
	using Exercises.Dependencies;

	public class NotifierService
    {
        private readonly Logger _logger = new Logger();
        private readonly Email _email = new Email();

        public void Notify()
        {
            _logger.Log("OK");
            _email.Send("john@doe.com", "OK");
        }
    }

    public class E1
    {
        public void Init()
        {
            var notifierService = new NotifierService();
            notifierService.Notify();
        }
    }
}
