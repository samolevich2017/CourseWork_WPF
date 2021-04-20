namespace CourseWork_Samolevich.EF {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;
    using System.Windows;

    [Table("Servicess")]
    public partial class Servicess : INotifyPropertyChanged {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Servicess() {
            Defects = new HashSet<Defects>();
        }

        [Key]
        public int idService { get; set; }

        [Required]
        [StringLength(100)]
        private string _titleService;
        public string TitleService {
            get => _titleService;
            set {
                _titleService = value;
                OnPropertyChanged("TitleService");
            } // set
        } // TitleService 

        private decimal _price;
        public decimal Price {
            get => _price;
            set {
                _price = value;
                OnPropertyChanged("Price");
            } // set
        } // Price

        private int _workingHours;
        public int WorkingHours {
            get => _workingHours;
            set {
                _workingHours = value;
                OnPropertyChanged("WorkingHours");
            } // set
        } // WorkingHours 

        private int? _idSpecialty;
        public int? idSpecialty {
            get => _idSpecialty;
            set {
                _idSpecialty = value;
                OnPropertyChanged("idSpecialty");
            } // set
        } // idSpecialty 

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Defects> Defects { get; set; }

        public virtual Specialty Specialty { get; set; }

        public override string ToString() =>
            $"-- {TitleService} --";

        // ---------------------------------------------------------------------------------

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "") {
            try {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error in Owners", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        } // OnPropertyChanged
    } // Servicess
}
