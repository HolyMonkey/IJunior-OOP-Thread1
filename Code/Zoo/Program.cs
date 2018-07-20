using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal[] animals = new Animal[] 
            {

            };
        }

        public void Preview(Animal animal)
        {
            Console.ForegroundColor = animal.Color;
            Console.WriteLine(animal.Name);
        }
    }

    class Animal
    {
        public string Name;
        public ConsoleColor Color;

        public Animal(string name, ConsoleColor color)
        {
            Name = name;
            Color = color;
        }

        public void Action()
        {
            Console.WriteLine("Оглянулось на вас");
        }
    }

    class Cat : Animal
    {
        public int WindSpeed;

        public Cat(string name, ConsoleColor color) : base(name, color)
        {

        }

        public new void Action()
        {
            Console.WriteLine("Мяучит");
        }
    }

    class Dog : Animal
    {
        public int RunSpeed;

        public Dog(string name, ConsoleColor color) : base(name, color)
        { 
        }

        public new void Action()
        {
            Console.WriteLine("Гавкать");
        }
    }
}
