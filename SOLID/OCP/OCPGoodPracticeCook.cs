namespace SOLID.OCP
{
    class OcpGoodPracticeCook
    {
        public string Name { get; set; }
        public IMeal Meal { get; set; }

        public OcpGoodPracticeCook(string name)
        {
            Name = name;
        }

        public void MakeDinner()      // now we can extend cook's functionality under IMeal
        {
            Meal.Cook();
        }
    }
}
