using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace ClienteMD.Vistas
{
    /// <summary>
    /// Interaction logic for RegistroUsuario.xaml
    /// </summary>
    public partial class RegistroUsuario : Window
    {
        public RegistroUsuario()
        {
            InitializeComponent();
        }

        private void clickSalir(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void moverVentana(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void clickRegistrar(object sender, RoutedEventArgs e)
        {
            //Boolean datosValidos = false;
            //Console.WriteLine("Boton registra");
            if ((validarNombre(Nombre.Text)) && (validarCorreo(Correo.Text)) && (validarTelefono(Telefono.Text)) && (validarContraseña(Contraseña.Text)) && (validarFecha()))
            {
                MessageBox.Show("Registro exitoso");
                //datosValidos = true; //En realidad no se necesita x ahora, pero la dejo por si acaso 
                //crear jugador
            }
           
        }


        public Boolean validarNombre(string nombre)
        {
           
            if (Regex.IsMatch(nombre, @"^([a-zA-Z]+)(\s[a-zA-Z]+)*$"))
            {
                return true;
            }
            else
            {
                MessageBox.Show("No se pudo registrar el usuario, nombre invalido");
                return false;
            }
            
        }

        public Boolean validarCorreo(string correo)
        {

            if (Regex.IsMatch(correo, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@"
            + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"))
            {
                return true;
            }
            else
            {
                MessageBox.Show("No se pudo registrar el usuario, correo invalido");
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
                MessageBox.Show("No se pudo registrar el usuario, telefono invalido");
                return false;
            }
            
        }
        
        public Boolean validarContraseña(string contraseña)
        {
            if (Regex.IsMatch(contraseña, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&#.$($)$-$_])[A-Za-z\d$@$!%*?&#.$($)$-$_]{8,15}$"))
            {
                return true;
            }
            else
            {
                MessageBox.Show("No se pudo registrar el usuario, la contraseña debe tener entre 8 y 15 caracteres, al menos un dígito, al menos una minúscula y al menos una mayúscula, un caracter especial y no espacios en blanco.");
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

        
}
}
