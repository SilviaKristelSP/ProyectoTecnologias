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
    /// Lógica de interacción para Perfil.xaml
    /// </summary>
    public partial class Perfil : Window
    {
        public Perfil()
        {
            InitializeComponent();
        }

        private void clicEditarDatos(object sender, RoutedEventArgs e)
        {
            EdicionPerfil edicionPerfil = new EdicionPerfil();
            edicionPerfil.Show();
            this.Close();
        }
    }
}
