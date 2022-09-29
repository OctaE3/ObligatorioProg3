using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioClases
{
    public class Cliente
    {
        private int _cliId;
        private string _cliNom;
        private string _cliCi;
        private string _cliTel;
        private string _cliDir;
        private string _cliMail;
        private DateTime _fchRegistro;
        private string _cliPass;
        private string _admin;

        public int CliId { get => _cliId; set => _cliId = value; }
        public string CliNom { get => _cliNom; set => _cliNom = value; }
        public string CliCi { get => _cliCi; set => _cliCi = value; }
        public string CliTel { get => _cliTel; set => _cliTel = value; }
        public string CliDir { get => _cliDir; set => _cliDir = value; }
        public string CliMail { get => _cliMail; set => _cliMail = value; }
        public DateTime FchRegistro { get => _fchRegistro; set => _fchRegistro = value; }
        public string CliPass { get => _cliPass; set => _cliPass = value; }
        public string Admin { get => _admin; set => _admin = value; }

        public override string ToString()
        {
            return this.CliId + " " + this.CliNom + " " + this.CliCi + " " + this.CliTel + " " + this.CliDir + " " + this.CliMail + " " + this.FchRegistro + " " + this.CliPass.ToString();
        }

        public Cliente() { }

        public Cliente(int pCliId, string pCliNom, string pCliCi, string pCliTel, string pCliDir, string pCliMail, DateTime pFchRegistro, string pCliPass, string pAdmin)
        {
            CliId = pCliId;
            CliNom = pCliNom;
            CliCi = pCliCi;
            CliTel = pCliTel;
            CliDir = pCliDir;
            CliMail = pCliMail;
            FchRegistro = pFchRegistro;
            CliPass = pCliPass;
            Admin = pAdmin;
        }
    }
}
