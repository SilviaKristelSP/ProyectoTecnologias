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

namespace ClienteMD.Vistas
{
    /// <summary>
    /// Interaction logic for CreacionPartida.xaml
    /// </summary>
    public partial class CreacionPartida : Window
    {
        public CreacionPartida()
        {
            InitializeComponent();
        }

        private void moverVentana(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void clickRegresar(object sender, RoutedEventArgs e)
        {
            PaginaPrincipal paginaPrincipal = new PaginaPrincipal(null);
            this.Close();
            paginaPrincipal.Show();
        }

        private void clickCrearPartida(object sender, RoutedEventArgs e)
        {
            PantallaRetador pantallaRetador = new PantallaRetador();
            this.Close();
            pantallaRetador.Show();
        }
    }
}
