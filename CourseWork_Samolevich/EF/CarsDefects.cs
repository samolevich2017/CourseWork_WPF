namespace CourseWork_Samolevich.EF {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;
    using System.Windows;

    public partial class CarsDefects : INotifyPropertyChanged {
        public int id { get; set; }

        private int? _idCar;
        public int? idCar {
            get => _idCar;
            set {
                _idCar = value;
                OnPropertyChanged("idCar");
            } // set
        } // idCar

        private int? _idDefect;
        public int? idDefect {
            get => _idDefect;
            set {
                _idDefect = value;
                OnPropertyChanged("idDefect");
            } // set
        } // idDefect

        private bool? _statusW;
        public bool? StatusW {
            get => _statusW;
            set {
                _statusW = value;
                OnPropertyChanged("StatusW");
            } // set
        } // StatusW

        public virtual Cars Cars { get; set; }

        public virtual Defects Defects { get; set; }

        // ---------------------------------------------------------------------------------

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "") {
            try {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            } catch (Exception ex) {
                System.Windows.MessageBox.Show(ex.Message, "Error in CarsDefects", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        } // OnPropertyChanged
    }
}
