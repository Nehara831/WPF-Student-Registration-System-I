using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using student_reg_system.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using System.Windows.Documents;
using System.Windows.Input;

using System.CodeDom.Compiler;
using System.Drawing;
using System.Runtime.Intrinsics.X86;

using Student_Res_Sys.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Windows.Media;

using System.Security.Cryptography;
using System.Xml.Linq;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace student_reg_system.ViewModels
{
    public partial class StudentRegistrationVM : ObservableObject
    {
        [ObservableProperty]
        public int id;
      
        [ObservableProperty]
        public string fname;
        [ObservableProperty]
        public string lname;
        [ObservableProperty]
        public string dateOfBirth;
        [ObservableProperty]
        public string adress;
        [ObservableProperty]
        public BitmapImage imageStudent;
        [ObservableProperty]
        public double gpa;
        

        public  Student NewStudent;

        
        public StudentRegistrationVM()
        {

        }

       

        [RelayCommand]
        public void Save()
        {
            if (ValidateFields())
            { 
                    NewStudent = new Student()
                    {
                        StudentIDStudent = Id,
                        FirstNameStudent = Fname,
                        LastNameStudent = Lname,
                        DateofBirthStudent = DateOfBirth,
                        AdressStudent = Adress,
                        Image = ImageStudent,
                        GPA = Gpa
                        
                    };

                StudentRegistrationView currentWindow = Application.Current.Windows.OfType<StudentRegistrationView>().SingleOrDefault(w => w.IsActive);
                currentWindow?.Close();
                Application.Current.MainWindow.Show();

            }
        }
        [RelayCommand]
        public void ClearTextBoxes()
        {
            var window = Application.Current.Windows.OfType<EditStudent>().SingleOrDefault(x => x.IsActive);

            window.t1.Clear();
            window.t2.Text = "";
            window.t3.Text = "";
            window.t6.Text = "";
            window.t7.Text = "";
            window.t8.Text = "";


        }
        [RelayCommand]
        public void UploadPhoto()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                ImageStudent = new BitmapImage(new Uri(dialog.FileName));

                MessageBox.Show("Imgae successfuly uploded!", "successfull");
            }
        }
        private bool ValidateFields()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(Fname))
            {
                MessageBox.Show("Please enter a first name.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                isValid = false;
            }

            if (string.IsNullOrEmpty(Lname))
            {
                MessageBox.Show("Please enter a last name.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                isValid = false;
            }

            if (string.IsNullOrEmpty(DateOfBirth))
            {
                MessageBox.Show("Please enter a date of birth.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                isValid = false;
            }

            if (string.IsNullOrEmpty(Adress))
            {
                MessageBox.Show("Please enter an address.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                isValid = false;
            }

            if (ImageStudent == null)
            {
                MessageBox.Show("Please uplad an image.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                isValid = false;
            }

           
            if (gpa < 0 || gpa > 4)
            {
                MessageBox.Show("GPA value must be between 0 and 4.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                isValid= false;
            }
            return isValid;
        }
    }


}