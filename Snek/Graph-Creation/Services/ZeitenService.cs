using Snek.Graph_Creation.Interfaces;
using Snek.Graph_Creation.Models;
using Snek.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace Snek.Graph_Creation.Services
{
    public class ZeitenService : IZeiten
    {

        public PracticalPerformanceCheckContext _dbContext;

        public ZeitenService(PracticalPerformanceCheckContext practicalPerformanceCheckContext)
        {
            _dbContext = practicalPerformanceCheckContext;
        }

        public List<Zeiten> GetZeitenByArbeiten(int arbeitenId)
        {
            return _dbContext.Zeiten.Where(p => p.Id == arbeitenId).OrderBy(p => p.Id).ToList();
        }

        public List<Zeiten> GetAllZeiten()
        {
            return _dbContext.Zeiten.ToList();
        }
    }
}
