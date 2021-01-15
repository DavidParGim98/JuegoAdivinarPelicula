using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace JuegoAdivinarPelicula
{
    public class Pelicula : INotifyPropertyChanged
    {
        private string _nombre;
        private string _imagen;
        private string _pista;
        private Genero _genero;
        private Dificultad _dificultad;
        public enum Genero
        {
            Comedia, Drama, Accion, Terror , Scifi
        }

        public enum Dificultad
        { 
            Facil, Normal, Dificil
        }

        public string Nombre
        {
            get => _nombre;

            set
            {
                if (this._nombre != value)
                {
                    this._nombre = value;
                    this.NotifyPropertyChanged("Nombre");
                }
            }
        }
        public string Imagen
        {
            get => _imagen;

            set
            {
                if (this._imagen != value)
                {
                    this._imagen = value;
                    this.NotifyPropertyChanged("Imagen");
                }
            }
        }

        public string Pista
        {
            get => _pista;

            set
            {
                if (this._pista != value)
                {
                    this._pista = value;
                    this.NotifyPropertyChanged("Pista");
                }
            }
        }

        public Genero GeneroPro
        {
            get => _genero;

            set
            {
                if (this._genero != value)
                {
                    this._genero = value;
                    this.NotifyPropertyChanged("GeneroPro");
                }
            }
        }        

        public Dificultad DificultadPro
        {
            get => _dificultad;

            set
            {
                if (this._dificultad != value)
                {
                    this._dificultad = value;
                    this.NotifyPropertyChanged("DificultadPro");
                }
            }
        }

        public Pelicula(string nombre, string imagen, string pista, Genero genero)
        {
            Nombre = nombre;
            Imagen = imagen;
            Pista = pista;
            GeneroPro = genero;
            DificultadPro = 0;
        }

        public static ObservableCollection<Genero> getListaGeneros()
        {
            ObservableCollection<Genero> generos = new ObservableCollection<Genero>();

            var values = Enum.GetValues(typeof(Genero));

            foreach (Genero item in values)
            {
                generos.Add(item);
            }

            return generos;
        }

        public Pelicula()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
