using MySql.Data.MySqlClient;

namespace SistemaPlanillas.Data
{
    public class ConexionBD
    {
        private string cadenaConexion =
            "Server=localhost;Port=3306;Database=planillasmunicipales;Uid=root;Pwd=yendri1234;";

        public MySqlConnection ObtenerConexion()
        {
            return new MySqlConnection(cadenaConexion);
        }
    }
}