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
using System.Text.RegularExpressions;
using ClienteMD.ServiceReference1;

namespace ClienteMD.Vistas
{
    /// <summary>
    /// Interaction logic for EdicionPerfil.xaml
    /// </summary>
    public partial class EdicionPerfil : Window
    {
        Service1Client servicio;
        int idAEditar;
        Jugador datosDelPerfil;

        public EdicionPerfil(int idJugador)
        {
            InitializeComponent();
            servicio = new Service1Client();
            idAEditar = idJugador;
            mostrarDatosPerfil();
        }

        private async void mostrarDatosPerfil()
        {
            datosDelPerfil = await servicio.obtenerDatosJugadorAsync(idAEditar);
            if (datosDelPerfil != null)
            {
                DateTime fechaAux = Convert.ToDateTime(datosDelPerfil.FechaNacimiento);
                FechaNacimiento.Text = fechaAux.ToString("dd/MM/yyyy");
                Telefono.Text = datosDelPerfil.Telefono;
                Nombre.Text = datosDelPerfil.Nombre;
            }
            else
            {
                MessageBox.Show("Lo sentimos, no fue posible cargar los datos", "Error");
            }
        }

        private void clickRegresar(object sender, RoutedEventArgs e)
        {
            Perfil perfil = new Perfil(idAEditar);
            perfil.Show();
            this.Close();
        }

        private async void clickGuardarCambios(object sender, RoutedEventArgs e)
        {
            if(validarTelefono(Telefono.Text) && validarNombre(Nombre.Text) && validarFecha())
            {
                actualizarDatos();
                Mensaje mensaje = await servicio.editarJugadorAsync(datosDelPerfil);
                if (mensaje.Error)
                {
                    MessageBox.Show(mensaje.MensajeRespuesta, "Error");
                }
                else
                {
                    MessageBox.Show(mensaje.MensajeRespuesta, "Edición Exitosa");
                    Perfil perfil = new Perfil(idAEditar);
                    perfil.Show();
                    this.Close();
                }
            }
        }

        private void actualizarDatos()
        {
            DateTime fechaAux = Convert.ToDateTime(FechaNacimiento.Text);
            datosDelPerfil.FechaNacimiento = fechaAux.ToString("yyyy-MM-dd");
            datosDelPerfil.Telefono = Telefono.Text;
            datosDelPerfil.Nombre = Nombre.Text;
        }

        public Boolean validarNombre(string nombre)
        {

            if (Regex.IsMatch(nombre, @"^([a-zA-Z]+)(\s[a-zA-Z]+)*$"))
            {
                return true;
            }
            else
            {
                MessageBox.Show("No se pudo editar el usuario, nombre invalido");
                return false;
            }

        }

        public Boolean validarTelefono(string telefono)
        {

            if (Regex.IsMatch(telefono, @"^[+-]?\d+(\.\d+)?$"))
            {
                return true;
            }
            else
            {
                MessageBox.Show("No se pudo editar el usuario, telefono invalido");
                return false;
            }

        }

        public Boolean validarFecha()
        {
            if (FechaNacimiento.SelectedDate == null)
            {
                MessageBox.Show("No se pudo registrar el usuario, ingrese su fecha de nacimiento");
                return false;
            }
            else
            {
                return true;

            }

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
