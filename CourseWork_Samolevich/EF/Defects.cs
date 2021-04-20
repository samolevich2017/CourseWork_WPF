namespace CourseWork_Samolevich.EF {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;
    using System.Windows;

    public partial class Defects : INotifyPropertyChanged {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Defects() {
            CarsDefects = new HashSet<CarsDefects>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idDef { get; set; }

        [Required]
        [StringLength(100)]
        private string _titleDefect;
        public string TitleDefect {
            get => _titleDefect;
            set {
                _titleDefect = value;
                OnPropertyChanged("TitleDefect");
            } // set
        } // TitleDefect 

        private int _idService;
        public int idService {
            get => _idService;
            set {
                _idService = value;
                OnPropertyChanged("idservice");
            } // set
        } // idService

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarsDefects> CarsDefects { get; set; }

        public virtual Servicess Servicess { get; set; }

        public override string ToString() =>
            $"ID: {idDef};\nНаименование: {TitleDefect};\nID услуги: {idService}";

        // ---------------------------------------------------------------------------------

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "") {
            try {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error in Services", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        } // OnPropertyChanged
    } // Defect
}

