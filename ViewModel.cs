using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Xps;

namespace EducateApp
{
    public class ViewModel : INotifyPropertyChanged
    {
        private string? text;      // текст, введенный пользователем в поле
        private string? fieldType; // тип поля: электронная почта, пароль, имя, фамилия и т д
        private string? role;      // роль пользователя: учитель или ученик
        

        public string? Text
        {
            get => text;
            set 
            {
                text = value;
                OnPropertyChanged("Text");
            }
        }
        public string? FieldType
        {
            get => fieldType;
            set
            {
                fieldType = value;
                OnPropertyChanged("FieldType");
            }
        }
        public string? Role
        {
            get => role;
            set 
            {
                role = value;
                OnPropertyChanged("Role");
            }
        }
        

        public RoutedCommand EnterCommand { get; private set; }
        public RoutedCommand RegistrationCommand { get; private set; }

        public ViewModel()
        {
            EnterCommand = new RoutedCommand();
            CommandManager.RegisterClassCommandBinding(typeof(Window), new CommandBinding(EnterCommand, ExecuteEnterCommand));
            RegistrationCommand = new RoutedCommand();
            CommandManager.RegisterClassCommandBinding(typeof(Window), new CommandBinding(RegistrationCommand, ExecuteRegistrationCommand));
            
        }

        private void ExecuteEnterCommand(object sender, ExecutedRoutedEventArgs e)
        {
            Role = e.Parameter?.ToString();
            Console.WriteLine(Role); 

            Window currentWindow = Application.Current.MainWindow;
            Windows.LogInWindow newWindow = new Windows.LogInWindow();
            newWindow.Show();
            currentWindow.Close();
        }
        private void ExecuteRegistrationCommand(object sender, ExecutedRoutedEventArgs e)
        {
            Window currentWindow = Application.Current.MainWindow;
            Windows.RegistrationWindow newWindow = new Windows.RegistrationWindow();
            newWindow.Show();
            currentWindow.Close();
        }



        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
