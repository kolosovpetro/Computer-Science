// TODO: Following classes have poor structural design. Fix it.

namespace Exercises.InterfaceSegregationPrinciple
{
	using Exercises.Dependencies;

	public interface IConsumable
    {
        void Consume();
        void Drop();
    }

    public class Potion : IConsumable
    {
        private readonly PotionManager _manager;

        public int Count { get; private set; }

        public Potion(PotionManager manager, int count)
        {
            _manager = manager;
            Count = count;
        }

        public void Consume()
        {
            Count--;
            _manager.Consume();
        }
        public void Drop()
        {
            Count = 0;
        }
    }

    public class Spell : IConsumable
    {
        private readonly SpellManager _manager;

        public int Count { get; private set; }

        public Spell(SpellManager manager, int count)
        {
            _manager = manager;
            Count = count;
        }

        public void Consume()
        {
            Count--;
            _manager.Invoke();
        }
        public void Drop()
        {
        }
    }
}
