﻿using System;
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
using System.Threading.Tasks;

namespace ClienteMD.Vistas
{
    /// <summary>
    /// Interaction logic for PantallaAdivinador.xaml
    /// </summary>
    public partial class PantallaAdivinador : Window
    {

        String letra = "";
        int intentos = 6;
        String palabra = "Aguacate";
        String[] letrasAdivinadas;

        public PantallaAdivinador()
        {
            InitializeComponent();
            inicializarPalabra();
            IntentosRestantes.Text = intentos.ToString();
            
        }

        private void inicializarPalabra()
        {
            palabra= palabra.ToUpper();
            letrasAdivinadas = new String[palabra.Length];
            for (int i = 0; i < palabra.Length; i++)
            {

                letrasAdivinadas[i] = "_ ";
            }
            PalabraSecreta.Text = String.Concat(letrasAdivinadas);
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
        
        private async void verificarTurno (Char letra)
        {
            if (intentos > 0)
            {
                if (palabra.Contains(letra))
                {
                    for (int i = 0; i < palabra.Length; i++)
                    {
                        if (palabra[i] == letra)
                        {
                            letrasAdivinadas[i] = letra.ToString();
                            string aux = String.Concat(letrasAdivinadas);
                            if (!aux.Contains("_"))
                            {
                                PalabraSecreta.Text = String.Concat(letrasAdivinadas);
                                await Task.Delay(1000);
                                MessageBox.Show("Felicidades, haz ganado 10 pts :)", "Partida ganada");
                                PaginaPrincipal paginaPrincipal = new PaginaPrincipal(null);
                                paginaPrincipal.Show();
                                this.Close();
                            }
                        }
                    }
                }
                else
                {
                    intentos--;
                    IntentosRestantes.Text = intentos.ToString();
                }
                PalabraSecreta.Text = String.Concat(letrasAdivinadas);
            }
            else
            {
                MessageBox.Show("Lo sentimos, parece que perdiste ;(", "Partida perdida");
                PaginaPrincipal paginaPrincipal = new PaginaPrincipal(null);
                paginaPrincipal.Show();
                this.Close();
            }
        }


        private void clickA(object sender, RoutedEventArgs e)
        {
            verificarTurno('A');
            BotonA.Visibility = Visibility.Hidden;
        }

        private void clickB(object sender, RoutedEventArgs e)
        {
            verificarTurno('B');
            BotonB.Visibility = Visibility.Hidden;
        }

        private void clickC(object sender, RoutedEventArgs e)
        {
            verificarTurno('C');
            BotonC.Visibility = Visibility.Hidden;
        }

        private void clickD(object sender, RoutedEventArgs e)
        {
            verificarTurno('D');
            BotonD.Visibility = Visibility.Hidden;
        }

        private void clickE(object sender, RoutedEventArgs e)
        {
            verificarTurno('E');
            BotonE.Visibility = Visibility.Hidden;
        }

        private void clickF(object sender, RoutedEventArgs e)
        {
            verificarTurno('F');
            BotonF.Visibility = Visibility.Hidden;
        }

        private void clickG(object sender, RoutedEventArgs e)
        {
            verificarTurno('G');
            BotonG.Visibility = Visibility.Hidden;
        }

        private void clickH(object sender, RoutedEventArgs e)
        {
            verificarTurno('H');
            BotonH.Visibility = Visibility.Hidden;
        }

        private void clickI(object sender, RoutedEventArgs e)
        {
            verificarTurno('I');
            BotonI.Visibility = Visibility.Hidden;
        }

        private void clickJ(object sender, RoutedEventArgs e)
        {
            verificarTurno('J');
            BotonJ.Visibility = Visibility.Hidden;
        }

        private void clickK(object sender, RoutedEventArgs e)
        {
            verificarTurno('K');
            BotonK.Visibility = Visibility.Hidden;
        }

        private void clickL(object sender, RoutedEventArgs e)
        {
            verificarTurno('L');
            BotonL.Visibility = Visibility.Hidden;
        }

        private void clickM(object sender, RoutedEventArgs e)
        {
            verificarTurno('M');
            BotonM.Visibility = Visibility.Hidden;
        }

        private void clickN(object sender, RoutedEventArgs e)
        {
            verificarTurno('N');
            BotonN.Visibility = Visibility.Hidden;
        }

        private void clickÑ(object sender, RoutedEventArgs e)
        {
            verificarTurno('Ñ');
            BotonÑ.Visibility = Visibility.Hidden;
        }

        private void clickO(object sender, RoutedEventArgs e)
        {
            verificarTurno('O');
            BotonO.Visibility = Visibility.Hidden;
        }

        private void clickP(object sender, RoutedEventArgs e)
        {
            verificarTurno('P');
            BotonP.Visibility = Visibility.Hidden;
        }

        private void clickQ(object sender, RoutedEventArgs e)
        {
            verificarTurno('Q');
            BotonQ.Visibility = Visibility.Hidden;
        }

        private void clickR(object sender, RoutedEventArgs e)
        {
            verificarTurno('R');
            BotonR.Visibility = Visibility.Hidden;
        }

        private void clickS(object sender, RoutedEventArgs e)
        {
            verificarTurno('S');
            BotonS.Visibility = Visibility.Hidden;
        }

        private void clickT(object sender, RoutedEventArgs e)
        {
            verificarTurno('T');
            BotonT.Visibility = Visibility.Hidden;
        }

        private void clickU(object sender, RoutedEventArgs e)
        {
            verificarTurno('U');
            BotonU.Visibility = Visibility.Hidden;
        }

        private void clickV(object sender, RoutedEventArgs e)
        {
            verificarTurno('V');
            BotonV.Visibility = Visibility.Hidden;
        }

        private void clickW(object sender, RoutedEventArgs e)
        {
            verificarTurno('W');
            BotonW.Visibility = Visibility.Hidden;
        }

        private void clickX(object sender, RoutedEventArgs e)
        {
            verificarTurno('X');
            BotonX.Visibility = Visibility.Hidden;
        }

        private void clickY(object sender, RoutedEventArgs e)
        {
            verificarTurno('Y');
            BotonY.Visibility = Visibility.Hidden;
        }

        private void clickZ(object sender, RoutedEventArgs e)
        {
            verificarTurno('Z');
            BotonZ.Visibility = Visibility.Hidden;
        }
    }
}
