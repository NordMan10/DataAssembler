using System.Collections.Generic;

namespace DataAssembler1.Data
{
    public class FormData
    {
        public Passport Passport { get; set; }
        public Dictionary<string, Child> Children { get; set; }
    }
}