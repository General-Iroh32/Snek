using Snek.Graph_Creation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snek.Graph_Creation.Interfaces
{
    public interface IMitwirkende
    {
        public List<Mitwirkende> GetAllMitwirkende();
    }
}
