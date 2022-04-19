using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Domain
{
    public class Katana
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ForgedDate { get; set; }
        public string Weight { get; set; }
        public List<Elemen> Elemens { get; set; } = new List<Elemen>();// many to many
        public Samurai Samurai { get; set; }//many to one
        public int SamuraiId { get; set; }//explicit foreign key
    }
}
