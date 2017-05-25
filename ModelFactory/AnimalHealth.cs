using System;

namespace ModelFactory
{
    public abstract class AnimalHealth
    {
        public abstract byte GetFullHealth(Animal animal);
    }

    public class LionFullHealth : AnimalHealth
    {
        public override byte GetFullHealth(Animal animal)
        {
            animal.AnimalKind = "Lion";
            return 5;
        }
    }

    public class TigerFullHealth : AnimalHealth
    {
        public override byte GetFullHealth(Animal animal)
        {
            animal.AnimalKind = "Tiger";
            return 4;
        }
    }

    public class ElephantFullHealth : AnimalHealth
    {
        public override byte GetFullHealth(Animal animal)
        {
            animal.AnimalKind = "Elephant";
            return 7;
        }
    }

    public class BearFullHealth : AnimalHealth
    {
        public override byte GetFullHealth(Animal animal)
        {
            animal.AnimalKind = "Bear";
            return 6;
        }
    }

    public class WolfFullHealth : AnimalHealth
    {
        public override byte GetFullHealth(Animal animal)
        {
            animal.AnimalKind = "Wolf";
            return 4;
        }
    }

    public class FoxFullHealth : AnimalHealth
    {
        public override byte GetFullHealth(Animal animal)
        {
            animal.AnimalKind = "Fox";
            return 3;
        }
    }
}