using Lab.Core;
using System.Windows;
using System.Windows.Controls;
using Lab.EF;
using Microsoft.EntityFrameworkCore;

namespace Lab.Pages
{
    /// <summary>
    /// Interaction logic for DataGridPage.xaml
    /// </summary>
    public partial class DataGridPage : Page
    {
        EmployeeContext EmployeeContext = new EmployeeContext();
        public DataGridPage()
        {
            InitializeComponent();
            // гарантируем, что база данных создана
            EmployeeContext.Database.Migrate();
            // загружаем данные из БД
            EmployeeContext.Employees.Load();
            // и устанавливаем данные в качестве контекста
            DataContext = EmployeeContext.Employees.Local.ToObservableCollection();
            employeeList.DataContext = DataContext;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow EmployeeWindow = new EmployeeWindow(new Employee());
            if (EmployeeWindow.ShowDialog() == true)
            {
                Employee Employee = EmployeeWindow.Employee;
                EmployeeContext.Employees.Add(Employee);
                EmployeeContext.SaveChanges();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Employee? employee = employeeList.SelectedItem as Employee;
            // если ни одного объекта не выделено, выходим
            if (employee is null) return;

            DeleteWindow deleteWindow = new DeleteWindow();

            if (deleteWindow.ShowDialog() == true)
            {
                EmployeeContext.Employees.Remove(employee);
                EmployeeContext.SaveChanges();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Employee? employee = employeeList.SelectedItem as Employee;
            // если ни одного объекта не выделено, выходим
            if (employee is null) return;

            EmployeeWindow EmployeeWindow = new EmployeeWindow(new Employee
            {
                Id = employee.Id,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                Date = employee.Date,
                Sex = employee.Sex,
                Age = employee.Age,
                FamilyStatus = employee.FamilyStatus,
                HasChildren = employee.HasChildren,
                Job = employee.Job,
                Degree = employee.Degree,
            });

            if (EmployeeWindow.ShowDialog() == true)
            {
                // получаем измененный объект
                employee = EmployeeContext.Employees.Find(EmployeeWindow.Employee.Id);
                if (employee != null)
                {
                    employee.LastName = EmployeeWindow.Employee.LastName;
                    employee.FirstName = EmployeeWindow.Employee.FirstName;
                    employee.MiddleName = EmployeeWindow.Employee.MiddleName;
                    employee.Date = EmployeeWindow.Employee.Date;
                    employee.Sex = EmployeeWindow.Employee.Sex;
                    employee.Age = EmployeeWindow.Employee.Age;
                    employee.FamilyStatus = EmployeeWindow.Employee.FamilyStatus;
                    employee.HasChildren = EmployeeWindow.Employee.HasChildren;
                    employee.Job = EmployeeWindow.Employee.Job;
                    employee.Degree = EmployeeWindow.Employee.Degree;

                    EmployeeContext.SaveChanges();
                    employeeList.Items.Refresh();
                }
            }
        }
    }
}
