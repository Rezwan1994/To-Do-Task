using ToDoApi.UnitOfWork;

namespace ToDoApi.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoUnitOfWork _todoUnitOfWork;
      

        public ToDoService( IToDoUnitOfWork todoUnitOfWork)
        {
            _todoUnitOfWork = todoUnitOfWork;

        }
        public void AddTask(Model.Task task)
        {
            var taskCount = _todoUnitOfWork.Tasks
                .GetCount(x => x.Name == task.Name);

            if (taskCount == 0)
            {
                _todoUnitOfWork.Tasks.Add(task);
                _todoUnitOfWork.Save();
            }
           
        }
        public void EditTask(Model.Task task)
        {
            var studentEntity = _todoUnitOfWork.Tasks.GetById(task.Id);

            _todoUnitOfWork.Save();
        }


        public void DeleteTask(int id)
        {
            _todoUnitOfWork.Tasks.Remove(id);
            _todoUnitOfWork.Save();
        }

        public IList<Model.Task> GetAll()
        {
            return _todoUnitOfWork.Tasks.GetAll();
        }

        public Model.Task GetById(int id)
        {
            return _todoUnitOfWork.Tasks.GetById(id);
        }  
        public void UpdateTask(Model.Task task)
        {
             _todoUnitOfWork.Tasks.Edit(task);
            _todoUnitOfWork.Save();
        }
    }
}
