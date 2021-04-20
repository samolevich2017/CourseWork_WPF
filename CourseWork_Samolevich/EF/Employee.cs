namespace CourseWork_Samolevich.EF {
    using System;
    using System.CodeDom;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;
    using System.Windows;

    [Table("Employee")]
    public partial class Employee : INotifyPropertyChanged {
        [Key]
        public int idEmployee { get; set; }

        [Required]
        [StringLength(100)]
        private string _surnameEmployee;
        public string SurnameEmployee {
            get => _surnameEmployee;
            set {
                _surnameEmployee = value;
                OnPropertyChanged("SurnameEmployee");
            } // set
        } // SurnameEmployee 

        [Required]
        [StringLength(100)]
        private string _nameEmployee;
        public string NameEmployee {
            get => _nameEmployee;
            set {
                _nameEmployee = value;
                OnPropertyChanged("NameEmployee");
            } // set
        } // NameEmployee 

        [Required]
        [StringLength(100)]
        private string _patronymicEmployee;
        public string PatronymicEmployee {
            get => _patronymicEmployee;
            set {
                _patronymicEmployee = value;
                OnPropertyChanged("PatronymicEmployee");
            } // set    
        } // PatronymicEmployee

        private int? _idSpecialty;
        public int? idSpecialty {
            get => _idSpecialty;
            set {
                _idSpecialty = value;
                OnPropertyChanged("idSpecialty");
            } // set
        } // idSpecialty 

        private byte _runk;
        public byte Runk {
            get => _runk;
            set {
                _runk = value;
                OnPropertyChanged("Runk");
            } // set
        } // Runk

        private byte _experience;
        public byte Experience {
            get => _experience;
            set {
                _experience = value;
                OnPropertyChanged("Experience");
            } // set
        } // Experience

        private bool _statusWorking;
        public bool StatusWorking {
            get => _statusWorking;
            set {
                _statusWorking = value;
                OnPropertyChanged("StatusWorking");
            } // set
        } // StatusWorking 

        private bool _stateDiss;
        public bool StateDiss {
            get => _stateDiss;
            set {
                _stateDiss = value;
                OnPropertyChanged("StateDiss");
            } // set    
        } // StateDiss

        public virtual Specialty Specialty { get; set; }

        public override string ToString() =>
            $"\nID: {idEmployee};\nФамилия: {SurnameEmployee};\nИмя: {NameEmployee};\nОтчество: {PatronymicEmployee};\n";

        // ---------------------------------------------------------------------------------

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "") {
            try {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error in Employee", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        } // OnPropertyChanged

    } // Employee
}
