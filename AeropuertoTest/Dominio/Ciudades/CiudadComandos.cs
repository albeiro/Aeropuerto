using AeropuertoTest.Context;
using AeropuertoTest.Models.Ciudades;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AeropuertoTest.Dominio.Ciudades
{
    public class CiudadComandos
    {
        private string connetionString;

        public CiudadComandos()
        {
            var aeropuertoDb = new AeropuertoDb();
            connetionString = aeropuertoDb.GetConnectionString();
        }
        internal List<Ciudad> BuscarCiudad()
        {
            var ciudades = new List<Ciudad>();
            var errores = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(connetionString))
                {
                    SqlCommand command = new SqlCommand("Sp_CiudadBuscar", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var ciudad = new Ciudad
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1)
                        };
                        ciudades.Add(ciudad);
                    }
                    connection.Close();
                }
            }
            catch (System.Exception e)
            {
                errores = e.Message;
            }
            return ciudades;
        }
    }
}
