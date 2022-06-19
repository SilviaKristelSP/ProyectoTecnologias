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
    /// Interaction logic for Perfil.xaml
    /// </summary>
    public partial class Perfil : Window
    {
        Service1Client servicio;
        int idDelJugador;
        Jugador datosDelPerfil;

        public Perfil(int idJugador)
        {
            InitializeComponent();
            servicio = new Service1Client();
            idDelJugador = idJugador;
            mostrarDatosPerfil();
            cargarPartidasGanadas();
        }

        private async void mostrarDatosPerfil()
        {
            datosDelPerfil = await servicio.obtenerDatosJugadorAsync(idDelJugador);
            if(datosDelPerfil != null)
            {
                tbCorreo.Text = datosDelPerfil.Email;
                DateTime fechaAux = Convert.ToDateTime(datosDelPerfil.FechaNacimiento);
                tbFechaNacimiento.Text = fechaAux.ToString("dd/MM/yyyy");
                tbTelefono.Text = datosDelPerfil.Telefono;
                tbNombreCompleto.Text = datosDelPerfil.Nombre;
                tbPuntajeGlobal.Text = datosDelPerfil.PuntajeGlobal.ToString();
            }
            else
            {
                MessageBox.Show("Lo sentimos, no fue posible cargar los datos", "Error");
            }
        }
        
        private async void cargarPartidasGanadas()
        {
            Partida[] partidas = await servicio.obtenerPartidasGanadasAsync(idDelJugador);
            if(partidas.Length > 0)
            {
                dgPartidasGanadas.ItemsSource = partidas;
            }
            else
            {
                dgPartidasGanadas.ItemsSource = null;
            }
        }

        private void clickRegresar(object sender, RoutedEventArgs e)
        {
            Jugador datosPrincipales = new Jugador();
            datosPrincipales.Email = datosDelPerfil.Email;
            datosPrincipales.Nombre = datosDelPerfil.Nombre; 
            datosPrincipales.Id = datosDelPerfil.Id;

            PaginaPrincipal paginaPrincipal = new PaginaPrincipal(datosPrincipales);
            this.Close();
            paginaPrincipal.Show();
        }

        private void clickEditarPerfil(object sender, RoutedEventArgs e)
        {
            EdicionPerfil edicionPerfil = new EdicionPerfil(idDelJugador);
            this.Close();
            edicionPerfil.Show();
        }

        private void moverVentana(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
    }
}
