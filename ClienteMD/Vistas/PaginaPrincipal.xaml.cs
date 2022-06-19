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
using ClienteMD.ServiceReference1;
using System.Windows.Threading;

namespace ClienteMD.Vistas
{
    /// <summary>
    /// Interaction logic for PaginaPrincipal.xaml
    /// </summary>
    public partial class PaginaPrincipal : Window
    {
        Jugador jugador;
        Service1Client servicio;
        DispatcherTimer dispachadorDeTiempo;

        public PaginaPrincipal(Jugador jugadorLogeado)
        {
            InitializeComponent();
            jugador = jugadorLogeado;
            servicio = new Service1Client();
        }

        private void mostrarPartidasDisponibles()
        {
            
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
            Perfil perfil = new Perfil(jugador.Id);
            this.Close();
            perfil.Show();
        }

        private void clickEntrarPartida(object sender, RoutedEventArgs e)
        {
            PantallaAdivinador pantallaAdivinador = new PantallaAdivinador();
            this.Close();
            pantallaAdivinador.Show();
        }

        private void clickCrearPartida(object sender, RoutedEventArgs e)
        {
            CreacionPartida creacionPartida = new CreacionPartida(jugador);
            this.Close();
            creacionPartida.Show();
        }
    }
}
