using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataGrid;
using Microsoft.Win32;
using student_reg_system.Models;
using Student_Res_Sys.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Student_Res_Sys.ViewModels
{
    public partial class EditStudentVM : ObservableObject
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
        private BitmapImage _imageStudent;
        public BitmapImage ImageStudent
        {
            get { return _imageStudent; }
            set { SetProperty(ref _imageStudent, value); }
        }
        [ObservableProperty]
        public double gpa;

        public Action CloseAction { get; internal set; }

        public Student Estudent { get; set; }
        public EditStudentVM()
        {



        }


        public EditStudentVM(Student student)
        {
            Estudent = student;
            Id = student.StudentIDStudent;
            Fname = Estudent.FirstNameStudent;
            Lname= Estudent.LastNameStudent;
            DateOfBirth = Estudent.DateofBirthStudent;
            Adress= Estudent.AdressStudent;
            Gpa = Estudent.GPA;
            ImageStudent=Estudent.Image;
           


        }


        [RelayCommand]
        public void Save()
        {

            if (ValidateFields())
            {
                Estudent.FirstNameStudent = Fname;
                Estudent.LastNameStudent = Lname;
                Estudent.DateofBirthStudent = DateOfBirth;
                Estudent.AdressStudent = Adress;
                Estudent.Image = ImageStudent;
                Estudent.GPA = Gpa;

                if (Estudent.FirstNameStudent != null)
                {

                    var window = Application.Current.Windows.OfType<EditStudent>().SingleOrDefault(x => x.IsActive);
                    window.Close();
                }
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
                isValid = false;
            }
            return isValid;
        }

    }
}
    
    

