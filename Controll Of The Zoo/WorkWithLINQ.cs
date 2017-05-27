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

        public static void HungryAnimals(List<Animal> animals)
        {
            if (!animals.Any())
            {
                Console.WriteLine("There is no animals in the Zoo.");
                return;
            }
            var hungryAnimals = animals.Where(animal => animal.AnimalCondition == Animal.Condition.IsHungry)
                .Select(animal => animal.AnimalName);
            if (!hungryAnimals.Any())
            {
                Console.WriteLine($"There is no hungry animals.");
                return;
            }
            Console.WriteLine("Hungry animals:");
            ShowAnimals(hungryAnimals);
        }

        public static void MostHealthyAnimalsByKind(List<Animal> animals)
        {
            if (!animals.Any())
            {
                Console.WriteLine("There is no animals in the Zoo.");
                return;
            }
            //сначала группируем животных по виду (groupAnimals - одна группа)
            var healthyAnimals = animals.GroupBy(animal => animal.AnimalKind, groupAnimals => groupAnimals)
                //дальше выбираем из каждой группы первого (animalList.First(...) - первый из группы)
                .Select(animalList => animalList.First(
                    //у которого текущее здоровье (CurrentHealth) максимальное из всей группы (из animalList)
                    mostHealthAnimal => mostHealthAnimal.CurrentHealth ==
                                        animalList.Max(health => health.CurrentHealth)));

            //ЛИБО С ПОМОЩЬЮ ЗАПРОСА 
            //var healthyAnimals = from animal in animals
            //    group animal by animal.AnimalKind
            //    into animalList
            //    select (from firstAnimal in animalList
            //        where firstAnimal.CurrentHealth == (from mostHealthAnimal in animalList
            //                  select mostHealthAnimal.CurrentHealth).Max()
            //        select firstAnimal).First();

            Console.WriteLine("Animals with better health grouped by kind:");
            foreach (var animal in healthyAnimals)
            {
                Console.WriteLine(
                    $"kind: {animal.AnimalKind} => name: {animal.AnimalName} => health: {animal.CurrentHealth}.");
            }
        }

        public static void CountDiedAnimals(List<Animal> animals)
        {
            if (!animals.Any())
            {
                Console.WriteLine("There is no animals in the Zoo.");
                return;
            }

            var diedAnimals = from animal in animals
                              group animal by animal.AnimalKind
                into listAnimals
                              select new
                              {
                                  Count = (from oneAnimal in listAnimals
                                           where oneAnimal.AnimalCondition == Animal.Condition.WasDead
                                           select oneAnimal).Count(),
                                  Kind = listAnimals.Key
                              };

            Console.WriteLine("Died animals grouped by kind:");
            foreach (var diedAnimal in diedAnimals)
            {
                Console.WriteLine($"kind: {diedAnimal.Kind} => count of died: {diedAnimal.Count}");
            }
        }
    }
}