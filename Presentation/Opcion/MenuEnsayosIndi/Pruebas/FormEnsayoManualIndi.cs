using Presentation.Opcion.MenuEnsayos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Opcion.MenuEnsayosIndi.Pruebas
{
    public partial class FormEnsayoManualIndi : Form
    {

        string inicio = DateTime.Now.ToString("HH:mm:ss");

        public FormEnsayoManualIndi()
        {
            InitializeComponent();
            FormPrueba aas = new FormPrueba();
            string inicio = DateTime.Now.ToString("HH:mm:ss");
        }

        public static string asd = "";






        public string tiempoReten()
        {

            if ((numericRetencion.Value != 0 && numericRetencion.Value > 0) || (numericInercia.Value != 0 && numericInercia.Value > 0))
            {
                string terminoReten = DateTime.Now.ToString("HH:mm:ss");

                return terminoReten;
            }
            else
            {
                return null;
            }

        }

        public string tiempoLlama()
        {

            if (checkBox5.Checked == true || checkBox6.Checked == true || checkBox8.Checked == true)
            {
                string terminoLlama = DateTime.Now.ToString("HH:mm:ss");

                return terminoLlama;
            }
            else
            {
                return null;
            }

        }


        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                checkBox6.Checked = false;
            }
            else
            {

                checkBox6.Checked = true;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                checkBox5.Checked = false;
            }
            else
            {

                checkBox5.Checked = true;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox7.Checked == true)
            {
                checkBox8.Checked = false;
            }
            else
            {

                checkBox8.Checked = true;
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                checkBox7.Checked = false;
            }
            else
            {

                checkBox7.Checked = true;
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {
                checkBox10.Checked = false;
            }
            else
            {

                checkBox10.Checked = true;
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox10.Checked == true)
            {
                checkBox9.Checked = false;
            }
            else
            {

                checkBox9.Checked = true;
            }
        }

       
        private void btnTerminar_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=10.130.14.248;Initial Catalog=NuevaQA;User ID=NRFT;Password=Nrft2019$");
            con.Open();

            if (numericRetencion.Value == 0 || numericInercia.Value == 0)
            {
                MessageBox.Show("Ingrese los datos correspondientes");
            }
            else
            {

                try
                {

                    string query = "select COUNT(*) from ensayo_retencion where id_retencion = @id;";
                    SqlCommand cmd2 = new SqlCommand(query, con);
                    cmd2.Parameters.AddWithValue("@id", asd);
                    int cant = Convert.ToInt32(cmd2.ExecuteScalar());

                    string query2 = "select COUNT(*) from ensayo_c_llama where id_c_llama = @id;";
                    SqlCommand cmd3 = new SqlCommand(query2, con);
                    cmd3.Parameters.AddWithValue("@id", asd);
                    int cant2 = Convert.ToInt32(cmd3.ExecuteScalar());

                    if (cant == 0 && cant2 == 0)
                    {
                        string connetionString = null;
                        connetionString = "Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$";
                        SqlConnection conn = new SqlConnection(connetionString);
                        SqlCommand comm = conn.CreateCommand();



                        //ensayo de retencion de puerta
                        conn.Open();
                        comm.CommandText = "INSERT INTO ensayo_retencion(id_retencion,tiem_retencion,tiem_inercia,cumple_inercia,cumple_retencion,cumple_reten,fecha_ret,hora_inicio_ret,hora_termino_ret) VALUES(@ret1,@ret2, @ret3, @ret4, @ret5, @ret6, @ret7,@ret8,@ret9)";
                        bool retencion = true;
                        if (numericRetencion.Value <= 15)
                        {

                            retencion = true;
                        }
                        else
                        {
                            retencion = false;
                        }
                        ///////////////////////////
                        bool inercia = true;
                        if (numericInercia.Value < 60)
                        {
                            inercia = true;
                        }
                        else
                        {
                            inercia = false;
                        }
                        /////////////////////////////
                        bool final = true;

                        if (inercia == true && retencion == true)
                        {
                            final = true;
                        }
                        else
                        {
                            final = false;
                        }

                        comm.Parameters.AddWithValue("@ret1", asd);
                        comm.Parameters.AddWithValue("@ret2", numericRetencion.Value);
                        comm.Parameters.AddWithValue("@ret3", numericInercia.Value);
                        comm.Parameters.AddWithValue("@ret4", inercia);//valor que debe cambiarse (generar funcion para ver si la prueba aprobo o no)
                        comm.Parameters.AddWithValue("@ret5", retencion);//valor que debe cambiarse (generar funcion para ver si la prueba aprobo o no)
                        comm.Parameters.AddWithValue("@ret6", final);//valor que debe cambiarse (generar funcion para ver si la prueba aprobo o no)
                        comm.Parameters.AddWithValue("@ret7", DateTime.Now);

                        comm.Parameters.AddWithValue("@ret8", inicio);//valor que debe ser cambiado (cuando se abra la ventana se debe recien tener una variable que indique la toma de hora)
                        comm.Parameters.AddWithValue("@ret9", tiempoReten());

                        comm.ExecuteNonQuery();
                        conn.Close();

                        conn.Open();
                        comm.CommandText = "INSERT INTO ensayo_c_llama(id_c_llama,disp_c_llama_f,disp_c_llama_c,encend_interc,cumple_control_llama,fecha_disp_llama,hora_inicio_dcl,hora_termino_dcl) VALUES(@llama1,@llama2, @llama3, @llama4, @llama5, @llama6, @llama7,@llama8)";

                        bool llamaf = true;
                        bool llamac = true;
                        bool llamafinal = true;
                        bool llamainter = true;
                        //true bueno  (1) - false malo (0)
                        if (checkBox6.Checked)
                        {
                            llamaf = false;
                        }
                        else
                        {
                            llamaf = true;
                        }
                        ///////////////////
                        if (checkBox8.Checked)
                        {
                            llamac = false;
                        }
                        else
                        {
                            llamac = true;
                        }
                        /////////////////////
                        if (checkBox10.Checked)
                        {
                            llamainter = false;
                        }
                        else
                        {
                            llamainter = true;
                        }
                        //////////////////////
                        if (checkBox5.Checked = true && checkBox7.Checked == true && checkBox9.Checked == true)
                        {
                            llamafinal = true;
                        }
                        else
                        {
                            llamafinal = false;
                        }

                        comm.Parameters.AddWithValue("@llama1", asd);
                        comm.Parameters.AddWithValue("@llama2", llamaf);
                        comm.Parameters.AddWithValue("@llama3", llamac);
                        comm.Parameters.AddWithValue("@llama4", llamainter);
                        comm.Parameters.AddWithValue("@llama5", llamafinal);
                        comm.Parameters.AddWithValue("@llama6", DateTime.Now);

                        comm.Parameters.AddWithValue("@llama7", inicio);
                        comm.Parameters.AddWithValue("@llama8", tiempoLlama());

                        comm.ExecuteNonQuery();
                        conn.Close();

                        var w = new Form() { Size = new Size(0, 0) };
                        Task.Delay(TimeSpan.FromSeconds(3))
                               .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                        MessageBox.Show("Ensayos manuales registrados satisfactoriamente");



                        this.Close();
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Datos ingresados ya existentes, ¿ desea actualizarlos ?", "Datos existentes", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            string connetionString = null;
                            connetionString = "Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$";
                            SqlConnection conn = new SqlConnection(connetionString);
                            SqlCommand comm = conn.CreateCommand();



                            //ensayo de retencion de puerta
                            conn.Open();
                            comm.CommandText = "update ensayo_retencion set id_retencion = @ret1,tiem_retencion = @ret2,tiem_inercia = @ret3,cumple_inercia = @ret4,cumple_retencion = @ret5,cumple_reten = @ret6,fecha_ret = @ret7,hora_inicio_ret = @ret8,hora_termino_ret = @ret9 where id_retencion = @ret1";
                            bool retencion = true;
                            if (numericRetencion.Value <= 15)
                            {

                                retencion = true;
                            }
                            else
                            {
                                retencion = false;
                            }
                            ///////////////////////////
                            bool inercia = true;
                            if (numericInercia.Value < 60)
                            {
                                inercia = true;
                            }
                            else
                            {
                                inercia = false;
                            }
                            /////////////////////////////
                            bool final = true;
                            if (inercia == true && retencion == true)
                            {
                                final = true;
                            }
                            else
                            {
                                final = false;
                            }

                            comm.Parameters.AddWithValue("@ret1", asd);
                            comm.Parameters.AddWithValue("@ret2", numericRetencion.Value);
                            comm.Parameters.AddWithValue("@ret3", numericInercia.Value);
                            comm.Parameters.AddWithValue("@ret4", inercia);//valor que debe cambiarse (generar funcion para ver si la prueba aprobo o no)
                            comm.Parameters.AddWithValue("@ret5", retencion);//valor que debe cambiarse (generar funcion para ver si la prueba aprobo o no)
                            comm.Parameters.AddWithValue("@ret6", final);//valor que debe cambiarse (generar funcion para ver si la prueba aprobo o no)
                            comm.Parameters.AddWithValue("@ret7", DateTime.Now);

                            comm.Parameters.AddWithValue("@ret8", inicio);//valor que debe ser cambiado (cuando se abra la ventana se debe recien tener una variable que indique la toma de hora)
                            comm.Parameters.AddWithValue("@ret9", tiempoReten());

                            comm.ExecuteNonQuery();
                            conn.Close();


                            conn.Open();
                            comm.CommandText = "update ensayo_c_llama set id_c_llama = @llama1,disp_c_llama_f = @llama2,disp_c_llama_c = @llama3,encend_interc = @llama4,cumple_control_llama = @llama5,fecha_disp_llama = @llama6,hora_inicio_dcl = @llama7,hora_termino_dcl = @llama8 where id_c_llama = @llama1";

                            bool llamaf = true;
                            bool llamac = true;
                            bool llamafinal = true;
                            bool llamainter = true;
                            //true bueno - false malo
                            if (checkBox6.Checked)
                            {
                                llamaf = false;
                            }
                            else if (checkBox5.Checked)
                            {
                                llamaf = true;
                            }
                            ///////////////////
                            if (checkBox8.Checked)
                            {
                                llamac = false;
                            }
                            else if (checkBox7.Checked)
                            {
                                llamac = true;
                            }
                            /////////////////////
                            if (checkBox10.Checked)
                            {
                                llamainter = false;
                            }
                            else if (checkBox9.Checked)
                            {
                                llamainter = true;
                            }
                            //////////////////////
                            if (checkBox5.Checked = true && checkBox7.Checked == true && checkBox9.Checked == true)
                            {
                                llamafinal = true;
                            }
                            else
                            {
                                llamafinal = false;
                            }

                            comm.Parameters.AddWithValue("@llama1", asd);
                            comm.Parameters.AddWithValue("@llama2", llamaf);
                            comm.Parameters.AddWithValue("@llama3", llamac);
                            comm.Parameters.AddWithValue("@llama4", llamainter);
                            comm.Parameters.AddWithValue("@llama5", llamafinal);
                            comm.Parameters.AddWithValue("@llama6", DateTime.Now);

                            comm.Parameters.AddWithValue("@llama7", inicio);
                            comm.Parameters.AddWithValue("@llama8", tiempoLlama());

                            comm.ExecuteNonQuery();
                            conn.Close();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(3))
                                   .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            MessageBox.Show("Ensayos manuales actualizados satisfactoriamente");



                            this.Close();

                        }
                        else if (dialogResult == DialogResult.No)
                        {

                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR");
                }


            }
        }

        private void FormEnsayoManualIndi_Leave(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
