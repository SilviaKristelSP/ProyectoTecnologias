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

namespace AplicacionCliente
{
    /// <summary>
    /// Lógica de interacción para PaginaPrincipal.xaml
    /// </summary>
    public partial class PaginaPrincipal : Window
    {
        public PaginaPrincipal()
        {
            InitializeComponent();
        }

        private void clicEntrarPartida(object sender, RoutedEventArgs e)
        {
            PantallaAdivinador pantallaAdivinador = new PantallaAdivinador();
            pantallaAdivinador.Show();
            this.Close();
        }

        private void clicCreaNuevaPartida(object sender, RoutedEventArgs e)
        {
            CreacionPartida creacionPartida = new CreacionPartida();
            creacionPartida.Show();
            this.Close();
        }

        private void clicVerPerfil(object sender, RoutedEventArgs e)
        {
            Perfil perfil = new Perfil();
            perfil.Show();
            this.Close();
        }

        private void clicCerrarSesion(object sender, RoutedEventArgs e)
        {
            InicioSesion inicioSesion  = new InicioSesion();
            inicioSesion.Show();
            this.Close();
        }
    }
}
