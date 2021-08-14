using Snek.Graph_Creation.Models;
using Snek.Graph_Creation.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            AllArbeiten = arbeitenService.GetArbeitenByMitwirkende();

            mitwirkendeService = mitwirkendeService1;
            AllMitwirkende = mitwirkendeService.GetAllMitwirkende();

            zeitenService = zeitenService1;
<<<<<<< Updated upstream
            AllZeiten = zeitenService.GetZeitenByArbeiten();
=======
            //   AllZeiten = zeitenService.GetZeitenByArbeiten();
        }

        public PosViewModel()
        {

>>>>>>> Stashed changes
        }

        public List<Mitwirkende> AllMitwirkende { get; set; }

        public List<Arbeiten> AllArbeiten { get; set; }

        public List<Zeiten> AllZeiten { get; set; }


        
        private  List<Zeiten> _zeitenByArbeiten;
        private Mitwirkende _selectedMitwirkende;

        public List<Arbeiten> ArbeitenByMitwirkende
        {
            get => _arbeitenBymitwirkende;

            set
            {
                _arbeitenBymitwirkende = value;
                //SelectedMitwirkende = null;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ArbeitenByMitwirkende)));
            }
        }

        public Mitwirkende SelectedMitwirkende
        {
            get => _selectedMitwirkende;

            set
            {
                if (value != null)
                {
                    _selectedMitwirkende = value;
                    ArbeitenByMitwirkende = arbeitenService.GetArbeitenByMitwirkende(_selectedMitwirkende.Id);
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedMitwirkende)));
                }
                else
                {
                    _selectedMitwirkende = null;
                }
                
            }

        }
        
        private List<Arbeiten> _arbeitenBymitwirkende;
        
       
        
        private Arbeiten _selectedArbeiten;

        public List<Zeiten> ZeitenByArbeiten
        {
            get => _zeitenByArbeiten;


            set
            {
                _zeitenByArbeiten = value;
            }
        }
        public Arbeiten SelectedArbeiten
        {
            get => _selectedArbeiten;
            set
            {
                _selectedArbeiten = value;
                if (_selectedArbeiten != null)
                {


                    ZeitenByArbeiten = zeitenService.GetZeitenByArbeiten(_selectedArbeiten.Id);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ZeitenByArbeiten)));
                }

            }
        }

        
       
    }

}
