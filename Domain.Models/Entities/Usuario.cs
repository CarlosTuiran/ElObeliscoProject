using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entities
{
    public class Usuario: Entity<int>
    {
        public string Nombre { get; set; }
        public string Password { get; set; }
        public int EmpleadoId { get; set; }
        public string Tipo { get; set; }

        private const string SharedSecret = "ElObeliescoPass123";
        public Crypto Crypto;
        public Usuario()
        {

        }
        public Usuario(string nombre, string password, int idEmpleado, string tipo)
        {
            this.Nombre = nombre;
            Crypto = new Crypto();
            this.Password = Encriptar(password);
            this.EmpleadoId = idEmpleado;
            this.Tipo = tipo;
        }
        public string Encriptar(string password)
        {
            string outPass=Crypto.EncryptStringAES(password, SharedSecret);
            return outPass;
        }
        public string Desencriptar(string password)
        {
            string outPass = Crypto.DecryptStringAES(password, SharedSecret);
            return outPass;
        }
        public IReadOnlyList<string> CanCrear(Usuario usuario)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(this.Nombre))
                errors.Add("Campo Nombre vacio");
            if (string.IsNullOrEmpty(this.Password))
                errors.Add("Campo Password vacio");
            if (this.EmpleadoId==0)
                errors.Add("Campo IdEmpleado vacio");

            /*if (this.PrecioTotal == 0)
                errors.Add("Campo Precio Total vacio");*/
            return errors;
        }
    }
}
