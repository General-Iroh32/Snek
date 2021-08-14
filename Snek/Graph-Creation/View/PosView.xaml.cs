using Snek.Graph_Creation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Snek.Graph_Creation.View
{
    /// <summary>
    /// Interaction logic for PosView.xaml
    /// </summary>
    public partial class PosView : UserControl
    {
        public PosView()
        {
            InitializeComponent();
            DataContext = new PosViewModel(
               new Snek.Graph_Creation.Services.ArbeitenService(new Snek.Infrastructure.PracticalPerformanceCheckContext()),
               new Snek.Graph_Creation.Services.MitwirkendeService(new Snek.Infrastructure.PracticalPerformanceCheckContext()),
               new Snek.Graph_Creation.Services.ZeitenService(new Snek.Infrastructure.PracticalPerformanceCheckContext()));
        }
    }
}
