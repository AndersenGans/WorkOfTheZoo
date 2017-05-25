﻿using System;
using System.Collections.Generic;
using System.Linq;
using ModelFactory;

namespace Controll_of_the_Zoo
{
    public class WorkOfZoo
    {
        private static System.Timers.Timer timer;

        //метод, ожидающий команды пользователя
        public void Working()
        {
            try
            {
                List<Animal> Animals = new List<Animal>();
                bool areAnimalsAdded = false;

                Console.WriteLine("Some help for you:");
                string helpMessage = "\n\t-write 'add' to add an animal; \n\t-write 'feed' to feed an animal; \n" +
                                     "\t-write 'cure' to cure an animal;\n\t-write 'delete' to delete an animal.\n" +
                                     "\t-to open Zoo write 'run'.\n\t-to close Zoo write 'close'.\n\t-to get help write 'help'." +
                                     "\n\t-to clean console write 'clean'.\n\t-to exit write 'exit'.\n";
                Console.Write(helpMessage);
                while (true)
                {
                    string command = Console.ReadLine();
                    if (IsEveryAnimalsDied(Animals))
                    {
                        Console.WriteLine("All animals died.");
                        Console.ReadKey();
                        return;
                    }
                    //приостановка таймера после ввода комманды, если таймер был запущен
                    if (timer != null)
                    {
                        timer.Stop();
                    }
                    switch (command)
                    {
                        case "add":
                            var animal = AddAnimal();
                            if (animal != null)
                            {
                                Animals.Add(animal);
                                areAnimalsAdded = true;
                            }
                            break;
                        case "feed":
                            FeedAnimal(Animals);
                            break;
                        case "cure":
                            CureAnimal(Animals);
                            break;
                        case "delete":
                            DeleteAnimal(Animals);
                            if (Animals.Count == 0 && areAnimalsAdded)
                            {
                                Console.WriteLine("All animals died.");
                                Console.ReadKey();
                                return;
                            }
                            break;
                        case "run":
                            RunZoo(Animals);
                            break;
                        case "close":
                            CloseZoo();
                            break;
                        case "clean":
                            Console.Clear();
                            break;
                        case "help":
                            Console.Write(helpMessage);
                            break;
                        case "exit": return;
                        default:
                            Console.WriteLine("Unknown command. Write 'help' if you don't know commands.");
                            break;
                    }
                    //возобновление таймера после обработки комманды, если таймер был приостановлен
                    if (timer != null)
                    {
                        timer.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR IN Working(): " + ex.Message);
            }
        }

        public Animal AddAnimal()
        {
            try
            {
                Animal animal = null;

                Console.Write("Write animal name: ");
                string nameOfAnimal = Console.ReadLine();
                Console.Write("Write kind of animal (lion,tiger,elephant,bear,wolf,fox): ");
                string kindOfAnimal = Console.ReadLine();

                switch (kindOfAnimal)
                {
                    case "lion":
                        animal = new Animal(new LionFactory(), nameOfAnimal);
                        Console.WriteLine("You added new сute animal (lion) with name '{0}'", nameOfAnimal);
                        break;
                    case "tiger":
                        animal = new Animal(new TigerFactory(), nameOfAnimal);
                        Console.WriteLine("You added new сute animal (tiger) with name '{0}'", nameOfAnimal);
                        break;
                    case "elephant":
                        animal = new Animal(new ElephantFactory(), nameOfAnimal);
                        Console.WriteLine("You added new сute animal (elephant) with name '{0}'", nameOfAnimal);
                        break;
                    case "bear":
                        animal = new Animal(new BearFactory(), nameOfAnimal);
                        Console.WriteLine("You added new сute animal (bear) with name '{0}'", nameOfAnimal);
                        break;
                    case "wolf":
                        animal = new Animal(new WolfFactory(), nameOfAnimal);
                        Console.WriteLine("You added new сute animal (wolf) with name '{0}'", nameOfAnimal);
                        break;
                    case "fox":
                        animal = new Animal(new FoxFactory(), nameOfAnimal);
                        Console.WriteLine("You added new сute animal (fox) with name '{0}'", nameOfAnimal);
                        break;
                    default:
                        Console.WriteLine("Unknown kind of animal.");
                        break;
                }

                return animal;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR IN AddAnimal(): " + ex.Message);
                return null;
            }
        }

        //покормить
        public void FeedAnimal(List<Animal> animals)
        {
            try
            {
                if (animals.Count == 0)
                {
                    Console.WriteLine("There is no animals in the Zoo. Try 'add' command.");
                    return;
                }
                Console.Write("Write animal name:");
                string nameOfAnimal = Console.ReadLine();

                var animal = animals.Find(x => x.AnimalName == nameOfAnimal);
                if (animal != null)
                {
                    Console.WriteLine(animal.FeedAnimal(nameOfAnimal));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR IN FeedAnimal(): " + ex.Message);
            }
        }

        //вылечить
        public void CureAnimal(List<Animal> animals)
        {
            try
            {
                if (animals.Count == 0)
                {
                    Console.WriteLine("There is no animals in the Zoo. Try 'add' command.");
                    return;
                }
                Console.Write("Write animal name:");
                string nameOfAnimal = Console.ReadLine();

                var animal = animals.Find(x => x.AnimalName == nameOfAnimal);
                if (animal != null)
                {
                    Console.WriteLine(animal.CureAnimal(nameOfAnimal));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR IN CureAnimal(): " + ex.Message);
            }
        }

        public void DeleteAnimal(List<Animal> animals)
        {
            try
            {
                if (animals.Count == 0)
                {
                    Console.WriteLine("There is no animals in the Zoo. Try 'add' command.");
                    return;
                }
                Console.Write("Write animal name:");
                string nameOfAnimal = Console.ReadLine();

                var animal = animals.Find(x => x.AnimalName == nameOfAnimal);
                if (animal != null)
                {
                    Console.WriteLine(animal.DeleteAnimal(nameOfAnimal));
                    if (animals.Count != 0 && animal.AnimalCondition == Animal.Condition.WasDead)
                        animals.Remove(animal);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR IN DeleteAnimal(): " + ex.Message);
            }
        }

        //механизм для смены состояний каждые пять минут
        public void RunZoo(List<Animal> animals)
        {
            try
            {
                if (animals.Count == 0)
                {
                    Console.WriteLine("There is no animals in the Zoo. Try 'add' command.");
                    return;
                }
                timer = new System.Timers.Timer(5000);
                timer.Elapsed += (sender, args) => ChangeAnimalCondition(animals);
                timer.Start();
                Console.WriteLine("Zoo opened.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR IN RunZoo(): " + ex.Message);
            }
        }

        //ядро механизма
        private static void ChangeAnimalCondition(List<Animal> animals)
        {
            try
            {
                if (animals != null)
                {
                    if (IsEveryAnimalsDied(animals))
                    {
                        CloseZoo();
                    }
                    Random random = new Random();

                    //чтоб механизм работал только с живыми животными
                    var notDeadAnimals = animals.FindAll(x => x.AnimalCondition != Animal.Condition.WasDead);
                    int indexOfAnimal = random.Next(0, notDeadAnimals.Count);
                    var animal = notDeadAnimals.ElementAt(indexOfAnimal);

                    switch (animal.AnimalCondition)
                    {
                        case Animal.Condition.IsFull:
                            animal.AnimalCondition = Animal.Condition.IsHungry;
                            Console.WriteLine("{0} ({1}) is hungry.", animal.AnimalName, animal.AnimalKind);
                            break;
                        case Animal.Condition.IsHungry:
                            animal.AnimalCondition = Animal.Condition.IsIll;
                            animal.CurrentHealth = (byte) (animal.CurrentHealth - 1);
                            Console.WriteLine("{0} ({1}) is ill. Health: {2}", animal.AnimalName, animal.AnimalKind,
                                animal.CurrentHealth);
                            break;
                        case Animal.Condition.IsIll:
                            if (animal.CurrentHealth == 0)
                            {
                                animal.AnimalCondition = Animal.Condition.WasDead;
                                Console.WriteLine("{0} was dead.", animal.AnimalName);
                                if (IsEveryAnimalsDied(animals))
                                {
                                    CloseZoo();
                                }
                            }
                            else
                            {
                                animal.AnimalCondition = Animal.Condition.IsFull;
                                Console.WriteLine("{0} ({1}) is full.", animal.AnimalName, animal.AnimalKind);
                            }
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR IN ChangeAnimalCondition(): " + ex.Message);
            }
        }

        public static void CloseZoo()
        {
            if (timer != null)
            {
                timer.Stop();
                timer = null;
            }
            Console.WriteLine("Zoo closed.");
        }

        public static bool IsEveryAnimalsDied(List<Animal> animals)
        {
            if (animals.Count > 0)
            {
                if (animals.TrueForAll(x => x.AnimalCondition == Animal.Condition.WasDead))
                {
                    return true;
                }
            }
            return false;
        }

    }
}