namespace SOLID.OCP
{
    class OCPGoodPracticeCook
    {
        public string Name { get; set; }
        public IMeal Meal { get; set; }

        public OCPGoodPracticeCook(string name)
        {
            Name = name;
        }

        public void MakeDinner()      // now we can extend cook's functionality under IMeal
        {
            Meal.Cook();
        }
    }
}
