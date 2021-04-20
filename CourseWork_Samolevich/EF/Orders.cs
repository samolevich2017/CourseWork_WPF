namespace CourseWork_Samolevich.EF {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;
    using System.Windows;

    public partial class Orders : INotifyPropertyChanged {

        [Key]
        public int idOrder { get; set; }

        private int? _idClient;
        public int? idClient {
            get => _idClient;
            set {
                _idClient = value;
                OnPropertyChanged("idClient");
            } // set
        } // idClient 

        private int _workingHours;
        public int WorkingHours {
            get => _workingHours;
            set {
                _workingHours = value;
                OnPropertyChanged("WorkingHours");
            } // set
        } // WorkingHours 

        private bool _stat;
        public bool Stat {
            get => _stat;
            set {
                _stat = value;
                OnPropertyChanged("Stat");
            } // set
        } // Stat

        private decimal _totalPrice;
        public decimal TotalPrice {
            get => _totalPrice;
            set {
                _totalPrice = value;
                OnPropertyChanged("TotalPrice");
            } // set
        } // TotalPrice

        public virtual Clients Clients { get; set; }

        public override string ToString() =>
             $"ID: {idOrder} ID CL : {idClient} Hours : {WorkingHours} Stat: {Stat.ToString()} Total: {TotalPrice}";

        // ---------------------------------------------------------------------------------

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "") {
            try {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error in Orders", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        } // OnPropertyChanged

    } // Orders
}
