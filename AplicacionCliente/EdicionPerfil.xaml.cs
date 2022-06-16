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
    /// Lógica de interacción para EdicionPerfil.xaml
    /// </summary>
    public partial class EdicionPerfil : Window
    {
        public EdicionPerfil()
        {
            InitializeComponent();
        }

        private void clicGuardarDatos(object sender, RoutedEventArgs e)
        {
            PaginaPrincipal paginaPrincipal = new PaginaPrincipal();
            paginaPrincipal.Show();
            this.Close();
        }
    }
}
