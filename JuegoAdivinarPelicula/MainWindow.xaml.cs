using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace JuegoAdivinarPelicula
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Pelicula> pelis = new List<Pelicula>();
        ObservableCollection<string> generos = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();

            generos.Add("Comedia");
            generos.Add("Drama");
            generos.Add("Acción");


            Pelicula p1 = new Pelicula("Ejemplo1", "https://i.blogs.es/5efe2c/cap_001/450_1000.jpg", "A", "A", 0);
            Pelicula p2 = new Pelicula("Ejemplo2", "https://i.blogs.es/5efe2c/cap_001/450_1000.jpg", "A", "A", 0);
            Pelicula p3 = new Pelicula("Ejemplo3", "https://i.blogs.es/5efe2c/cap_001/450_1000.jpg", "A", "A", 0);
            Pelicula p4 = new Pelicula("Ejemplo4", "https://i.blogs.es/5efe2c/cap_001/450_1000.jpg", "A", "A", 0);
            Pelicula p5 = new Pelicula("Ejemplo5", "https://i.blogs.es/5efe2c/cap_001/450_1000.jpg", "A", "A", 0);

            pelis.Add(p1);
            pelis.Add(p2);
            pelis.Add(p3);
            pelis.Add(p3);
            pelis.Add(p3);
            pelis.Add(p3);
            pelis.Add(p3);
            pelis.Add(p3);
            pelis.Add(p3);
            pelis.Add(p3);
            pelis.Add(p4);
            pelis.Add(p5);

            Pelis.DataContext = pelis;
            GeneroSeleccionado.ItemsSource = generos;
        }
    }
}
