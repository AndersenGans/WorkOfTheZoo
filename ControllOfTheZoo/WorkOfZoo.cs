using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using ModelFactory;

namespace Controll_of_the_Zoo
{
    public class WorkOfZoo
    {
        private static System.Timers.Timer timer;
        public void Working()
        {
            List<Animal> Animals = new List<Animal>();

            Console.WriteLine("Some help for you:");

            while (true)
            {
                Console.Write("Write 'add' to add an animal; \nwrite 'feed' to feed an animal; \n" +
                              "write 'cure' to cure an animal;\nwrite 'delete' to delete an animal.\n" +
                              "To open Zoo write 'run'.\nTo close Zoo write 'close'.\nTo exit write 'exit'.");
                string command = Console.ReadLine();

                switch (command)
                {
                    case "add":
                        Animals.Add(AddAnimal());
                        break;
                    case "feed":
                        FeedAnimal(Animals);
                        break;
                    case "cure":
                        CureAnimal(Animals);
                        break;
                    case "delete":
                        DeleteAnimal(Animals);
                        if (Animals.Count == 0)
                        {
                            Console.WriteLine("All animals died.");
                            return;
                        }
                        break;
                    case "run":RunZoo(Animals);
                        break;
                    case "close":CloseZoo();
                        break;
                    case "exit": return;
                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            }
        }

        public Animal AddAnimal()
        {
            Animal animal = null;

            Console.WriteLine("\nWrite animal name:");
            string nameOfAnimal = Console.ReadLine();
            Console.WriteLine("\nWrite kind of animal (lion,tiger,elephant,bear,wolf,fox):");
            string kindOfAnimal = Console.ReadLine();

            switch (kindOfAnimal)
            {
                case "lion":
                    animal = new Animal(new LionFactory(), nameOfAnimal);
                    break;
                case "tiger":
                    animal = new Animal(new TigerFactory(), nameOfAnimal);
                    break;
                case "elephant":
                    animal = new Animal(new ElephantFactory(), nameOfAnimal);
                    break;
                case "bear":
                    animal = new Animal(new BearFactory(), nameOfAnimal);
                    break;
                case "wolf":
                    animal = new Animal(new WolfFactory(), nameOfAnimal);
                    break;
                case "fox":
                    animal = new Animal(new FoxFactory(), nameOfAnimal);
                    break;
                default:
                    Console.WriteLine("Unknown kind of animal.");
                    break;
            }

            return animal;
        }

        public void FeedAnimal(List<Animal> animals)
        {
            Console.WriteLine("\nWrite animal name:");
            string nameOfAnimal = Console.ReadLine();

            var animal = animals.Find(x => x.AnimalName == nameOfAnimal);
            if (animal != null)
            {
                Console.WriteLine(animal.FeedAnimal(nameOfAnimal));
            }
        }

        public void CureAnimal(List<Animal> animals)
        {
            Console.WriteLine("\nWrite animal name:");
            string nameOfAnimal = Console.ReadLine();

            var animal = animals.Find(x => x.AnimalName == nameOfAnimal);
            if (animal != null)
            {
                Console.WriteLine(animal.CureAnimal(nameOfAnimal));
            }
        }

        public void DeleteAnimal(List<Animal> animals)
        {
            Console.WriteLine("\nWrite animal name:");
            string nameOfAnimal = Console.ReadLine();

            var animal = animals.Find(x => x.AnimalName == nameOfAnimal);
            if (animal != null)
            {
                Console.WriteLine(animal.DeleteAnimal(nameOfAnimal));
                if (animals.Count != 0)
                    animals.Remove(animal);
            }
        }

        public void RunZoo(List<Animal> animals)
        {
            timer = new System.Timers.Timer(5000);
            timer.Elapsed += (sender, args) => ChangeAnimalCondition(animals);
            timer.Start();
        }

        private static void ChangeAnimalCondition(List<Animal> animals)
        {
            if (animals != null)
            {
                Random random = new Random();
                int indexOfAnimal = random.Next(0, animals.Count);
                var animal = animals.ElementAt(indexOfAnimal);
                switch (animal.AnimalCondition)
                {
                    case Animal.Condition.IsFull:
                        animal.AnimalCondition = Animal.Condition.IsHungry;
                        break;
                    case Animal.Condition.IsHungry:
                        animal.AnimalCondition = Animal.Condition.IsIll;
                        animal.CurrentHealth -= 1;
                        break;
                    case Animal.Condition.IsIll:
                        animal.AnimalCondition = Animal.Condition.IsFull;
                        break;
                    default:
                        Console.WriteLine("{1} was dead.", animal.AnimalName);
                        break;
                }
            }
        }

        public void CloseZoo()
        {
            timer.Stop();
            timer.Dispose();
        }

    }
}
