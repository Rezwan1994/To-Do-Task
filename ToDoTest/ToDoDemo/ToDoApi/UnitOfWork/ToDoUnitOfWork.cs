using Microsoft.EntityFrameworkCore;
using ToDoApi.Model;
using ToDoApi.Repository;

namespace ToDoApi.UnitOfWork
{

    public class ToDoUnitOfWork : UnitOfWork, IToDoUnitOfWork
    {
        public IToDoRepository Tasks { get; private set; }

    

        public ToDoUnitOfWork(ToDoDbContext dbContext,
            IToDoRepository toDoRepository) : base((DbContext)dbContext)
        {
            Tasks = toDoRepository;
     
        }
    }
}
