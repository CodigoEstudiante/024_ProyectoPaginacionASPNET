using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;


using WebApplication3.Logica;
using WebApplication3.Modelos;

namespace WebApplication3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static DataTableResponse<Orden> obtener(string ClientParameters) {



            List<Orden> Lista = new List<Orden>();


            DataTableParameter dtp = JsonConvert.DeserializeObject<DataTableParameter>(ClientParameters);


            Lista = new LO_Orden().obtener(dtp.start, dtp.length, dtp.search.value);

            int total = new LO_Orden().obtenerTotal(dtp.search.value);

            return new DataTableResponse<Orden>() { draw = dtp.draw, recordsFiltered = total, recordsTotal = total, data = Lista };
        }






    }

    public class DataTableParameter
    {
        public int draw { get; set; }
        public int length { get; set; }
        public int start { get; set; }
        public searchtxt search { get; set; }
    }

    public class searchtxt
    {
        public string value { get; set; }
    }

    public struct DataTableResponse<T>
    {
        public int draw;
        public int recordsTotal;
        public int recordsFiltered;
        public List<T> data;
    }

}