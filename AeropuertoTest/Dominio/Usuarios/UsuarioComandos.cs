using AeropuertoTest.Context;
using System.Data.SqlClient;

namespace AeropuertoTest.Dominio.Usuarios
{
    public class UsuarioComandos
    {
        private string connetionString;

        public UsuarioComandos()
        {
            var aeropuertoDb = new AeropuertoDb();
            connetionString = aeropuertoDb.GetConnectionString();
        }

        public string BuscarUsuario(string usuario, string contrasena)
        {
            var usuarioExiste = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(connetionString))
                {
                    SqlCommand command = new SqlCommand("Sp_AccesoBuscar", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    command.Parameters.AddWithValue("@Contrasena", contrasena);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        usuarioExiste = reader.GetString(0);
                    }
                    connection.Close();
                }


            }
            catch (System.Exception e)
            {
                usuarioExiste = e.Message;
            }
            return usuarioExiste;
        }
    }
}
