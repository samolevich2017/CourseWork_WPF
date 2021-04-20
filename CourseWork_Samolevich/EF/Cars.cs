namespace CourseWork_Samolevich.EF {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;
    using System.Security;
    using System.Windows;

    public partial class Cars : INotifyPropertyChanged {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cars() {
            CarsDefects = new HashSet<CarsDefects>();
            Clients = new HashSet<Clients>();
        }

        [Key]
        public int idCar { get; set; }

        [Required]
        [StringLength(100)]
        private string _carMake;
        public string CarMake {
            get => _carMake;
            set {
                _carMake = value;
                OnPropertyChanged("CarMake");
            } // set
        } // CarMake

        [Required]
        [StringLength(50)]
        private string _color;
        public string Color {
            get => _color;
            set {
                _color = value;
                OnPropertyChanged("Color");
            } // set
        } // Color

        private int _yearOfCarManufacturer;
        public int YearOfCarManufacturer {
            get => _yearOfCarManufacturer;
            set {
                _yearOfCarManufacturer = value;
                OnPropertyChanged("YearOfCarManufacturer");
            } // set
        } // YearOfCarManufacturer 

        [Required]
        [StringLength(8)]
        private string _govermentNumber;
        public string GovernmentNumber {
            get => _govermentNumber;
            set {
                _govermentNumber = value;
                OnPropertyChanged("GovernmentNumber");
            } // set
        } // GovernmentNumber 

        private int _idOwner;
        public int idOwner {
            get => _idOwner;
            set {
                _idOwner = value;
                OnPropertyChanged("idOwner");
            } // set
        } // idOwner

        public virtual Owners Owners { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarsDefects> CarsDefects { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Clients> Clients { get; set; }

        // ---------------------------------------------------------------------------------

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "") {
            try {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error in Cars", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        } // OnPropertyChanged
    } // Cars
}
