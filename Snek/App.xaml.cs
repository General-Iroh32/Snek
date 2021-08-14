using Snek.Graph_Creation.Services;
using Snek.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Snek
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            
            PracticalPerformanceCheckContext practicalPerformanceCheckContext = new PracticalPerformanceCheckContext();
            practicalPerformanceCheckContext.Database.EnsureDeleted();
            practicalPerformanceCheckContext.Database.EnsureCreated();
            SeedService db = new SeedService(practicalPerformanceCheckContext);
            //db.CreateDatabase();
            db.Seed();
        }       
    }
}
