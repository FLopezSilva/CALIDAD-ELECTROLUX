using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentation.Opcion.MenuEnsayos.Pruebas;
using System.Data.SqlClient;
using Presentation.Informe;
using Domain;
using Presentation.Helpers;
using System.Diagnostics;
using System.IO;

namespace Presentation.Opcion.MenuEnsayos
{
    public partial class FormPrueba : Form
    {

        string inicio = DateTime.Now.ToString("HH:mm:ss");
        private DragControl dragControl;//Permite arrastrar el formulario.       
        Stopwatch stopwatch = new Stopwatch();

        public FormPrueba()
        {
            InitializeComponent();
            string asd = txtCodigo.Text;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            stopwatch.Start();

            dragControl = new DragControl(panel1, this);


            FormCondicionEnsayo manual = new FormCondicionEnsayo() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            manual.FormBorderStyle = FormBorderStyle.None;
            this.panelOpciones.Controls.Add(manual);
            label1.Text = "Condicion Ensayo";
            manual.txtCodCocina.Text = txtCodigo.Text;


            btnGuardarCondicion.Visible = false;

        }



        //guardar todas las pruebas
        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=10.130.14.248;Initial Catalog=NuevaQA;User ID=NRFT;Password=Nrft2019$");
            con.Open();

            /////////////////////////////// ENSAYO COMBUSTION /////////////////////////////

            string query = "select COUNT(*) from ensayo_comb where id_combu = @id;";
            SqlCommand cmd2 = new SqlCommand(query, con);
            cmd2.Parameters.AddWithValue("@id", txtCodigo.Text);
            int cant = Convert.ToInt32(cmd2.ExecuteScalar());

            if (cant == 0)
            {
                MessageBox.Show("SIN DATOS REGISTRADOS EN ENSAYO COMBUSTION, INGRESE PRUEBA", "ALERTA");
            }

            //////////////////////////// ENSAYO ELECTRICO //////////////////////////////

            string query2 = "select COUNT(*) from ENSAYO_ELECTR where id_electr = @id;";
            SqlCommand cmd3 = new SqlCommand(query2, con);
            cmd3.Parameters.AddWithValue("@id", txtCodigo.Text);
            int cant2 = Convert.ToInt32(cmd3.ExecuteScalar());

            if (cant2 == 0)
            {
                MessageBox.Show("SIN DATOS REGISTRADOS EN ENSAYO ELECTRICO, INGRESE PRUEBA", "ALERTA");
            }

            /////////////////////////// ENSAYO TERMOCUPLA //////////////////////////////////

            string query3 = "select COUNT(*) from ENSAYO_TERMOCUP where id_termo = @id;";
            SqlCommand cmd4 = new SqlCommand(query3, con);
            cmd4.Parameters.AddWithValue("@id", txtCodigo.Text);
            int cant3 = Convert.ToInt32(cmd4.ExecuteScalar());

            if (cant3 == 0)
            {
                MessageBox.Show("SIN DATOS REGISTRADOS EN ENSAYO TERMOCUPLA, INGRESE PRUEBA", "ALERTA");
            }

            ///////////////////////////////////// ENSAYO NIVELACION ////////////////////////////////////////

            string query5 = "select COUNT(*) from ENSAYO_BASCUL where id_basc = @id;";
            SqlCommand cmd6 = new SqlCommand(query5, con);
            cmd6.Parameters.AddWithValue("@id", txtCodigo.Text);
            int cant5 = Convert.ToInt32(cmd6.ExecuteScalar());


            string query6 = "select COUNT(*) from ENSAYO_RESIST where id_resist = @id;";
            SqlCommand cmd7 = new SqlCommand(query6, con);
            cmd7.Parameters.AddWithValue("@id", txtCodigo.Text);
            int cant6 = Convert.ToInt32(cmd7.ExecuteScalar());

      

            string query7 = "select COUNT(*) from ENSAYO_TRABAM where id_trab = @id;";
            SqlCommand cmd8 = new SqlCommand(query7, con);
            cmd8.Parameters.AddWithValue("@id", txtCodigo.Text);
            int cant7 = Convert.ToInt32(cmd8.ExecuteScalar());


            string query8 = "select COUNT(*) from ENSAYO_NIVELAC where id_nivelac = @id;";
            SqlCommand cmd9 = new SqlCommand(query8, con);
            cmd9.Parameters.AddWithValue("@id", txtCodigo.Text);
            int cant8 = Convert.ToInt32(cmd9.ExecuteScalar());

            if (cant8 == 0 || cant7 == 0 || cant6 == 0 || cant5 == 0)
            {
                MessageBox.Show("SIN DATOS REGISTRADOS EN ENSAYO NIVELACION, INGRESE PRUEBA", "ALERTA");
            }

            //////////////////////////////////// CONDICION ENSAYO ///////////////////////////////////////
            
            string query9 = "select COUNT(*) from CONDICION_ENSAYO where cod_cocina = @id;";
            SqlCommand cmd10 = new SqlCommand(query9, con);
            cmd10.Parameters.AddWithValue("@id", txtCodigo.Text);
            int cant9 = Convert.ToInt32(cmd10.ExecuteScalar());

            if (cant9 == 0)
            {
                MessageBox.Show("SIN DATOS REGISTRADOS EN CONDICION DE ENSAYO, INGRESE PRUEBA", "ALERTA");
            }

            //////////////////////////////////// FUGA GAS //////////////////////////////////////////////

            string query10 = "select COUNT(*) from ENSAYO_FUGA_G where id_fuga = @id;";
            SqlCommand cmd11 = new SqlCommand(query10, con);
            cmd11.Parameters.AddWithValue("@id", txtCodigo.Text);
            int cant10 = Convert.ToInt32(cmd11.ExecuteScalar());

            if (cant10 == 0)
            {
                MessageBox.Show("SIN DATOS REGISTRADOS EN ENSAYO FUGA GAS, INGRESE PRUEBA", "ALERTA");
            }
            /////////////////////////////////// OBSERVACIONES Y NOTAS ///////////////////////////////////////

            string query11 = "select COUNT(*) from INFORME_PRUEBA where n_planilla = @id;";
            SqlCommand cmd12 = new SqlCommand(query11, con);
            cmd12.Parameters.AddWithValue("@id", txtCodigo.Text);
            int cant11 = Convert.ToInt32(cmd12.ExecuteScalar());

            if (cant11 == 0)
            {
                MessageBox.Show("SIN DATOS REGISTRADOS EN OBSERVACIONES Y NOTAS, INGRESE PRUEBA", "ALERTA");
            }

            //////////////////////////////// RETENCION Y LLAMA ///////////////////////////////////////////////
           
            string query12 = "select COUNT(*) from ENSAYO_C_LLAMA where id_c_llama = @id;";
            SqlCommand cmd13 = new SqlCommand(query12, con);
            cmd13.Parameters.AddWithValue("@id", txtCodigo.Text);
            int cant12 = Convert.ToInt32(cmd13.ExecuteScalar());

            string query4 = "select COUNT(*) from ENSAYO_RETENCION where id_retencion = @id;";
            SqlCommand cmd5 = new SqlCommand(query4, con);
            cmd5.Parameters.AddWithValue("@id", txtCodigo.Text);
            int cant4 = Convert.ToInt32(cmd5.ExecuteScalar());

            if (cant12 == 0 || cant4 == 0)
            {
                MessageBox.Show("SIN DATOS REGISTRADOS EN ENSAYO MANUALES, INGRESE PRUEBA", "ALERTA");
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////
            

            try
            {
                if (cant == 0 || cant2 == 0 || cant3 == 0 || cant4 == 0 || cant5 == 0 || cant6 == 0 || cant7 == 0 || cant8 == 0 || cant9 == 0 || cant10 == 0 || cant11 == 0 || cant12 == 0)
                {
                    MessageBox.Show("INGRESE DATOS CORRESPONDIENTES", "ALERTA");

                }
                else
                {
                    string connetionString = null;
                    connetionString = "Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$";
                    SqlConnection conn = new SqlConnection(connetionString);
                    conn.Open();

                    string prueba = "select COUNT(*) from PRUEBA where id_retencion = @id;";
                    SqlCommand pruebas = new SqlCommand(prueba, con);
                    pruebas.Parameters.AddWithValue("@id", txtCodigo.Text);
                    int cantidadprueba = Convert.ToInt32(pruebas.ExecuteScalar());

                    if (cantidadprueba == 0)
                    {
                        SqlCommand comm = conn.CreateCommand();

                        string a = DateTime.Now.ToString("HH:mm:ss");
                        string b = DateTime.Now.ToString("dd/MM/yyyy");

                        comm.CommandText = "INSERT INTO prueba(fec_pruebas,hora_inicio_p,hora_termino_p,tiem_prueba,id_combu,id_electr,id_termo,id_retencion,id_basc,id_resist,id_trab,id_nivelac,id_condicion,id_fuga,n_planilla,id_c_llama) VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16)";

                        comm.Parameters.AddWithValue("@p1", DateTime.Now);
                        comm.Parameters.AddWithValue("@p2", inicio);
                        comm.Parameters.AddWithValue("@p3", DateTime.Now.ToString("HH:mm:ss"));

                        stopwatch.Stop();

                        comm.Parameters.AddWithValue("@p4", stopwatch.Elapsed); // ver esto
                        comm.Parameters.AddWithValue("@p5", txtCodigo.Text);
                        comm.Parameters.AddWithValue("@p6", txtCodigo.Text);
                        comm.Parameters.AddWithValue("@p7", txtCodigo.Text);
                        comm.Parameters.AddWithValue("@p8", txtCodigo.Text);
                        comm.Parameters.AddWithValue("@p9", txtCodigo.Text);
                        comm.Parameters.AddWithValue("@p10", txtCodigo.Text);
                        comm.Parameters.AddWithValue("@p11", txtCodigo.Text);
                        comm.Parameters.AddWithValue("@p12", txtCodigo.Text);
                        string codigo1 = txtCodigo.Text.Substring(0, txtCodigo.Text.IndexOf("'"));
                        string codigo2 = txtCodigo.Text.Substring(txtCodigo.Text.IndexOf("'") + 1);
                        // ver el id de condicion tambien
                        int testeo;
                        string A = "select id_condicion from CONDICION_ENSAYO where cod_cocina = '" + codigo1 + "''" + codigo2 + "'";
                        SqlCommand cmd = new SqlCommand(A, conn);

                        testeo = (int)cmd.ExecuteScalar();
                        comm.Parameters.AddWithValue("@p13", testeo/*comm.CommandText = "select id_condicion from CONDICION_ENSAYO where cod_cocina = '" + codigo1 + "''" + codigo2 + "';")*/); ;
                        comm.Parameters.AddWithValue("@p14", txtCodigo.Text);
                        comm.Parameters.AddWithValue("@p15", txtCodigo.Text);
                        comm.Parameters.AddWithValue("@p16", txtCodigo.Text);

                        comm.ExecuteNonQuery();
                        conn.Close();

                        var w = new Form() { Size = new Size(0, 0) };
                        Task.Delay(TimeSpan.FromSeconds(3))
                               .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                        MessageBox.Show("Todas las pruebas de la cocina fueron ingresadas satisfactoriamente");

                        FormInformePDF.rut = txtrut.Text;
                        FormInformePDF.modelo = txtCodigo.Text.Substring(0, txtCodigo.Text.IndexOf("'"));
                        FormInformePDF.codigocompleto = txtCodigo.Text;
                        FormInformePDF.codigo2 = txtCodigo.Text.Substring(txtCodigo.Text.IndexOf("'") + 1);
                        FormInformePDF.opcion = 0;



                        FormInformePDF informe = new FormInformePDF();

                        informe.Show();

                        this.Close();
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Datos ingresados ya existentes, ¿ desea actualizarlos ?", "Datos existentes", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            SqlCommand comm = conn.CreateCommand();

                            string a = DateTime.Now.ToString("HH:mm:ss");
                            string b = DateTime.Now.ToString("dd/MM/yyyy");

                            comm.CommandText = "update prueba set fec_pruebas = @p1,hora_inicio_p = @p2,hora_termino_p = @p3,tiem_prueba = @p4,id_combu = @p5 ,id_electr= @p6,id_termo= @p7,id_retencion= @p8,id_basc= @p9,id_resist= @p10,id_trab= @p11,id_nivelac= @p12,id_condicion= @p13,id_fuga= @p14,n_planilla= @p15,id_c_llama= @p16 where id_c_llama = @p5";

                            comm.Parameters.AddWithValue("@p1", DateTime.Now);
                            comm.Parameters.AddWithValue("@p2", inicio);
                            comm.Parameters.AddWithValue("@p3", DateTime.Now.ToString("HH:mm:ss"));

                            stopwatch.Stop();

                            comm.Parameters.AddWithValue("@p4", stopwatch.Elapsed); // ver esto
                            comm.Parameters.AddWithValue("@p5", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@p6", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@p7", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@p8", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@p9", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@p10", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@p11", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@p12", txtCodigo.Text);
                            string codigo1 = txtCodigo.Text.Substring(0, txtCodigo.Text.IndexOf("'"));
                            string codigo2 = txtCodigo.Text.Substring(txtCodigo.Text.IndexOf("'") + 1);
                            // ver el id de condicion tambien
                            int testeo;
                            string A = "select id_condicion from CONDICION_ENSAYO where cod_cocina = '" + codigo1 + "''" + codigo2 + "'";
                            SqlCommand cmd = new SqlCommand(A, conn);

                            testeo = (int)cmd.ExecuteScalar();
                            comm.Parameters.AddWithValue("@p13", testeo/*comm.CommandText = "select id_condicion from CONDICION_ENSAYO where cod_cocina = '" + codigo1 + "''" + codigo2 + "';")*/); ;
                            comm.Parameters.AddWithValue("@p14", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@p15", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@p16", txtCodigo.Text);

                            comm.ExecuteNonQuery();
                            conn.Close();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(3))
                                   .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            MessageBox.Show("Todas las pruebas de la cocina fueron modificadas satisfactoriamente");

                            FormInformePDF.rut = txtrut.Text;
                            FormInformePDF.modelo = txtCodigo.Text.Substring(0, txtCodigo.Text.IndexOf("'"));
                            FormInformePDF.codigocompleto = txtCodigo.Text;
                            FormInformePDF.codigo2 = txtCodigo.Text.Substring(txtCodigo.Text.IndexOf("'") + 1);
                            FormInformePDF.opcion = 0;


                            FormInformePDF informe = new FormInformePDF();

                            informe.Show();

                            this.Close();

                        }
                        else if (dialogResult == DialogResult.No)
                        {

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void FormPrueba_Load(object sender, EventArgs e)
        {

        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormCondicionEnsayo mainMenu = new FormCondicionEnsayo();
            mainMenu.FormClosed += (s, args) => this.Show();
            FormEnsayo asd = new FormEnsayo();
            asd.Show();
            this.Close();
        }

        private void txtTesteo_TextChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            btnGuardarCondicion.Visible = false;

            btnCondiciones.BackColor = Color.Green;
            btnManuales.BackColor = Color.FromArgb(33, 53, 73);
            btnNivelacion.BackColor = Color.FromArgb(33, 53, 73);
            btnFugaGas.BackColor = Color.FromArgb(33, 53, 73);
            btnCombustion.BackColor = Color.FromArgb(33, 53, 73);
            btnTermocupla.BackColor = Color.FromArgb(33, 53, 73);
            btnElectrico.BackColor = Color.FromArgb(33, 53, 73);
            btnObservacion.BackColor = Color.FromArgb(33, 53, 73);

            FormCondicionEnsayo manual = new FormCondicionEnsayo() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            manual.FormBorderStyle = FormBorderStyle.None;
            this.panelOpciones.Controls.Add(manual);
            label1.Text = "Condicion Ensayo";
            manual.txtCodCocina.Text = txtCodigo.Text;

            manual.BringToFront();
            manual.Show();

            SqlConnection con = new SqlConnection("Data Source=10.130.14.248;Initial Catalog=NuevaQA;User ID=NRFT;Password=Nrft2019$");
            con.Open();

            string query2 = "select COUNT(*) from condicion_ensayo where cod_cocina = @id";


            SqlCommand cmd3 = new SqlCommand(query2, con);
            cmd3.Parameters.AddWithValue("@id", txtCodigo.Text);


            int cant2 = Convert.ToInt32(cmd3.ExecuteScalar());

            if (cant2 == 0)
            {


            }
            else
            {

                string sqlquery = "select presion_gas,poder_calorifico,humed_relativa,temp_ambiente from CONDICION_ENSAYO where cod_cocina = '" + txtdesde.Text + "''" + txthasta.Text + "';";

                SqlCommand command = new SqlCommand(sqlquery, con);

                SqlDataReader sdr = command.ExecuteReader();

                while (sdr.Read())
                {
                    manual.txtPresiongas.Text = sdr["presion_gas"].ToString();
                    manual.txtCalorifico.Text = sdr["poder_calorifico"].ToString();
                    manual.numericHumedad.Value = Convert.ToDecimal(sdr["humed_relativa"]);
                    manual.numericTemperatura.Value = Convert.ToDecimal(sdr["temp_ambiente"]);

                }
            }

            con.Close();

        }

        private void btnManuales_Click(object sender, EventArgs e)
        {

            //FormEnsayoManual manual = new FormEnsayoManual() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            //manual.FormBorderStyle = FormBorderStyle.None;
            //this.panelOpciones.Controls.Add(manual);
            btnGuardarCondicion.Visible = false;

            btnCondiciones.BackColor = Color.FromArgb(33, 53, 73);
            btnManuales.BackColor = Color.Green;
            btnNivelacion.BackColor = Color.FromArgb(33, 53, 73);
            btnFugaGas.BackColor = Color.FromArgb(33, 53, 73);
            btnCombustion.BackColor = Color.FromArgb(33, 53, 73);
            btnTermocupla.BackColor = Color.FromArgb(33, 53, 73);
            btnElectrico.BackColor = Color.FromArgb(33, 53, 73);
            btnObservacion.BackColor = Color.FromArgb(33, 53, 73);

            FormEnsayoManual manual = new FormEnsayoManual() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            manual.FormBorderStyle = FormBorderStyle.None;
            this.panelOpciones.Controls.Add(manual);
            label1.Text = "Pruebas Manuales";
            FormEnsayoManual.asd = txtCodigo.Text;

            manual.BringToFront();
            manual.Show();



            ///////////////////////////////////////////////////////////////

            SqlConnection con = new SqlConnection("Data Source=10.130.14.248;Initial Catalog=NuevaQA;User ID=NRFT;Password=Nrft2019$");
            con.Open();

            string query1 = "select COUNT(*) from ensayo_retencion where id_retencion = @id;";
            string query2 = "select COUNT(*) from ensayo_c_llama where id_c_llama = @id;";
            string query3 = "select disp_c_llama_f from ensayo_c_llama where id_c_llama = @id;";
            string query4 = "select disp_c_llama_c from ensayo_c_llama where id_c_llama = @id;";
            string query5 = "select encend_interc from ensayo_c_llama where id_c_llama = @id;";



            SqlCommand cmd2 = new SqlCommand(query1, con);
            SqlCommand cmd3 = new SqlCommand(query2, con);
            SqlCommand cmd4 = new SqlCommand(query3, con);
            SqlCommand cmd5 = new SqlCommand(query4, con);
            SqlCommand cmd6 = new SqlCommand(query5, con);


            cmd2.Parameters.AddWithValue("@id", txtCodigo.Text);
            cmd3.Parameters.AddWithValue("@id", txtCodigo.Text);
            cmd4.Parameters.AddWithValue("@id", txtCodigo.Text);
            cmd5.Parameters.AddWithValue("@id", txtCodigo.Text);
            cmd6.Parameters.AddWithValue("@id", txtCodigo.Text);


            int cant1 = Convert.ToInt32(cmd2.ExecuteScalar());
            int cant2 = Convert.ToInt32(cmd3.ExecuteScalar());

            int cant3 = Convert.ToInt32(cmd4.ExecuteScalar());
            int cant4 = Convert.ToInt32(cmd5.ExecuteScalar());
            int cant5 = Convert.ToInt32(cmd6.ExecuteScalar());


            if (cant2 == 0 && cant1 == 0)
            {


            }
            else
            {

                string sqlquery = "select tiem_retencion,tiem_inercia from ENSAYO_RETENCION where id_retencion = '" + txtdesde.Text + "''" + txthasta.Text + "';";

                SqlCommand command = new SqlCommand(sqlquery, con);

                SqlDataReader sdr = command.ExecuteReader();

                while (sdr.Read()) 
                {
                    manual.numericRetencion.Value = Convert.ToInt32(sdr["tiem_retencion"]);
                    manual.numericInercia.Value = Convert.ToInt32(sdr["tiem_inercia"]);

                    if (cant3 == 1)
                    {
                        manual.checkBox5.Checked = true;
                    }
                    else
                    {
                        manual.checkBox6.Checked = true;

                    }
                    if (cant4 == 1)
                    {
                        manual.checkBox7.Checked = true;
                    }
                    else
                    {
                        manual.checkBox8.Checked = true;

                    }
                    if (cant5 == 1)
                    {
                        manual.checkBox9.Checked = true;
                    }
                    else
                    {
                        manual.checkBox10.Checked = true;

                    }


                }
            }

            con.Close();
        }

        //botones de menú lateral
        private void button1_Click_2(object sender, EventArgs e)
        {

            //FormEnsayoNivelacion nivelacion = new FormEnsayoNivelacion() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            //manual.FormBorderStyle = FormBorderStyle.None;
            //this.panelOpciones.Controls.Add(manual);
            btnGuardarCondicion.Visible = false;

            btnCondiciones.BackColor = Color.FromArgb(33, 53, 73);
            btnManuales.BackColor = Color.FromArgb(33, 53, 73);
            btnNivelacion.BackColor = Color.Green;
            btnFugaGas.BackColor = Color.FromArgb(33, 53, 73);
            btnCombustion.BackColor = Color.FromArgb(33, 53, 73);
            btnTermocupla.BackColor = Color.FromArgb(33, 53, 73);
            btnElectrico.BackColor = Color.FromArgb(33, 53, 73);
            btnObservacion.BackColor = Color.FromArgb(33, 53, 73);




            FormEnsayoNivelacion nivelacion = new FormEnsayoNivelacion() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            nivelacion.TopLevel = false;
            nivelacion.AutoScroll = true;
            this.panelOpciones.Controls.Add(nivelacion);

            label1.Text = "Ensayo Nivelación";
            //AbrirFormHija(new FormEnsayoNivelacion());

            FormEnsayoNivelacion.asd2 = txtCodigo.Text;

            nivelacion.Show();
            nivelacion.BringToFront();

            ///////////////////////////////////////////////////////////////

            SqlConnection con = new SqlConnection("Data Source=10.130.14.248;Initial Catalog=NuevaQA;User ID=NRFT;Password=Nrft2019$");
            con.Open();

            string query1 = "select COUNT(*) from ensayo_nivelac where id_nivelac = @id;";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            cmd1.Parameters.AddWithValue("@id", txtCodigo.Text);
            int cant1 = Convert.ToInt32(cmd1.ExecuteScalar());

            string query2 = "select COUNT(*) from ensayo_resist where id_resist = @id;";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.Parameters.AddWithValue("@id", txtCodigo.Text);
            int cant2 = Convert.ToInt32(cmd2.ExecuteScalar());

            string query3 = "select COUNT(*) from ensayo_trabam where id_trab = @id;";
            SqlCommand cmd3 = new SqlCommand(query3, con);
            cmd3.Parameters.AddWithValue("@id", txtCodigo.Text);
            int cant3 = Convert.ToInt32(cmd3.ExecuteScalar());

            string query4 = "select COUNT(*) from ENSAYO_BASCUL where id_basc = @id;";
            SqlCommand cmd4 = new SqlCommand(query4, con);
            cmd4.Parameters.AddWithValue("@id", txtCodigo.Text);
            int cant4 = Convert.ToInt32(cmd4.ExecuteScalar());

            /////////////////////////////////////////////

            string query5 = "select cumple_trab from ENSAYO_TRABAM where id_trab = @id;";
            SqlCommand cmd5 = new SqlCommand(query5, con);
            cmd5.Parameters.AddWithValue("@id", txtCodigo.Text);
            int cant5 = Convert.ToInt32(cmd5.ExecuteScalar());

            string query6 = "select cumple_basc from ENSAYO_BASCUL where id_basc = @id;";
            SqlCommand cmd6 = new SqlCommand(query6, con);
            cmd6.Parameters.AddWithValue("@id", txtCodigo.Text);
            int cant6 = Convert.ToInt32(cmd6.ExecuteScalar());


            if (cant1 == 0 && cant2 == 0 && cant3 == 0 && cant4 == 0)
            {

            }
            else
            {

                string sqlquery = "select a.niv_puerta_sp,a.niv_puerta_cp,b.resist_puerta  from ENSAYO_NIVELAC a inner join ENSAYO_RESIST  b on a.id_nivelac = b.id_resist where a.id_nivelac = '" + txtdesde.Text + "''" + txthasta.Text + "';";

                SqlCommand command = new SqlCommand(sqlquery, con);

                SqlDataReader sdr = command.ExecuteReader();

                while (sdr.Read())
                {
                    nivelacion.numericNivSPeso.Value = Convert.ToInt32(sdr["niv_puerta_sp"]);
                    nivelacion.numericNivCPeso.Value = Convert.ToInt32(sdr["niv_puerta_cp"]);
                    nivelacion.numericResistencia.Value = Convert.ToInt32(sdr["resist_puerta"]);

                    if (cant5 == 1)
                    {
                        nivelacion.checkBox3.Checked = true;
                    }
                    else
                    {
                        nivelacion.checkBox4.Checked = true;
                    }

                    if (cant6 == 1)
                    {
                        nivelacion.checkBox2.Checked = true;
                    }
                    else
                    {
                        nivelacion.checkBox1.Checked = true;
                    }



                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //FormEnsayoFugaGas fugagas = new FormEnsayoFugaGas() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            //manual.FormBorderStyle = FormBorderStyle.None;
            //this.panelOpciones.Controls.Add(manual);
            btnGuardarCondicion.Visible = false;

            btnCondiciones.BackColor = Color.FromArgb(33, 53, 73);
            btnManuales.BackColor = Color.FromArgb(33, 53, 73);
            btnNivelacion.BackColor = Color.FromArgb(33, 53, 73);
            btnFugaGas.BackColor = Color.Green;
            btnCombustion.BackColor = Color.FromArgb(33, 53, 73);
            btnTermocupla.BackColor = Color.FromArgb(33, 53, 73);
            btnElectrico.BackColor = Color.FromArgb(33, 53, 73);
            btnObservacion.BackColor = Color.FromArgb(33, 53, 73);


            FormEnsayoFugaGas fugagas = new FormEnsayoFugaGas() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            fugagas.TopLevel = false;
            fugagas.AutoScroll = true;
            this.panelOpciones.Controls.Add(fugagas);

            label1.Text = "Ensayo Fuga de Gas";

            FormEnsayoFugaGas.asd3 = txtCodigo.Text;

            fugagas.Show();
            fugagas.BringToFront();

            ///////////////////////////////////////
            SqlConnection con = new SqlConnection("Data Source=10.130.14.248;Initial Catalog=NuevaQA;User ID=NRFT;Password=Nrft2019$");
            con.Open();

            string query3 = "select count(*) from ensayo_fuga_g where id_fuga = @id;";
            SqlCommand cmd3 = new SqlCommand(query3, con);
            cmd3.Parameters.AddWithValue("@id", txtCodigo.Text);
            int cant3 = Convert.ToInt32(cmd3.ExecuteScalar());

            string query1 = "select est_conj_gas from ensayo_fuga_g where id_fuga = @id;";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            cmd1.Parameters.AddWithValue("@id", txtCodigo.Text);
            int cant1 = Convert.ToInt32(cmd1.ExecuteScalar());

            string query2 = "select est_indiv_gas from ensayo_fuga_g where id_fuga = @id;";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.Parameters.AddWithValue("@id", txtCodigo.Text);
            int cant2 = Convert.ToInt32(cmd2.ExecuteScalar());

            if (cant3 == 0)
            {

            }
            else
            {

                string sqlquery = "select COUNT(*) from ensayo_fuga_g where id_fuga = '" + txtdesde.Text + "''" + txthasta.Text + "'";

                SqlCommand command = new SqlCommand(sqlquery, con);

                SqlDataReader sdr = command.ExecuteReader();

                while (sdr.Read())
                {

                    if (cant1 == 1)
                    {
                        fugagas.checkBox3.Checked = true;
                    }
                    else
                    {
                        fugagas.checkBox1.Checked = true;
                    }

                    if (cant2 == 1)
                    {
                        fugagas.checkBox5.Checked = true;
                    }
                    else
                    {
                        fugagas.checkBox4.Checked = true;
                    }
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //FormEnsayoCombustion combustion = new FormEnsayoCombustion() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            //manual.FormBorderStyle = FormBorderStyle.None;
            //this.panelOpciones.Controls.Add(manual);
            btnGuardarCondicion.Visible = false;

            btnCondiciones.BackColor = Color.FromArgb(33, 53, 73);
            btnManuales.BackColor = Color.FromArgb(33, 53, 73);
            btnNivelacion.BackColor = Color.FromArgb(33, 53, 73);
            btnFugaGas.BackColor = Color.FromArgb(33, 53, 73);
            btnCombustion.BackColor = Color.Green;
            btnTermocupla.BackColor = Color.FromArgb(33, 53, 73);
            btnElectrico.BackColor = Color.FromArgb(33, 53, 73);
            btnObservacion.BackColor = Color.FromArgb(33, 53, 73);


            FormEnsayoCombustion combustion = new FormEnsayoCombustion() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            combustion.TopLevel = false;
            combustion.AutoScroll = true;
            this.panelOpciones.Controls.Add(combustion);

            label1.Text = "Ensayo Combustion";
            //AbrirFormHija(new FormEnsayoFugaGas());
       
            FormEnsayoCombustion.asd4 = txtCodigo.Text;

            combustion.Show();
            combustion.BringToFront();

            ///////////////////////////////////////
            SqlConnection con = new SqlConnection("Data Source=10.130.14.248;Initial Catalog=NuevaQA;User ID=NRFT;Password=Nrft2019$");
            con.Open();

            string query1 = "select co from COMBU where id_combu = @id AND nom_quemador = 'Quemador Trasero Derecho' AND nom_posicion = 'Consumo Total';";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            cmd1.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant1 = Convert.ToSingle(cmd1.ExecuteScalar());

            string query2 = "select co_2 from COMBU where id_combu = @id AND nom_quemador = 'Quemador Trasero Derecho' AND nom_posicion = 'Consumo Total';";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant2 = Convert.ToSingle(cmd2.ExecuteScalar());

            ////////////////////////////

            string query3 = "select co from COMBU where id_combu = @id AND nom_quemador = 'Quemador Trasero Derecho' AND nom_posicion = 'Consumo medio (1/2)';";
            SqlCommand cmd3 = new SqlCommand(query3, con);
            cmd3.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant3 = Convert.ToSingle(cmd3.ExecuteScalar());

            string query4 = "select co_2 from COMBU where id_combu = @id AND nom_quemador = 'Quemador Trasero Derecho' AND nom_posicion = 'Consumo medio (1/2)';";
            SqlCommand cmd4 = new SqlCommand(query4, con);
            cmd4.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant4 = Convert.ToSingle(cmd4.ExecuteScalar());

            //////////////////////////////
            ///
            string query5 = "select co from COMBU where id_combu = @id AND nom_quemador = 'Quemador Trasero Izquierdo' AND nom_posicion = 'Consumo Total';";
            SqlCommand cmd5 = new SqlCommand(query5, con);
            cmd5.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant5 = Convert.ToSingle(cmd5.ExecuteScalar());

            string query6 = "select co_2 from COMBU where id_combu = @id AND nom_quemador = 'Quemador Trasero Izquierdo' AND nom_posicion = 'Consumo Total';";
            SqlCommand cmd6 = new SqlCommand(query6, con);
            cmd6.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant6 = Convert.ToSingle(cmd6.ExecuteScalar());

            //////////////////////////////
            ///
            string query7 = "select co from COMBU where id_combu = @id AND nom_quemador = 'Quemador Trasero Izquierdo' AND nom_posicion = 'Consumo medio (1/2)';";
            SqlCommand cmd7 = new SqlCommand(query7, con);
            cmd7.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant7 = Convert.ToSingle(cmd7.ExecuteScalar());

            string query8 = "select co_2 from COMBU where id_combu = @id AND nom_quemador = 'Quemador Trasero Izquierdo' AND nom_posicion = 'Consumo medio (1/2)';";
            SqlCommand cmd8 = new SqlCommand(query8, con);
            cmd8.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant8 = Convert.ToSingle(cmd8.ExecuteScalar());

            //////////////////////////////
            ///
            string query9 = "select co from COMBU where id_combu = @id AND nom_quemador = 'Quemador Delantero Izquierdo' AND nom_posicion = 'Consumo Total';";
            SqlCommand cmd9 = new SqlCommand(query9, con);
            cmd9.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant9 = Convert.ToSingle(cmd9.ExecuteScalar());

            string query10 = "select co_2 from COMBU where id_combu = @id AND nom_quemador = 'Quemador Delantero Izquierdo' AND nom_posicion = 'Consumo Total';";
            SqlCommand cmd10 = new SqlCommand(query10, con);
            cmd10.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant10 = Convert.ToSingle(cmd10.ExecuteScalar());

            //////////////////////////////
            ///
            string query11 = "select co from COMBU where id_combu = @id AND nom_quemador = 'Quemador Delantero Izquierdo' AND nom_posicion = 'Consumo medio (1/2)';";
            SqlCommand cmd11 = new SqlCommand(query11, con);
            cmd11.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant11 = Convert.ToSingle(cmd11.ExecuteScalar());

            string query12 = "select co_2 from COMBU where id_combu = @id AND nom_quemador = 'Quemador Delantero Izquierdo' AND nom_posicion = 'Consumo medio (1/2)';";
            SqlCommand cmd12 = new SqlCommand(query12, con);
            cmd12.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant12 = Convert.ToSingle(cmd12.ExecuteScalar());

            //////////////////////////////
            ///
            string query13 = "select co from COMBU where id_combu = @id AND nom_quemador = 'Quemador Delantero Derecho' AND nom_posicion = 'Consumo Total';";
            SqlCommand cmd13 = new SqlCommand(query13, con);
            cmd13.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant13 = Convert.ToSingle(cmd13.ExecuteScalar());

            string query14 = "select co_2 from COMBU where id_combu = @id AND nom_quemador = 'Quemador Delantero Derecho' AND nom_posicion = 'Consumo Total';";
            SqlCommand cmd14 = new SqlCommand(query14, con);
            cmd14.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant14 = Convert.ToSingle(cmd14.ExecuteScalar());

            //////////////////////////////
            ///
            string query15 = "select co from COMBU where id_combu = @id AND nom_quemador = 'Quemador Delantero Derecho' AND nom_posicion = 'Consumo medio (1/2)';";
            SqlCommand cmd15 = new SqlCommand(query15, con);
            cmd15.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant15 = Convert.ToSingle(cmd15.ExecuteScalar());

            string query16 = "select co_2 from COMBU where id_combu = @id AND nom_quemador = 'Quemador Delantero Derecho' AND nom_posicion = 'Consumo medio (1/2)';";
            SqlCommand cmd16 = new SqlCommand(query16, con);
            cmd16.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant16 = Convert.ToSingle(cmd16.ExecuteScalar());

            //////////////////////////////
            ///
            string query17 = "select co from COMBU where id_combu = @id AND nom_quemador = 'Quemador Central Delantero' AND nom_posicion = 'Consumo Total';";
            SqlCommand cmd17 = new SqlCommand(query17, con);
            cmd17.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant17 = Convert.ToSingle(cmd17.ExecuteScalar());

            string query18 = "select co_2 from COMBU where id_combu = @id AND nom_quemador = 'Quemador Central Delantero' AND nom_posicion = 'Consumo Total';";
            SqlCommand cmd18 = new SqlCommand(query18, con);
            cmd18.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant18 = Convert.ToSingle(cmd18.ExecuteScalar());

            //////////////////////////////
            ///
            string query19 = "select co from COMBU where id_combu = @id AND nom_quemador = 'Quemador Central Delantero' AND nom_posicion = 'Consumo medio (1/2)';";
            SqlCommand cmd19 = new SqlCommand(query19, con);
            cmd19.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant19 = Convert.ToSingle(cmd19.ExecuteScalar());

            string query20 = "select co_2 from COMBU where id_combu = @id AND nom_quemador = 'Quemador Central Delantero' AND nom_posicion = 'Consumo medio (1/2)';";
            SqlCommand cmd20 = new SqlCommand(query20, con);
            cmd20.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant20 = Convert.ToSingle(cmd20.ExecuteScalar());

            //////////////////////////////
            ///
            string query21 = "select co from COMBU where id_combu = @id AND nom_quemador = 'Quemador Central Trasero' AND nom_posicion = 'Consumo Total';";
            SqlCommand cmd21 = new SqlCommand(query21, con);
            cmd21.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant21 = Convert.ToSingle(cmd21.ExecuteScalar());

            string query22 = "select co_2 from COMBU where id_combu = @id AND nom_quemador = 'Quemador Central Trasero' AND nom_posicion = 'Consumo Total';";
            SqlCommand cmd22 = new SqlCommand(query22, con);
            cmd22.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant22 = Convert.ToSingle(cmd22.ExecuteScalar());

            //////////////////////////////
            ///
            string query23 = "select co from COMBU where id_combu = @id AND nom_quemador = 'Quemador Central Trasero' AND nom_posicion = 'Consumo medio (1/2)';";
            SqlCommand cmd23 = new SqlCommand(query23, con);
            cmd23.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant23 = Convert.ToSingle(cmd23.ExecuteScalar());

            string query24 = "select co_2 from COMBU where id_combu = @id AND nom_quemador = 'Quemador Central Trasero' AND nom_posicion = 'Consumo medio (1/2)';";
            SqlCommand cmd24 = new SqlCommand(query24, con);
            cmd24.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant24 = Convert.ToSingle(cmd24.ExecuteScalar());

            //////////////////////////////
            ///
            string query25 = "select co from COMBU where id_combu = @id AND nom_quemador = 'Quemador Central' AND nom_posicion = 'Consumo Total';";
            SqlCommand cmd25 = new SqlCommand(query25, con);
            cmd25.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant25 = Convert.ToSingle(cmd25.ExecuteScalar());

            string query26 = "select co_2 from COMBU where id_combu = @id AND nom_quemador = 'Quemador Central' AND nom_posicion = 'Consumo Total';";
            SqlCommand cmd26 = new SqlCommand(query26, con);
            cmd26.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant26 = Convert.ToSingle(cmd26.ExecuteScalar());

            //////////////////////////////
            ///
            string query27 = "select co from COMBU where id_combu = @id AND nom_quemador = 'Quemador Central' AND nom_posicion = 'Consumo medio (1/2)';";
            SqlCommand cmd27 = new SqlCommand(query27, con);
            cmd27.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant27 = Convert.ToSingle(cmd27.ExecuteScalar());

            string query28 = "select co_2 from COMBU where id_combu = @id AND nom_quemador = 'Quemador Central' AND nom_posicion = 'Consumo medio (1/2)';";
            SqlCommand cmd28 = new SqlCommand(query28, con);
            cmd28.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant28 = Convert.ToSingle(cmd28.ExecuteScalar());

            //////////////////////////////
            ///
            string query29 = "select co from COMBU where id_combu = @id AND nom_quemador = 'Horno' AND nom_posicion = 'Consumo Total';";
            SqlCommand cmd29 = new SqlCommand(query29, con);
            cmd29.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant29 = Convert.ToSingle(cmd29.ExecuteScalar());

            string query30 = "select co_2 from COMBU where id_combu = @id AND nom_quemador = 'Horno' AND nom_posicion = 'Consumo Total';";
            SqlCommand cmd30 = new SqlCommand(query30, con);
            cmd30.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant30 = Convert.ToSingle(cmd30.ExecuteScalar());

            //////////////////////////////
            ///
            string query31 = "select co from COMBU where id_combu = @id AND nom_quemador = 'Horno' AND nom_posicion = 'Consumo medio (1/2)';";
            SqlCommand cmd31 = new SqlCommand(query31, con);
            cmd31.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant31 = Convert.ToSingle(cmd31.ExecuteScalar());

            string query32 = "select co_2 from COMBU where id_combu = @id AND nom_quemador = 'Horno' AND nom_posicion = 'Consumo medio (1/2)';";
            SqlCommand cmd32 = new SqlCommand(query32, con);
            cmd32.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant32 = Convert.ToSingle(cmd32.ExecuteScalar());





            try
            {
                string sqlquery = "select COUNT(*) from COMBU where id_combu = '" + txtdesde.Text + "''" + txthasta.Text + "'";

                SqlCommand command = new SqlCommand(sqlquery, con);

                SqlDataReader sdr = command.ExecuteReader();

                while (sdr.Read())
                {


                    double resultado1 = (cant1 / cant2) * 14 * 0.0001;

                    float t = Convert.ToSingle(resultado1);

                    if (t > 0)
                    {
                        double total_1 = (Math.Truncate(t * 10000)) / 10000;

                        combustion.textBox1.Text = total_1.ToString();
                    }
                    else
                    {
                        combustion.textBox1.Text = "0";
                    }


                    double resultado2 = (cant3 / cant4) * 14 * 0.0001;

                    float t2 = Convert.ToSingle(resultado2);

                    if (t2 > 0)
                    {
                        double total_2 = (Math.Truncate(t2 * 10000)) / 10000;

                        combustion.textBox17.Text = total_2.ToString();
                    }
                    else
                    {
                        combustion.textBox17.Text = "0";
                    }

                    double resultado3 = (cant5 / cant6) * 14 * 0.0001;

                    float t3 = Convert.ToSingle(resultado3);

                    if (t3 > 0)
                    {
                        double total_3 = (Math.Truncate(t3 * 10000)) / 10000;

                        combustion.textBox3.Text = total_3.ToString();
                    }
                    else
                    {
                        combustion.textBox3.Text = "0";
                    }

                    double resultado4 = (cant7 / cant8) * 14 * 0.0001;

                    float t4 = Convert.ToSingle(resultado4);

                    if (t4 > 0)
                    {
                        double total_4 = (Math.Truncate(t4 * 10000)) / 10000;

                        combustion.textBox4.Text = total_4.ToString();
                    }
                    else
                    {
                        combustion.textBox4.Text = "0";
                    }

                    double resultado5 = (cant9 / cant10) * 14 * 0.0001;

                    float t5 = Convert.ToSingle(resultado5);

                    if (t5 > 0)
                    {
                        double total_5 = (Math.Truncate(t5 * 10000)) / 10000;

                        combustion.textBox5.Text = total_5.ToString();
                    }
                    else
                    {
                        combustion.textBox5.Text = "0";
                    }

                    double resultado6 = (cant11 / cant12) * 14 * 0.0001;

                    float t6 = Convert.ToSingle(resultado6);

                    if (t6 > 0)
                    {
                        double total_6 = (Math.Truncate(t6 * 10000)) / 10000;

                        combustion.textBox6.Text = total_6.ToString();
                    }
                    else
                    {
                        combustion.textBox6.Text = "0";
                    }

                    double resultado7 = (cant13 / cant14) * 14 * 0.0001;

                    float t7 = Convert.ToSingle(resultado7);

                    if (t7 > 0)
                    {
                        double total_7 = (Math.Truncate(t7 * 10000)) / 10000;

                        combustion.textBox7.Text = total_7.ToString();
                    }
                    else
                    {
                        combustion.textBox7.Text = "0";
                    }

                    double resultado8 = (cant15 / cant16) * 14 * 0.0001;

                    float t8 = Convert.ToSingle(resultado8);

                    if (t8 > 0)
                    {
                        double total_8 = (Math.Truncate(t8 * 10000)) / 10000;

                        combustion.textBox8.Text = total_8.ToString();
                    }
                    else
                    {
                        combustion.textBox8.Text = "0";
                    }

                    double resultado9 = (cant17 / cant18) * 14 * 0.0001;

                    float t9 = Convert.ToSingle(resultado9);

                    if (t9 > 0)
                    {
                        double total_9 = (Math.Truncate(t9 * 10000)) / 10000;

                        combustion.textBox9.Text = total_9.ToString();
                    }
                    else
                    {
                        combustion.textBox9.Text = "0";
                    }

                    double resultado10 = (cant19 / cant20) * 14 * 0.0001;

                    float t10 = Convert.ToSingle(resultado10);

                    if (t10 > 0)
                    {
                        double total_10 = (Math.Truncate(t10 * 10000)) / 10000;

                        combustion.textBox10.Text = total_10.ToString();
                    }
                    else
                    {
                        combustion.textBox10.Text = "0";
                    }

                    double resultado11 = (cant21 / cant22) * 14 * 0.0001;

                    float t11 = Convert.ToSingle(resultado11);

                    if (t11 > 0)
                    {
                        double total_11 = (Math.Truncate(t11 * 10000)) / 10000;

                        combustion.textBox11.Text = total_11.ToString();
                    }
                    else
                    {
                        combustion.textBox11.Text = "0";
                    }

                    double resultado12 = (cant23 / cant24) * 14 * 0.0001;

                    float t12 = Convert.ToSingle(resultado12);

                    if (t12 > 0)
                    {
                        double total_12 = (Math.Truncate(t12 * 10000)) / 10000;

                        combustion.textBox12.Text = total_12.ToString();
                    }
                    else
                    {
                        combustion.textBox12.Text = "0";
                    }


                    double resultado13 = (cant25 / cant26) * 14 * 0.0001;

                    float t13 = Convert.ToSingle(resultado13);

                    if (t13 > 0)
                    {
                        double total_13 = (Math.Truncate(t13 * 10000)) / 10000;

                        combustion.textBox13.Text = total_13.ToString();
                    }
                    else
                    {
                        combustion.textBox13.Text = "0";
                    }

                    double resultado14 = (cant27 / cant28) * 14 * 0.0001;

                    float t14 = Convert.ToSingle(resultado14);

                    if (t14 > 0)
                    {
                        double total_14 = (Math.Truncate(t14 * 10000)) / 10000;

                        combustion.textBox14.Text = total_14.ToString();
                    }
                    else
                    {
                        combustion.textBox14.Text = "0";
                    }

                    double resultado15 = (cant29 / cant30) * 14 * 0.0001;

                    float t15 = Convert.ToSingle(resultado15);

                    if (t15 > 0)
                    {
                        double total_15 = (Math.Truncate(t15 * 10000)) / 10000;

                        combustion.textBox15.Text = total_15.ToString();
                    }
                    else
                    {
                        combustion.textBox15.Text = "0";
                    }

                    double resultado16 = (cant31 / cant32) * 14 * 0.0001;

                    float t16 = Convert.ToSingle(resultado16);

                    if (t16 > 0)
                    {
                        double total_16 = (Math.Truncate(t16 * 10000)) / 10000;
                        combustion.textBox16.Text = total_16.ToString();
                    }
                    else
                    {
                        combustion.textBox16.Text = "0";
                    }


                    combustion.textBoxCo.Text = cant1.ToString();
                    combustion.textBoxCo_2.Text = cant2.ToString();

                    combustion.textBoxCo2.Text = cant3.ToString();
                    combustion.textBoxCo_2_2.Text = cant4.ToString();

                    combustion.textBoxCo3.Text = cant5.ToString();
                    combustion.textBoxCo_2_3.Text = cant6.ToString();

                    combustion.textBoxCo4.Text = cant7.ToString();
                    combustion.textBoxCo_2_4.Text = cant8.ToString();

                    combustion.textBoxCo5.Text = cant9.ToString();
                    combustion.textBoxCo_2_5.Text = cant10.ToString();

                    combustion.textBoxCo6.Text = cant11.ToString();
                    combustion.textBoxCo_2_6.Text = cant12.ToString();

                    combustion.textBoxCo7.Text = cant13.ToString();
                    combustion.textBoxCo_2_7.Text = cant14.ToString();

                    combustion.textBoxCo8.Text = cant15.ToString();
                    combustion.textBoxCo_2_8.Text = cant16.ToString();

                    combustion.textBoxCo9.Text = cant17.ToString();
                    combustion.textBoxCo_2_9.Text = cant18.ToString();

                    combustion.textBoxCo10.Text = cant19.ToString();
                    combustion.textBoxCo_2_10.Text = cant20.ToString();

                    combustion.textBoxCo11.Text = cant21.ToString();
                    combustion.textBoxCo_2_11.Text = cant22.ToString();

                    combustion.textBoxCo12.Text = cant23.ToString();
                    combustion.textBoxCo_2_12.Text = cant24.ToString();

                    combustion.textBoxCo13.Text = cant25.ToString();
                    combustion.textBoxCo_2_13.Text = cant26.ToString();

                    combustion.textBoxCo14.Text = cant27.ToString();
                    combustion.textBoxCo_2_14.Text = cant28.ToString();

                    combustion.textBoxCo15.Text = cant29.ToString();
                    combustion.textBoxCo_2_15.Text = cant30.ToString();

                    combustion.textBoxCo16.Text = cant31.ToString();
                    combustion.textBoxCo_2_16.Text = cant32.ToString();

                }

            }
            catch (Exception )
            {

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //FormEnsayoTermocupla termocupla = new FormEnsayoTermocupla() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            //manual.FormBorderStyle = FormBorderStyle.None;
            //this.panelOpciones.Controls.Add(manual);
            btnGuardarCondicion.Visible = false;

            btnCondiciones.BackColor = Color.FromArgb(33, 53, 73);
            btnManuales.BackColor = Color.FromArgb(33, 53, 73);
            btnNivelacion.BackColor = Color.FromArgb(33, 53, 73);
            btnFugaGas.BackColor = Color.FromArgb(33, 53, 73);
            btnCombustion.BackColor = Color.FromArgb(33, 53, 73);
            btnTermocupla.BackColor = Color.Green;
            btnElectrico.BackColor = Color.FromArgb(33, 53, 73);
            btnObservacion.BackColor = Color.FromArgb(33, 53, 73);



            FormEnsayoTermocupla termocupla = new FormEnsayoTermocupla() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            termocupla.TopLevel = false;
            termocupla.AutoScroll = true;
            this.panelOpciones.Controls.Add(termocupla);

            label1.Text = "Ensayo Termocupla";
            //AbrirFormHija(new FormEnsayoFugaGas());
      
            FormEnsayoTermocupla.asd5 = txtCodigo.Text;

            termocupla.Show();
            termocupla.BringToFront();

            ////////////////////////////////////////////////
            ///

            SqlConnection con = new SqlConnection("Data Source=10.130.14.248;Initial Catalog=NuevaQA;User ID=NRFT;Password=Nrft2019$");
            con.Open();

            string query1 = "select temp_pieza from TERMOC where id_termo = @id AND descrip_pieza = 'Perrilla QTD';";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            cmd1.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant1 = Convert.ToSingle(cmd1.ExecuteScalar());

            //////////////////////////////

            string query2 = "select temp_pieza from TERMOC where id_termo = @id AND descrip_pieza = 'Perrilla QDD';";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant2 = Convert.ToSingle(cmd2.ExecuteScalar());

            ////////////////////////////

            string query3 = "select temp_pieza from TERMOC where id_termo = @id AND descrip_pieza = 'Perrilla QTI';";
            SqlCommand cmd3 = new SqlCommand(query3, con);
            cmd3.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant3 = Convert.ToSingle(cmd3.ExecuteScalar());

            string query4 = "select temp_pieza from TERMOC where id_termo = @id AND descrip_pieza = 'Perrilla QDI';";
            SqlCommand cmd4 = new SqlCommand(query4, con);
            cmd4.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant4 = Convert.ToSingle(cmd4.ExecuteScalar());

            //////////////////////////////
            ///
            string query5 = "select temp_pieza from TERMOC where id_termo = @id AND descrip_pieza = 'Perrilla Horno';";
            SqlCommand cmd5 = new SqlCommand(query5, con);
            cmd5.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant5 = Convert.ToSingle(cmd5.ExecuteScalar());

            string query6 = "select temp_pieza from TERMOC where id_termo = @id AND descrip_pieza = 'Perrilla QC';";
            SqlCommand cmd6 = new SqlCommand(query6, con);
            cmd6.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant6 = Convert.ToSingle(cmd6.ExecuteScalar());

            //////////////////////////////
            ///
            string query7 = "select temp_pieza from TERMOC where id_termo = @id AND descrip_pieza = 'Perrilla QCD';";
            SqlCommand cmd7 = new SqlCommand(query7, con);
            cmd7.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant7 = Convert.ToSingle(cmd7.ExecuteScalar());

            string query8 = "select temp_pieza from TERMOC where id_termo = @id AND descrip_pieza = 'Perrilla QCT';";
            SqlCommand cmd8 = new SqlCommand(query8, con);
            cmd8.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant8 = Convert.ToSingle(cmd8.ExecuteScalar());

            //////////////////////////////
            ///
            string query9 = "select temp_pieza from TERMOC where id_termo = @id AND descrip_pieza = 'Tirador puerta';";
            SqlCommand cmd9 = new SqlCommand(query9, con);
            cmd9.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant9 = Convert.ToSingle(cmd9.ExecuteScalar());

            string query10 = "select temp_pieza from TERMOC where id_termo = @id AND descrip_pieza = 'Conexión boquilla';";
            SqlCommand cmd10 = new SqlCommand(query10, con);
            cmd10.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant10 = Convert.ToSingle(cmd10.ExecuteScalar());

            //////////////////////////////
            ///
            string query11 = "select temp_pieza from TERMOC where id_termo = @id AND descrip_pieza = 'Frente llaves';";
            SqlCommand cmd11 = new SqlCommand(query11, con);
            cmd11.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant11 = Convert.ToSingle(cmd11.ExecuteScalar());

            string query12 = "select temp_pieza from TERMOC where id_termo = @id AND descrip_pieza = 'Piso panel';";
            SqlCommand cmd12 = new SqlCommand(query12, con);
            cmd12.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant12 = Convert.ToSingle(cmd12.ExecuteScalar());

            //////////////////////////////
            ///
            string query13 = "select temp_pieza from TERMOC where id_termo = @id AND descrip_pieza = 'Panel lateral';";
            SqlCommand cmd13 = new SqlCommand(query13, con);
            cmd13.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant13 = Convert.ToSingle(cmd13.ExecuteScalar());

            string query14 = "select temp_pieza from TERMOC where id_termo = @id AND descrip_pieza = 'Panel posterior';";
            SqlCommand cmd14 = new SqlCommand(query14, con);
            cmd14.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant14 = Convert.ToSingle(cmd14.ExecuteScalar());

            //////////////////////////////
            ///
            string query15 = "select temp_pieza from TERMOC where id_termo = @id AND descrip_pieza = 'Costado libre';";
            SqlCommand cmd15 = new SqlCommand(query15, con);
            cmd15.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant15 = Convert.ToSingle(cmd15.ExecuteScalar());

            string query16 = "select temp_pieza from TERMOC where id_termo = @id AND descrip_pieza = 'Centro horno';";
            SqlCommand cmd16 = new SqlCommand(query16, con);
            cmd16.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant16 = Convert.ToSingle(cmd16.ExecuteScalar());

            //////////////////////////////
            ///
            string query17 = "select temp_pieza from TERMOC where id_termo = @id AND descrip_pieza = 'Puerta vidrio';";
            SqlCommand cmd17 = new SqlCommand(query17, con);
            cmd17.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant17 = Convert.ToSingle(cmd17.ExecuteScalar());

            string query18 = "select temp_pieza from TERMOC where id_termo = @id AND descrip_pieza = 'Paredes flexibles';";
            SqlCommand cmd18 = new SqlCommand(query18, con);
            cmd18.Parameters.AddWithValue("@id", txtCodigo.Text);
            float cant18 = Convert.ToSingle(cmd18.ExecuteScalar());

            string query19 = "select COUNT(*) from ENSAYO_TERMOCUP where id_termo =  @id;";
            SqlCommand cmd19 = new SqlCommand(query19, con);
            cmd19.Parameters.AddWithValue("@id", txtCodigo.Text);
            int cant19 = Convert.ToInt32(cmd19.ExecuteScalar());

            if (cant19 == 1)
            {
                string sqlquery = "select COUNT(*) from ENSAYO_TERMOCUP where id_termo = '" + txtdesde.Text + "''" + txthasta.Text + "'";

                SqlCommand command = new SqlCommand(sqlquery, con);

                SqlDataReader sdr = command.ExecuteReader();

                while (sdr.Read())
                {

                    termocupla.textBoxTerm1.Text = cant1.ToString();
                    termocupla.textBoxTerm2.Text = cant2.ToString();
                    termocupla.textBoxTerm3.Text = cant3.ToString();
                    termocupla.textBoxTerm4.Text = cant4.ToString();
                    termocupla.textBoxTerm5.Text = cant5.ToString();
                    termocupla.textBoxTerm6.Text = cant6.ToString();
                    termocupla.textBoxTerm7.Text = cant7.ToString();
                    termocupla.textBoxTerm8.Text = cant8.ToString();
                    termocupla.textBoxTerm9.Text = cant9.ToString();
                    termocupla.textBoxTerm10.Text = cant10.ToString();
                    termocupla.textBoxTerm11.Text = cant11.ToString();
                    termocupla.textBoxTerm12.Text = cant12.ToString();
                    termocupla.textBoxTerm13.Text = cant13.ToString();
                    termocupla.textBoxTerm14.Text = cant14.ToString();
                    termocupla.textBoxTerm15.Text = cant15.ToString();
                    termocupla.textBoxTerm16.Text = cant16.ToString();
                    termocupla.textBoxTerm17.Text = cant17.ToString();
                    termocupla.textBoxTerm18.Text = cant18.ToString();

                }
            }
            else
            {

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //FormEnsayoElectrico electrico = new FormEnsayoElectrico() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            //manual.FormBorderStyle = FormBorderStyle.None;
            //this.panelOpciones.Controls.Add(manual);
            btnGuardarCondicion.Visible = false;

            btnCondiciones.BackColor = Color.FromArgb(33, 53, 73);
            btnManuales.BackColor = Color.FromArgb(33, 53, 73);
            btnNivelacion.BackColor = Color.FromArgb(33, 53, 73);
            btnFugaGas.BackColor = Color.FromArgb(33, 53, 73);
            btnCombustion.BackColor = Color.FromArgb(33, 53, 73);
            btnTermocupla.BackColor = Color.FromArgb(33, 53, 73);
            btnElectrico.BackColor = Color.Green;
            btnObservacion.BackColor = Color.FromArgb(33, 53, 73);




            FormEnsayoElectrico electrico = new FormEnsayoElectrico() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            electrico.TopLevel = false;
            electrico.AutoScroll = true;
            this.panelOpciones.Controls.Add(electrico);

            label1.Text = "Ensayo Electrico";
            //AbrirFormHija(new FormEnsayoFugaGas());

            FormEnsayoElectrico.asd6 = txtCodigo.Text;


            electrico.Show();
            electrico.BringToFront();

            ///////////////////////////////////////
            SqlConnection con = new SqlConnection("Data Source=10.130.14.248;Initial Catalog=NuevaQA;User ID=NRFT;Password=Nrft2019$");
            con.Open();

            string query1 = "select marc_instrucc from ENSAYO_ELECTR where id_electr = @id;";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            cmd1.Parameters.AddWithValue("@id", txtCodigo.Text);
            int cant1 = Convert.ToInt32(cmd1.ExecuteScalar());

            string query2 = "select pr_part_activa from ENSAYO_ELECTR where id_electr = @id;";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.Parameters.AddWithValue("@id", txtCodigo.Text);
            int cant2 = Convert.ToInt32(cmd2.ExecuteScalar());

            string query3 = "select cumple_electr from ENSAYO_ELECTR where id_electr = @id;";
            SqlCommand cmd3 = new SqlCommand(query3, con);
            cmd3.Parameters.AddWithValue("@id", txtCodigo.Text);
            int cant3 = Convert.ToInt32(cmd3.ExecuteScalar());

            string query4 = "select count(*) from ENSAYO_ELECTR where id_electr = @id;";
            SqlCommand cmd4 = new SqlCommand(query4, con);
            cmd4.Parameters.AddWithValue("@id", txtCodigo.Text);
            int cant4 = Convert.ToInt32(cmd4.ExecuteScalar());

            //////////////////////////////////////
            ///

            string query5 = "select potencia from ENSAYO_ELECTR where id_electr = @id;";
            SqlCommand cmd5 = new SqlCommand(query5, con);
            cmd5.Parameters.AddWithValue("@id", txtCodigo.Text);
            decimal cant5 = Convert.ToDecimal(cmd5.ExecuteScalar());

            string query6 = "select corriente from ENSAYO_ELECTR where id_electr = @id;";
            SqlCommand cmd6 = new SqlCommand(query6, con);
            cmd6.Parameters.AddWithValue("@id", txtCodigo.Text);
            decimal cant6 = Convert.ToDecimal(cmd6.ExecuteScalar());

            string query7 = "select continuidad from ENSAYO_ELECTR where id_electr = @id;";
            SqlCommand cmd7 = new SqlCommand(query7, con);
            cmd7.Parameters.AddWithValue("@id", txtCodigo.Text);
            decimal cant7 = Convert.ToDecimal(cmd7.ExecuteScalar());

            string query8 = "select aislamiento from ENSAYO_ELECTR where id_electr = @id;";
            SqlCommand cmd8 = new SqlCommand(query8, con);
            cmd8.Parameters.AddWithValue("@id", txtCodigo.Text);
            decimal cant8 = Convert.ToDecimal(cmd8.ExecuteScalar());

            string query9 = "select rig_dielect from ENSAYO_ELECTR where id_electr = @id;";
            SqlCommand cmd9 = new SqlCommand(query9, con);
            cmd9.Parameters.AddWithValue("@id", txtCodigo.Text);
            decimal cant9 = Convert.ToDecimal(cmd9.ExecuteScalar());

            if (cant4 == 0)
            {

            }
            else
            {

                string sqlquery = "select count(*) from ENSAYO_ELECTR where id_electr = '" + txtdesde.Text + "''" + txthasta.Text + "'";

                SqlCommand command = new SqlCommand(sqlquery, con);

                SqlDataReader sdr = command.ExecuteReader();

                while (sdr.Read())
                {

                    if (cant1 == 1)
                    {
                        electrico.checkBox2.Checked = true;
                    }
                    else
                    {
                        electrico.checkBox3.Checked = true;
                    }

                    if (cant2 == 1)
                    {
                        electrico.checkBox4.Checked = true;
                    }
                    else
                    {
                        electrico.checkBox5.Checked = true;
                    }

                    if (cant3 == 1)
                    {
                        electrico.checkBox6.Checked = true;
                    }
                    else
                    {
                        electrico.checkBox7.Checked = true;
                    }

                    electrico.numericPotencia.Value = cant5;
                    electrico.numericCorriente.Value = cant6;
                    electrico.numericUpDown2.Value = cant7;
                    electrico.numericUpDown1.Value = cant8;
                    electrico.numericUpDown3.Value = cant9;
                }

            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //FormObservacionNota observacion = new FormObservacionNota() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            //manual.FormBorderStyle = FormBorderStyle.None;
            //this.panelOpciones.Controls.Add(manual);

            btnCondiciones.BackColor = Color.FromArgb(33, 53, 73);
            btnManuales.BackColor = Color.FromArgb(33, 53, 73);
            btnNivelacion.BackColor = Color.FromArgb(33, 53, 73);
            btnFugaGas.BackColor = Color.FromArgb(33, 53, 73);
            btnCombustion.BackColor = Color.FromArgb(33, 53, 73);
            btnTermocupla.BackColor = Color.FromArgb(33, 53, 73);
            btnElectrico.BackColor = Color.FromArgb(33, 53, 73);
            btnObservacion.BackColor = Color.Green;



            FormObservacionNota notas = new FormObservacionNota() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };

            notas.TopLevel = false;
            notas.AutoScroll = true;
            this.panelOpciones.Controls.Add(notas);

            label1.Text = "Observaciones y notas";
            //AbrirFormHija(new FormEnsayoFugaGas());

            FormObservacionNota.asd7 = txtCodigo.Text;
            notas.txtrut.Text = txtrut.Text;
            btnGuardarCondicion.Visible = true;



            notas.Show();
            notas.BringToFront();

            ///////////////////////////////////////
            SqlConnection con = new SqlConnection("Data Source=10.130.14.248;Initial Catalog=NuevaQA;User ID=NRFT;Password=Nrft2019$");
            con.Open();


            string query3 = "select count(*) from INFORME_PRUEBA where n_planilla = @id;";
            SqlCommand cmd3 = new SqlCommand(query3, con);
            cmd3.Parameters.AddWithValue("@id", txtCodigo.Text);
            int cant3 = Convert.ToInt32(cmd3.ExecuteScalar());

          


            if (cant3 == 0)
            {

            }
            else
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select observacion,nota,foto_1,foto_2,foto_3 from informe_prueba where n_planilla = '" + txtdesde.Text + "''" + txthasta.Text + "'", con);
                adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                DataSet ds = new DataSet(); adapter.Fill(ds, "informe_prueba");
                int rno = 0;
                byte[] photo_aray;

                if (ds.Tables[0].Rows.Count > 0)
                {
                    notas.richTextBox2.Text = ds.Tables[0].Rows[rno][0].ToString();
                    notas.richTextBox1.Text = ds.Tables[0].Rows[rno][1].ToString();
                    notas.pictureBox1.Image = null;
                    notas.pictureBox2.Image = null;
                    notas.pictureBox3.Image = null;

                    if (ds.Tables[0].Rows[rno][2] != System.DBNull.Value)
                    {
                        photo_aray = (byte[])ds.Tables[0].Rows[rno][2];
                        MemoryStream ms = new MemoryStream(photo_aray);
                        notas.pictureBox1.Image = Image.FromStream(ms);
                        notas.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                    }
                    if (ds.Tables[0].Rows[rno][3] != System.DBNull.Value)
                    {
                        photo_aray = (byte[])ds.Tables[0].Rows[rno][3];
                        MemoryStream ms = new MemoryStream(photo_aray);
                        notas.pictureBox2.Image = Image.FromStream(ms);
                        notas.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                    }
                    if (ds.Tables[0].Rows[rno][4] != System.DBNull.Value)
                    {
                        photo_aray = (byte[])ds.Tables[0].Rows[rno][4];
                        MemoryStream ms = new MemoryStream(photo_aray);
                        notas.pictureBox3.Image = Image.FromStream(ms);
                        notas.pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }

            con.Close();
        }

        private void panelOpciones_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
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

        private void button1_Click_3(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro de cerrar sesión ? ", "Mensaje", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                FormLogin ads = new FormLogin();
                ads.Show();
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
