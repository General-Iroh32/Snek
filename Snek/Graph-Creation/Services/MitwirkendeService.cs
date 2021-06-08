using Snek.Graph_Creation.Interfaces;
using Snek.Graph_Creation.Models;
using Snek.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snek.Graph_Creation.Services
{
    public class MitwirkendeService : IMitwirkende
    {

        public PracticalPerformanceCheckContext _dbContext;

        public MitwirkendeService(PracticalPerformanceCheckContext practicalPerformanceCheckContext)
        {
            _dbContext = practicalPerformanceCheckContext;
        }

        public List<Mitwirkende> GetAllMitwirkende()
        {
            return _dbContext.Mitwirkende.OrderBy(c => c.Id).ToList();
        }
    }
}
