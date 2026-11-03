using Microsoft.AspNetCore.Mvc;
using SistemaPlanillas.Data;
using SistemaPlanillas.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace SistemaPlanillas.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly ConexionBD _conexionBD;

        public EmpleadoController()
        {
            _conexionBD = new ConexionBD();
        }

        private List<Empleado> ObtenerEmpleados()
        {
            List<Empleado> lista = new List<Empleado>();

            using (MySqlConnection conexion = _conexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = "SELECT * FROM empleado";

                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Empleado
                            {
                                IdEmpleado = Convert.ToInt32(reader["id_empleado"]),
                                Cedula = reader["cedula"].ToString() ?? "",
                                Nombre = reader["nombre"].ToString() ?? "",
                                Apellido1 = reader["apellido1"].ToString() ?? "",
                                Apellido2 = reader["apellido2"].ToString(),
                                IdDepartamento = Convert.ToInt32(reader["id_departamento"]),
                                IdPuesto = Convert.ToInt32(reader["id_puesto"])
                            });
                        }
                    }
                }
            }

            return lista;
        }
        public IActionResult Index()
        {
            var empleados = ObtenerEmpleados();
            return View(empleados);
        }
    }
}
