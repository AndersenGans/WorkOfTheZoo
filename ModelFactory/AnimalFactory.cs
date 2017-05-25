namespace ModelFactory
{
    public abstract class AnimalFactory
    {
        public abstract AnimalHealth GetFullHealth();
    }

    public class LionFactory : AnimalFactory
    {
        public override AnimalHealth GetFullHealth()
        {
            return new LionFullHealth();
        }
    }

    public class TigerFactory : AnimalFactory
    {
        public override AnimalHealth GetFullHealth()
        {
            return new TigerFullHealth();
        }
    }

    public class ElephantFactory : AnimalFactory
    {
        public override AnimalHealth GetFullHealth()
        {
            return new ElephantFullHealth();
        }
    }

    public class BearFactory : AnimalFactory
    {
        public override AnimalHealth GetFullHealth()
        {
            return new BearFullHealth();
        }
    }

    public class WolfFactory : AnimalFactory
    {
        public override AnimalHealth GetFullHealth()
        {
            return new WolfFullHealth();
        }
    }

    public class FoxFactory : AnimalFactory
    {
        public override AnimalHealth GetFullHealth()
        {
            return new FoxFullHealth();
        }
    }

}