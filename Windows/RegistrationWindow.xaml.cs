using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EducateApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
            this.Left = 0;
            this.Top = 0;
            DataContext = new ViewModel();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                Label hintLabel = FindChild<Label>(textBox.Tag.ToString());
                if (hintLabel != null && string.IsNullOrEmpty(textBox.Text))
                {
                    hintLabel.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                Label hintLabel = FindChild<Label>(textBox.Tag.ToString());
                if (hintLabel != null && string.IsNullOrEmpty(textBox.Text))
                {
                    hintLabel.Visibility = Visibility.Visible;
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                Label hintLabel = FindChild<Label>(textBox.Tag.ToString());
                if (hintLabel != null)
                {
                    if (!string.IsNullOrEmpty(textBox.Text))
                    {
                        hintLabel.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        hintLabel.Visibility = Visibility.Visible;
                    }
                }
            }

        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            if (passwordBox != null)
            {
                Label hintLabel = FindChild<Label>(passwordBox.Tag.ToString());
                if (hintLabel != null && string.IsNullOrEmpty(passwordBox.Password))
                {
                    hintLabel.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            if (passwordBox != null)
            {
                Label hintLabel = FindChild<Label>(passwordBox.Tag.ToString());
                if (hintLabel != null && string.IsNullOrEmpty(passwordBox.Password))
                {
                    hintLabel.Visibility = Visibility.Visible;
                }
            }
        }

        private T FindChild<T>(string childName) where T : FrameworkElement
        {
            // Ищем элемент среди дочерних элементов
            return (T)FindName(childName);
        }
    }
}
