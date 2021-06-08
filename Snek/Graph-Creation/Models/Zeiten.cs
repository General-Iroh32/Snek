using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snek.Graph_Creation.Models
{
    public class Zeiten
    {
        public Zeiten()
        {

        }

        public Zeiten(int id, int stunden, int minuten, int sekunden)
        {
            Id = id;
            Stunden = stunden;
            Minuten = minuten;
            Sekunden = sekunden;            
        }
        
        public int Id { get; set; }
        public int Stunden { get; set; }
        public int Minuten { get; set; }
        public int Sekunden { get; set; }
    }
}
