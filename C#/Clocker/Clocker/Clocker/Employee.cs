namespace Clocker
{
    public class Employee
    {
        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public decimal Hour { get; set; }
        public int PIN { get; set; }
        public Employee(string name, int id, decimal hour, int pin)
        {
            this.Name = name;
            this.EmployeeId = id;
            this.Hour = hour;
            this.PIN = pin;
        }
        public void AddTime(Time time)
        {
            Hour = time + ;
        }
    }
}
