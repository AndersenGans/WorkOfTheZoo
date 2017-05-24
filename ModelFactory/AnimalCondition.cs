using System;

namespace ModelFactory
{
    public abstract class AnimalCondition
    {
        public abstract string GetCondition(Animal animal);

        public abstract string ChangeCondition(Animal animal);
    }

    public class FullCondition : AnimalCondition
    {
        public override string GetCondition(Animal animal)
        {
            return String.Format("{1} ({2}) is full.", animal.AnimalName, animal.AnimalKind);
        }

        public override string ChangeCondition(Animal animal)
        {
            animal.AnimalCondition = Animal.Condition.IsFull;
            return String.Format("The condition of {1} ({2}) changed to 'full'.", animal.AnimalName, animal.AnimalKind);
        }
    }

    public class HungryCondition : AnimalCondition
    {
        public override string GetCondition(Animal animal)
        {
            return String.Format("{1} ({2}) is hungry.", animal.AnimalName, animal.AnimalKind);
        }

        public override string ChangeCondition(Animal animal)
        {
            animal.AnimalCondition = Animal.Condition.IsHungry;
            return String.Format("The condition of {1} ({2}) changed to 'hungry'.", animal.AnimalName, animal.AnimalKind);
        }
    }

    public class IllCondition : AnimalCondition
    {
        public override string GetCondition(Animal animal)
        {
            return String.Format("{1} ({2}) is ill.", animal.AnimalName, animal.AnimalKind);
        }

        public override string ChangeCondition(Animal animal)
        {
            animal.AnimalCondition = Animal.Condition.IsIll;
            return String.Format("The condition of {1} ({2}) changed to 'ill'.", animal.AnimalName, animal.AnimalKind);
        }
    }

    public class DeadCondition : AnimalCondition
    {
        public override string GetCondition(Animal animal)
        {
            return String.Format("{1} ({2}) was dead.", animal.AnimalName, animal.AnimalKind);
        }

        public override string ChangeCondition(Animal animal)
        {
            animal.AnimalCondition = Animal.Condition.WasDead;
            return String.Format("The condition of {1} ({2}) changed to 'dead'.", animal.AnimalName, animal.AnimalKind);
        }
    }
}