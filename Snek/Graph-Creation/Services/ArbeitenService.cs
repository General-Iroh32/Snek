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
    public class ArbeitenService : IArbeiten
    {

        public PracticalPerformanceCheckContext _dbContext;

        public ArbeitenService(PracticalPerformanceCheckContext practicalPerformanceCheckContext)
        {
            _dbContext = practicalPerformanceCheckContext;
        }

        public List<Arbeiten> GetArbeitenByMitwirkende(int mitwirkendeId)
        {
            return _dbContext.Arbeiten.Where(c => c.Id == mitwirkendeId).OrderBy(c => c.Id).ToList();
        }

       
    }


}



       


