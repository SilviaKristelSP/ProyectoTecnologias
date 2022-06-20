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
using ClienteMD.ServiceReference1;

namespace ClienteMD.Vistas
{
    /// <summary>
    /// Interaction logic for CreacionPartida.xaml
    /// </summary>
    public partial class CreacionPartida : Window
    {
        Service1Client servicio;
        List<Categoria> categorias;
        List<Palabra> palabras;
        Jugador retador;

        public CreacionPartida(Jugador jugador)
        {
            InitializeComponent();
            servicio = new Service1Client();
            retador = jugador;
            cargarCategoria();
            cargarPalabra();
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
            PaginaPrincipal paginaPrincipal = new PaginaPrincipal(retador);
            this.Close();
            paginaPrincipal.Show();
        }

        private async void clickCrearPartida(object sender, RoutedEventArgs e)
        {
            if(Palabra.SelectedIndex > -1)
            {
                Partida partida = crearPartida();
                int idPartidaCreada = await servicio.registrarPartidaNuevaAsync(partida);
                if(idPartidaCreada > -1)
                {
                    PantallaRetador pantallaRetador = new PantallaRetador(partida, retador); 
                    MessageBox.Show("Tú partida fue generada con éxito", "Nueva Partida Creada");
                    pantallaRetador.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No fue posible crear la partida, inténtelo más tarde", "Error");
                }
            }
            else
            {
                MessageBox.Show("Selecciona una palabra para crear la partida", "Error");
            }
        }

        private Partida crearPartida()
        {
            Partida partidaNueva = new Partida();
            partidaNueva.IdRetador = retador.Id;
            partidaNueva.Fecha = DateTime.Now;
            
            Palabra palabra = (Palabra)Palabra.SelectedItem;
            
            int idSeleccionada = palabra.IdPalabra;

            partidaNueva.IdPalabra = idSeleccionada;
            partidaNueva.Palabra = palabra.PalabraSecreta;
            partidaNueva.Categoria = Categoria.SelectedItem.ToString();
            partidaNueva.Pista = palabra.Pista;

            return partidaNueva;
        }

        private async void cargarCategoria()
        {
            Categoria[] auxiliar = await servicio.obtenerCategoriasAsync();
            categorias = auxiliar.ToList();
            Categoria.ItemsSource = categorias;
        }

        private async void cargarPalabra()
        {
            Palabra[] auxiliar = await servicio.obtenerPalabrasAsync();
            palabras = auxiliar.ToList();
        }

        private void Categoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Categoria categoria = (Categoria)Categoria.SelectedItem;
            int idSeleccionada = categoria.IdCategoria;

            List<Palabra> palabrasAsociadas = new List<Palabra>();
            foreach (Palabra palabra in palabras)
            {
                if(palabra.IdCategoria == idSeleccionada)
                {
                    palabrasAsociadas.Add(palabra);
                }
            }
            Palabra.ItemsSource = null;
            Palabra.ItemsSource = palabrasAsociadas;
        }
    }
}
