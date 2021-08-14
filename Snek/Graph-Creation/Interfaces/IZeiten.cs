using Snek.Graph_Creation.Models;
using System.Collections.Generic;

namespace Snek.Graph_Creation.Interfaces
{
    public interface IZeiten
    {
        public List<Zeiten> GetZeitenByArbeiten(int arbeitenId);
        public List<Zeiten> GetAllZeiten();
    }
}
