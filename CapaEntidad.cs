using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaNegocio;
namespace CapaEntidad
{
    public class E_Choferes
    {
        private int _IdChoferes;
        private string _Nombre;
        private string _Apellido;
        private DateTime _Fecha_de_nacimiento;
        private string _Cedula;
        private int _IdAutobus;
        private string _Marca;
        private string _Modelo;
        private string _Placa;
        private string _Color;
        private int _Año;
        private int _IdRutas;
        private string _Nombre_de_ruta;
        private string codigo;
        private string _Estado;

        public int IdChoferes { get => _IdChoferes; set => _IdChoferes = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
      
        public string Cedula { get => _Cedula; set => _Cedula = value; }
        public int IdAutobus { get => _IdAutobus; set => _IdAutobus = value; }
        public string Marca { get => _Marca; set => _Marca = value; }
        public string Modelo { get => _Modelo; set => _Modelo = value; }
        public string Placa { get => _Placa; set => _Placa = value; }
        public string Color { get => _Color; set => _Color = value; }
        public int Año { get => _Año; set => _Año = value; }
        public int IdRutas { get => _IdRutas; set => _IdRutas = value; }
        public string Nombre_de_ruta { get => _Nombre_de_ruta; set => _Nombre_de_ruta = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public DateTime Fecha_de_nacimiento { get => _Fecha_de_nacimiento; set => _Fecha_de_nacimiento = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
    }
}
