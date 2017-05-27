using System;
using System.Collections.Generic;
using ModelFactory;

namespace Controll_of_the_Zoo
{
    public class AddNewAnimalsForTest
    {
        public static void AddNewAnimals(List<Animal> animals)
        {
            #region Foxes

            //add foxes
            animals.Add(new Animal(new FoxFactory(), "JackFox")
            {
                CurrentHealth = 2,
                AnimalCondition = Animal.Condition.IsHungry,
                AnimalKind = "fox"
            });
            Console.WriteLine("Added new сute animal (fox) with name '{0}'", "JackFox");
            animals.Add(new Animal(new FoxFactory(), "BillFox")
            {
                AnimalKind = "fox"
            });
            Console.WriteLine("Added new сute animal (fox) with name '{0}'", "BillFox");
            animals.Add(new Animal(new FoxFactory(), "MichaelFox")
            {
                CurrentHealth = 2,
                AnimalCondition = Animal.Condition.IsHungry,
                AnimalKind = "fox"
            });
            Console.WriteLine("Added new сute animal (fox) with name '{0}'", "MichaelFox");
            animals.Add(new Animal(new FoxFactory(), "MatthewFox")
            {
                CurrentHealth = 0,
                AnimalCondition = Animal.Condition.WasDead,
                AnimalKind = "fox"
            });
            Console.WriteLine("Added new сute animal (fox) with name '{0}'", "MatthewFox");
            animals.Add(new Animal(new FoxFactory(), "EthanFox")
            {
                CurrentHealth = 2,
                AnimalKind = "fox"
            });
            Console.WriteLine("Added new сute animal (fox) with name '{0}'", "EthanFox");
            Console.WriteLine("-----------------------------------------------------");

            #endregion

            #region Wolfs

            //add wolfs
            animals.Add(new Animal(new WolfFactory(), "AndyWolf")
            {
                CurrentHealth = 2,
                AnimalCondition = Animal.Condition.IsIll,
                AnimalKind = "wolf"
            });
            Console.WriteLine("Added new сute animal (wolf) with name '{0}'", "AndyWolf");
            animals.Add(new Animal(new WolfFactory(), "CarryWolf")
            {
                CurrentHealth = 2,
                AnimalCondition = Animal.Condition.IsIll,
                AnimalKind = "wolf"
            });
            Console.WriteLine("Added new сute animal (wolf) with name '{0}'", "CarryWolf");
            animals.Add(new Animal(new WolfFactory(), "JohnyWolf")
            {
                AnimalCondition = Animal.Condition.IsHungry,
                AnimalKind = "wolf"
            });
            Console.WriteLine("Added new сute animal (wolf) with name '{0}'", "JohnyWolf");
            animals.Add(new Animal(new WolfFactory(), "AndrewWolf")
            {
                AnimalCondition = Animal.Condition.IsHungry,
                AnimalKind = "wolf"
            });
            Console.WriteLine("Added new сute animal (wolf) with name '{0}'", "AndrewWolf");
            animals.Add(new Animal(new WolfFactory(), "DanielWolf")
            {
                CurrentHealth = 0,
                AnimalCondition = Animal.Condition.WasDead,
                AnimalKind = "wolf"
            });
            Console.WriteLine("Added new сute animal (wolf) with name '{0}'", "DanielWolf");
            animals.Add(new Animal(new WolfFactory(), "ChrisWolf")
            {
                CurrentHealth = 2,
                AnimalCondition = Animal.Condition.IsHungry,
                AnimalKind = "wolf"
            });
            Console.WriteLine("Added new сute animal (wolf) with name '{0}'", "ChrisWolf");
            Console.WriteLine("-----------------------------------------------------");

            #endregion

            #region Elephants

            //add elephants
            animals.Add(new Animal(new ElephantFactory(), "OmarElephant")
            {
                CurrentHealth = 0,
                AnimalCondition = Animal.Condition.WasDead,
                AnimalKind = "elephant"
            });
            Console.WriteLine("Added new сute animal (elephant) with name '{0}'", "OmarElephant");
            animals.Add(new Animal(new ElephantFactory(), "JosephElephant")
            {
                CurrentHealth = 0,
                AnimalCondition = Animal.Condition.WasDead,
                AnimalKind = "elephant"
            });
            Console.WriteLine("Added new сute animal (elephant) with name '{0}'", "JosephElephant");
            animals.Add(new Animal(new ElephantFactory(), "RyanElephant")
            {
                CurrentHealth = 2,
                AnimalCondition = Animal.Condition.IsIll,
                AnimalKind = "elephant"
            });
            Console.WriteLine("Added new сute animal (elephant) with name '{0}'", "RyanElephant");
            animals.Add(new Animal(new ElephantFactory(), "DavidElephant")
            {
                AnimalKind = "elephant"
            });
            Console.WriteLine("Added new сute animal (elephant) with name '{0}'", "DavidElephant");
            Console.WriteLine("-----------------------------------------------------");

            #endregion

            #region Bears

            //add bears
            animals.Add(new Animal(new BearFactory(), "TeddyBear")
            {
                CurrentHealth = 2,
                AnimalCondition = Animal.Condition.IsHungry,
                AnimalKind = "bear"
            });
            Console.WriteLine("Added new сute animal (bear) with name '{0}'", "TeddyBear");
            animals.Add(new Animal(new BearFactory(), "JacksonBear")
            {
                CurrentHealth = 0,
                AnimalCondition = Animal.Condition.WasDead,
                AnimalKind = "bear"
            });
            Console.WriteLine("Added new сute animal (bear) with name '{0}'", "JacksonBear");
            animals.Add(new Animal(new BearFactory(), "TylerBear")
            {
                CurrentHealth = 0,
                AnimalCondition = Animal.Condition.WasDead,
                AnimalKind = "bear"
            });
            Console.WriteLine("Added new сute animal (bear) with name '{0}'", "TylerBear");
            animals.Add(new Animal(new BearFactory(), "NathanBear")
            {
                CurrentHealth = 0,
                AnimalCondition = Animal.Condition.WasDead,
                AnimalKind = "bear"
            });
            Console.WriteLine("Added new сute animal (bear) with name '{0}'", "NathanBear");
            animals.Add(new Animal(new BearFactory(), "LuisBear")
            {
                AnimalCondition = Animal.Condition.IsIll,
                AnimalKind = "bear"
            });
            Console.WriteLine("Added new сute animal (bear) with name '{0}'", "LuisBear");
            Console.WriteLine("-----------------------------------------------------");

            #endregion

            #region Lions

            //add lions
            animals.Add(new Animal(new LionFactory(), "JacobLion")
            {
                CurrentHealth = 2,
                AnimalKind = "lion"
            });
            Console.WriteLine("Added new сute animal (lion) with name '{0}'", "JacobLion");
            animals.Add(new Animal(new LionFactory(), "SamuelLion")
            {
                CurrentHealth = 2,
                AnimalCondition = Animal.Condition.IsHungry,
                AnimalKind = "lion"
            });
            Console.WriteLine("Added new сute animal (lion) with name '{0}'", "SamuelLion");
            animals.Add(new Animal(new LionFactory(), "DylanLion")
            {
                AnimalCondition = Animal.Condition.IsHungry,
                AnimalKind = "lion"
            });
            Console.WriteLine("Added new сute animal (lion) with name '{0}'", "DylanLion");
            animals.Add(new Animal(new LionFactory(), "BenLion")
            {
                CurrentHealth = 0,
                AnimalCondition = Animal.Condition.WasDead,
                AnimalKind = "lion"
            });
            Console.WriteLine("Added new сute animal (lion) with name '{0}'", "BenLion");
            animals.Add(new Animal(new LionFactory(), "LoganLion")
            {
                CurrentHealth = 0,
                AnimalCondition = Animal.Condition.WasDead,
                AnimalKind = "lion"
            });
            Console.WriteLine("Added new сute animal (lion) with name '{0}'", "LoganLion");
            Console.WriteLine("-----------------------------------------------------");

            #endregion

            #region Tigers

            //add tigers
            animals.Add(new Animal(new TigerFactory(), "JordanTiger")
            {
                CurrentHealth = 2,
                AnimalKind = "tiger"
            });
            Console.WriteLine("Added new сute animal (tiger) with name '{0}'", "JordanTiger");
            animals.Add(new Animal(new TigerFactory(), "CameronTiger")
            {
                AnimalCondition = Animal.Condition.IsHungry,
                AnimalKind = "tiger"
            });
            Console.WriteLine("Added new сute animal (tiger) with name '{0}'", "CameronTiger");
            animals.Add(new Animal(new TigerFactory(), "HunterTiger")
            {
                AnimalCondition = Animal.Condition.IsIll,
                AnimalKind = "tiger"
            });
            Console.WriteLine("Added new сute animal (tiger) with name '{0}'", "HunterTiger");
            animals.Add(new Animal(new TigerFactory(), "JaydenTiger")
            {
                CurrentHealth = 0,
                AnimalCondition = Animal.Condition.WasDead,
                AnimalKind = "tiger"
            });
            Console.WriteLine("Added new сute animal (tiger) with name '{0}'", "JaydenTiger");
            animals.Add(new Animal(new TigerFactory(), "CharlesTiger")
            {
                CurrentHealth = 2,
                AnimalCondition = Animal.Condition.IsIll,
                AnimalKind = "tiger"
            });
            Console.WriteLine("Added new сute animal (tiger) with name '{0}'", "CharlesTiger");
            animals.Add(new Animal(new TigerFactory(), "DiegoTiger")
            {
                CurrentHealth = 2,
                AnimalCondition = Animal.Condition.IsIll,
                AnimalKind = "tiger"
            });
            Console.WriteLine("Added new сute animal (tiger) with name '{0}'", "DiegoTiger");
            Console.WriteLine("-----------------------------------------------------");

            #endregion
        }
    }
}