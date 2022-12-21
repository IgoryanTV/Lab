using Lab.Core.Enums;
using System;

namespace Lab.Core
{
    public class Employee
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public SexEnum Sex { get; set; }
        public uint Age { get; set; }
        public FamilyStatusEnum FamilyStatus { get; set; }
        public HasChildEnum HasChildren { get; set; }
        public string? Job { get; set; }
        public string? Degree { get; set; }
    }
}
