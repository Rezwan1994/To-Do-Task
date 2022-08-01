namespace ToDoApi.Services
{
    public interface IToDoService
    {
        void EditTask(Model.Task task);
        void AddTask(Model.Task task);
        void UpdateTask(Model.Task task);
        IList<Model.Task> GetAll();
        Model.Task GetById(int id);
        void DeleteTask(int id);
        
    }
}
