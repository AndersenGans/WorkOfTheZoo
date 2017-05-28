using System;
using System.Collections.Generic;
using System.Linq;
using ModelFactory;

namespace Controll_of_the_Zoo
{
    public class WorkWithLINQ
    {
        public void ShowAnimals<T>(IEnumerable<T> animals)
        {
            if (!IsAnyAnimals(animals, "There is no animals in the Zoo.")) return;

            foreach (var animal in animals)
            {
                Console.WriteLine($"\t{animal}");
            }
        }

        private bool IsAnyAnimals<T>(IEnumerable<T> animals, string message)
        {
            if (!animals.Any())
            {
                Console.WriteLine(message);
                return false;
            }
            return true;
        }

        public void GroupByKindOfAnimals(List<Animal> animals)
        {
            if (!IsAnyAnimals(animals, "There is no animals in the Zoo.")) return;

            var groupAnimals = animals.GroupBy(animal => animal.AnimalKind, x => x.AnimalName);
            foreach (var animal in groupAnimals)
            {
                Console.WriteLine($"{animal.Key} has animals:");
                ShowAnimals(animal);
            }
        }

        public void AnimalByCondition(List<Animal> animals, Animal.Condition condition)
        {
            if (!IsAnyAnimals(animals, "There is no animals in the Zoo.")) return;

            var conditionAnimals = animals.Where(animal => animal.AnimalCondition == condition);

            if (!IsAnyAnimals(conditionAnimals, $"There is no animals with condition '{condition}'.")) return;

            ShowAnimals(conditionAnimals);
        }

        public void TigersAreIll(List<Animal> animals)
        {
            if (!IsAnyAnimals(animals, "There is no animals in the Zoo.")) return;

            var illTigers = animals
                .Where(animal => animal.AnimalKind == "tiger" && animal.AnimalCondition == Animal.Condition.IsIll);

            if (!IsAnyAnimals(illTigers, "There are no sick tigers.")) return;

            Console.WriteLine("Tigers are sick:");
            ShowAnimals(illTigers);
        }

        public void SelectConcreteElephant(List<Animal> animals, string animalName)
        {
            if (!IsAnyAnimals(animals, "There is no animals in the Zoo.")) return;

            var elephants = animals
                .Where(animal => animal.AnimalName == animalName && animal.AnimalKind == "elephant");

            if (!IsAnyAnimals(elephants, $"There is no elephants with name {animalName}.")) return;

            Console.WriteLine("Finded elephants:");
            ShowAnimals(elephants);
        }

        public void HungryAnimals(List<Animal> animals)
        {
            if (!IsAnyAnimals(animals, "There is no animals in the Zoo.")) return;

            var hungryAnimals = animals.Where(animal => animal.AnimalCondition == Animal.Condition.IsHungry)
                .Select(animal => animal.AnimalName);

            if (!IsAnyAnimals(hungryAnimals, "There is no hungry animals.")) return;

            Console.WriteLine("Hungry animals:");
            ShowAnimals(hungryAnimals);
        }

        public void MostHealthyAnimalsByKind(List<Animal> animals)
        {
            if (!IsAnyAnimals(animals, "There is no animals in the Zoo.")) return;

            //ЛИБО С ПОМОЩЬЮ ЗАПРОСА
            var healthyAnimals = from animal in animals
                group animal by animal.AnimalKind
                into animalList
                select (from firstAnimal in animalList
                    where firstAnimal.CurrentHealth == (from mostHealthAnimal in animalList
                              select mostHealthAnimal.CurrentHealth).Max()
                    orderby firstAnimal.AnimalName
                    select firstAnimal).First();

            ////ЛИБО С ПОМОЩЬЮ ЦЕПОЧКИ
            ////сначала группируем животных по виду (groupAnimals - одна группа)
            //var healthyAnimals = animals.GroupBy(animal => animal.AnimalKind, groupAnimals => groupAnimals)
            //    //дальше выбираем из каждой группы первого отсортированного (animalList.First(...) - первый из группы)
            //    .Select(animalList => animalList.OrderBy(order => order.AnimalName).First(
            //        //у которого текущее здоровье (CurrentHealth) максимальное из всей группы (из animalList)
            //        mostHealthAnimal => mostHealthAnimal.CurrentHealth ==
            //                            animalList.Max(health => health.CurrentHealth)));

            Console.WriteLine("Animals with better health grouped by kind:");
            foreach (var animal in healthyAnimals)
            {
                Console.WriteLine(
                    $"kind: {animal.AnimalKind} => name: {animal.AnimalName} => health: {animal.CurrentHealth}.");
            }
        }

        public void CountDiedAnimals(List<Animal> animals)
        {
            if (!IsAnyAnimals(animals, "There is no animals in the Zoo.")) return;

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

            if (!IsAnyAnimals(diedAnimals, "There is no died animals.")) return;

            Console.WriteLine("Died animals grouped by kind:");
            foreach (var diedAnimal in diedAnimals)
            {
                Console.WriteLine($"kind: {diedAnimal.Kind} => count of died: {diedAnimal.Count}");
            }
        }

        public void WolfsAndBearsHealthMore3(List<Animal> animals)
        {
            if (!IsAnyAnimals(animals, "There is no animals in the Zoo.")) return;

            var bearsAndWolfs = animals
                .Where(animal => (animal.AnimalKind == "wolf" || animal.AnimalKind == "bear") &&
                                 animal.CurrentHealth > 3);

            if (!IsAnyAnimals(bearsAndWolfs, "There is no wolfs or bears with health more than 3.")) return;

            Console.WriteLine("Wolfs and bears with health more than 3:");
            ShowAnimals(bearsAndWolfs);
        }

        public void MaxMinHealthAnimals(List<Animal> animals)
        {
            if (!IsAnyAnimals(animals, "There is no animals in the Zoo.")) return;

            var maxMinHlthAnimals = animals.Select(animal => new
            {
                MaxHealth = animals
                    .Where(oneAnimal => oneAnimal.CurrentHealth == animals.Max(animalMax => animalMax.CurrentHealth))
                    .OrderBy(key => key.AnimalName).First(),
                MinHealth = animals
                    .Where(oneAnimal => oneAnimal.CurrentHealth == animals.Min(animalMin => animalMin.CurrentHealth))
                    .OrderBy(key => key.AnimalName).First()
            }).First();

            Console.WriteLine(
                $"Animal with max health:\n\t{maxMinHlthAnimals.MaxHealth};\nanimal with min health:\n\t{maxMinHlthAnimals.MinHealth}.");
        }

        public void AverageHealth(List<Animal> animals)
        {
            if (!IsAnyAnimals(animals, "There is no animals in the Zoo.")) return;

            var averageHlth = animals.Average(animal => animal.CurrentHealth);

            Console.WriteLine("Average animal health in the Zoo is {0:0.##}.", averageHlth);
        }
    }
}