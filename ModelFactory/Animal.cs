namespace ModelFactory
{
    public abstract class Animal
    {
        public enum Condition
        {
            IsFull,
            IsHungry,
            IsIll,
            WasDead
        }

        public string AnimalName = "";

        public string AnimalKind = "";

        public Condition AnimalCondition = Condition.IsFull;
    }
}
