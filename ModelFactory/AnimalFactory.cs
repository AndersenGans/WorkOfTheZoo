namespace ModelFactory
{
    public abstract class AnimalFactory
    {
        public abstract AnimalCondition ChangeCondition();

        public abstract AnimalHealth ChangeHealth();

        public abstract AnimalName GetName();
    }
}