using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkOutAppDatabase.Models
{
    public class Goals
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Dátum")]
        public string Date { get; set; }
        [DisplayName("Napi ajánlott kalóriamennyiség")]
        public int CalculatedCalorie { get; set; }
        [DisplayName("Cél")]
        public int Goal { get; set; }
        [DisplayName("Munka aktivitás")]
        public int WorkingType { get; set; }
        [DisplayName("Nem")]
        public int Gender { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
