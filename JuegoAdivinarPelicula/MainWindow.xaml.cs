using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        ObservableCollection<Pelicula> pelis = new ObservableCollection<Pelicula>();
        List<Pelicula> pelisJugar = new List<Pelicula>();
        ObservableCollection<Pelicula.Genero> generos;

        public MainWindow()
        {
            InitializeComponent();
            generos = Pelicula.getListaGeneros();


            Pelicula p1 = new Pelicula("Ejemplo1", "https://i.blogs.es/5efe2c/cap_001/450_1000.jpg", "A", (Pelicula.Genero)0, true, false, false);
            Pelicula p2 = new Pelicula("Ejemplo2", "https://www.gettyimages.es/gi-resources/images/500px/983794168.jpg", "A", (Pelicula.Genero)1, false, true, false);
            Pelicula p3 = new Pelicula("Ejemplo3", "https://helpx.adobe.com/content/dam/help/en/stock/how-to/visual-reverse-image-search/jcr_content/main-pars/image/visual-reverse-image-search-v2_intro.jpg", "A", (Pelicula.Genero)2, true, false, false);
            Pelicula p4 = new Pelicula("Ejemplo4", "https://francis.naukas.com/files/2019/04/D20190410-M87-black-hole-even-horizon-telescope-image.png", "A", (Pelicula.Genero)3, false, false, true);
            Pelicula p5 = new Pelicula("Ejemplo5", "https://www.publicdomainpictures.net/pictures/320000/nahled/background-image.png", "A", (Pelicula.Genero)4, false, true, false);

            pelis.Add(p1);
            pelis.Add(p2);
            pelis.Add(p3);
            pelis.Add(p4);
            pelis.Add(p5);

            Pelis.DataContext = pelis;
            GeneroSeleccionado.ItemsSource = generos;

            numPeliculas.Text = pelis.Count.ToString();
        }

        private void NuevaPartida_Click(object sender, RoutedEventArgs e)
        {
            List<int> pelisIntroducidas = new List<int>();
            pelisJugar = new List<Pelicula>();
            Random r = new Random();
            int random; // = r.Next(0, pelis.Count);

            if (pelis.Count < 5)
            {
                MessageBox.Show("Introduce al menos 5 películas para jugar", "ATENCIÓN", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    random = r.Next(0, pelis.Count);
                
                    if (pelisIntroducidas.Contains(random))
                    {
                        while (pelisIntroducidas.Contains(random))
                        {
                            random = r.Next(0, pelis.Count);
                        }
                    }
                    pelisJugar.Add(pelis[random]);
                    pelisIntroducidas.Add(random);
                    
                    
                }
                
                jugarPartida.DataContext = pelisJugar;
            }
            
        }

        private void Validar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cargar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            { 
                using (StreamReader jsonStream = File.OpenText(openFileDialog.FileName))
                {
                    var json = jsonStream.ReadToEnd();
                    List<Pelicula> peliculas = JsonConvert.DeserializeObject<List<Pelicula>>(json);
                
                    foreach (Pelicula p in peliculas)
                    {
                        pelis.Add(p);
                    }
                } 
            }

        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            string peliculasJson = JsonConvert.SerializeObject(pelis);
            //File.WriteAllText("peliculas.json", peliculasJson);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Json file (*.json)|*.json";
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, peliculasJson);
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Anyadir_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
