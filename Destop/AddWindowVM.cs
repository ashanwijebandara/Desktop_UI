using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Pipes;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Destop
{
    public partial class AddWindowVM: ObservableObject
    {
       
        [ObservableProperty]
       // [NotifyPropertyChangedFor(nameof(P1))]
        public string? firstName;

        [ObservableProperty]
       // [NotifyPropertyChangedFor(nameof(P1))]
        public string? lastName;

        [ObservableProperty]
       // [NotifyPropertyChangedFor(nameof(P1))]
        public string gpa;

        [ObservableProperty]
       // [NotifyPropertyChangedFor(nameof(P1))]
        public string? birthday;

        [ObservableProperty]
       // [NotifyPropertyChangedFor(nameof(P1))]
        public string? imageName;

        [ObservableProperty]
        public string? address;
        public AddWindowVM(Student prsn) {
           P1= prsn;
            firstName = P1.FirstName;
            lastName = P1.LastName;
            gpa = P1.GPA;
            birthday =P1.Birthday;
            imageName =P1.Image;
            address=P1.Address;
        }
        public AddWindowVM() { }

        public Student P1 { get; private set; }
        public Action CloseWindow { get; internal set; }
        
        [RelayCommand]
        public void AddStudent()
        {
            if (P1 == null)
            {
                P1 = new Student()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    GPA = gpa,
                    Birthday = birthday,
                    Image = imageName,
                    Address = address
                };
            }
            else
            {
                P1.FirstName = firstName;
                P1.LastName = lastName;
                P1.GPA = gpa;
                P1.Birthday = birthday;
                P1.Image = imageName;
                P1.Address = address;
            }
            if (P1.FirstName != null)
            {

                CloseWindow();
            }
            
        }
        private void CloseCurrentWindow()
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item.DataContext == this)
                {
                    item.Close();
                }
            }
        }
        [RelayCommand]
        public void close()
        {
            CloseCurrentWindow();
        }
    }
}
