using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioFinal.DATA.Model
{
    public class Catologo
    {
        public int ID { get; set; }
        public string Nombre_Consola { get; set; }
        public string Compania { get; set; }
        public DateTime Fecha_Lanzamiento { get; set; }
        public string Generacion { get; set; }

        // Constructor sin parámetros
        public Catologo() { }

        // Constructor con parámetros
        public Catologo(int id, string nombre_consola, string compania, DateTime anio_lanzamiento, string generacion)
        {
            ID = id;
            Nombre_Consola = nombre_consola;
            Compania = compania;
            Fecha_Lanzamiento = anio_lanzamiento;
            Generacion = generacion;
        }

        // Método para mostrar información del usuario
        public override string ToString()
        {
            return $"ID: {ID}, Nombre: {Nombre_Consola}, Compania: {Compania}, Fecha de Lanzamiento: {Fecha_Lanzamiento.ToShortDateString()}, Generacion: {Generacion}";
        }
    }
}
