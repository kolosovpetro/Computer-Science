using AdapterLibrary.Animal;

namespace AdapterLibrary.Transport
{
    internal class TransportToAnimalAdapter : ITransport
    {
        private readonly IAnimal _animal;

        public TransportToAnimalAdapter(IAnimal animal)
        {
            _animal = animal;
        }

        public string Drive()
        {
            return _animal.Move();
        }
    }
}
