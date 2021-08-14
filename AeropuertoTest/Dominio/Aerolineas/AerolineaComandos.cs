using AeropuertoTest.Context;
using AeropuertoTest.Models.Aerolineas;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AeropuertoTest.Dominio.Aerolineas
{
    public class AerolineaComandos
    {
        private string connetionString;

        public AerolineaComandos()
        {
            var aeropuertoDb = new AeropuertoDb();
            connetionString = aeropuertoDb.GetConnectionString();
        }
        internal List<Aerolinea> BuscarCiudad()
        {
            var Aerolineas = new List<Aerolinea>();
            var errores = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(connetionString))
                {
                    SqlCommand command = new SqlCommand("Sp_AerolineaBuscar", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var aerolinea = new Aerolinea
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1)
                        };
                        Aerolineas.Add(aerolinea);
                    }
                    connection.Close();
                }
            }
            catch (System.Exception e)
            {
                errores = e.Message;
            }
            return Aerolineas;
        }
    }
}
