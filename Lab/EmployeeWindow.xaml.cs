using Lab.Core;
using Lab.Core.Enums;
using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace Lab
{
    /// <summary>
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        Regex regex = new Regex("^[A-ZА-Я][a-zA-Zа-яА-Я]+$");

        bool check1 = false;
        bool check2 = false;
        bool check3 = true;

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
            if (Employee.MiddleName != null)
                hasMiddleName_CheckBox.IsChecked = true;

            sexComboBox.SelectedItem = employee.Sex;
            familyComboBox.SelectedItem = employee.FamilyStatus;
            childrenComboBox.SelectedItem = employee.HasChildren;
        }

        void Accept_Click(object sender, RoutedEventArgs e)
        {
            if(check1 && check2 && check3)
            {
                DateTime date = (DateTime)datePicker.SelectedDate;
                DateOnly dateOnly = DateOnly.FromDateTime(date);
                Employee.Date = dateOnly;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Одно или несколько полей заполнено неверно");
            }
        }

        private void lastNameText_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (regex.IsMatch(lastNameText.Text))
            {
                lastNameTextBlock.Visibility = Visibility.Hidden;
                check1 = true;
            }
            else
            {
                lastNameTextBlock.Visibility = Visibility.Visible;
                check1 = false;
            }
        }

        private void firstNameText_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (regex.IsMatch(firstNameText.Text))
            {
                firstNameTextBlock.Visibility = Visibility.Hidden;
                check2 = true;
            }
            else
            {
                firstNameTextBlock.Visibility = Visibility.Visible;
                check2 = false;
            }
        }

        private void middleNameText_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (regex.IsMatch(middleNameText.Text))
            {
                middleNameTextBlock.Visibility = Visibility.Hidden;
                check3 = true;
            }
            else
            {
                middleNameTextBlock.Visibility = Visibility.Visible;
                check3 = false;
            }
        }

        private void hasMiddleName_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            middleNameText.IsEnabled = true;
            middleNameTextBlock.Visibility = Visibility.Visible;
            middleNameText.Text = null;
            check3 = false;
        }

        private void hasMiddleName_CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            middleNameText.IsEnabled = false;
            middleNameTextBlock.Visibility = Visibility.Hidden;
            middleNameText.Text = null;
            check3 = true;
        }
    }
}
