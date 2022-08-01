namespace ToDoApi.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
