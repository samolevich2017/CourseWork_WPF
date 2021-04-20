namespace CourseWork_Samolevich.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;
    using System.Windows;

    public partial class Clients : INotifyPropertyChanged {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clients()
        {
            Orders = new HashSet<Orders>();
        }

        [Key]
        public int idClient { get; set; }

        [Required]
        [StringLength(100)]
        private string _surnameClient;
        public string SurnameClient {
            get => _surnameClient;
            set {
                _surnameClient = value;
                OnPropertyChanged("SurnameClient");
            } // set
        } // SurnameClient 

        [Required]
        [StringLength(100)]
        private string _nameClient;
        public string NameClient {
            get => _nameClient;
            set {
                _nameClient = value;
                OnPropertyChanged("NameClient");
            } // set
        } // NameClient 

        [Required]
        [StringLength(100)]
        private string _patronymicClient;
        public string PatronymicClient {
            get => _patronymicClient;
            set {
                _patronymicClient = value;
                OnPropertyChanged("PatronymicClient");
            } // set
        } // PatronymicClient 

        [Required]
        [StringLength(100)]
        private string _registration;
        public string Registration {
            get => _registration;
            set {
                _registration = value;
                OnPropertyChanged("Registration");
            } // set
        } // Registration 

        [Column(TypeName = "date")]
        private DateTime _dateOfApplication;
        public DateTime DateOfApplication {
            get => _dateOfApplication;
            set {
                _dateOfApplication = value;
                OnPropertyChanged("DateOfApplication");
            } // set
        } // DateOfApplication 

        private bool _isOwner;
        public bool isOwner {
            get => _isOwner;
            set {
                _isOwner = value;
                OnPropertyChanged("isOwner");
            } // set
        } // isOwner

        private int _idCar;
        public int idCar {
            get => _idCar;
            set {
                _idCar = value;
                OnPropertyChanged("idCar");
            } // set
        } // idCar

        [Column(TypeName = "date")]
        private DateTime _dateOfBirthday;
        public DateTime DateOfBirthday {
            get => _dateOfBirthday;
            set {
                _dateOfBirthday = value;
                OnPropertyChanged("DateOfBirthday");
            } // set
        } // DateOfBirthday 

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
        public Cars Cars { get; internal set; }

        public override string ToString() =>
                $"{SurnameClient} {NameClient} {PatronymicClient}";

        // ---------------------------------------------------------------------------------

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "") {
            try {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            } catch (Exception ex) {
                System.Windows.MessageBox.Show(ex.Message, "Error in Client", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        } // OnPropertyChanged
    }
}
