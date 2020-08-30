using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quiz_WPF
{
    /// <summary>
    /// Lógica de interacción para Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public string[] Names { get; set; }
        public Home()
        {
            InitializeComponent();
            Names = new string[] { "Superior", "Jungla", "Medio", "Tirador", "Soporte" };
            DataContext = this;
        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string championName = txtChampion.Text;
            string rol = cmbRol.Text.ToString();
            if (championName.ToLower()=="vayne" && rol=="Superior")
            {
                txtResults.Text += championName + " (" + rol + ") => Yasuo, Malphite, Teemo" + "\n";
            }
            else if (championName.ToLower() == "vayne" && rol == "Tirador")
            {
                txtResults.Text += championName + " (" + rol + ") => Caitlyn, Veigar, Twitch" + "\n";
            }
            else if (championName.ToLower() == "mordekaiser" && rol == "Superior")
            {
                txtResults.Text += championName + " (" + rol + ") => Yone, Fiora, Vayne" + "\n";
            }
            else if (championName.ToLower() == "mordekaiser" && rol == "Jungla")
            {
                txtResults.Text += championName + " (" + rol + ") => Olaf, Maestro yi, Warwick" + "\n";
            }
            else if (championName.ToLower() == "mordekaiser" && rol == "Medio")
            {
                txtResults.Text += championName + " (" + rol + ") => Yone, Xerath, Qiyana" + "\n";
            }
            else if (championName.ToLower() == "nautilus" && rol == "Soporte")
            {
                txtResults.Text += championName + " (" + rol + ") => Brand, Rakan, Lux" + "\n";
            }
            else
            {
                MessageBox.Show("Campeón o posición para este campeón no disponible en estos momentos");
            }
            string advice = lblAdvice.Content.ToString();
            if (chkAdvices.IsChecked == true)
            {
                chkAdvices.IsChecked = false;
            }
            else
            {
                advice = "";
            }
            string year = clnConsult.DisplayDate.Year.ToString();
            string month = clnConsult.DisplayDate.Month.ToString();
            string day = clnConsult.DisplayDate.Day.ToString();
            string time = DateTime.Now.ToLongTimeString();
            txtResults.Text += advice + "Fecha de consulta: " + year + "/" + month + "/" + day + " " + time + "\n" + "\n";
        }

        private void chkAdvices_Checked(object sender, RoutedEventArgs e)
        {
            string championName = txtChampion.Text.ToLower();
            CheckBox chkAdvices = sender as CheckBox;
            if (chkAdvices.IsChecked.Value && championName == "vayne")
            {
                lblAdvice.Content = "Consejo: No le pelees solo si eres tanque. Ella puede alcanzarte mucho más fácil y acabar con tu campeón, ya que ella es una mata tanque" + "\n";
            }
            if (chkAdvices.IsChecked.Value && championName == "mordekaiser")
            {
                lblAdvice.Content = "Consejo: Usa items que te sirvan para heridas graves para reducir la curación de la habilidad “Indestructible” de Mordekaiser" + "\n";
            }
            if (chkAdvices.IsChecked.Value && championName == "nautilus")
            {
                lblAdvice.Content = "Consejo: No esté en medio de su ultimate. La ultimate de Nautilus es una onda expansiva que lanza a sus enemigos al aire, mientras más se aleja al que se le otorgo más ondas apareceran" + "\n";
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = (MainWindow)Window.GetWindow(this);
            w.frameMain.NavigationService.Navigate(new Login());
        }

        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            txtResults.Text = "";
        }
    }
}
