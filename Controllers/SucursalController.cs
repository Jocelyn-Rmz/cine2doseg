using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using cine2doseg.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Security.Cryptography.X509Certificates;
//------------------------

//LUZ MARIA CRUZ GARCIA
//JOCELYN RAMIREZ PEREZ
//JOSE ANTONIO FUENTES RAMIREZ
namespace cine2doseg.Controllers
{
    public class SucursalController : ApiController
    {
        [HttpGet]
        [Route("cine/sucursal/vwrptsucursales")]
        public clsApiStatus vwRptSucursales()
        {
            clsApiStatus respuesta = new clsApiStatus();
            JObject jsonResp = new JObject();
            DataSet ds = new DataSet();

            try
            {
                clsSucursal sucursal = new clsSucursal();
                ds = sucursal.vwRptSucursales();
                respuesta.statusExec = true;
                respuesta.ban = ds.Tables[0].Rows.Count;
                respuesta.msg = "Sucursales consultadas correctamente";
                jsonResp["sucursales"] = JToken.FromObject(ds.Tables[0]);
                respuesta.datos = jsonResp;
            }
            catch (Exception ex)
            {
                respuesta.statusExec = false;
                respuesta.ban = -1;
                respuesta.msg = "Error al consultar sucursales";
                jsonResp["msgData"] = ex.Message;
                respuesta.datos = jsonResp;
            }

            return respuesta;
        }

        [HttpPost]
        [Route("cine/sucursal/spinssucursales")]
        public clsApiStatus spInsSucursales([FromBody] clsSucursal modelo)
        {
            clsApiStatus respuesta = new clsApiStatus();
            JObject jsonResp = new JObject();
            DataSet ds = new DataSet();

            try
            {
                clsSucursal sucursal = new clsSucursal(modelo.Nombre, modelo.Direccion, modelo.Url, modelo.Logo);
                ds = sucursal.spInsSucursales();
                respuesta.statusExec = true;
                respuesta.ban = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                respuesta.msg = respuesta.ban == 0 ? "Sucursal registrada exitosamente" : "Error en la inserción";
                jsonResp["msgData"] = respuesta.msg;
                respuesta.datos = jsonResp;
            }
            catch (Exception ex)
            {
                respuesta.statusExec = false;
                respuesta.ban = -1;
                respuesta.msg = "Error al insertar sucursal";
                jsonResp["msgData"] = ex.Message;
                respuesta.datos = jsonResp;
            }

            return respuesta;
        }
    }
}
