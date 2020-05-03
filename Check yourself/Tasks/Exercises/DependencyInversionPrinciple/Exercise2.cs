// TODO: NotifierModule has poor structural design. Fix it.

namespace Exercises.DependencyInversionPrinciple
{
	using Exercises.Dependencies;

	public class NotifierModule
  {
        private readonly Logger _logger = new Logger();
        private readonly Email _email = new Email();

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
          var factory = new ModuleFactory();
          var module = factory.Create<NotifierModule>();

          module.Notify();
      }
  }
}
