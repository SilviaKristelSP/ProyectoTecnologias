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
    /// Interaction logic for PantallaAdivinador.xaml
    /// </summary>
    public partial class PantallaRetador : Window
    {
        Partida partidaCreada;
        Jugador retador;
        Service1Client service1;
        int intentosRestantes = 6;
        DispatcherTimer actualizador;
        int idPartida;
        int numeroRepeticiones = 0;
   

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
            idPartida = partida.IdPartida;
            NombreUsuario.Text = "";
            actualizarTurnos();
            
            
        }

       

        private void actualizarTurnos()
        {
            actualizador = new DispatcherTimer();
            actualizador.Interval = new TimeSpan(0, 0, 0, 3);
            actualizador.Tick += (a, b) =>
            {
                actualizarDatos();
            };
            actualizador.Start();
        }

        
        private async void actualizarDatos()
        {
            
            try
            {
                Turno turno = await service1.recuperarTurnoAsync(idPartida);
                int estadoGanador = await service1.recuperarEstadoGanadorAsync(idPartida);
                if (turno != null)
                {
                    
                
                    LetraElegida.Text = turno.Letra;
                    intentosRestantes = turno.IntentosRestantes;
                    IntentosRestantes.Text = turno.IntentosRestantes.ToString();
                    if (numeroRepeticiones == 0)
                    {
                        String resultado = await service1.recuperarNombreAdivinadorAsync(idPartida);
                        
                        if (!resultado.Equals(""))
                        {
                            NombreUsuario.Text = resultado;
                            numeroRepeticiones = 1;
                        }
                    }
                    
                    ocultarImagenes();
                }
                else if(estadoGanador != 0)
                {
                    actualizador.Stop();
                    if (estadoGanador == -1)
                    {
                        
                        MessageBox.Show("La partida fue abandonada por el adivinador");
                        cerrarVentana();
                    }
                    else if (estadoGanador == 1)
                    {
                        MessageBox.Show("El adivinador logró acertar la palabra", "Perdiste");
                        imagenGano();
                        cerrarVentana();
                    }
                }
            }catch (Exception ex)
            {
                Console.WriteLine("Error al recuperar");
            }
            
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
        private void cerrarVentana()
        {
            actualizador.Stop();
            PaginaPrincipal paginaPrincipal = new PaginaPrincipal(retador);
            paginaPrincipal.Show();
            this.Close();
        }
        private async void clickAbandonarPartida(object sender, RoutedEventArgs e)
        {
            var confirmacionEliminacion = MessageBox.Show("¿Realmente quiere abandonar la partida?",
                "Confirmación", MessageBoxButton.YesNo);

            if (confirmacionEliminacion == MessageBoxResult.Yes)
            {
                if (await service1.eliminarPartidaPerdidaOAbandonadaAsync(idPartida))
                {
                    
                    MessageBox.Show("Partida abandonada", "Abandonar partida");
                    cerrarVentana();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error", "Error");
                    cerrarVentana();
                }

            } 
        }
    }
}
