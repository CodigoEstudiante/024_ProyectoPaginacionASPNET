using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data;
using WebApplication3.Modelos;


namespace WebApplication3.Logica
{
    public class LO_Orden
    {
        public List<Orden> obtener(int ignorar_primeros, int cantidad_filas, string filtro) {

            List<Orden> lista = new List<Orden>();

            using (SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True")) {

                SqlCommand cmd = new SqlCommand("sp_ObtenerOrdenes", cn);
                cmd.Parameters.AddWithValue("ignorar_primeros", ignorar_primeros);
                cmd.Parameters.AddWithValue("cantidad_filas", cantidad_filas);
                cmd.Parameters.AddWithValue("filtro", filtro);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader()) {
                    while (dr.Read()) {
                        lista.Add(new Orden()
                        {
                            OrderId = dr["OrderId"].ToString(),
                            CustomerID = dr["CustomerID"].ToString(),
                            ShipAddress = dr["ShipAddress"].ToString(),
                            ShipCountry = dr["ShipCountry"].ToString()
                        });

                    }

                }

            }

            return lista;
        }


        public int obtenerTotal(string filtro)
        {
            int total = 0;

            using (SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True"))
            {

                SqlCommand cmd = new SqlCommand("select dbo.fn_obtenertotal(@filtro)", cn);
                cmd.Parameters.AddWithValue("@filtro", filtro);
                cmd.CommandType = CommandType.Text;

                cn.Open();

                total = Convert.ToInt32(cmd.ExecuteScalar().ToString());

            }


            return total;

        }


    }
}