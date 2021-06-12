using System.Collections.Generic;

namespace DataAssembler1.Data
{
    public class Passport
    {
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }
        public string IssuePlace { get; set; }
        public string IssueDate { get; set; }
        public string UnitNumber { get; set; }
        public List<Child> Children { get; set; } = new List<Child>();
    }
}