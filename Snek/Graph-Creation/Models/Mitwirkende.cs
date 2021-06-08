using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snek.Graph_Creation.Models
{
    public class Mitwirkende
    {
        public Mitwirkende()
        {

        }

        public Mitwirkende(int id, string vorname, string nachname)
        {
            Id = id;
            Vorname = vorname;
            Nachname = nachname;
        }
        
        public int Id { get; set; }
        public string Vorname { get; set;  }
        public string Nachname { get; set; }


        public List<Arbeiten> Arbeiten{ get; set; }      
    }
}
