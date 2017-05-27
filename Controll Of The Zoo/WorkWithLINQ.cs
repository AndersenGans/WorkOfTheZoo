using System;
using System.Collections.Generic;
using System.Linq;
using ModelFactory;

namespace Controll_of_the_Zoo
{
    public static class WorkWithLINQ
    {
        private static void ShowAnimals<T>(IEnumerable<T> animals)
        {
            foreach (var animal in animals)
            {
                Console.WriteLine($"\t{animal}");
            }
        }

        public static void GroupByKindOfAnimals(List<Animal> animals)
        {
            if (!animals.Any())
            {
                Console.WriteLine("There is no animals in the Zoo.");
                return;
            }
            var groupAnimals = animals.GroupBy(animal => animal.AnimalKind, x => x.AnimalName);
            Console.WriteLine();
            foreach (var animal in groupAnimals)
            {
                Console.WriteLine($"{animal.Key} has animals:");
                ShowAnimals(animal);
            }
        }

        public static void AnimalByCondition(List<Animal> animals, Animal.Condition condition)
        {
            if (!animals.Any())
            {
                Console.WriteLine("There is no animals in the Zoo.");
                return;
            }
            var conditionAnimals = animals.Where(animal => animal.AnimalCondition == condition);
            ShowAnimals(conditionAnimals);
        }

        public static void TigersAreIll(List<Animal> animals)
        {
            if (!animals.Any())
            {
                Console.WriteLine("There is no animals in the Zoo.");
                return;
            }
            var illTigers = animals
                .Where(animal => animal.AnimalKind == "tiger" && animal.AnimalCondition == Animal.Condition.IsIll)
                .Select(animal => animal.AnimalName);
            if (!illTigers.Any())
            {
                Console.WriteLine("There are no sick tigers.");
                return;
            }
            Console.WriteLine("Tigers are sick:");
            ShowAnimals(illTigers);
        }

        public static void SelectConcreteElephant(List<Animal> animals, string animalName)
        {
            if (!animals.Any())
            {
                Console.WriteLine("There is no animals in the Zoo.");
                return;
            }
            var elephant = animals
                .Where(animal => animal.AnimalName == animalName && animal.AnimalKind == "elephant")
                .Select(animal => animal);
            if (!elephant.Any())
            {
                Console.WriteLine($"There is no elephants with name {animalName}");
                return;
            }
            Console.WriteLine("Finded elephants:");
            ShowAnimals(elephant);
        }
    }
}