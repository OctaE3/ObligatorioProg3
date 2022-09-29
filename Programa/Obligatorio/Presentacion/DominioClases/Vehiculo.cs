using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioClases
{
    public class Vehiculo
    {
        private int _vehiculoCod;
        private string _matricula;
        private string _marca;
        private string _modelo;
        private int _anio;
        private string _color;

        public int VehiculoCod { get => _vehiculoCod; set => _vehiculoCod = value; }
        public string Matricula { get => _matricula; set => _matricula = value; }
        public string Marca { get => _marca; set => _marca = value; }
        public string Modelo { get => _modelo; set => _modelo = value; }
        public int Anio { get => _anio; set => _anio = value; }
        public string Color { get => _color; set => _color = value; }

        public override string ToString()
        {
            return this.VehiculoCod + " " + this.Matricula + " " + this.Marca + " " + this.Modelo + " " + this.Anio + " " + this.Color.ToString();
        }

        public Vehiculo() { }

        public Vehiculo(int pVehiculoCod, string pMatricula, string pMarca, string pModelo, int pAnio, string pColor)
        {
            VehiculoCod = pVehiculoCod;
            Matricula = pMatricula;
            Marca = pMarca;
            Modelo = pModelo;
            Anio = pAnio;
            Color = pColor;
        }
    }
}
