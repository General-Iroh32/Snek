using Snek.Graph_Creation.Models;
using Snek.Graph_Creation.Services;
using System.Collections.Generic;
using System.ComponentModel;

namespace Snek.Graph_Creation.ViewModel
{

    public class PosViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly ArbeitenService arbeitenService;
        private readonly MitwirkendeService mitwirkendeService;
        private readonly ZeitenService zeitenService;

        public PosViewModel(ArbeitenService arbeitenService1, MitwirkendeService mitwirkendeService1, ZeitenService zeitenService1)
        {
            arbeitenService = arbeitenService1;
            //  AllArbeiten = arbeitenService.GetArbeitenByMitwirkende();

            mitwirkendeService = mitwirkendeService1;
            AllMitwirkende = mitwirkendeService.GetAllMitwirkende();

            zeitenService = zeitenService1;
            //   AllZeiten = zeitenService.GetZeitenByArbeiten();
        }

        public PosViewModel()
        {
        }

        public List<Mitwirkende> AllMitwirkende { get; set; }

        public List<Arbeiten> AllArbeiten { get; set; }

        public List<Zeiten> AllZeiten { get; set; }
    }
}
