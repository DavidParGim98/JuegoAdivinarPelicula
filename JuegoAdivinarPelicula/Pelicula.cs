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
        private bool _facil;
        private bool _normal;
        private bool _dificil;
        public enum Genero
        {
            Comedia, Drama, Accion, Terror , Scifi
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

        public bool Facil
        {
            get => _facil;

            set
            {
                if (this._facil != value)
                {
                    this._facil = value;
                    this.NotifyPropertyChanged("Facil");
                }
            }
        }
        public bool Normal
        {
            get => _normal;

            set
            {
                if (this._normal != value)
                {
                    this._normal = value;
                    this.NotifyPropertyChanged("Normal");
                }
            }
        }
        public bool Dificil
        {
            get => _dificil;

            set
            {
                if (this._dificil != value)
                {
                    this._dificil = value;
                    this.NotifyPropertyChanged("Dificil");
                }
            }
        }

        public Pelicula(string nombre, string imagen, string pista, Genero genero, bool facil, bool normal, bool dificil)
        {
            Nombre = nombre;
            Imagen = imagen;
            Pista = pista;
            GeneroPro = genero;
            Facil = facil;
            Normal = normal;
            Dificil = dificil;
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
