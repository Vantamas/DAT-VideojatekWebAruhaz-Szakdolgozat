using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GameMaintenance
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        int szamlalo = 3;
        public Login()
        {
            InitializeComponent();
        }

        private string SaltRequest(string UserName)
        {
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Encoding = System.Text.Encoding.UTF8;
            try
            {
                string result = client.UploadString("https://localhost:5001/Login/SaltRequest/" + UserName, "POST");
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private string[] LoginUser(string nev, string tmpHash)
        {
            string[] valasz = new string[3];
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Encoding = System.Text.Encoding.UTF8;
            string url = $"https://localhost:5001/Login?nev={nev}&tmpHash={tmpHash}";
            try
            {
                string result = client.UploadString(url, "POST");
                valasz = JsonConvert.DeserializeObject<string[]>(result);
                return valasz;
            }
            catch (Exception ex)
            {
                valasz[0] = ex.Message;
                valasz[1] = "";
                return valasz;
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string salt = SaltRequest(UserName.Text);
            string tmpHash = MainWindow.CreateSHA256(Password.Password + salt);
            string[] result = LoginUser(UserName.Text, tmpHash);
            if (szamlalo > 0)
            {
                if (result[1] != "")
                {
                    GameMaintenance.MainWindow.uId = result[0];
                    GameMaintenance.MainWindow.UserName = result[1];
                    GameMaintenance.MainWindow.Jogosultsag = int.Parse(result[2]);
                    MainWindow window1 = new MainWindow();
                    window1.ShowDialog();
                    window1.Close();
                    this.Close();
                    
                    

                }
                else
                {
                    szamlalo--;
                    MessageBox.Show($"Sikertelen bejelentkezés!");
                    if (szamlalo == 0)
                    {
                        this.Close();
                    }
                }
            }
        }

        //private void UserName_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (UserName.Text == "")
        //    {
        //        ImageBrush userNameTextImageBrush = new ImageBrush();
        //        userNameTextImageBrush.ImageSource = new BitmapImage(new Uri(@"Images\fn.jpg", UriKind.Relative));
        //        userNameTextImageBrush.AlignmentX = AlignmentX.Left;
        //        userNameTextImageBrush.AlignmentY = AlignmentY.Center;
        //        userNameTextImageBrush.Stretch = Stretch.None;
        //        UserName.Background = userNameTextImageBrush;
        //    }
        //    else
        //    {
        //        UserName.Background = null;
        //    }
        //}

        //private void Password_TextChanged(object sender, RoutedEventArgs e)
        //{
        //    if (Password.Password == "")
        //    {
        //        ImageBrush passwordTextImageBrush = new ImageBrush();
        //        passwordTextImageBrush.ImageSource = new BitmapImage(new Uri(@"Images\pw.jpg", UriKind.Relative));
        //        passwordTextImageBrush.AlignmentX = AlignmentX.Left;
        //        passwordTextImageBrush.AlignmentY = AlignmentY.Center;
        //        passwordTextImageBrush.Stretch = Stretch.None;
        //        Password.Background = passwordTextImageBrush;
        //    }
        //    else
        //    {
        //        Password.Background = null;
        //    }
        //}

    }
}

