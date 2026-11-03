using Microsoft.AspNetCore.Mvc;
using SistemaPlanillas.Data;
using SistemaPlanillas.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace SistemaPlanillas.Controllers
{

    public class PuestoController : Controller
    {
        private readonly ConexionBD _conexionBD;

        public PuestoController()
        {
            _conexionBD = new ConexionBD();
        }
        private List<Puesto> ObtenerPuestos()
        {
            List<Puesto> lista = new List<Puesto>();

            using (MySqlConnection conexion = _conexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = "SELECT * FROM puesto";

                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Puesto
                            {
                                IdPuesto = Convert.ToInt32(reader["id_puesto"]),
                                NombrePuesto = reader["nombre_puesto"].ToString() ?? "",
                                SalarioBase = Convert.ToDecimal(reader["salario_base"]),
                                Descripcion = reader["descripcion"].ToString()
                            });
                        }
                    }
                }
            }

            return lista;
        }
        public IActionResult Index()
        {
            var puestos = ObtenerPuestos();
            return View(puestos);
        }
    }
}
