using AeropuertoTest.Context;
using AeropuertoTest.Models.Vuelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AeropuertoTest.Dominio.Vuelos
{
    public class VueloComandos
    {
        private string connetionString;

        public VueloComandos()
        {
            var aeropuertoDb = new AeropuertoDb();
            connetionString = aeropuertoDb.GetConnectionString();
        }

        public List<VueloBuscarViewModel> BuscarVuelos()
        {
            var vuelos = new List<VueloBuscarViewModel>();
            var errores = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(connetionString))
                {
                    SqlCommand command = new SqlCommand("Sp_VueloBuscar", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var vuelo = new VueloBuscarViewModel
                        {
                            Id = reader.GetInt32(0),
                            CiudadOrigen = reader.GetString(1),
                            CiudadDestino = reader.GetString(2),
                            FechaSalida = reader.GetDateTime(3),
                            FechaLlegada = reader.GetDateTime(4),
                            NumeroVuelo = reader.GetString(5),
                            Aerolinea = reader.GetString(6),
                            EstadoVuelo = reader.GetString(7)
                        };
                        vuelos.Add(vuelo);
                    }
                    connection.Close();
                }
            }
            catch (System.Exception e)
            {
                errores = e.Message;
            }
            return vuelos;
        }

        internal string Actualizarvuelo(VueloActualizarViewModel vuelo)
        {
            var errores = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(connetionString))
                {
                    SqlCommand command = new SqlCommand("Sp_VueloActualizar", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id",vuelo.Id);
                    command.Parameters.AddWithValue("@CiudadOrigenId", vuelo.CiudadOrigenId);
                    command.Parameters.AddWithValue("@CiudadDestinoId", vuelo.CiudadDestinoId);
                    command.Parameters.AddWithValue("@FechaSalida", vuelo.FechaSalida);
                    command.Parameters.AddWithValue("@FechaLlegada", vuelo.FechaLlegada);
                    command.Parameters.AddWithValue("@NumeroVuelo", vuelo.NumeroVuelo);
                    command.Parameters.AddWithValue("@AerolineaId", vuelo.AerolineaId);
                    command.Parameters.AddWithValue("@EstadoVuelo", vuelo.EstadoVuelo);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (System.Exception e)
            {
                errores = e.Message;
            }
            return errores;
        }

        internal string CrearVuelo(VueloCrearViewModel vuelo)
        {
            var errores = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(connetionString))
                {
                    SqlCommand command = new SqlCommand("Sp_VueloCrear", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CiudadOrigenId", vuelo.CiudadOrigenId);
                    command.Parameters.AddWithValue("@CiudadDestinoId", vuelo.CiudadDestinoId);
                    command.Parameters.AddWithValue("@FechaSalida", vuelo.FechaSalida);
                    command.Parameters.AddWithValue("@FechaLlegada", vuelo.FechaLlegada);
                    command.Parameters.AddWithValue("@NumeroVuelo", vuelo.NumeroVuelo);
                    command.Parameters.AddWithValue("@AerolineaId", vuelo.AerolineaId);
                    command.Parameters.AddWithValue("@EstadoVuelo", vuelo.EstadoVuelo);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (System.Exception e)
            {
                errores = e.Message;
            }
            return errores;
        }

        public VueloActualizarViewModel BuscarVuelosPorId(int id)
        {
            var errores = "";
            var vuelo = new VueloActualizarViewModel();
            try
            {
                using (SqlConnection connection = new SqlConnection(connetionString))
                {
                    SqlCommand command = new SqlCommand("Sp_VueloBuscarPorId", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        vuelo.Id = reader.GetInt32(0);
                        vuelo.CiudadOrigenId = reader.GetInt32(1);
                        vuelo.CiudadDestinoId = reader.GetInt32(2);
                        vuelo.FechaSalida = reader.GetDateTime(3);
                        vuelo.FechaLlegada = reader.GetDateTime(4);
                        vuelo.NumeroVuelo = reader.GetString(5);
                        vuelo.AerolineaId = reader.GetInt32(6);
                        vuelo.EstadoVuelo = reader.GetString(7);
                    }
                    connection.Close();
                }
            }
            catch (System.Exception e)
            {
                errores = e.Message;
            }
            return vuelo;
        }
        internal string EliminarVuelo(int id)
        {
            var errores = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(connetionString))
                {
                    SqlCommand command = new SqlCommand("Sp_VueloEliminar", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                errores = e.Message;
            }
            return errores;
        }
    }

}