using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snek.Graph_Creation.Models
{
    public class Arbeiten
    {
        public Arbeiten()
        {

        }

        public Arbeiten(int id, string art, List<Zeiten> zeiten, List<Mitwirkende> mitwirkende)
        {
            Id = id;
            Art = art;
            Zeiten = zeiten;
            Mitwirkende = mitwirkende;
        }
        public int Id { get; set; }
        public string Art { get; set; }

        public List<Zeiten> Zeiten { get; set; } = null;
        public List<Mitwirkende> Mitwirkende { get; set; }
    }
}
