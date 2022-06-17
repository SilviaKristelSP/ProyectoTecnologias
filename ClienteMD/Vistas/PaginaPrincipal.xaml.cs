using System;
using System.Collections.Generic;
using System.Linq;
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

namespace ClienteMD.Vistas
{
    /// <summary>
    /// Interaction logic for PaginaPrincipal.xaml
    /// </summary>
    public partial class PaginaPrincipal : Window
    {
        public PaginaPrincipal()
        {
            InitializeComponent();
        }

        private void moverVentana(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void clickCerrarSesion(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.Show();
        }

        private void clickPerfil(object sender, RoutedEventArgs e)
        {

        }

        private void clickEntrarPartida(object sender, RoutedEventArgs e)
        {

        }

        private void clickCrearPartida(object sender, RoutedEventArgs e)
        {

        }
    }
}
