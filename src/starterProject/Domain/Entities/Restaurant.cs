using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Restaurant : Entity<Guid>
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public TimeSpan OpeningHours { get; set; }
    public TimeSpan ClosingHours { get; set; }
    public string Location { get; set; }
    public string? Photo { get; set; }
    public ICollection<Menu> Menus { get; set; }
    public ICollection<RestaurantTable> RestaurantTables { get; set; }
    public ICollection<Employee> Employees { get; set; }
    public ICollection<DayOfWeek> WorkingDays { get; set; }

}
