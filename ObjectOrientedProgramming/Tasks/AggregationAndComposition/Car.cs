namespace AggregationAndComposition
{
    class Car
    {
        string model = "Porsche";
        Engine engine;

        public Car(string model)
        {
            this.model = model;
            engine = new Engine(360);     // Composition. Engine instance is instanciated inside class Car.
                                          // Can be instanciated by means of methods as well.
        }

        public Car(string model, Engine engine) : this(model)
        {
            this.engine = engine;       // Aggregation. Engine instance is instanciated outside class Car.
                                        // Can be implemented by means of setters as well.
        }
    }
}
