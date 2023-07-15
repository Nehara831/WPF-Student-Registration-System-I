
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace student_reg_system.Models
{
    public class Student
    {
        
        public int StudentIDStudent { get; set; }

        public string FirstNameStudent { get; set; }
        public string LastNameStudent { get; set; }
        public string DateofBirthStudent { get; set; }
        public string AdressStudent { get; set; }
        public BitmapImage Image { get; set; }
        public double GPA { get; set; }

        
        public String ImagePath
        {
            get { return $"/Models/Images/{Image}"; }
        }


        public Student(int id,int age, string firstName, string lastName, string adress,string dateOfBirth, BitmapImage image,string email,double gPA)
        {
            StudentIDStudent = id;
            FirstNameStudent = firstName;
            LastNameStudent = lastName;
            DateofBirthStudent = dateOfBirth;
            Image = image;
            AdressStudent = adress;
           
            GPA = gPA;


        }
        public Student() { }

        public Student(int id, int age, string firstName, string lastName, string adress, string dateOfBirth, BitmapImage image, string email)
        {
            StudentIDStudent = id;
            FirstNameStudent = firstName;
            LastNameStudent = lastName;
            DateofBirthStudent = dateOfBirth;
            Image = image;
            AdressStudent = adress;
            
            


        }


    }
}