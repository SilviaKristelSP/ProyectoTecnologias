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
    /// Lógica de interacción para CreacionPartida.xaml
    /// </summary>
    public partial class CreacionPartida : Window
    {
        public CreacionPartida()
        {
            InitializeComponent();
        }

        private void clicCrear(object sender, RoutedEventArgs e)
        {
            PantallaRetador pantallaRetador = new PantallaRetador();
            pantallaRetador.Show();
            this.Close();
        }
    }
}
