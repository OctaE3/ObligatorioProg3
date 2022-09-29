using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioClases
{
    public class Reserva
    {
        private int _reservasCod;
        private DateTime _reservaFch;
        private string _reservaDsc;
        private int _cliCod;
        private int _vehiculoCod;

        public int ReservasCod { get => _reservasCod; set => _reservasCod = value; }
        public DateTime ReservaFch { get => _reservaFch; set => _reservaFch = value; }
        public string ReservaDsc { get => _reservaDsc; set => _reservaDsc = value; }
        public int CliCod { get => _cliCod; set => _cliCod = value; }
        public int VehiculoCod { get => _vehiculoCod; set => _vehiculoCod = value; }

        public override string ToString()
        {
            return this.ReservasCod + " - " + this.ReservaFch + " - " + this.ReservaDsc + " - " + this.CliCod + " - " + this.VehiculoCod.ToString();
        }

        public Reserva() { }

        public Reserva(int pReservasCod, DateTime pReservaFch, string pReservaDsc, int pCliCod, int pVehiculoCod)
        {
            this.ReservasCod = pReservasCod;
            this.ReservaFch = pReservaFch;
            this.ReservaDsc = pReservaDsc;
            this.CliCod = pCliCod;
            this.VehiculoCod = pVehiculoCod;
        }
    }
}
