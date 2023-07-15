using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using student_reg_system.Models;
using student_reg_system.ViewModels;
using Student_Res_Sys.Views;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Student_Res_Sys.ViewModels
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public static ObservableCollection<Student> studentList;

        [ObservableProperty]
        public Student selectedStudent;
        [ObservableProperty]
        public string searchName;

        [RelayCommand]
        public void AddStudent()
        {
            var vm = new StudentRegistrationVM();

            StudentRegistrationView window = new StudentRegistrationView(vm);
            window.ShowDialog();

            if (vm.NewStudent != null)
            {
                StudentList.Add(vm.NewStudent);
            }
            else
                return;
        }

        [RelayCommand]
        public void EditStudent()
        {
            if (SelectedStudent != null)
            {

                EditStudentVM newEditVM = new EditStudentVM(SelectedStudent);
                var window = new EditStudent(SelectedStudent);

                window.ShowDialog();


                int index = StudentList.IndexOf(SelectedStudent);
                StudentList.RemoveAt(index);
                StudentList.Insert(index, newEditVM.Estudent);

            }
            else
            {
                MessageBox.Show("Please Select a student", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        [RelayCommand]
        public void Delete()
        {
            if (SelectedStudent != null)
            {
                string st = SelectedStudent.FirstNameStudent + " " + SelectedStudent.LastNameStudent;
                StudentList.Remove(SelectedStudent);
                MessageBox.Show($"{st} is Deleted Successfully");

            }
            else
            {
                MessageBox.Show("Plese Select a Student before Deleting.", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);


            }
        }
        [RelayCommand]
        public void Search()
        {
           
                ObservableCollection<Student> stuList = new ObservableCollection<Student>();
                foreach (var st in StudentList)
                {

                    if (string.Equals(st.FirstNameStudent, SearchName, StringComparison.OrdinalIgnoreCase) || string.Equals(st.LastNameStudent, SearchName, StringComparison.OrdinalIgnoreCase))
                    {
                        stuList.Add(st);
                    }

                }
                if(stuList.Count > 0) { StudentList = new ObservableCollection<Student>(stuList); }
            else MessageBox.Show("No matching student found ", "Error",MessageBoxButton.OK,MessageBoxImage.Error);







        }
        public MainWindowVM()
        {
            StudentList = new ObservableCollection<Student>();
            BitmapImage image1 = new BitmapImage(new Uri("C:\\Users\\User\\OneDrive\\Desktop\\WPF-DataTable-Dashboard-master\\Models\\Images\\1.png", UriKind.Absolute));
            StudentList.Add(new Student(1234, 12, "Tharushi", "Nehara", "Matara", "09/09/1998", image1, "tnehara831@gmail.com"));
            BitmapImage image2 = new BitmapImage(new Uri("C:\\Users\\User\\OneDrive\\Desktop\\WPF-DataTable-Dashboard-master\\Models\\Images\\2.png", UriKind.Absolute));
            StudentList.Add(new Student(1235, 12, "Oshan", "Devinda", "Gampaha", "09/09/1998", image2, "oshandevinda@gmail.com"));
            BitmapImage image3 = new BitmapImage(new Uri("C:\\Users\\User\\OneDrive\\Desktop\\WPF-DataTable-Dashboard-master\\Models\\Images\\4.png", UriKind.Absolute));
            StudentList.Add(new Student(1236, 12, "Ashen", "Nethsara", "Colombo", "09/09/1998", image3, "ashennethsara@gmail.com"));
            BitmapImage image4 = new BitmapImage(new Uri("C:\\Users\\User\\OneDrive\\Desktop\\WPF-DataTable-Dashboard-master\\Models\\Images\\5.png", UriKind.Absolute));
            StudentList.Add(new Student(1234, 12, "Lathini", "Navoda", "Matara", "09/09/1998", image4, "lathininavoda@gmail.com"));
        }
    }

}
