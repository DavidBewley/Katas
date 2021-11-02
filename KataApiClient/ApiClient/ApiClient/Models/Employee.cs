using System;

namespace ApiClient.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }

        public override string ToString() 
            => $"ID: {Id}\r\n" + $"Name: {Name}\r\n" + $"Start Date: {StartDate:dd/MM/yyyy}\r\n\r\n";
    }
}