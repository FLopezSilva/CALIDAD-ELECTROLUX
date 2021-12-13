using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentation.Opcion.MenuEnsayos;
using Presentation.Opcion.MenuEnsayos.Pruebas;
using Domain;
using Presentation.Helpers;
using Presentation.Opcion.MenuEnsayosIndi;
using System.Globalization;

namespace Presentation.Opcion
{
    public partial class FormEnsayo : Form
    {

        private DragControl dragControl;//Permite arrastrar el formulario.       

        public FormEnsayo()
        {
            InitializeComponent();
            txtrut.Text = rut;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            dragControl = new DragControl(panel1, this);


          


        }

        public static int opcion = 0;

        DataSet dss = new DataSet();

        public static string rut = "";



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnComenzar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Digite el codigo de cocina..");
                txtCodigo.Focus();
                txtCodigo.SelectAll();
            }
            else
            {
                string connetionStrings = null;
                connetionStrings = "Data Source=10.130.14.248;Initial Catalog=NuevaQA;User ID=NRFT;Password=Nrft2019$";
                SqlConnection conni = new SqlConnection(connetionStrings);
                conni.Open();
                SqlCommand comando = conni.CreateCommand();
                comando.CommandText = "SELECT * FROM cocina where cod_cocina = @asd";
                comando.Parameters.AddWithValue("@asd", txtCodigo.Text);
                SqlDataAdapter das = new SqlDataAdapter(comando);
                das.Fill(dss);
                int i = dss.Tables[0].Rows.Count;
                if (i > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Datos ingresados ya existentes, ¿ desea actualizarlos ?", "Datos existentes", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string connetionString = null;
                        connetionString = "Data Source = 10.130.14.248; Initial Catalog =NuevaQA; User ID = NRFT; Password = Nrft2019$";
                        SqlConnection conn = new SqlConnection(connetionString);
                        conn.Open();
                        SqlCommand comm = conn.CreateCommand();
                        comm.CommandText = "update cocina set cod_cocina = @miau1,mes_certif = @miau2,solicitud = @miau3,n_serie_desde = @miau4,n_serie_hasta = @miau5,id_modelo = @miau6,id_n_ensayo = @miau7 where cod_cocina = @miau1";
                        comm.Parameters.AddWithValue("@miau1", txtCodigo.Text);
                        string asd = txtCodigo.Text;
                        string asd2 = txtCodigo.Text;
                        comm.Parameters.AddWithValue("@miau4", asd.Substring(0, txtCodigo.Text.IndexOf("'")));

                        comm.Parameters.AddWithValue("@miau2", dateCertificacion.Value);
                        comm.Parameters.AddWithValue("@miau3", txtSolicitud.Text);
                        comm.Parameters.AddWithValue("@miau5", asd.Substring(txtCodigo.Text.IndexOf("'") + 1));
                        comm.Parameters.AddWithValue("@miau6", asd2.Substring(0, txtCodigo.Text.IndexOf("'")));
                        comm.Parameters.AddWithValue("@miau7", asd2.Substring(0, txtCodigo.Text.IndexOf("'")));


                        comm.ExecuteNonQuery();
                        conn.Close();

                        conn.Open();
                        SqlCommand comma = conn.CreateCommand();
                        comma.CommandText = "INSERT INTO CORRELATIVO VALUES ('')";

                        comma.ExecuteNonQuery();
                        conn.Close();

                        var w = new Form() { Size = new Size(0, 0) };
                        Task.Delay(TimeSpan.FromSeconds(3))
                               .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                        MessageBox.Show(w, "COCINA ACTUALIZADA SATISFACTORIAMENTE!", "DATO INGRESADO");

                        FormPrueba mainMenu = new FormPrueba();
                        FormPruebaIndi indi = new FormPruebaIndi();
                        mainMenu.txtrut.Text = txtrut.Text;
                        mainMenu.txtCodigo.Text = asd;
                        mainMenu.txtdesde.Text = txtHasta.Text;
                        mainMenu.txthasta.Text = txtSerie.Text;
                        indi.txtCodigo.Text = asd;
                        indi.txtrut.Text = txtrut.Text;
                        indi.txtdesde.Text = txtHasta.Text;
                        indi.txthasta.Text = txtSerie.Text;


                        if (opcion == 1)
                        {
                            mainMenu.Show();
                            this.Hide();
                        }

                        if (opcion == 0)
                        {
                            indi.Show();
                            this.Hide();
                        }

                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        dss.Clear();
                        txtCodigo.Focus();
                        txtCodigo.SelectAll();
                        txtSerie.Text = "";
                        txtHasta.Text = "";
                        txtFamilia.Text = "";
                        txtModelo.Text = "";
                        txtMarca.Text = "";
                        txtSolicitud.Text = "";
                    }

                }
                else
                {
                    try
                    {

                        string connetionString = null;
                        connetionString = "Data Source = 10.130.14.248; Initial Catalog =NuevaQA; User ID = NRFT; Password = Nrft2019$";
                        SqlConnection conn = new SqlConnection(connetionString);
                        conn.Open();
                        SqlCommand comm = conn.CreateCommand();
                        comm.CommandText = "INSERT INTO cocina(cod_cocina,mes_certif,solicitud,n_serie_desde,n_serie_hasta,id_modelo,id_n_ensayo) VALUES(@miau1, @miau2, @miau3,@miau4,@miau5,@miau6,@miau7)";
                        comm.Parameters.AddWithValue("@miau1", txtCodigo.Text);
                        string asd = txtCodigo.Text;
                        string asd2 = txtCodigo.Text;
                        comm.Parameters.AddWithValue("@miau4", asd.Substring(0, txtCodigo.Text.IndexOf("'")));

                        comm.Parameters.AddWithValue("@miau2", dateCertificacion.Value);
                        comm.Parameters.AddWithValue("@miau3", txtSolicitud.Text);
                        comm.Parameters.AddWithValue("@miau5", asd.Substring(txtCodigo.Text.IndexOf("'") + 1));
                        comm.Parameters.AddWithValue("@miau6", asd2.Substring(0, txtCodigo.Text.IndexOf("'")));
                        comm.Parameters.AddWithValue("@miau7", asd2.Substring(0, txtCodigo.Text.IndexOf("'")));


                        comm.ExecuteNonQuery();
                        conn.Close();

                        conn.Open();
                        SqlCommand comma = conn.CreateCommand();
                        comma.CommandText = "INSERT INTO CORRELATIVO VALUES ('')";

                        comma.ExecuteNonQuery();
                        conn.Close();

                        var w = new Form() { Size = new Size(0, 0) };
                        Task.Delay(TimeSpan.FromSeconds(3))
                               .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                        MessageBox.Show(w, "COCINA INGRESADA SATISFACTORIAMENTE!", "DATO INGRESADO");

                        FormPrueba mainMenu = new FormPrueba();
                        FormPruebaIndi indi = new FormPruebaIndi();
                        mainMenu.txtrut.Text = txtrut.Text;
                        mainMenu.txtCodigo.Text = asd;
                        mainMenu.txtdesde.Text = txtHasta.Text;
                        mainMenu.txthasta.Text = txtSerie.Text;
                        indi.txtCodigo.Text = asd;
                        indi.txtrut.Text = txtrut.Text;

                        
                        if (opcion == 1)
                        {
                            mainMenu.Show();
                            this.Hide();
                        }

                        if (opcion == 0)
                        {
                            indi.Show();
                            this.Hide();
                        }





                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR");
                    }
                }
            }
        }


        // Extracción de datos familia, modelo y marca de la BD con el código de la cocina.
        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            //conexion de la bd
            SqlConnection con = new SqlConnection("Data Source=10.130.14.248;Initial Catalog=NuevaQA;User ID=NRFT;Password=Nrft2019$");
            con.Open();

            // pregunta por txt (si fue ingresado algun dato)
            if (txtCodigo.Text != "")
            {
                string query = "select COUNT(*) from modelo where id_modelo = @id;";

                SqlCommand cmd2 = new SqlCommand(query, con);
                cmd2.Parameters.AddWithValue("@id", txtCodigo.Text);

                string query2 = "select max(id) from correlativo";
                SqlCommand cmd3 = new SqlCommand(query2, con);
                int cant2 = Convert.ToInt32(cmd3.ExecuteScalar());

                string query3 = "select len (id) from correlativo order by id desc";
                SqlCommand cmd4 = new SqlCommand(query3, con);
                int cant3 = Convert.ToInt32(cmd4.ExecuteScalar());

                int cant = Convert.ToInt32(cmd2.ExecuteScalar());

                if (cant == 0)
                {
                    txtSerie.Text = "@id";
                    txtFamilia.Text = "select nom_familia from modelo where id_modelo = @id";
                    txtModelo.Text = "select nom_modelo from modelo where id_modelo = @id";
                    txtMarca.Text = "select nom_marca from modelo where id_modelo = @id";
                }
                else
                {


                }

                SqlCommand cmd = new SqlCommand("select nom_familia, nom_marca ,nom_modelo from modelo where id_modelo = @id;", con);
                string[] pairs = { txtCodigo.Text };
                foreach (var pair in pairs)
                {
                    try
                    {
                        int position = pair.IndexOf("'");
                        if (position < 0)
                            continue;
                        pair.Substring(0, position);
                        cmd.Parameters.AddWithValue("@id", pair.Substring(0, position));

                        SqlDataReader da = cmd.ExecuteReader();
                        while (da.Read())
                        {

                            DateTime v2 = DateTime.Now;
                            int x = System.Globalization.CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(v2, CalendarWeekRule.FirstDay, v2.DayOfWeek);

                            string abc =  "0000";
                            string abc2 = "000";
                            string abc3 = "00";
                            string abc4 = "0";


                            if (cant3 == 1)
                            {
                                txtSolicitud.Text = "21" + x.ToString() + abc + cant2;
                            }
                            else if (cant3 == 2)
                            {
                                txtSolicitud.Text = "21" + x.ToString() + abc2 + cant2;
                            }
                            else if (cant3 == 3)
                            {
                                txtSolicitud.Text = "21" + x.ToString() + abc3 + cant2;
                            }
                            else if (cant3 == 4)
                            {
                                txtSolicitud.Text = "21" + x.ToString() + abc4 + cant2;
                            }

                            txtSerie.Text = pair.Substring(txtCodigo.Text.IndexOf("'") + 1);
                            txtHasta.Text = pair.Substring(0,txtCodigo.Text.IndexOf("'"));
                            txtFamilia.Text = da.GetValue(0).ToString();
                            txtModelo.Text = da.GetValue(2).ToString();
                            txtMarca.Text = da.GetValue(1).ToString();

                        }
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR");
                    }
                }
            }

            //valor que entrega los datos correspondientes de la familia , modelo y marca de la cocina.
            else
            {
                txtSerie.Text = "";
                txtHasta.Text = "";
                txtFamilia.Text = "";
                txtModelo.Text = "";
                txtMarca.Text = "";
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //FormPrueba mainMenu = new FormPrueba();
            //mainMenu.FormClosed += (s, args) => this.Show();
            //this.Close();
            //FormOpcion ads = new FormOpcion();
            //ads.Show();
        }
    
        private void FormEnsayo_Load(object sender, EventArgs e)
        {
            if (opcion == 1)
            {
                label1.Text = "REALIZAR ENSAYO INDIVIDUAL";
            }
            else
            {
                label1.Text = "REALIZAR ENSAYO CERTIFICADO";

            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtHasta_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿ Está seguro de cerrar la aplicación ? ", "Mensaje", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();//Cierra toda la aplicación finalizando todos los procesos.

            }
            else
            {

            }

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro de cerrar sesión ? ", "Mensaje", MessageBoxButtons.YesNo);

            if(dialogResult == DialogResult.Yes)
            {
                this.Close();
                FormLogin ads = new FormLogin();
                ads.Show();
            }
            else
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("¿Está seguro de volver?", "Mensaje", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                var userModel = new UserModel();//Devuelve un objeto UserModel como resultado.
                this.Close();
                Form FormOpcion;
                FormOpcion = new FormOpcion(userModel);
                FormOpcion.Show();
            }
            else
            {

            }

              
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
    }
}
