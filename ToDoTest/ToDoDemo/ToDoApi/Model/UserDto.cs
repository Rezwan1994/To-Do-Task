namespace ToDoApi.Model
{
    public class UserDto
    {
        public int EmployeeId { get; set; }
        public string? Email { get; set; }
        public string? DisplayName { get; set; }
        public string? Token { get; set; }
        public string? PhoneNumber { get; set; }
        public bool? isAdmin { get; set; }
      
    }
}
