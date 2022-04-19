using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Domain
{
    public class Elemen
    {
        public int ElemenId { get; set; }
        public string Name { get; set; }
        public List<Katana> Katanas { get; set; } = new List<Katana>();//many to many
    }
}
