using Lab.EF;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using System.Windows.Input;
using System.Windows.Controls.Primitives;
using System;
using Lab.Game;

namespace Lab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeContext db = new EmployeeContext();
        public MainWindow()
        {
            InitializeComponent();

            //Loaded += MainWindow_Loaded;
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        private void btnHome_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnHome;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Home";
            }
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Pages/DataGridPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnHome_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnGame_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Pages/GamePage.xaml", UriKind.RelativeOrAbsolute));
            GameWindow gmWindow = new GameWindow();
            gmWindow.ShowDialog();
        }

        private void btnGame_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnGame;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Bored";
            }
        }

        private void btnGame_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        //private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        //{
        //    // гарантируем, что база данных создана
        //    db.Database.Migrate();
        //    // загружаем данные из БД
        //    db.Employees.Load();
        //    // и устанавливаем данные в качестве контекста
        //    DataContext = db.Employees.Local.ToObservableCollection();

        //    //employeeList.DataContext = DataContext;
        //}
    }
}
