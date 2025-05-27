using System;

namespace NhtLab06.Models
{
    public class NhtEmployee
    {
        public int NhtId { get; set; }
        public string NhtName { get; set; }
        public DateTime NhtBirthDay { get; set; }
        public string NhtEmail { get; set; }
        public string NhtPhone { get; set; }
        public decimal NhtSalary { get; set; }
        public bool NhtStatus { get; set; }
    }
}
