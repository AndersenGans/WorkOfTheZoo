using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelFactory;

namespace Controll_of_the_Zoo
{
    public class WorkOfZoo
    {
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
                        AddAnimal();
                        break;
                    case "feed":
                        FeedAnimal();
                        break;
                    case "cure":
                        CureAnimal();
                        break;
                    case "delete":
                        DeleteAnimal();
                        break;
                    case "run":RunZoo();
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

        public void FeedAnimal(Animal animal)
        {
            
        }

        public void CureAnimal()
        {
            
        }

        public void DeleteAnimal()
        {
            
        }

        public void RunZoo()
        {
            
        }

        public void CloseZoo()
        {
            
        }

    }
}
