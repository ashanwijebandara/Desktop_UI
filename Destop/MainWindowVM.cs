using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Destop
{
    public partial class MainWindowVM: ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student> students;
        [ObservableProperty]
        public Student selected=null;

        [RelayCommand]
        public void RemoveStudent()
        {
            if (selected != null)
            {
                students.Remove(selected);
            }
            else
            {
                MessageBox.Show("Select Student before Delete.", "Error ! ");


            }
        }
        [RelayCommand]
        public void AddStudent()
        {
            var person = new AddWindowVM();
            AddWindow window = new AddWindow(person);
            window.ShowDialog();
            if (person.P1.FirstName != null)
            {
                students.Add(person.P1);
            }
        }
        [RelayCommand]
        public void EditStudent()
        {
            if (selected != null)
            {
                var edit = new AddWindowVM(selected);
                var window = new AddWindow(edit);
                window.ShowDialog();
                int position = students.IndexOf(selected);
                students.Remove(selected);
                students.Insert(position, edit.P1);

            }
            else
            {
                MessageBox.Show("Select Student before Edit.", "Error ! ");
            }

        }
        public MainWindowVM()
        {
            students = new ObservableCollection<Student>();

            students.Add(new Student("2.3", "Tom", "Brown", "1.png", "2000.10.24","Kegalle"));
            students.Add(new Student("3.7", "Will", "Smith", "2.png", "2001.10.24","Kandy"));
            students.Add(new Student("1.3", "Steve", "Roge", "3.png", "2002.10.24","Colombo"));
            students.Add(new Student("3.3", "McClum", "Brenden", "4.png", "2005.10.24","Mannar"));
            students.Add(new Student("2.8", "George", "Stuward", "5.png", "1999.11.24","Galle"));
           

                       
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
