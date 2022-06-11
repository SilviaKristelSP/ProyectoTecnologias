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
        }

        private void clickRegistrarse(object sender, RoutedEventArgs e)
        {

        }
    }
}
