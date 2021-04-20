namespace CourseWork_Samolevich.EF {
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;
    using System.Windows;

    [Table("Specialty")]
    public partial class Specialty : INotifyPropertyChanged {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Specialty() {
            Employee = new HashSet<Employee>();
            Servicess = new HashSet<Servicess>();
        }

        [Key]
        public int idSpecialty { get; set; }

        [Required]
        [StringLength(100)]
        private string _titleSpecialty;
        public string TitleSpecialty {
            get => _titleSpecialty;
            set {
                _titleSpecialty = value;
                OnPropertyChanged("TitleSpecialty");
            } // set
        } // TitleSpecialty

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Servicess> Servicess { get; set; }

        public override string ToString() =>
            $"--- {TitleSpecialty} ---";

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
