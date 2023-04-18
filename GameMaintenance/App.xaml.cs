using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GameMaintenance
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void JatekKarb(MainWindow window)
        {
            if (GameMaintenance.MainWindow.Jogosultsag == 9)
            {
                window.JatekokAdatai.IsEnabled = true;
            }
        }
        private void Login(object sender, StartupEventArgs e)
        {
            Login login = new Login();
            Application.Current.MainWindow = login;
            MainWindow window = new MainWindow();
            login.ShowDialog();
            if (GameMaintenance.MainWindow.UserName == "")
            {
                Application.Current.Shutdown();
            }
            else
            {
                MessageBox.Show("Sikeresen bejelentkezve: " + GameMaintenance.MainWindow.UserName);
                JatekKarb(window);
                window.Show();
            }
        }
    }
}
