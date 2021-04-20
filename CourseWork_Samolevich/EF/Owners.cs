namespace CourseWork_Samolevich.EF {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;
    using System.Windows;

    public partial class Owners : INotifyPropertyChanged {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Owners() {
            Cars = new HashSet<Cars>();
        }

        [Key]
        public int idOwner { get; set; }

        [Required]
        [StringLength(100)]
        private string _surnameOwner;
        public string SurnameOwner {
            get => _surnameOwner;
            set {
                _surnameOwner = value;
                OnPropertyChanged("SurnameOwner");
            } // set
        } // SurnameOwner

        [Required]
        [StringLength(100)]
        private string _nameOwner;
        public string NameOwner {
            get => _nameOwner;
            set {
                _nameOwner = value;
                OnPropertyChanged("NameOwner");
            } // set
        } // NameOwner

        [Required]
        [StringLength(100)]
        private string _patronymicOwner;
        public string PatronymicOwner {
            get => _patronymicOwner;
            set {
                _patronymicOwner = value;
                OnPropertyChanged("PatronymicOwner");
            } // set
        } // PatronymicOwner 

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
        public virtual ICollection<Cars> Cars { get; set; }

        public override string ToString() =>
            $"{SurnameOwner} {NameOwner} {PatronymicOwner}";

        // ---------------------------------------------------------------------------------

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "") {
            try {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error in Owners", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        } // OnPropertyChanged
    }
}
