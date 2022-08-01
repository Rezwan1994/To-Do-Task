namespace ToDoApi.Model
{
    public class Task : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public bool isCompleted { get; set; }
    }
}
