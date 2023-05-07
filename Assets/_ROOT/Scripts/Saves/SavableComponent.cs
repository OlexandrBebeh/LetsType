namespace _ROOT.Scripts.Saves
{
    public interface ISavable
    {
    }

    public abstract class SavableComponent<T> : ISavable where T : SaveComponent, new()
    {
        public virtual T PrepareInitial()
        {
            return new T();
        }

        public abstract T Serialize();

        public abstract void Deserialize(T save);
    }
}