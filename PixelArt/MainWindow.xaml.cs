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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pixel_Art
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Brush ColorPaleta = Brushes.Black;
        bool ColorPersonalizado = false;
        TextBlock[,] listaTextBlock = new TextBlock[15, 15];
        Grid Pixel_Grid = new Grid();
        public MainWindow()
        {
            InitializeComponent();


            Pixel_Grid.Margin = new Thickness(5, 5, 5, 20);
            Panel_DockPanel.Children.Add(Pixel_Grid);
            for (int i = 0; i < 15; i++)
            {
                Pixel_Grid.RowDefinitions.Add(new RowDefinition());
                Pixel_Grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    Border n = new Border();
                    n.BorderBrush = Brushes.Black;
                    n.BorderThickness = new Thickness(1);
                    TextBlock cuadro = new TextBlock();
                    listaTextBlock[i, j] = cuadro;
                    n.Child = cuadro;
                    Grid.SetRow(n, i);
                    Grid.SetColumn(n, j);
                    cuadro.MouseEnter += Cuadro_MouseEnter;
                    cuadro.MouseLeftButtonDown += Cuadro_MouseLeftButtonDown;
                    Pixel_Grid.Children.Add(n);
                }
            }

        }

        private void Cuadro_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock cuadro = (TextBlock)sender;
            cuadro.Background = ColorPaleta;
        }

        private void Cuadro_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBlock cuadro = (TextBlock)sender;
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                cuadro.Background = ColorPaleta;
            }
        }


        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ColorPersonalizado = false;
            ColorPaleta = Brushes.White;
        }

        private void Negro_RadioButton(object sender, RoutedEventArgs e)
        {
            ColorPersonalizado = false;
            ColorPaleta = Brushes.Black;
        }

        private void Rojo_RadioButton(object sender, RoutedEventArgs e)
        {
            ColorPersonalizado = false;
            ColorPaleta = Brushes.Red;
        }

        private void Verde_RadioButton(object sender, RoutedEventArgs e)
        {
            ColorPersonalizado = false;
            ColorPaleta = Brushes.Green;
        }

        private void Azul_RadioButton(object sender, RoutedEventArgs e)
        {
            ColorPersonalizado = false;
            ColorPaleta = Brushes.Blue;
        }

        private void Amarillo_RadioButton(object sender, RoutedEventArgs e)
        {
            ColorPersonalizado = false;
            ColorPaleta = Brushes.Yellow;
        }

        private void Naranja_RadioButton(object sender, RoutedEventArgs e)
        {
            ColorPersonalizado = false;
            ColorPaleta = Brushes.Orange;
        }

        private void Rosa_RadioButton(object sender, RoutedEventArgs e)
        {
            ColorPersonalizado = false;
            ColorPaleta = Brushes.Pink;
        }

        private void Personalizado_RadioButton(object sender, RoutedEventArgs e)
        {
            try
            {
                ColorPersonalizado = true;
                ColorPaleta = (Brush)new BrushConverter().ConvertFrom(Color_TextBox.Text);
            }
            catch (FormatException z)
            {

            }


        }

        private void Color_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (ColorPersonalizado)
                {
                    ColorPaleta = (Brush)new BrushConverter().ConvertFrom(Color_TextBox.Text);
                }
            }
            catch (FormatException z)
            {

            }

        }

        private void Rellenar_Button(object sender, RoutedEventArgs e)
        {
            foreach (TextBlock n in listaTextBlock)
            {
                n.Background = ColorPaleta;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button m = (Button)sender;

            MessageBoxResult mb = MessageBox.Show("Se va a eliminar tu dibujo.\n ¿Quieres continuar?", "Cuidado", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (mb == MessageBoxResult.OK)
            {
                int numeroFilas = int.Parse(m.Tag.ToString());
                Pixel_Grid.RowDefinitions.Clear();
                Pixel_Grid.ColumnDefinitions.Clear();
                Pixel_Grid.Children.Clear();
                for (int i = 0; i < numeroFilas; i++)
                {
                    Pixel_Grid.RowDefinitions.Add(new RowDefinition());
                    Pixel_Grid.ColumnDefinitions.Add(new ColumnDefinition());
                }
                for (int i = 0; i < numeroFilas; i++)
                {
                    for (int j = 0; j < numeroFilas; j++)
                    {
                        Border n = new Border();
                        n.BorderBrush = Brushes.Black;
                        n.BorderThickness = new Thickness(1);
                        TextBlock cuadro = new TextBlock();
                        listaTextBlock[i, j] = cuadro;
                        n.Child = cuadro;
                        Grid.SetRow(n, i);
                        Grid.SetColumn(n, j);
                        cuadro.MouseEnter += Cuadro_MouseEnter;
                        cuadro.MouseLeftButtonDown += Cuadro_MouseLeftButtonDown;
                        Pixel_Grid.Children.Add(n);
                    }
                }
            }

        }
    }
}
