using ClienteMD.Vistas;
using System;
using System.Windows;
using System.Windows.Input;
namespace ClienteMD
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
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

        private void clickIngresar(object sender, RoutedEventArgs e)
        {
            Console.WriteLine($"Usuario: {Usuario.Text} Contraseña:{Contraseña.Password}");
            Boolean camposVacios = false;
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
            if (camposVacios == false)
            {
                PaginaPrincipal paginaPrincipal = new PaginaPrincipal();
                this.Close();
                paginaPrincipal.Show();
            }
        }

        private void clickRegistrarse(object sender, RoutedEventArgs e)
        {
            RegistroUsuario registroUsuario = new RegistroUsuario();
            this.Close();
            registroUsuario.Show();
        }
    }
}
