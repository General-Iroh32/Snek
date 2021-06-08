using Snek.Graph_Creation.Models;
using Snek.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snek.Graph_Creation.Services
{
    public class SeedService
    {
        private readonly PracticalPerformanceCheckContext _dbContext;

        public SeedService(PracticalPerformanceCheckContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteDatabase()
     => _dbContext.Database.EnsureDeleted();
        public void CreateDatabase()
            => _dbContext.Database.EnsureCreated();


        public void seed()
        {
            List<Mitwirkende> mitwirkende = new List<Mitwirkende>();
            List<Zeiten> zeiten = new List<Zeiten>();


            Mitwirkende dzovani = new Mitwirkende(1, "Dzovani", "Koller");
            Mitwirkende florian = new Mitwirkende(2, "Florian", "Kozak");
            Mitwirkende karl = new Mitwirkende(3, "Karl-Gabriel", "Jimenez");
            Mitwirkende jonas = new Mitwirkende(4, "Jonas", "Taferner");
            Mitwirkende oliver = new Mitwirkende(5, "Oliver", "Mate");

            _dbContext.Mitwirkende.AddRange(dzovani, florian, karl, jonas, oliver);
            _dbContext.SaveChanges();

            mitwirkende.Add(dzovani);
            mitwirkende.Add(florian);
            mitwirkende.Add(karl);
            mitwirkende.Add(jonas);
            mitwirkende.Add(oliver);

            Zeiten zeitend = new Zeiten(1, 15, 13, 57);
            Zeiten zeitenf = new Zeiten(2, 13, 26, 13);
            Zeiten zeitenk = new Zeiten(3, 14, 35, 16);
            Zeiten zeitenj = new Zeiten(4, 13, 45, 37);
            Zeiten zeiteno = new Zeiten(5, 15, 50, 14);

            _dbContext.Zeiten.AddRange(zeitend, zeitenf, zeitenk, zeitenj, zeiteno);
            _dbContext.SaveChanges();


            zeiten.Add(zeitend);
            zeiten.Add(zeitenf);
            zeiten.Add(zeitenk);
            zeiten.Add(zeitenj);
            zeiten.Add(zeiteno);          
           

            Arbeiten arbeit1 = new Arbeiten(1, "POS bezogen", zeiten, mitwirkende);
            Arbeiten arbeit2 = new Arbeiten(1, "PRE bezogen", zeiten, mitwirkende);

            _dbContext.Arbeiten.AddRange(arbeit1, arbeit2);
            _dbContext.SaveChanges();
        }
    }
}
