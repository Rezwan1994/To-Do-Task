using ToDoApi.Repository;

namespace ToDoApi.UnitOfWork
{
    
    public interface IToDoUnitOfWork : IUnitOfWork
    {
        IToDoRepository Tasks { get; }
       
    }
}
