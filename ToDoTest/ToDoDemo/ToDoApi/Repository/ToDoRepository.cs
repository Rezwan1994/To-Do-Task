using Microsoft.EntityFrameworkCore;
using ToDoApi.Model;

namespace ToDoApi.Repository
{
  
    public class ToDoRepository : Repository<Model.Task, int>, IToDoRepository
    {
        public ToDoRepository(ToDoDbContext context) : base((DbContext)context)
        {
        }
    }
}
