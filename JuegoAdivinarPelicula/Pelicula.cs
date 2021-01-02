using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace JuegoAdivinarPelicula
{
    public class Pelicula : INotifyPropertyChanged
    {
        private string _nombre;
        private string _imagen;
        private string _pista;
        private string _genero;
        private int _dificultad;

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

        public string Genero
        {
            get => _genero;

            set
            {
                if (this._genero != value)
                {
                    this._genero = value;
                    this.NotifyPropertyChanged("Genero");
                }
            }
        }

        public int Dificultad
        {
            get => _dificultad;

            set
            {
                if (this._dificultad != value)
                {
                    this._dificultad = value;
                    this.NotifyPropertyChanged("Dificultad");
                }
            }
        }

        public Pelicula(string nombre, string imagen, string pista, string genero, int dificultad)
        {
            Nombre = nombre;
            Imagen = imagen;
            Pista = pista;
            Genero = genero;
            Dificultad = dificultad;
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
