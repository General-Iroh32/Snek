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
            SeedService db = new SeedService(new PracticalPerformanceCheckContext());
            db.DeleteDatabase();
            db.CreateDatabase();
            db.Seed();
        }       
    }
}
