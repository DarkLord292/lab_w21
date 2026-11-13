using System;
using System.IO;
using System.Windows;
using LogicTier;

namespace PresentationTier
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "students.txt");
            if (!File.Exists(path))
            {
                path = @"students.txt";
            }

            try
            {
                DataContext = new University(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки: " + ex.Message);
                DataContext = new University(""); // пустой
            }
        }
    }
}