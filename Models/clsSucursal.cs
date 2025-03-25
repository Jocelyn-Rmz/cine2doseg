using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// -----------------------------
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using Mysqlx.Connection;

//LUZ MARIA CRUZ GARCIA
//JOCELYN RAMIREZ PEREZ
//JOSE ANTONIO FUENTES RAMIREZ
// Modelo: clsSucursal.cs
namespace cine2doseg.Models
{
    public class clsSucursal
    {
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Url { get; set; }
        public string Logo { get; set; }

        string cadConn = ConfigurationManager.ConnectionStrings["bdCine"].ConnectionString;

        public clsSucursal() { }

        public clsSucursal(string nombre, string direccion, string url, string logo)
        {
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Url = url;
            this.Logo = logo;
        }

        public DataSet vwRptSucursales()
        {
            string query = "SELECT * FROM vwRptSucursales";
            MySqlConnection cnn = new MySqlConnection(cadConn);
            MySqlDataAdapter da = new MySqlDataAdapter(query, cnn);
            DataSet ds = new DataSet();
            da.Fill(ds, "vwRptSucursales");
            return ds;
        }

        public DataSet spInsSucursales()
        {
            string cadSql = "CALL spInsSucursales('" + this.Nombre +
                                    "', '" + this.Direccion +
                                    "', '" + this.Url +
                                    "', '" + this.Logo + "')";

            MySqlConnection cnn = new MySqlConnection(cadConn);
            MySqlDataAdapter da = new MySqlDataAdapter(cadSql, cnn);
            DataSet ds = new DataSet();
            da.Fill(ds, "spInsSucursales");
            return ds;
        }
    }
}

