using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using SistemaPlanillas.Data;
using SistemaPlanillas.Models;
using System.Collections.Generic;

namespace SistemaPlanillas.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly ConexionBD _conexionBD;

        public DepartamentoController()
        {
            _conexionBD = new ConexionBD();
        }

        private List<Departamento> ObtenerDepartamentos()
        {
            List<Departamento> lista = new List<Departamento>();

            using (MySqlConnection conexion = _conexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = "SELECT * FROM departamento";

                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Departamento
                            {
                                IdDepartamento = Convert.ToInt32(reader["id_departamento"]),
                                NombreDepartamento = reader["nombre_departamento"].ToString() ?? "",
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
            var departamentos = ObtenerDepartamentos();
            return View(departamentos);
        }
    }
}
