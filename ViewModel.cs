using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EducateApp
{
    class ViewModel : INotifyPropertyChanged
    {
        public ViewModel() 
        {
        }

        private RelayCommand enterAsTeacherCommand;
        private RelayCommand enterAsStudentCommand;
        private RelayCommand registrationCommand;
        public HeightToFontSizeConverter HeightToFontSizeConverterObject { get; } = new HeightToFontSizeConverter();
        public RelayCommand EnterAsTeacherCommand
        {
            get
            {
                return enterAsTeacherCommand ??
                  (enterAsTeacherCommand = new RelayCommand(obj =>
                  {
                      MessageBox.Show("Вход Учителя");
                  }));
            }
        }
        public RelayCommand EnterAsStudentCommand
        {
            get
            {
                return enterAsStudentCommand ??
                  (enterAsStudentCommand = new RelayCommand(obj =>
                  {
                      MessageBox.Show("Вход Ученика");
                  }));
            }
        }
        public RelayCommand RegistrationCommand
        {
            get
            {
                return registrationCommand ??
                  (registrationCommand = new RelayCommand(obj =>
                  {
                      MessageBox.Show("Регистрация");
                  }));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
