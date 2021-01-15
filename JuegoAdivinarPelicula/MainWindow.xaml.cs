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
        List<Pelicula> peliculasAdivinadas = new List<Pelicula>();
        ObservableCollection<Pelicula.Genero> generos;
        Pelicula peliculaAnyadir = new Pelicula();
        int i = 0;

        public MainWindow()
        {
            InitializeComponent();
            generos = Pelicula.getListaGeneros();


            Pelicula p1 = new Pelicula("Ejemplo1", "https://i.blogs.es/5efe2c/cap_001/450_1000.jpg", "A", (Pelicula.Genero)0);
            Pelicula p2 = new Pelicula("Ejemplo2", "https://www.gettyimages.es/gi-resources/images/500px/983794168.jpg", "A", (Pelicula.Genero)1);
            Pelicula p3 = new Pelicula("Ejemplo3", "https://helpx.adobe.com/content/dam/help/en/stock/how-to/visual-reverse-image-search/jcr_content/main-pars/image/visual-reverse-image-search-v2_intro.jpg", "A", (Pelicula.Genero)2);
            Pelicula p4 = new Pelicula("Ejemplo4", "https://francis.naukas.com/files/2019/04/D20190410-M87-black-hole-even-horizon-telescope-image.png", "A", (Pelicula.Genero)3);
            Pelicula p5 = new Pelicula("Ejemplo5", "https://www.publicdomainpictures.net/pictures/320000/nahled/background-image.png", "A", (Pelicula.Genero)4);

            pelis.Add(p1);
            pelis.Add(p2);
            pelis.Add(p3);
            pelis.Add(p4);
            pelis.Add(p5);

            Pelis.DataContext = pelis;
            GeneroSeleccionado.ItemsSource = generos;
            

            Mayor.Text = pelisJugar.Count.ToString();
        }

        private void NuevaPartida_Click(object sender, RoutedEventArgs e)
        {
            List<int> pelisIntroducidas = new List<int>();
            pelisJugar = new List<Pelicula>();
            Random r = new Random();
            int random;
            puntuacion.Text = "0";

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
                i = 0;
                Mayor.Text = pelisJugar.Count.ToString();
                Menor.Text = "1";
                jugarPartida.DataContext = pelisJugar[0];
                peliculasAdivinadas.Clear();
            }
            
        }

        private void Validar_Click(object sender, RoutedEventArgs e)
        {
            

            if (nombreComprobar.Text.Equals(pelisJugar[i].Nombre))
            {
                if (!peliculasAdivinadas.Contains(pelisJugar[i]))
                {
                    switch (pelisJugar[i].DificultadPro)
                    {                    
                        case Pelicula.Dificultad.Facil:
                            peliculasAdivinadas.Add(pelisJugar[i]);
                            puntuacion.Text = (2 + int.Parse(puntuacion.Text)).ToString();
                            break;
                        case Pelicula.Dificultad.Normal:
                            peliculasAdivinadas.Add(pelisJugar[i]);
                            puntuacion.Text = (4 + int.Parse(puntuacion.Text)).ToString();
                            break;
                        case Pelicula.Dificultad.Dificil:
                            peliculasAdivinadas.Add(pelisJugar[i]);
                            puntuacion.Text = (6 + int.Parse(puntuacion.Text)).ToString();
                            break;
                        default:
                            MessageBox.Show("Ese no es el título de la película", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                    }
                }
                
            }
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
            pelis.Remove(Pelis.SelectedItem as Pelicula);
        }

        private void Anyadir_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Name.Equals("anyadirPeliculaButton"))
            {

                if (nombrePelicula.Text.Equals("") || imagenPelicula.Text.Equals("") || pistaPelicula.Text.Equals("") || GeneroSeleccionado.SelectedItem.Equals(""))
                {
                    MessageBox.Show("La película debe tener al menos NOMBRE, IMAGEN, PISTA y GENERO. La dificultad generica sera fácil.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    //Esta parte se que esta mal, pero no me aclaraba con DataContext
                    int dificultad;
                    if (facil.IsChecked.Value)
                    {
                        dificultad = 0;
                    }
                    else if (normal.IsChecked.Value)
                    {
                        dificultad = 1;
                    }
                    else
                    {
                        dificultad = 2;
                    }
                    
                    peliculaAnyadir.Nombre = nombrePelicula.Text;
                    peliculaAnyadir.Pista = pistaPelicula.Text;
                    peliculaAnyadir.Imagen = imagenPelicula.Text;
                    peliculaAnyadir.GeneroPro = (Pelicula.Genero)GeneroSeleccionado.SelectedItem;
                    peliculaAnyadir.DificultadPro = (Pelicula.Dificultad)dificultad;

                    pelis.Add(peliculaAnyadir);
                    
                    peliculaAnyadir = new Pelicula();

                    MessageBox.Show("La película se ha añadido", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                }
            }
        }

        private void AnyadirImagen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                imagenPelicula.Text = openFileDialog.FileName;
            }
        }

        private void Menor_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (int.Parse(Menor.Text) >= 1 && i >= 1)
            {
                i--;
                Menor.Text = (i + 1) + "";
                jugarPartida.DataContext = pelisJugar[i];

            }
        }

        private void Mayor_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (i + 1 < pelisJugar.Count && i <= pelisJugar.Count)
            {
                i++;
                Menor.Text = (i + 1) + "";
                jugarPartida.DataContext = pelisJugar[i];

            }
        }
    }
}
