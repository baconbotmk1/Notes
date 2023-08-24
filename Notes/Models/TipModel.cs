using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Models
{
    public class TipModel : INotifyPropertyChanged
    {
        //public double Bill { get; set; }
        //public double Tip { get; set; }
        //public double TipProcent { get; set; }
        //public double Total { get; set; }

        private double _bill;
        private double _tip;
        private double _tipPercent;
        private double _total;
        public double Bill
        {
            get => _bill;
            set
            {
                _bill = value;
                RaisePropertyChanged();
            }
        }
        public double Tip
        {
            get => _tip;
            set
            {
                _tip = value;
                RaisePropertyChanged();
            }
        }
        public double TipPercent
        {
            get => _tipPercent;
            set
            {
                _tipPercent = value;
                RaisePropertyChanged();
            }
        }
        public double Total
        {
            get => _total;
            set
            {
                _total = value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

