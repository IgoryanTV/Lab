using Lab.Core;
using Lab.Core.Enums;
using System;
using System.Windows;

namespace Lab
{
    /// <summary>
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        public Employee Employee { get; private set; }
        public EmployeeWindow(Employee employee)
        {
            InitializeComponent();

            sexComboBox.ItemsSource = Enum.GetValues(typeof(SexEnum));
            familyComboBox.ItemsSource = Enum.GetValues(typeof(FamilyStatusEnum));
            childrenComboBox.ItemsSource = Enum.GetValues(typeof(HasChildEnum));
            datePicker.Text = DateTime.Today.ToShortDateString();

            Employee = employee;
            DataContext = Employee;

            datePicker.Text = employee.Date.ToShortDateString();

            sexComboBox.SelectedItem = employee.Sex;
            familyComboBox.SelectedItem = employee.FamilyStatus;
            childrenComboBox.SelectedItem = employee.HasChildren;
        }

        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = (DateTime)datePicker.SelectedDate;
            DateOnly dateOnly = DateOnly.FromDateTime(date);
            Employee.Date = dateOnly;
            DialogResult = true;
        }
    }
}
