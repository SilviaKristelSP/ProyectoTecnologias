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
    /// Interaction logic for PaginaPrincipal.xaml
    /// </summary>
    public partial class PaginaPrincipal : Window
    {
        Jugador jugador;
        Service1Client servicio;
        
        public PaginaPrincipal(Jugador jugadorLogeado)
        {
            InitializeComponent();
            jugador = jugadorLogeado;
            servicio = new Service1Client();
            mostrarPartidasDisponibles();
        }

        private async void mostrarPartidasDisponibles()
        {
            Partida[] partidas = await servicio.recuperarPartidasDisponiblesAsync();
            partidasDisponibles.ItemsSource = null;
            partidasDisponibles.ItemsSource = partidas;
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

        private async void clickEntrarPartida(object sender, RoutedEventArgs e)
        {
            Partida partidaSeleccionada = (Partida)partidasDisponibles.SelectedItem;
            if (partidaSeleccionada != null)
            {
                String estadoPartida = await servicio.verificarEstadoPartidaAsync(partidaSeleccionada.IdPartida);
                if (estadoPartida.Equals("En Espera"))
                {
                    bool unirseAPartida = false;
                    unirseAPartida = await servicio.unirseAPartidaAsync(partidaSeleccionada.IdPartida, jugador.Id);
                    if (unirseAPartida)
                    {
                        PantallaAdivinador pantallaAdivinador = new PantallaAdivinador(partidaSeleccionada, jugador);
                        pantallaAdivinador.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al unirse en la partida", "Error en la partida");
                        mostrarPartidasDisponibles();
                    }
                }
                else
                {
                    MessageBox.Show("Partida iniciada, selecciona otra partida", "Error en la partida");
                    mostrarPartidasDisponibles();
                }
                
            }
            else
            {
                MessageBox.Show("Selecciona una partida de la lista", "Partida invalida");
                mostrarPartidasDisponibles();
            }
            
        }



        private void clickCrearPartida(object sender, RoutedEventArgs e)
        {
            CreacionPartida creacionPartida = new CreacionPartida(jugador);
            this.Close();
            creacionPartida.Show();
        }

        private void clickRecargarPartida(object sender, RoutedEventArgs e)
        {
            mostrarPartidasDisponibles();
        }
    }
}
