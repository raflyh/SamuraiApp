using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Domain
{
    public class Horse
    {
        public int Id { get; set; }//primary key
        public string? Name { get; set; }
        public int SamuraiId { get; set; }
    }
}
