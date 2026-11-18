using Microsoft.AspNetCore.Mvc;
using SistemaPlanillas.Data;
using SistemaPlanillas.Models;
using MySql.Data.MySqlClient;

namespace SistemaPlanillas.Controllers
{
    public class VacacionesController : Controller
    {
        private readonly ConexionBD _conexionBD;

        public VacacionesController()
        {
            _conexionBD = new ConexionBD();
        }

        private List<Vacacion> ObtenerVacaciones()
        {
            List<Vacacion> lista = new List<Vacacion>();

            using (MySqlConnection conexion = _conexionBD.ObtenerConexion())
            {
                conexion.Open();

                string consulta = "SELECT * FROM vacaciones";

                using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Vacacion
                            {
                                IdVacacion = Convert.ToInt32(reader["id_vacacion"]),
                                IdEmpleado = Convert.ToInt32(reader["id_empleado"]),
                                FechaInicio = Convert.ToDateTime(reader["fecha_inicio"]),
                                FechaFin = Convert.ToDateTime(reader["fecha_fin"]),
                                DiasSolicitados = Convert.ToDecimal(reader["dias_solicitados"]),
                                Observaciones = reader["observaciones"]?.ToString(),
                                Estado = reader["estado"]?.ToString() ?? ""
                            });
                        }
                    }
                }
            }

            return lista;
        }

        public IActionResult Index()
        {
            var vacaciones = ObtenerVacaciones();
            return View(vacaciones);
        }
        public IActionResult Aprobar(int id)
        {
            using (MySqlConnection conexion = _conexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = @"UPDATE vacaciones
                               SET estado = 'Aprobada'
                               WHERE id_vacacion = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexion))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult Rechazar(int id)
        {
            using (MySqlConnection conexion = _conexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = @"UPDATE vacaciones
                               SET estado = 'Rechazada'
                               WHERE id_vacacion = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexion))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Index");
        }
    }
}