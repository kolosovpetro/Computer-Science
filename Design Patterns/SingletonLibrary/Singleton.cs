using System;

namespace SingletonLibrary
{
    class Singleton
    {
        private static Singleton Instance;          // declare here potential single instance of class
        public DateTime TimeCreated { get; }
        private Singleton() 
        {
            TimeCreated = DateTime.Now;
        }                     
        public static Singleton GetInstance()       // method to get an instance of class
        {
            if (Instance == null)                   // if instance not exist - returns new, otherwise returns existent
                Instance = new Singleton();
            return Instance;
        }

        public string Repeat(string str)            // declare instance method for tests
        {
            return str;
        }

        public int CountLetters(string str)        // declare instance method for tests  
        {
            return str.Length;
        }
    }
}
