using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Presentation
{
    class ConexionBD
    {
        string c = "Data Source=10.130.14.248;Initial Catalog=QA;Persist Security Info=True;User ID=NRFT;Password=Nrft2019$";
        public SqlConnection con = new SqlConnection();

        public ConexionBD()
        {

            con.ConnectionString = c;

        }

        public void abrir()
        {

            try
            {

                con.Open();
                Console.WriteLine("Conexion abierta");


            }
            catch (Exception ex)
            {

                Console.WriteLine("Error en la conexion" + ex.Message);

            }
        }

        public void cerrar()
        {

            con.Close();
        }

    }
}
