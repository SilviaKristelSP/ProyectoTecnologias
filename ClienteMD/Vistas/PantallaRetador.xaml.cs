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

namespace ClienteMD.Vistas
{
    /// <summary>
    /// Interaction logic for PantallaAdivinador.xaml
    /// </summary>
    public partial class PantallaRetador : Window
    {
        Partida partidaCreada;
        Jugador retador;
        Service1Client service1;
        int intentosRestantes = 6;
        public PantallaRetador(Partida partida, Jugador jugador)
        {
            InitializeComponent();
            service1 = new Service1Client();
            retador = jugador;
            partidaCreada = partida;
            Pista.Text = partida.Pista;
            NumeroLetras.Text = partida.Palabra.Length.ToString();
            PalabraSecreta.Text = partida.Palabra;
            IntentosRestantes.Text = intentosRestantes.ToString();
        }

        private void moverVentana(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void imagenGano()
        {
            PartidaInicio.Visibility = Visibility.Hidden;
            Partida1.Visibility = Visibility.Hidden;
            Partida2.Visibility = Visibility.Hidden;
            Partida3.Visibility = Visibility.Hidden;
            Partida4.Visibility = Visibility.Hidden;
            Partida5.Visibility = Visibility.Hidden;
            PartidaPerdio.Visibility = Visibility.Hidden;
            PartidaGano.Visibility = Visibility.Visible;
        }

        private void ocultarImagenes()
        {
            switch (intentosRestantes)
            {
                case 5:
                    PartidaInicio.Visibility = Visibility.Hidden;
                    Partida1.Visibility = Visibility.Visible;
                    break;
                case 4:
                    Partida1.Visibility = Visibility.Hidden;
                    Partida2.Visibility = Visibility.Visible;
                    break;
                case 3:
                    Partida2.Visibility = Visibility.Hidden;
                    Partida3.Visibility = Visibility.Visible;
                    break;
                case 2:
                    Partida3.Visibility = Visibility.Hidden;
                    Partida4.Visibility = Visibility.Visible;
                    break;
                case 1:
                    Partida4.Visibility = Visibility.Hidden;
                    Partida5.Visibility = Visibility.Visible;
                    break;
                case 0:
                    Partida5.Visibility = Visibility.Hidden;
                    PartidaPerdio.Visibility = Visibility.Visible;
                    break;

            }
        }

        private async void clickAbandonarPartida(object sender, RoutedEventArgs e)
        {
            /*for(int i = 0; i < intentosRestantes; i++)
            {
                intentosRestantes--;
                ocultarImagenes();
                await Task.Delay(3500);
            }*/
            PaginaPrincipal paginaPrincipal = new PaginaPrincipal(retador);
            this.Close();
            paginaPrincipal.Show();
        }
    }
}
