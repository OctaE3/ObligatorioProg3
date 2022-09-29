using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioClases
{
    public class Mecanico
    {
        private int _mecCod;
        private string _mecNom;
        private string _mecCi;
        private string _mecTel;
        private DateTime _mecFchIng;
        private int _mecValorHora;
        private string _mecActivo;

   
        public int MecCod { get => _mecCod; set => _mecCod = value; }
        public string MecNom { get => _mecNom; set => _mecNom = value; }
        public string MecCi { get => _mecCi; set => _mecCi = value; }
        public string MecTel { get => _mecTel; set => _mecTel = value; }
        public DateTime MecFchIng { get => _mecFchIng; set => _mecFchIng = value; }
        public int MecValorHora { get => _mecValorHora; set => _mecValorHora = value; }
        public string MecActivo { get => _mecActivo; set => _mecActivo = value; }

        public override string ToString()
        {
            return this.MecCod + " " + this.MecNom + " " + this.MecCi + " " + this.MecTel + " " + this.MecFchIng + " " + this.MecValorHora + " " + this.MecActivo.ToString();
        }

        public Mecanico() { }

        public Mecanico(int pMecCod, string pMecNom, string pMecCi, string pMecTel, DateTime pMecFchIng, int pMecValorHora, string pMecActivo)
        {
            MecCod = pMecCod;
            MecNom = pMecNom;
            MecCi = pMecCi;
            MecTel = pMecTel;
            MecFchIng = pMecFchIng;
            MecValorHora = pMecValorHora;
            MecActivo = pMecActivo;
        }
    }
}
