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
    /// Interaction logic for PantallaAdivinador.xaml
    /// </summary>
    public partial class PantallaAdivinador : Window
    {
        public PantallaAdivinador()
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

        private void clickAbandonarPartida(object sender, RoutedEventArgs e)
        {
            PaginaPrincipal paginaPrincipal = new PaginaPrincipal(null);
            this.Close();
            paginaPrincipal.Show();
        }

        private void clickA(object sender, RoutedEventArgs e)
        {

        }

        private void clickB(object sender, RoutedEventArgs e)
        {

        }

        private void clickC(object sender, RoutedEventArgs e)
        {

        }

        private void clickD(object sender, RoutedEventArgs e)
        {

        }

        private void clickE(object sender, RoutedEventArgs e)
        {

        }

        private void clickF(object sender, RoutedEventArgs e)
        {

        }

        private void clickG(object sender, RoutedEventArgs e)
        {

        }

        private void clickH(object sender, RoutedEventArgs e)
        {

        }

        private void clickI(object sender, RoutedEventArgs e)
        {

        }

        private void clickJ(object sender, RoutedEventArgs e)
        {

        }

        private void clickK(object sender, RoutedEventArgs e)
        {

        }

        private void clickL(object sender, RoutedEventArgs e)
        {

        }

        private void clickM(object sender, RoutedEventArgs e)
        {

        }

        private void clickN(object sender, RoutedEventArgs e)
        {

        }

        private void clickÑ(object sender, RoutedEventArgs e)
        {

        }

        private void clickO(object sender, RoutedEventArgs e)
        {

        }

        private void clickP(object sender, RoutedEventArgs e)
        {

        }

        private void clickQ(object sender, RoutedEventArgs e)
        {

        }

        private void clickR(object sender, RoutedEventArgs e)
        {

        }

        private void clickS(object sender, RoutedEventArgs e)
        {

        }

        private void clickT(object sender, RoutedEventArgs e)
        {

        }

        private void clickU(object sender, RoutedEventArgs e)
        {

        }

        private void clickV(object sender, RoutedEventArgs e)
        {

        }

        private void clickW(object sender, RoutedEventArgs e)
        {

        }

        private void clickX(object sender, RoutedEventArgs e)
        {

        }

        private void clickY(object sender, RoutedEventArgs e)
        {

        }

        private void clickZ(object sender, RoutedEventArgs e)
        {

        }
    }
}
