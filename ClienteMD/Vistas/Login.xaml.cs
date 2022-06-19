using ClienteMD.Vistas;
using System;
using System.Windows;
using System.Windows.Input;
using ClienteMD.ServiceReference1;

namespace ClienteMD
{
    public partial class Login : Window
    {
        Service1Client servicio;

        public Login()
        {
            InitializeComponent();
            servicio = new Service1Client();
        }

        private void moverVentana(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void clickSalir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void clickIngresar(object sender, RoutedEventArgs e)
        {
            if (!verificarFormulario())
            {
                RespuestaLogin respuesta = await servicio.logearAsync(Usuario.Text, Contraseña.Password);
                if (respuesta.Error)
                {
                    MessageBox.Show(respuesta.Mensaje, "Login fallido");
                }
                else
                {
                    MessageBox.Show(respuesta.Mensaje, "Login exitoso");
                    PaginaPrincipal paginaPrincipal = new PaginaPrincipal(respuesta.DatosJugador);
                    paginaPrincipal.Show();
                    this.Close();
                }
            }
            
        }

        private void clickRegistrarse(object sender, RoutedEventArgs e)
        {
            RegistroUsuario registroUsuario = new RegistroUsuario();
            this.Close();
            registroUsuario.Show();
        }

        private bool verificarFormulario()
        {
            bool camposVacios = false;
            if (Usuario.Text.Equals(""))
            {
                MessageBox.Show("El nombre de usuario se encuentra vacio, ingresa tu usuario");
                camposVacios = true;
            }
            if (Contraseña.Password.Equals(""))
            {
                MessageBox.Show("La contraseña se encuentra vacio, ingresa tu contraseña");
                camposVacios = true;
            }
            return camposVacios;
        }
    }
}
