using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DataAssembler1.Data
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Gender
    {
        Male,
        Female
    }

    public class Child
    {
        [Key]
        public int Id { get; set; }
        [JsonProperty("childSecondName")]
        public string SecondName { get; set; }
        [JsonProperty("childFirstName")]
        public string FirstName { get; set; }
        [JsonProperty("childPatronymic")]
        public string Patronymic { get; set; }
        [JsonProperty("childGender")]
        public Gender Gender { get; set; }
        [JsonProperty("childBirthDate")]
        public string Birthday { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
    }
}