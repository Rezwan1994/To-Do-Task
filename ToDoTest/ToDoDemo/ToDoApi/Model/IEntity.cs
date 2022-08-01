namespace ToDoApi.Model
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
