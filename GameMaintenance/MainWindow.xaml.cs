using GameMaintenance.Models;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace GameMaintenance
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int ID = 0;
        bool beolvasva = false;

        private byte[] imageBytes;

        public MainWindow()
        {
            InitializeComponent();
            if (!beolvasva)
            {
                AdatBeolvasas();

            }
        }


        private string Ellenorzes()
        {
            return "";
        }

        private void AdatBeolvasas()
        {
            List<Models.Osszesjatek> list = new List<Models.Osszesjatek>();
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Encoding = Encoding.UTF8;
            string url = $"https://localhost:5001/api/jatek/";

            try
            {
                string result = client.DownloadString(url);
                list = JsonConvert.DeserializeObject<List<Models.Osszesjatek>>(result);
            }
            catch (Exception ex)
            { }
            JatekokAdatai.ItemsSource = list;
            beolvasva = true;


        }

        public static Felhasznalok loggedInUser = new Felhasznalok();
        public static string uId = "";
        public static string UserName = "";
        public static int Jogosultsag = 0;

        static int SaltLength = 64;
        public static string GenerateSalt()
        {
            Random random = new Random();
            string karakterek = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string salt = "";
            for (int i = 0; i < SaltLength; i++)
            {
                salt += karakterek[random.Next(karakterek.Length)];
            }
            return salt;
        }

        public static string CreateSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] data = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }



        private void Exit(object sender, RoutedEventArgs e)
        {
            //Application.Current.Shutdown();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string result;
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Encoding = System.Text.Encoding.UTF8;
            try
            {
                result = client.UploadString("https://localhost:5001/Logout/" + uId, "POST");
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            MessageBox.Show($"{result}\nViszlát " + UserName + "!");
        }

        private void Jatekok_adatai_Changed(object sender, SelectionChangedEventArgs e)
        {
            
            try
            {
                Osszesjatek osszesjatek = JatekokAdatai.SelectedItems[0] as Osszesjatek;
                ID = osszesjatek.Id;
                txb_Nev.Text = osszesjatek.Nev;
                txb_Kategoria.Text = osszesjatek.Kategoria;
                txb_Ar.Text = osszesjatek.Ar.ToString();
                txb_Leiras.Text = osszesjatek.Leiras;
                txb_Kategoria.Text = osszesjatek.Kategoria;
                //txb_Kep.Text = osszesjatek.Kep.ToString();
                txb_Megjelenes.Text = osszesjatek.Megjelenes.ToString();
            }
            catch (Exception ex)
            {
                AdatBeolvasas();
            }
        }

        private void btn_Modositas_Click(object sender, RoutedEventArgs e)
        {
           

            string uzenet = Ellenorzes();
            if (uzenet == "")
            {
                if (ID != 0)
                {
                    Models.Osszesjatek osszesjatek = new Models.Osszesjatek();
                    osszesjatek.Id = ID;
                    osszesjatek.Nev = txb_Nev.Text;
                    osszesjatek.Kategoria = txb_Kategoria.Text;
                    osszesjatek.Ar = int.Parse(txb_Ar.Text);
                    osszesjatek.Leiras = txb_Leiras.Text.ToString();
                    //txb_Kep.Text = osszesjatek.Kep.ToString();
                    
                    txb_Megjelenes.Text = osszesjatek.Megjelenes.ToString();
                    WebClient client = new WebClient();
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Encoding = Encoding.UTF8;
                    string url = $"https://localhost:5001/api/jatek/";
                    try
                    {
                        string result = client.UploadString(url, "PUT", JsonConvert.SerializeObject(osszesjatek));
                        MessageBox.Show(result);
                        AdatBeolvasas();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show(uzenet);
            }
        }




        private void btn_Torles_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Biztosan törli a(z) {txb_Nev.Text} nevű játékot?",
                    "Játék törlése",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Models.Osszesjatek osszesjatek = new Models.Osszesjatek();
                //osszesjatek.Id = ID;
                osszesjatek.Id = ID;
                osszesjatek.Nev = txb_Nev.Text;
                osszesjatek.Kategoria = txb_Kategoria.Text;
                osszesjatek.Ar = int.Parse(txb_Ar.Text);
                osszesjatek.Leiras = txb_Leiras.Text.ToString();
                //txb_Kep.Text = osszesjatek.Kep.ToString();
                txb_Megjelenes.Text = osszesjatek.Megjelenes.ToString();
                WebClient client = new WebClient();
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                client.Encoding = Encoding.UTF8;
                string url = $"https://localhost:5001/api/jatek/?id={ID}";
                try
                {
                    string result = client.UploadString(url, "DELETE", "");
                    MessageBox.Show("Sikeres törlés!");
                    AdatBeolvasas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }



        


        private void btnUploadImage_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png";

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;

                // Display the selected image in the preview
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(filename);
                bitmap.EndInit();
                imgPreview.Source = bitmap;

                // Read the selected image into a byte array
                using (FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        imageBytes = reader.ReadBytes((int)stream.Length);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string connectionString = "datasource=localhost;port=3306;username=root;password=;database=jatekshop;";


                string sql = "INSERT INTO osszesjatek (nev, kategoria, ar, leiras, kep, megjelenes) VALUES (@Nev, @Kategoria, @Ar, @Leiras, @Kep, @Megjelenes)";


                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();


                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Nev", txb_Nev.Text);
                        command.Parameters.AddWithValue("@Kategoria", txb_Kategoria.Text);
                        command.Parameters.AddWithValue("@Ar", int.Parse(txb_Ar.Text));
                        command.Parameters.AddWithValue("@Leiras", txb_Leiras.Text);
                        command.Parameters.AddWithValue("@Kep", imageBytes);
                        command.Parameters.AddWithValue("@Megjelenes", txb_Megjelenes.Text.ToString());


                        int rowsAffected = command.ExecuteNonQuery();

                        MessageBox.Show("Sikeres hozzáadás!");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

    }
}

