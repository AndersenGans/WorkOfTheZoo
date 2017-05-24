using System;

namespace ModelFactory
{
    public class Animal
    {
        public enum Condition
        {
            IsFull,
            IsHungry,
            IsIll,
            WasDead
        }

        public AnimalHealth animalHealth;

        private byte currentHealth;

        private byte fullHealth;

        public byte CurrentHealth
        {
            get => currentHealth;
            set
            {
                if (currentHealth < fullHealth && AnimalCondition != Condition.WasDead)
                    currentHealth = value;
            }
        }

        public string AnimalName = "";

        public string AnimalKind = "";

        public Condition AnimalCondition = Condition.IsFull;

        public Animal(AnimalFactory factory, string AnimalName)
        {
            animalHealth = factory.GetFullHealth();
            this.AnimalName = AnimalName;
            fullHealth = animalHealth.GetFullHealth(this);
            currentHealth = fullHealth;
        }

        public string FeedAnimal(string animalName)
        {
            if (AnimalName == animalName)
            {
                return String.Format("'{1}' was fed.", animalName);
            }
            return String.Format("There is no animal with name like '{1}'.", animalName);
        }

        public string CureAnimal(string animalName)
        {
            if (AnimalName == animalName)
            {
                currentHealth += 1;
                return String.Format("'{1}' was cured.", animalName);
            }
            return String.Format("There is no animal with name like '{1}'.", animalName);
        }

        public string DeleteAnimal(string animalName)
        {
            if (AnimalName == animalName && AnimalCondition == Condition.WasDead)
            {
                return String.Format("'{1}' was deleted.", animalName);
            }
            return String.Format("There is no animal with name like '{1}'.", animalName);
        }
    }
}
