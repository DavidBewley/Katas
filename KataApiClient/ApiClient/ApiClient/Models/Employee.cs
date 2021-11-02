using System;

namespace ApiClient.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
    }
}