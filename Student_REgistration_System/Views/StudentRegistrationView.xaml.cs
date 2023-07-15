using student_reg_system.Models;
using student_reg_system.ViewModels;
using Student_Res_Sys.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Student_Res_Sys.Views
{
    /// <summary>
    /// Interaction logic for StudentRegistrationView.xaml
    /// </summary>
    public partial class StudentRegistrationView : Window
    {
        public StudentRegistrationView(StudentRegistrationVM viewmodel)
        {
            InitializeComponent();
            DataContext = viewmodel;
        }
        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
        private void OnTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (textBox.Foreground.Equals(Brushes.LightGray))
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}