using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Diagnostics;
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Configuration;
using Domain;
using Presentation.Opcion;

namespace Presentation.Informe


{
    public partial class FormInformePDF : Form
    {

        public FormInformePDF()
        {
            InitializeComponent();

            pictureBox1.Image = Obt();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            pictureBox2.Image = Obt1();
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

            pictureBox4.Image = Obt2();
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;

            label50.Text = DateTime.Now.ToString("dd/MM/yyyy");

            metodo1();
            metodo2();
            metodo3();
            metodo4();
            metodo5();
            metodo6();
            metodo7();
            metodo8();
            metodo9();
            metodo10();
            metodo11();
            metodo12();
            metodo13();
        }

        //rut del usuario actual
        public static string rut = "";
        //modelo del codigo ingresado
        public static string modelo = "";
        // codigo completo

        public static string codigo2 = "";

        public static string codigocompleto = "";
        //metodo de extracción de datos generales
        public static int opcion = 0;


        //metodo de extracción de datos generales

        public void metodo1()
        {


            try
            {

                string connetionString = null;
                connetionString = "Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$";
                SqlConnection cn = new SqlConnection(connetionString);

                //240059585'1231232

                using (SqlCommand cmd = cn.CreateCommand())
                {

                    //extraer el valor de familia
                    //SELECT column_name(s)  FROM table1 INNER JOIN table2 ON table1.column_name = table2.column_name;

                    cmd.CommandText = "select modelo.nom_familia from modelo inner join cocina on modelo.id_modelo = cocina.id_modelo where cocina.id_modelo = @id";
                    cmd.Parameters.AddWithValue("@id", modelo);
                    SqlDataReader dato;
                    cn.Open();
                    dato = cmd.ExecuteReader();
                    dato.Read();
                    label37.Text = dato.GetString(0);
                    cn.Close();

                    cmd.CommandText = "select modelo.nom_modelo from modelo inner join cocina on modelo.id_modelo = cocina.id_modelo where cocina.id_modelo = @id";
                    SqlDataReader dato1;
                    cn.Open();
                    dato1 = cmd.ExecuteReader();
                    dato1.Read();
                    label38.Text = dato1.GetString(0);
                    cn.Close();

                    cmd.CommandText = "select modelo.nom_marca from modelo inner join cocina on modelo.id_modelo = cocina.id_modelo where cocina.id_modelo = @id";
                    SqlDataReader dato2;
                    cn.Open();
                    dato2 = cmd.ExecuteReader();
                    dato2.Read();
                    label39.Text = dato2.GetString(0);
                    cn.Close();

                    cmd.CommandText = "select n_serie_hasta,mes_certif,solicitud from cocina where cod_cocina = @id22";
                    cmd.Parameters.AddWithValue("@id22", codigocompleto);

                    SqlDataReader datos;
                    cn.Open();
                    datos = cmd.ExecuteReader();
                    datos.Read();
                    label40.Text = datos.GetString(0);
                    label41.Text = (datos.GetDateTime(1)).ToString("dd/MM/yyyy");
                    label42.Text = (datos.GetInt32(2)).ToString();
                    label49.Text = (datos.GetInt32(2)).ToString();


                    cn.Close();

                    cmd.CommandText = "select tipo_gas.nombre_gas,condicion_ensayo.presion_gas,condicion_ensayo.poder_calorifico,condicion_ensayo.temp_ambiente,condicion_ensayo.humed_relativa from condicion_ensayo inner join tipo_gas ON condicion_ensayo.id_gas = tipo_gas.id_gas where cod_cocina= @id1";
                    cmd.Parameters.AddWithValue("@id1", codigocompleto);
                    SqlDataReader dato3;
                    cn.Open();
                    dato3 = cmd.ExecuteReader();
                    dato3.Read();

                    label43.Text = dato3.GetString(0);
                    label44.Text = (dato3.GetSqlSingle(1)).ToString();
                    label45.Text = (dato3.GetInt32(2)).ToString();
                    label46.Text = (dato3.GetSqlSingle(3)).ToString();
                    label47.Text = (dato3.GetSqlSingle(4)).ToString();
                    cn.Close();


                    cmd.CommandText = "select observacion, nota, n_planilla from informe_prueba where n_planilla = @inf";
                    cmd.Parameters.AddWithValue("@inf", codigocompleto);
                    SqlDataReader dato4;
                    cn.Open();
                    dato4 = cmd.ExecuteReader();
                    dato4.Read();

                    richTextBox1.Text = dato4.GetString(0);
                    richTextBox2.Text = dato4.GetString(1);
                    label48.Text = dato4.GetString(2);

                    cn.Close();

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");

            }

        }

        //metodo de ensayos combustion
        public void metodo2()
        {


            try
            {
                var c = new SqlConnection("Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$");

                var consulta = "select nom_quemador as 'Quemador',nom_posicion as 'Posición',co as 'CO (ppm)',co_2 as 'CO2 (%)', co_n as 'CO n (%)', case when co_n in ('0') then 'N/A' when cumple_comb in ('0') then 'No cumple' when cumple_comb in ('1') then 'Cumple' end  as 'Resultado Test' from combu where id_combu = '" + modelo + "''" + codigo2 + "';";
                var adaptador = new SqlDataAdapter(consulta, c);
                var commandBuilder = new SqlCommandBuilder(adaptador);
                var ds = new DataSet();
                adaptador.Fill(ds);
                dataGridView3.ReadOnly = true;
                dataGridView3.DataSource = ds.Tables[0];

                dataGridView3.Columns[0].Width = 240;
                dataGridView3.Columns[1].Width = 190;
                dataGridView3.Columns[2].Width = 95;
                dataGridView3.Columns[3].Width = 90;
                dataGridView3.Columns[4].Width = 95;
                dataGridView3.Columns[5].Width = 175;
                this.dataGridView3.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");

            }
        }

        //metodo de ensayos termocupla
        public void metodo3()
        {

            try
            {

                var consult = "select descrip_pieza as 'Posición cocina',temp_pieza as 'Temperatura (C°)', case when temp_pieza in ('0') then 'N/A' when cumple_term in ('0') then 'No cumple' when cumple_term in ('1') then 'Cumple' end as 'Resultado Test', temp_norma as 'Temperatura según norma' from termoc where id_termo = '" + modelo + "''" + codigo2 + "';";
                var ca = new SqlConnection("Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$"); // Tu String de conexión
                var adaptado = new SqlDataAdapter(consult, ca);

                var command = new SqlCommandBuilder(adaptado);
                var d = new DataSet();
                adaptado.Fill(d);
                dataGridView2.ReadOnly = true;
                dataGridView2.DataSource = d.Tables[0];

                dataGridView2.Columns[0].Width = 260;
                dataGridView2.Columns[1].Width = 190;
                dataGridView2.Columns[2].Width = 135;
                dataGridView2.Columns[3].Width = 300;
                this.dataGridView2.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");

            }

        }

        //ensayo de basculamiento
        public void metodo4()
        {

            try
            {

                var consult = "select 'Basculamiento del artefacto' as 'Requisito de la norma', case cumple_basc when '0' then 'No cumple' when '1' then 'Cumple' end as 'Resultado Test' from ensayo_bascul where id_basc  =  '" + modelo + "''" + codigo2 + "';";
                var ca = new SqlConnection("Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$"); // Tu String de conexión
                var adaptado = new SqlDataAdapter(consult, ca);

                var command = new SqlCommandBuilder(adaptado);
                var d = new DataSet();
                adaptado.Fill(d);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = d.Tables[0];

                dataGridView1.Columns[0].Width = 260;
                dataGridView1.Columns[1].Width = 190;
                this.dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");

            }

        }




        //ensayo de trabamiento de puerta
        public void metodo5()
        {

            try
            {

                var consult = "select 'Trabamiento de puerta de horno' as 'Requisito de la norma', case cumple_trab when '0' then 'No cumple' when '1' then 'Cumple' end as 'Resultado Test' from ENSAYO_TRABAM where id_trab  =  '" + modelo + "''" + codigo2 + "';";
                var ca = new SqlConnection("Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$"); // Tu String de conexión
                var adaptado = new SqlDataAdapter(consult, ca);

                var command = new SqlCommandBuilder(adaptado);
                var d = new DataSet();
                adaptado.Fill(d);
                dataGridView7.ReadOnly = true;
                dataGridView7.DataSource = d.Tables[0];

                dataGridView7.Columns[0].Width = 260;
                dataGridView7.Columns[1].Width = 190;
                this.dataGridView7.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");

            }

        }



        //ensayo de resistencia

        public void metodo6()
        {

            try
            {

                var consult = "select 'Resistencia de la puerta del horno' as 'Requisito de la norma', resist_puerta as 'Resistencia en (N)', case cumple_resis when '0' then 'No cumple' when '1' then 'Cumple' end as 'Resultado Test' from ENSAYO_RESIST where id_resist  =  '" + modelo + "''" + codigo2 + "';";
                var ca = new SqlConnection("Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$"); // Tu String de conexión
                var adaptado = new SqlDataAdapter(consult, ca);

                var command = new SqlCommandBuilder(adaptado);
                var d = new DataSet();
                adaptado.Fill(d);
                dataGridView6.ReadOnly = true;
                dataGridView6.DataSource = d.Tables[0];

                dataGridView6.Columns[0].Width = 260;
                dataGridView6.Columns[1].Width = 190;
                dataGridView6.Columns[2].Width = 100;
                this.dataGridView6.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");

            }

        }

        //ensayo retencion e inercia
        public void metodo7()
        {

            try
            {

                var consult = "select 'Tiempo retencion y tiempo inercia' as 'Requisito de la norma', tiem_retencion as 'Tiempo de retención en (s)', tiem_inercia as 'Tiempo de inercia en (s)', case cumple_reten when '0' then 'No cumple' when '1' then 'Cumple' end as 'Resultado Test'from ENSAYO_REtencion where id_retencion  =  '" + modelo + "''" + codigo2 + "';";
                var ca = new SqlConnection("Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$"); // Tu String de conexión
                var adaptado = new SqlDataAdapter(consult, ca);

                var command = new SqlCommandBuilder(adaptado);
                var d = new DataSet();
                adaptado.Fill(d);
                dataGridView4.ReadOnly = true;
                dataGridView4.DataSource = d.Tables[0];

                dataGridView4.Columns[0].Width = 260;
                dataGridView4.Columns[1].Width = 190;
                dataGridView4.Columns[2].Width = 100;
                dataGridView4.Columns[3].Width = 300;
                this.dataGridView4.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");

            }

        }

        //ensayo de nivelación
        public void metodo8()
        {

            try
            {

                var consult = "select 'Nivelación de puerta' as 'Requisito de la norma', niv_puerta_sp as 'Nivelación sin peso', niv_puerta_cp as 'Nivelación con peso', case cumple_nivelam when '0' then 'No cumple' when '1' then 'Cumple' end as 'Resultado Test'from ENSAYO_NIVELAC where id_nivelac  =  '" + modelo + "''" + codigo2 + "';";
                var ca = new SqlConnection("Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$"); // Tu String de conexión
                var adaptado = new SqlDataAdapter(consult, ca);

                var command = new SqlCommandBuilder(adaptado);
                var d = new DataSet();
                adaptado.Fill(d);
                dataGridView5.ReadOnly = true;
                dataGridView5.DataSource = d.Tables[0];

                dataGridView5.Columns[0].Width = 260;
                dataGridView5.Columns[1].Width = 190;
                dataGridView5.Columns[2].Width = 100;
                dataGridView5.Columns[3].Width = 300;
                this.dataGridView5.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");

            }

        }

        // ensayo de fuga de gas

        public void metodo9()
        {

            try
            {

                var consult = "select 'Estanqueidad individual y en conjunto de gas' as 'Requisito de la norma', est_indiv_gas as 'Estanqueidad individual de gas', est_conj_gas as 'Estanqueidad del conjunto de gas', case cumple_fuga_g when '0' then 'No cumple' when '1' then 'Cumple' end as 'Resultado Test'from ENSAYO_FUGA_G where id_fuga  =  '" + modelo + "''" + codigo2 + "';";
                var ca = new SqlConnection("Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$"); // Tu String de conexión
                var adaptado = new SqlDataAdapter(consult, ca);

                var command = new SqlCommandBuilder(adaptado);
                var d = new DataSet();
                adaptado.Fill(d);
                dataGridView8.ReadOnly = true;
                dataGridView8.DataSource = d.Tables[0];

                dataGridView8.Columns[0].Width = 260;
                dataGridView8.Columns[1].Width = 190;
                dataGridView8.Columns[2].Width = 180;
                dataGridView8.Columns[3].Width = 270;
                this.dataGridView8.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");

            }

        }



        //ensayo electrico

        public void metodo10()
        {

            try
            {

                var consult = "select 'Marcado, protección de partes activas, potencia y corriente electrica' as 'Requisito de la norma', case when continuidad in('0') then 'N/A' when marc_instrucc in( '0') then 'No cumple' when marc_instrucc in ( '1') then 'Cumple' end as 'Marcado de instrucciones', case when continuidad in ('0') then 'N/A ' when  pr_part_activa in ( '0') then 'No cumple'  when pr_part_activa in ( '1' )then 'Cumple' end as 'Protección contra acceso p/a', potencia as 'Potencia (W)', corriente as 'Corriente (mA)', continuidad as 'Continuidad (mΩ)',aislamiento as 'Aislamiento (MΩ)', rig_dielect as 'Rig. Dielect. (mA)',case when continuidad in ('0') then 'N/A' when cumple_electr in('0') then 'No cumple' when cumple_electr in ( '1') then 'Cumple' end as 'Resultado Test'from ENSAYO_ELECTR where id_electr  = '" + modelo + "''" + codigo2 + "';";
                var ca = new SqlConnection("Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$"); // Tu String de conexión
                var adaptado = new SqlDataAdapter(consult, ca);

                var command = new SqlCommandBuilder(adaptado);
                var d = new DataSet();
                adaptado.Fill(d);
                dataGridView9.ReadOnly = true;
                dataGridView9.DataSource = d.Tables[0];

                dataGridView9.Columns[0].Width = 260;
                dataGridView9.Columns[1].Width = 190;
                dataGridView9.Columns[2].Width = 180;
                dataGridView9.Columns[3].Width = 100;
                dataGridView9.Columns[4].Width = 100;
                dataGridView9.Columns[4].Width = 100;
                dataGridView9.Columns[5].Width = 120;
                dataGridView9.Columns[6].Width = 120;
                dataGridView9.Columns[7].Width = 120;
                this.dataGridView9.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");

            }

        }


        //ensayo control de llama

        public void metodo12()
        {

            try
            {

                var consult = "select case disp_c_llama_f when '0' then 'No cumple' when '1' then 'Cumple' end as 'Dispositivo control llama (funcional)',case disp_c_llama_c when '0' then 'No cumple' when '1' then 'Cumple' end as 'Dispositivo control llama (construcción)',case encend_interc when '0' then 'No cumple' when '1' then 'Cumple' end as 'Encendido e interecentido',case cumple_control_llama when '0' then 'No cumple' when '1' then 'Cumple' end as 'Resultado Test' from ENSAYO_C_LLAMA where id_c_llama  =  '" + modelo + "''" + codigo2 + "';";
                var ca = new SqlConnection("Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$"); // Tu String de conexión
                var adaptado = new SqlDataAdapter(consult, ca);

                var command = new SqlCommandBuilder(adaptado);
                var d = new DataSet();
                adaptado.Fill(d);
                dataGridView10.ReadOnly = true;
                dataGridView10.DataSource = d.Tables[0];

                dataGridView10.Columns[0].Width = 250;
                dataGridView10.Columns[1].Width = 250;
                dataGridView10.Columns[2].Width = 250;
                dataGridView10.Columns[3].Width = 135;
                this.dataGridView10.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");

            }

        }


        //extracción de datos de usuario y su encargado

        public void metodo11()
        {

            try
            {
                string connetionString = null;
                connetionString = "Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$";
                SqlConnection cn = new SqlConnection(connetionString);


                using (SqlCommand cmd = cn.CreateCommand())
                {

                    //extraer el valor de familia
                    //SELECT column_name(s)  FROM table1 INNER JOIN table2 ON table1.column_name = table2.column_name;

                    cmd.CommandText = "select concat(usuario.nom_usuario,' ',usuario.apell_usuario), usuario.nom_supervisor from USUARIO inner join ROL on usuario.id_rol = rol.id_rol where usuario.rut_usuario = @id ; ";
                    cmd.Parameters.AddWithValue("@id", rut);
                    SqlDataReader dato;
                    cn.Open();
                    dato = cmd.ExecuteReader();
                    dato.Read();
                    label54.Text = dato.GetString(0);
                    label55.Text = dato.GetString(1);
                    cn.Close();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");

            }

        }

        //extracción de numero y requisito de normas

        public void metodo13()
        {

            try
            {
                string connetionString = null;
                connetionString = "Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$";
                SqlConnection cn = new SqlConnection(connetionString);


                using (SqlCommand cmd = cn.CreateCommand())
                {

                    //norma nivelacion
                    cmd.CommandText = "select cod_norma , requis_norma , descrip_norma from NORMA where id_norma = @norma ;";
                    cmd.Parameters.AddWithValue("@norma", "4");
                    SqlDataReader dato;
                    cn.Open();
                    dato = cmd.ExecuteReader();
                    dato.Read();
                    label121.Text = dato.GetString(0);
                    label116.Text = dato.GetString(1);
                    label133.Text = dato.GetString(2);
                    cn.Close();

                    //norma Trabamiento
                    cmd.CommandText = "select cod_norma , requis_norma , descrip_norma from NORMA where id_norma = @norma1 ;";
                    cmd.Parameters.AddWithValue("@norma1", "4");
                    SqlDataReader dato1;
                    cn.Open();
                    dato1 = cmd.ExecuteReader();
                    dato1.Read();
                    label62.Text = dato1.GetString(0);
                    label109.Text = dato1.GetString(1);
                    label127.Text = dato1.GetString(2);
                    cn.Close();


                    //norma resistencia
                    cmd.CommandText = "select cod_norma , requis_norma , descrip_norma from NORMA where id_norma = @norma2 ;";
                    cmd.Parameters.AddWithValue("@norma2", "15");
                    SqlDataReader dato2;
                    cn.Open();
                    dato2 = cmd.ExecuteReader();
                    dato2.Read();
                    label64.Text = dato2.GetString(0);
                    label107.Text = dato2.GetString(1);
                    label129.Text = dato2.GetString(2);
                    cn.Close();

                    //norma combustion
                    cmd.CommandText = "select cod_norma , requis_norma , descrip_norma from NORMA where id_norma = @norma3 ;";
                    cmd.Parameters.AddWithValue("@norma3", "20");
                    SqlDataReader dato3;
                    cn.Open();
                    dato3 = cmd.ExecuteReader();
                    dato3.Read();
                    label88.Text = dato3.GetString(0);
                    label93.Text = dato3.GetString(1);
                    label143.Text = dato3.GetString(2);
                    cn.Close();


                    //norma termocupla
                    cmd.CommandText = "select cod_norma , requis_norma , descrip_norma from NORMA where id_norma = @norma4 ;";
                    cmd.Parameters.AddWithValue("@norma4", "19");
                    SqlDataReader dato4;
                    cn.Open();
                    dato4 = cmd.ExecuteReader();
                    dato4.Read();
                    label86.Text = dato4.GetString(0);
                    label90.Text = dato4.GetString(1);
                    label141.Text = dato4.GetString(2);
                    cn.Close();

                    //norma de basculamiento
                    cmd.CommandText = "select cod_norma , requis_norma , descrip_norma from NORMA where id_norma = @norma5 ;";
                    cmd.Parameters.AddWithValue("@norma5", "5");
                    SqlDataReader dato5;
                    cn.Open();
                    dato5 = cmd.ExecuteReader();
                    dato5.Read();
                    label60.Text = dato5.GetString(0);
                    label111.Text = dato5.GetString(1);
                    label125.Text = dato5.GetString(2);
                    cn.Close();


                    //norma electrica
                    cmd.CommandText = "select cod_norma , requis_norma , descrip_norma from NORMA where id_norma = @norma6 ;";
                    cmd.Parameters.AddWithValue("@norma6", "18");
                    SqlDataReader dato6;
                    cn.Open();
                    dato6 = cmd.ExecuteReader();
                    dato6.Read();
                    label83.Text = dato6.GetString(0);
                    label94.Text = dato6.GetString(1);
                    label139.Text = dato6.GetString(2);
                    cn.Close();

                    cmd.CommandText = "select cod_norma , requis_norma , descrip_norma from NORMA where id_norma = @norma7 ;";
                    cmd.Parameters.AddWithValue("@norma7", "16");
                    SqlDataReader dato7;
                    cn.Open();
                    dato7 = cmd.ExecuteReader();
                    dato7.Read();
                    label168.Text = dato7.GetString(0);
                    label167.Text = dato7.GetString(1);
                    label166.Text = dato7.GetString(2);
                    cn.Close();

                    cmd.CommandText = "select cod_norma , requis_norma , descrip_norma from NORMA where id_norma = @norma8 ;";
                    cmd.Parameters.AddWithValue("@norma8", "17");
                    SqlDataReader dato8;
                    cn.Open();
                    dato8 = cmd.ExecuteReader();
                    dato8.Read();
                    label171.Text = dato8.GetString(0);
                    label170.Text = dato8.GetString(1);
                    label169.Text = dato8.GetString(2);
                    cn.Close();


                    //norma control llama
                    cmd.CommandText = "select cod_norma , requis_norma , descrip_norma from NORMA where id_norma = @norma9 ;";
                    cmd.Parameters.AddWithValue("@norma9", "9");
                    SqlDataReader dato9;
                    cn.Open();
                    dato9 = cmd.ExecuteReader();
                    dato9.Read();
                    label70.Text = dato9.GetString(0);
                    label103.Text = dato9.GetString(1);
                    label135.Text = dato9.GetString(2);
                    cn.Close();

                    cmd.CommandText = "select cod_norma , requis_norma , descrip_norma from NORMA where id_norma = @norma10 ;";
                    cmd.Parameters.AddWithValue("@norma10", "7");
                    SqlDataReader dato10;
                    cn.Open();
                    dato10 = cmd.ExecuteReader();
                    dato10.Read();
                    label152.Text = dato10.GetString(0);
                    label151.Text = dato10.GetString(1);
                    label99.Text = dato10.GetString(2);
                    cn.Close();

                    cmd.CommandText = "select cod_norma , requis_norma , descrip_norma from NORMA where id_norma = @norma11 ;";
                    cmd.Parameters.AddWithValue("@norma11", "3");
                    SqlDataReader dato11;
                    cn.Open();
                    dato11 = cmd.ExecuteReader();
                    dato11.Read();
                    label155.Text = dato11.GetString(0);
                    label154.Text = dato11.GetString(1);
                    label153.Text = dato11.GetString(2);
                    cn.Close();


                    //norma retencion e inercia
                    cmd.CommandText = "select cod_norma , requis_norma , descrip_norma from NORMA where id_norma = @norma12 ;";
                    cmd.Parameters.AddWithValue("@norma12", "14");
                    SqlDataReader dato12;
                    cn.Open();
                    dato12 = cmd.ExecuteReader();
                    dato12.Read();
                    label67.Text = dato12.GetString(0);
                    label105.Text = dato12.GetString(1);
                    label131.Text = dato12.GetString(2);
                    cn.Close();

                    cmd.CommandText = "select cod_norma , requis_norma , descrip_norma from NORMA where id_norma = @norma13 ;";
                    cmd.Parameters.AddWithValue("@norma13", "13");
                    SqlDataReader dato13;
                    cn.Open();
                    dato13 = cmd.ExecuteReader();
                    dato13.Read();
                    label147.Text = dato13.GetString(0);
                    label146.Text = dato13.GetString(1);
                    label145.Text = dato13.GetString(2);
                    cn.Close();

                    cmd.CommandText = "select cod_norma , requis_norma , descrip_norma from NORMA where id_norma = @norma14 ;";
                    cmd.Parameters.AddWithValue("@norma14", "8");
                    SqlDataReader dato14;
                    cn.Open();
                    dato14 = cmd.ExecuteReader();
                    dato14.Read();
                    label150.Text = dato14.GetString(0);
                    label149.Text = dato14.GetString(1);
                    label148.Text = dato14.GetString(2);
                    cn.Close();

                    cmd.CommandText = "select cod_norma , requis_norma , descrip_norma from NORMA where id_norma = @norma17 ;";
                    cmd.Parameters.AddWithValue("@norma17", "10");
                    SqlDataReader dato17;
                    cn.Open();
                    dato17 = cmd.ExecuteReader();
                    dato17.Read();
                    label162.Text = dato17.GetString(0);
                    label161.Text = dato17.GetString(1);
                    label160.Text = dato17.GetString(2);
                    cn.Close();

                    //norma fuga
                    cmd.CommandText = "select cod_norma , requis_norma , descrip_norma from NORMA where id_norma = @norma15 ;";
                    cmd.Parameters.AddWithValue("@norma15", "6");
                    SqlDataReader dato15;
                    cn.Open();
                    dato15 = cmd.ExecuteReader();
                    dato15.Read();
                    label79.Text = dato15.GetString(0);
                    label101.Text = dato15.GetString(1);
                    label137.Text = dato15.GetString(2);
                    cn.Close();

                    cmd.CommandText = "select cod_norma , requis_norma , descrip_norma from NORMA where id_norma = @norma16 ;";
                    cmd.Parameters.AddWithValue("@norma16", "1");
                    SqlDataReader dato16;
                    cn.Open();
                    dato16 = cmd.ExecuteReader();
                    dato16.Read();
                    label159.Text = dato16.GetString(0);
                    label158.Text = dato16.GetString(1);
                    label157.Text = dato16.GetString(2);
                    cn.Close();

                    cmd.CommandText = "select cod_norma , requis_norma , descrip_norma from NORMA where id_norma = @norma18 ;";
                    cmd.Parameters.AddWithValue("@norma18", "2");
                    SqlDataReader dato18;
                    cn.Open();
                    dato18 = cmd.ExecuteReader();
                    dato18.Read();
                    label165.Text = dato18.GetString(0);
                    label164.Text = dato18.GetString(1);
                    label163.Text = dato18.GetString(2);
                    cn.Close();

                    //numero de serie de cocina
                    cmd.CommandText = "select n_serie_hasta from cocina where id_modelo = @id";
                    cmd.Parameters.AddWithValue("@id", modelo);
                    SqlDataReader datos;
                    cn.Open();
                    datos = cmd.ExecuteReader();
                    datos.Read();
                    label53.Text = datos.GetString(0);
                    label36.Text = datos.GetString(0);
                    label58.Text = datos.GetString(0);
                    label73.Text = datos.GetString(0);
                    label119.Text = datos.GetString(0);
                    label75.Text = datos.GetString(0);
                    label72.Text = datos.GetString(0);
                    label81.Text = datos.GetString(0);
                    label51.Text = datos.GetString(0);
                    label52.Text = datos.GetString(0);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");

            }

        }



        private System.Drawing.Image Obt()
        {

            try
            {

                string connetionString = null;
                connetionString = "Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$";
                SqlConnection cn = new SqlConnection(connetionString);

                using (SqlCommand cmd = cn.CreateCommand())
                {

                    cn.Open();

                    cmd.CommandText = "Select foto_1 from informe_prueba where n_planilla = @id";

                    cmd.Parameters.AddWithValue("@id", System.Data.SqlDbType.Image).Value = codigocompleto;

                    byte[] arr = (byte[])cmd.ExecuteScalar();

                    cn.Close();

                    MemoryStream ms = new MemoryStream(arr);
                    System.Drawing.Image img = System.Drawing.Image.FromStream(ms);


                    ms.Close();

                    return img;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");
                return null;

            }
        }


        private System.Drawing.Image Obt1()
        {

            try
            {

                string connetionString = null;
                connetionString = "Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$";
                SqlConnection cn = new SqlConnection(connetionString);

                using (SqlCommand cmd = cn.CreateCommand())
                {

                    cn.Open();

                    cmd.CommandText = "Select foto_2 from informe_prueba where n_planilla = @id";

                    cmd.Parameters.AddWithValue("@id", System.Data.SqlDbType.Image).Value = codigocompleto;

                    byte[] arr = (byte[])cmd.ExecuteScalar();

                    cn.Close();

                    MemoryStream ms = new MemoryStream(arr);
                    System.Drawing.Image img = System.Drawing.Image.FromStream(ms);


                    ms.Close();

                    return img;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");
                return null;

            }
        }

        private System.Drawing.Image Obt2()
        {

            try
            {

                string connetionString = null;
                connetionString = "Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$";
                SqlConnection cn = new SqlConnection(connetionString);

                using (SqlCommand cmd = cn.CreateCommand())
                {

                    cn.Open();

                    cmd.CommandText = "Select foto_3 from informe_prueba where n_planilla = @id";

                    cmd.Parameters.AddWithValue("@id", System.Data.SqlDbType.Image).Value = codigocompleto;

                    byte[] arr = (byte[])cmd.ExecuteScalar();

                    cn.Close();

                    MemoryStream ms = new MemoryStream(arr);
                    System.Drawing.Image img = System.Drawing.Image.FromStream(ms);


                    ms.Close();

                    return img;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");
                return null;

            }
        }

        //imagenes para pdf
        private byte[] GetImage(string Roll_no)
        {
            string sConn = ConfigurationManager.ConnectionStrings["Presentation.Properties.Settings.Conexion"].ToString();
            SqlConnection objConn = new SqlConnection(sConn);
            objConn.Open();
            string sTSQL = "select foto_1 from informe_prueba where n_planilla='" + Roll_no + "'";
            SqlCommand objCmd = new SqlCommand(sTSQL, objConn);
            objCmd.CommandType = CommandType.Text;
            object result = objCmd.ExecuteScalar();
            objConn.Close();
            return (byte[])result;
        }
        private byte[] GetImage2(string Roll_no)
        {
            string sConn = ConfigurationManager.ConnectionStrings["Presentation.Properties.Settings.Conexion"].ToString();
            SqlConnection objConn = new SqlConnection(sConn);
            objConn.Open();
            string sTSQL = "select foto_2 from informe_prueba where n_planilla='" + Roll_no + "'";
            SqlCommand objCmd = new SqlCommand(sTSQL, objConn);
            objCmd.CommandType = CommandType.Text;
            object result = objCmd.ExecuteScalar();
            objConn.Close();
            return (byte[])result;
        }
        private byte[] GetImage3(string Roll_no)
        {
            string sConn = ConfigurationManager.ConnectionStrings["Presentation.Properties.Settings.Conexion"].ToString();
            SqlConnection objConn = new SqlConnection(sConn);
            objConn.Open();
            string sTSQL = "select foto_3 from informe_prueba where n_planilla='" + Roll_no + "'";
            SqlCommand objCmd = new SqlCommand(sTSQL, objConn);
            objCmd.CommandType = CommandType.Text;
            object result = objCmd.ExecuteScalar();
            objConn.Close();
            return (byte[])result;
        }


        //metodo de datos hornos y gratinadores

        public string hornos()
        {

            try
            {
                string j = "";

                string connetionString = null;
                connetionString = "Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$";
                SqlConnection cn = new SqlConnection(connetionString);


                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "select cumple_trab from ENSAYO_TRABAM where id_trab = @t ;";

                    cmd.Parameters.AddWithValue("@t",codigocompleto);
                    SqlDataReader dato;
                    cn.Open();
                    dato = cmd.ExecuteReader();
                    dato.Read();
                    bool t1 = dato.GetBoolean(0);
                    cn.Close();


                    cmd.CommandText = "select cumple_resis from ENSAYO_RESIST where id_resist = @r ;";

                    cmd.Parameters.AddWithValue("@r", codigocompleto);
                    SqlDataReader dato1;
                    cn.Open();
                    dato1 = cmd.ExecuteReader();
                    dato1.Read();
                    bool r1 = dato1.GetBoolean(0);
                    cn.Close();

                    cmd.CommandText = "select cumple_nivelam from ENSAYO_NIVELAC where id_nivelac = @n ;";

                    cmd.Parameters.AddWithValue("@n",codigocompleto);
                    SqlDataReader dato2;
                    cn.Open();
                    dato2 = cmd.ExecuteReader();
                    dato2.Read();
                    bool n1 = dato2.GetBoolean(0);
                    cn.Close();


                    if (t1 == true && r1 == true && n1 == true)
                    {

                        j = "Cumple";
                        return j;
                    }
                    else
                    {
                        j = "No cumple";
                        return j;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
                return null;
            }

        }

        //metodo de datos basculamiento y nivelacion

        public string bascul_niv()
        {

            try
            {
                string j = "";

                string connetionString = null;
                connetionString = "Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$";
                SqlConnection cn = new SqlConnection(connetionString);


                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "select cumple_basc from ENSAYO_BASCUL where id_basc = @b ;";

                    cmd.Parameters.AddWithValue("@b", codigocompleto);
                    SqlDataReader dato;
                    cn.Open();
                    dato = cmd.ExecuteReader();
                    dato.Read();
                    bool b1 = dato.GetBoolean(0);
                    cn.Close();


                    cmd.CommandText = "select cumple_nivelam from ENSAYO_NIVELAC where id_nivelac = @n ;";

                    cmd.Parameters.AddWithValue("@n", codigocompleto);
                    SqlDataReader dato2;
                    cn.Open();
                    dato2 = cmd.ExecuteReader();
                    dato2.Read();
                    bool n1 = dato2.GetBoolean(0);
                    cn.Close();


                    if (b1 == true && n1 == true)
                    {

                        j = "Cumple";
                        return j;
                    }
                    else
                    {
                        j = "No cumple";
                        return j;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
                return null;
            }

        }


        // generar pdf 
        private void button1_Click(object sender, EventArgs e)
        {

            var userModel = new UserModel();//Devuelve un objeto UserModel como resultado.

            MessageBox.Show("Informe creado y guardado en carpeta correspondiente");

            this.Hide();
            FormLogin ads = new FormLogin();
            ads.Show();

            Document documento = new Document(iTextSharp.text.PageSize.LETTER, 25, 25, 20, 40);

            string folderPath = @"C:\informes";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);

            }
            else
            {
               
            }
            try
            {
                if (opcion == 1)
                {

                    PdfWriter wri = PdfWriter.GetInstance(documento, new FileStream(@"C:\informes\Ensayo Individual N° " + codigocompleto + ".pdf", FileMode.Create));

                }
                else if (opcion == 0)
                {

                    PdfWriter wri = PdfWriter.GetInstance(documento, new FileStream(@"C:\informes\Ensayo Completo N° " + codigocompleto + ".pdf", FileMode.Create));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message , "ERROR");
            }
           

            documento.Open();

            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, false);
            iTextSharp.text.Font f = new iTextSharp.text.Font(bfTimes, 12f, iTextSharp.text.Font.ITALIC, BaseColor.BLACK);

            BaseFont bfTimes1 = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1257, false);
            iTextSharp.text.Font f1 = new iTextSharp.text.Font(bfTimes1, 16f, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            BaseFont bfTimes2 = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, false);
            iTextSharp.text.Font f2 = new iTextSharp.text.Font(bfTimes2, 14f, iTextSharp.text.Font.ITALIC, BaseColor.BLACK);

            string[] z = {label7.Text,label19.Text,label30.Text,label3.Text,label4.Text,label5.Text,label6.Text,label48.Text,label49.Text,label50.Text
                         ,label10.Text,label11.Text,label12.Text,label13.Text,label14.Text,label15.Text,label37.Text,label38.Text,label39.Text
                         ,label40.Text,label41.Text,label42.Text,label20.Text,label18.Text,label17.Text,label16.Text,label9.Text,label8.Text
                         ,label43.Text,label44.Text,label45.Text,label46.Text,label47.Text,label32.Text,label35.Text,label53.Text};

            //imagen de electrolux
            string imagen = Path.Combine(Application.StartupPath, "Logo/electrolux.png");
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(imagen);

            //tabla de ingreso de encabezado de hoja
            PdfPTable TA = new PdfPTable(new float[] { 100f, 90f, 40f, 40f }) { WidthPercentage = 100 };
            TA.AddCell(new PdfPCell(img) { Border = 0, Rowspan = 3, HorizontalAlignment = Element.ALIGN_LEFT });
            TA.AddCell(new PdfPCell(new Phrase(" ")) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
            TA.AddCell(new PdfPCell(new Phrase(z[4])) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            TA.AddCell(new PdfPCell(new Phrase(z[7])) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            TA.AddCell(new PdfPCell(new Phrase(z[0], f)) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
            TA.AddCell(new PdfPCell(new Phrase(z[5])) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            TA.AddCell(new PdfPCell(new Phrase(z[8])) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            TA.AddCell(new PdfPCell(new Phrase(z[1], f)) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
            TA.AddCell(new PdfPCell(new Phrase(z[6])) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            TA.AddCell(new PdfPCell(new Phrase(z[9])) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

            documento.Add(TA);

            Paragraph a = new Paragraph(" ");

            //titulo de informe
            Paragraph a2 = new Paragraph(z[2], f2);
            Paragraph a3 = new Paragraph(z[3], f1);

            a2.Alignment = Element.ALIGN_CENTER;
            a3.Alignment = Element.ALIGN_CENTER;

            documento.Add(a2);
            documento.Add(a3);
            documento.Add(a);
            documento.Add(a);
            documento.Add(a);

            //tabla de ingreso de ingreso de información de cocina

            PdfPTable T = new PdfPTable(new float[] { 50f, 70f, 15F, 50f, 30f }) { WidthPercentage = 100f };

            var col1 = new PdfPCell(new Phrase(z[10])) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
            var col2 = new PdfPCell(new Phrase(z[16])) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
            var col3 = new PdfPCell(new Phrase(" ")) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
            var col4 = new PdfPCell(new Phrase(z[22])) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
            var col5 = new PdfPCell(new Phrase(" ")) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
            T.AddCell(col1);
            T.AddCell(col2);
            T.AddCell(col3);
            T.AddCell(col4);
            T.AddCell(col5);

            col1.Phrase = new Phrase(z[11]);
            col2.Phrase = new Phrase(z[17]);
            col3.Phrase = new Phrase(" ");
            col4.Phrase = new Phrase(z[23]);
            col5.Phrase = new Phrase(z[28]);
            T.AddCell(col1);
            T.AddCell(col2);
            T.AddCell(col3);
            T.AddCell(col4);
            T.AddCell(col5);

            col1.Phrase = new Phrase(z[12]);
            col2.Phrase = new Phrase(z[18]);
            col3.Phrase = new Phrase(" ");
            col4.Phrase = new Phrase(z[24]);
            col5.Phrase = new Phrase(z[29]);
            T.AddCell(col1);
            T.AddCell(col2);
            T.AddCell(col3);
            T.AddCell(col4);
            T.AddCell(col5);

            col1.Phrase = new Phrase(z[13]);
            col2.Phrase = new Phrase(z[19]);
            col3.Phrase = new Phrase(" ");
            col4.Phrase = new Phrase(z[25]);
            col5.Phrase = new Phrase(z[30]);
            T.AddCell(col1);
            T.AddCell(col2);
            T.AddCell(col3);
            T.AddCell(col4);
            T.AddCell(col5);

            col1.Phrase = new Phrase(z[14]);
            col2.Phrase = new Phrase(z[20]);
            col3.Phrase = new Phrase(" ");
            col4.Phrase = new Phrase(z[26]);
            col5.Phrase = new Phrase(z[31]);
            T.AddCell(col1);
            T.AddCell(col2);
            T.AddCell(col3);
            T.AddCell(col4);
            T.AddCell(col5);

            col1.Phrase = new Phrase(z[15]);
            col2.Phrase = new Phrase(z[21]);
            col3.Phrase = new Phrase(" ");
            col4.Phrase = new Phrase(z[27]);
            col5.Phrase = new Phrase(z[32]);
            T.AddCell(col1);
            T.AddCell(col2);
            T.AddCell(col3);
            T.AddCell(col4);
            T.AddCell(col5);

            documento.Add(T);

            documento.Add(a);
            documento.Add(a);

            //tabla de ensayos manuales

            try
            {
                string connetionString = null;
                connetionString = "Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$";
                SqlConnection cn = new SqlConnection(connetionString);


                using (SqlCommand cmd = cn.CreateCommand())
                {

                    cmd.CommandText = "select case est_conj_gas when '0' then 'No cumple' when '1' then 'Cumple' end as 'estado conjunto gas', case est_indiv_gas when '0' then 'No cumple' when '1' then 'Cumple' end as 'estado individual gas', case conexion when '0' then 'No cumple' when '1' then 'Cumple' end as 'conexiones' from ENSAYO_FUGA_G where id_fuga = @f ;";

                    cmd.Parameters.AddWithValue("@f", codigocompleto);
                    SqlDataReader dato;
                    cn.Open();
                    dato = cmd.ExecuteReader();
                    dato.Read();
                    string f3 = dato.GetString(0);
                    string f4 = dato.GetString(1);
                    string f5 = dato.GetString(2);
                    cn.Close();


                    cmd.CommandText = "select case disp_c_llama_f when '0' then 'No cumple' when '1' then 'Cumple' end as 'Dispositivo control llama (funcional)',case disp_c_llama_c when '0' then 'No cumple' when '1' then 'Cumple' end as 'Dispositivo control llama (construcción)',case encend_interc when '0' then 'No cumple' when '1' then 'Cumple' end as 'Encendido e interecentido',case cumple_control_llama when '0' then 'No cumple' when '1' then 'Cumple' end as 'Resultado Test' from ENSAYO_C_LLAMA where id_c_llama  = @c";

                    cmd.Parameters.AddWithValue("@c", codigocompleto);
                    SqlDataReader dato1;
                    cn.Open();
                    dato1 = cmd.ExecuteReader();
                    dato1.Read();
                    string cl1 = dato1.GetString(0);
                    string cl2 = dato1.GetString(1);
                    string cl3 = dato1.GetString(2);
                    cn.Close();


                    cmd.CommandText = "select case cumple_reten when '0' then 'No cumple' when '1' then 'Cumple' end as 'seguridad funcionamiento' from ENSAYO_RETENCION where id_retencion = @r ;";

                    cmd.Parameters.AddWithValue("@r",codigocompleto);
                    SqlDataReader dato2;
                    cn.Open();
                    dato2 = cmd.ExecuteReader();
                    dato2.Read();
                    string r1 = dato2.GetString(0);
                    cn.Close();

                    cmd.CommandText = "select case cast(cast(foto_2 as varbinary(max)) as varchar(max)) when null then 'No Cumple' else 'Cumple' end as 'Resultado Test', case cast(cast(foto_3 as varbinary(max)) as varchar(max)) when null then 'No Cumple' else 'Cumple' end as 'Resultado Test' from INFORME_PRUEBA where n_planilla = @i ;";

                    cmd.Parameters.AddWithValue("@i", codigocompleto);
                    SqlDataReader datoi;
                    cn.Open();
                    datoi = cmd.ExecuteReader();
                    datoi.Read();
                    string i1 = datoi.GetString(0);
                    string i2 = datoi.GetString(1);
                    cn.Close();


                    //valores de tabla manuales

                    Paragraph n2 = new Paragraph("Ensayos manuales", f2);
                    n2.Alignment = Element.ALIGN_CENTER;
                    documento.Add(n2);

                    documento.Add(a);

                    PdfPTable Z = new PdfPTable(new float[] { 20f, 60f, 20f, 20f, 20f }) { WidthPercentage = 100f };
                    var zz1 = new PdfPCell(new Phrase(" ")) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
                    var zz2 = new PdfPCell(new Phrase(" ")) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
                    var zz3 = new PdfPCell(new Phrase(" ")) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
                    var zz4 = new PdfPCell(new Phrase(label33.Text)) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
                    var zz5 = new PdfPCell(new Phrase(label52.Text)) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
                    Z.AddCell(zz1);
                    Z.AddCell(zz2);
                    Z.AddCell(zz3);
                    Z.AddCell(zz4);
                    Z.AddCell(zz5);
                    documento.Add(Z);

                    documento.Add(a);


                    PdfPTable D = new PdfPTable(new float[] { 50f, 90f, 50f, 50f }) { WidthPercentage = 100f, HorizontalAlignment = Element.ALIGN_CENTER };

                    var dd1 = new PdfPCell(new Phrase("Punto de la norma")) { HorizontalAlignment = Element.ALIGN_LEFT };
                    var dd2 = new PdfPCell(new Phrase("Requisito de la norma")) { HorizontalAlignment = Element.ALIGN_LEFT };
                    var dd3 = new PdfPCell(new Phrase("Descripción Norma")) { HorizontalAlignment = Element.ALIGN_LEFT };
                    var dd4 = new PdfPCell(new Phrase("Resultado del test")) { HorizontalAlignment = Element.ALIGN_LEFT };
                    D.AddCell(dd1);
                    D.AddCell(dd2);
                    D.AddCell(dd3);
                    D.AddCell(dd4);

                    //encendido e interecendido
                    dd1.Phrase = new Phrase(label70.Text);
                    dd2.Phrase = new Phrase(label103.Text);
                    dd3.Phrase = new Phrase(label135.Text);
                    dd4.Phrase = new Phrase(bascul_niv());
                    D.AddCell(dd1);
                    D.AddCell(dd2);
                    D.AddCell(dd3);
                    D.AddCell(dd4);

                    //dispositivo de control llama
                    dd1.Phrase = new Phrase(label152.Text);
                    dd2.Phrase = new Phrase(label151.Text);
                    dd3.Phrase = new Phrase(label99.Text);
                    dd4.Phrase = new Phrase(f5);
                    D.AddCell(dd1);
                    D.AddCell(dd2);
                    D.AddCell(dd3);
                    D.AddCell(dd4);

                    //dispositivo control llama funcional
                    dd1.Phrase = new Phrase(label155.Text);
                    dd2.Phrase = new Phrase(label154.Text);
                    dd3.Phrase = new Phrase(label153.Text);
                    dd4.Phrase = new Phrase(cl2);
                    D.AddCell(dd1);
                    D.AddCell(dd2);
                    D.AddCell(dd3);
                    D.AddCell(dd4);

                    //estabilidad
                    dd1.Phrase = new Phrase(label162.Text);
                    dd2.Phrase = new Phrase(label161.Text);
                    dd3.Phrase = new Phrase(label160.Text);
                    dd4.Phrase = new Phrase(hornos());
                    D.AddCell(dd1);
                    D.AddCell(dd2);
                    D.AddCell(dd3);
                    D.AddCell(dd4);

                    //estanqueidad 
                    dd1.Phrase = new Phrase(label79.Text);
                    dd2.Phrase = new Phrase(label101.Text);
                    dd3.Phrase = new Phrase(label137.Text);
                    dd4.Phrase = new Phrase(cl3);
                    D.AddCell(dd1);
                    D.AddCell(dd2);
                    D.AddCell(dd3);
                    D.AddCell(dd4);

                    //estanqueidad del conjunto
                    dd1.Phrase = new Phrase(label159.Text);
                    dd2.Phrase = new Phrase(label158.Text);
                    dd3.Phrase = new Phrase(label157.Text);
                    dd4.Phrase = new Phrase(f3);
                    D.AddCell(dd1);
                    D.AddCell(dd2);
                    D.AddCell(dd3);
                    D.AddCell(dd4);

                    //conexiones
                    dd1.Phrase = new Phrase(label165.Text);
                    dd2.Phrase = new Phrase(label164.Text);
                    dd3.Phrase = new Phrase(label163.Text);
                    dd4.Phrase = new Phrase(cl1);
                    D.AddCell(dd1);
                    D.AddCell(dd2);
                    D.AddCell(dd3);
                    D.AddCell(dd4);

                    //seguridad de funcionamiento
                    dd1.Phrase = new Phrase(label150.Text);
                    dd2.Phrase = new Phrase(label149.Text);
                    dd3.Phrase = new Phrase(label148.Text);
                    dd4.Phrase = new Phrase(r1);
                    D.AddCell(dd1);
                    D.AddCell(dd2);
                    D.AddCell(dd3);
                    D.AddCell(dd4);

                    //basculamiento
                    dd1.Phrase = new Phrase(label60.Text);
                    dd2.Phrase = new Phrase(label111.Text);
                    dd3.Phrase = new Phrase(label125.Text);
                    dd4.Phrase = new Phrase(cl3);
                    D.AddCell(dd1);
                    D.AddCell(dd2);
                    D.AddCell(dd3);
                    D.AddCell(dd4);

                    //hornos
                    dd1.Phrase = new Phrase(label62.Text);
                    dd2.Phrase = new Phrase(label109.Text);
                    dd3.Phrase = new Phrase(label127.Text);
                    dd4.Phrase = new Phrase(f4);
                    D.AddCell(dd1);
                    D.AddCell(dd2);
                    D.AddCell(dd3);
                    D.AddCell(dd4);

                    //marcado instrucciones
                    dd1.Phrase = new Phrase("8");
                    dd2.Phrase = new Phrase("Marcado de instrucciones");
                    dd3.Phrase = new Phrase("Manual");
                    dd4.Phrase = new Phrase(i1);
                    D.AddCell(dd1);
                    D.AddCell(dd2);
                    D.AddCell(dd3);
                    D.AddCell(dd4);

                    //marcado pc
                    dd1.Phrase = new Phrase("8");
                    dd2.Phrase = new Phrase("Marcado según PC N°7");
                    dd3.Phrase = new Phrase("Manual");
                    dd4.Phrase = new Phrase(i2);
                    D.AddCell(dd1);
                    D.AddCell(dd2);
                    D.AddCell(dd3);
                    D.AddCell(dd4);

                    documento.Add(D);

                    documento.Add(a);
                    documento.Add(a);
                    documento.Add(a);
                    documento.Add(a);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");

            }

            //Tabla de combustion

            Paragraph l1 = new Paragraph(label2.Text, f2);
            l1.Alignment = Element.ALIGN_CENTER;
            documento.Add(l1);

            documento.Add(a);

            PdfPTable N = new PdfPTable(new float[] { 20f, 60f, 20f, 20f, 20f }) { WidthPercentage = 100f };

            var nn1 = new PdfPCell(new Phrase(label89.Text)) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
            var nn2 = new PdfPCell(new Phrase(label88.Text)) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
            var nn3 = new PdfPCell(new Phrase(" ")) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
            var nn4 = new PdfPCell(new Phrase(label34.Text)) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
            var nn5 = new PdfPCell(new Phrase(label52.Text)) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
            N.AddCell(nn1);
            N.AddCell(nn2);
            N.AddCell(nn3);
            N.AddCell(nn4);
            N.AddCell(nn5);

            documento.Add(N);

            documento.Add(a);

            PdfPTable table = new PdfPTable(dataGridView3.Columns.Count) { HorizontalAlignment = Element.ALIGN_CENTER };

            for (int j = 0; j < dataGridView3.Columns.Count; j++)
            {
                table.AddCell(new Phrase(dataGridView3.Columns[j].HeaderText));
            }

            table.HeaderRows = 1;

            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {

                for (int k = 0; k < dataGridView3.Columns.Count; k++)
                {
                    if (dataGridView3[k, i].Value != null)
                    {
                        table.AddCell(new Phrase(dataGridView3[k, i].Value.ToString()));
                    }

                }

            }

            documento.Add(table);

            documento.Add(a);
            documento.Add(a);

            //tabla de resistencia, retencion e inercia

            try
            {
                string connetionString = null;
                connetionString = "Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$";
                SqlConnection cn = new SqlConnection(connetionString);


                using (SqlCommand cmd = cn.CreateCommand())
                {

                    cmd.CommandText = "select CONVERT(varchar(10),tiem_retencion) as 'Tiempo de retención en (s)', CONVERT(varchar(10),tiem_inercia) as 'Tiempo de inercia en (s)', case cumple_retencion when '0' then 'No cumple' when '1' then 'Cumple' end as 'Resultado Test', case cumple_inercia when '0' then 'No cumple' when '1' then 'Cumple' end as 'Resultado Test' from ENSAYO_RETENCION where id_retencion = @r ;";

                    cmd.Parameters.AddWithValue("@r",codigocompleto);
                    SqlDataReader dato;
                    cn.Open();
                    dato = cmd.ExecuteReader();
                    dato.Read();
                    string e1 = dato.GetString(0);
                    string e2 = dato.GetString(1);
                    string e3 = dato.GetString(2);
                    string e4 = dato.GetString(3);
                    cn.Close();

                    //string eb = Convert.ToString(e1);
                    //string ec = Convert.ToString(e2);

                    cmd.CommandText = "select CONVERT(varchar(10),resist_puerta) as 'resistencia',case cumple_resis when '0' then 'No cumple' when '1' then 'Cumple' end as 'Resultado Test' from ENSAYO_RESIST where id_resist = @re ;";

                    cmd.Parameters.AddWithValue("@re", codigocompleto);
                    SqlDataReader dato1;
                    cn.Open();
                    dato1 = cmd.ExecuteReader();
                    dato1.Read();
                    string e5 = dato1.GetString(0);
                    string e6 = dato1.GetString(1);
                    cn.Close();

                    //string ea = Convert.ToString(e5);                  


                    Paragraph l5 = new Paragraph("Ensayos resistencia, inercia y retención de artefacto", f2);
                    l5.Alignment = Element.ALIGN_CENTER;
                    documento.Add(l5);
                    documento.Add(a);

                    PdfPTable M = new PdfPTable(new float[] { 20f, 60f, 20f, 20f, 20f }) { WidthPercentage = 100f };
                    var mm1 = new PdfPCell(new Phrase(" ")) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
                    var mm2 = new PdfPCell(new Phrase(" ")) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
                    var mm3 = new PdfPCell(new Phrase(" ")) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
                    var mm4 = new PdfPCell(new Phrase(label33.Text)) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
                    var mm5 = new PdfPCell(new Phrase(label52.Text)) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
                    M.AddCell(mm1);
                    M.AddCell(mm2);
                    M.AddCell(mm3);
                    M.AddCell(mm4);
                    M.AddCell(mm5);
                    documento.Add(M);

                    documento.Add(a);

                    PdfPTable J = new PdfPTable(new float[] { 60f, 60f, 60f, 60f }) { WidthPercentage = 100f, HorizontalAlignment = Element.ALIGN_CENTER };

                    var jj1 = new PdfPCell(new Phrase("Nombre ensayo")) { HorizontalAlignment = Element.ALIGN_LEFT };
                    var jj2 = new PdfPCell(new Phrase("Punto de la norma")) { HorizontalAlignment = Element.ALIGN_LEFT };
                    var jj3 = new PdfPCell(new Phrase("Valor Ensayo (Segundos)")) { HorizontalAlignment = Element.ALIGN_LEFT };
                    var jj4 = new PdfPCell(new Phrase("Resultado Test")) { HorizontalAlignment = Element.ALIGN_LEFT };
                    J.AddCell(jj1);
                    J.AddCell(jj2);
                    J.AddCell(jj3);
                    J.AddCell(jj4);

                    jj1.Phrase = new Phrase(label67.Text);
                    jj2.Phrase = new Phrase(label105.Text);
                    jj3.Phrase = new Phrase(e2);
                    jj4.Phrase = new Phrase(e4);
                    J.AddCell(jj1);
                    J.AddCell(jj2);
                    J.AddCell(jj3);
                    J.AddCell(jj4);

                    jj1.Phrase = new Phrase(label147.Text);
                    jj2.Phrase = new Phrase(label146.Text);
                    jj3.Phrase = new Phrase(e1);
                    jj4.Phrase = new Phrase(e3);
                    J.AddCell(jj1);
                    J.AddCell(jj2);
                    J.AddCell(jj3);
                    J.AddCell(jj4);


                    jj1.Phrase = new Phrase(label64.Text);
                    jj2.Phrase = new Phrase(label107.Text);
                    jj3.Phrase = new Phrase(e5);
                    jj4.Phrase = new Phrase(e6);
                    J.AddCell(jj1);
                    J.AddCell(jj2);
                    J.AddCell(jj3);
                    J.AddCell(jj4);

                    documento.Add(J);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");

            }

            documento.Add(a);
            documento.Add(a);

            //tabla de termocupla

            Paragraph b1 = new Paragraph(label27.Text, f2);
            b1.Alignment = Element.ALIGN_CENTER;
            documento.Add(b1);

            PdfPTable B = new PdfPTable(new float[] { 20f, 60f, 20f, 20f, 20f }) { WidthPercentage = 100f };

            var bb1 = new PdfPCell(new Phrase(label87.Text)) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
            var bb2 = new PdfPCell(new Phrase(label86.Text)) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
            var bb3 = new PdfPCell(new Phrase(" ")) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
            var bb4 = new PdfPCell(new Phrase(label33.Text)) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
            var bb5 = new PdfPCell(new Phrase(label51.Text)) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
            B.AddCell(bb1);
            B.AddCell(bb2);
            B.AddCell(bb3);
            B.AddCell(bb4);
            B.AddCell(bb5);

            documento.Add(B);

            documento.Add(a);

            PdfPTable table1 = new PdfPTable(dataGridView2.Columns.Count);

            for (int j = 0; j < dataGridView2.Columns.Count; j++)
            {
                table1.AddCell(new Phrase(dataGridView2.Columns[j].HeaderText));
            }

            table1.HeaderRows = 1;

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {

                for (int k = 0; k < dataGridView2.Columns.Count; k++)
                {
                    if (dataGridView2[k, i].Value != null)
                    {
                        table1.AddCell(new Phrase(dataGridView2[k, i].Value.ToString()));
                    }

                }

            }

            documento.Add(table1);

            documento.Add(a);
            documento.Add(a);
            documento.Add(a);
            documento.Add(a);
            documento.Add(a);
            documento.Add(a);
            documento.Add(a);
            documento.Add(a);

            //tabla electrico 

            try
            {
                string connetionString = null;
                connetionString = "Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$";
                SqlConnection cn = new SqlConnection(connetionString);


                using (SqlCommand cmd = cn.CreateCommand())
                {

                    //select de resultados electricos
                    cmd.CommandText = "select case when potencia in ('0') then 'N/A' when cumple_v_numeric in  ('0') then 'No cumple' when cumple_v_numeric in ( '1') then 'Cumple' end as 'Resultado Test', case when potencia in ('0') then 'N/A' when marc_instrucc in ( '0')  then 'No cumple' when marc_instrucc in ('1') then 'Cumple' end as 'Marcado de instrucciones', case when potencia in ('0') then 'N/A' when pr_part_activa in ('0') then 'No cumple' when pr_part_activa in ('1') then 'Cumple' end as 'Protección contra acceso p/a' from ENSAYO_ELECTR where id_electr = @e; ";
                    cmd.Parameters.AddWithValue("@e", codigocompleto);
                    SqlDataReader dato;
                    cn.Open();
                    dato = cmd.ExecuteReader();
                    dato.Read();
                    string e1 = dato.GetString(0);
                    string e2 = dato.GetString(1);
                    string e3 = dato.GetString(2);
                    cn.Close();

                    Paragraph l6 = new Paragraph("Ensayo eléctrico", f2);
                    l6.Alignment = Element.ALIGN_CENTER;
                    documento.Add(l6);

                    PdfPTable P = new PdfPTable(new float[] { 20f, 60f, 20f, 20f, 20f }) { WidthPercentage = 100f };
                    var pp1 = new PdfPCell(new Phrase(" ")) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
                    var pp2 = new PdfPCell(new Phrase(" ")) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
                    var pp3 = new PdfPCell(new Phrase(" ")) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
                    var pp4 = new PdfPCell(new Phrase(label33.Text)) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
                    var pp5 = new PdfPCell(new Phrase(label52.Text)) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
                    P.AddCell(pp1);
                    P.AddCell(pp2);
                    P.AddCell(pp3);
                    P.AddCell(pp4);
                    P.AddCell(pp5);
                    documento.Add(P);

                    documento.Add(a);

                    PdfPTable K = new PdfPTable(new float[] { 60f, 60f, 60f, 60f }) { WidthPercentage = 100f, HorizontalAlignment = Element.ALIGN_CENTER };

                    var kk1 = new PdfPCell(new Phrase("Punto de la norma")) { HorizontalAlignment = Element.ALIGN_LEFT };
                    var kk2 = new PdfPCell(new Phrase("Descripción Norma")) { HorizontalAlignment = Element.ALIGN_LEFT };
                    var kk3 = new PdfPCell(new Phrase("Requisito de la norma")) { HorizontalAlignment = Element.ALIGN_LEFT };
                    var kk4 = new PdfPCell(new Phrase("Resultado del test")) { HorizontalAlignment = Element.ALIGN_LEFT };
                    K.AddCell(kk1);
                    K.AddCell(kk2);
                    K.AddCell(kk3);
                    K.AddCell(kk4);

                    //marcado e instrucciones

                    kk1.Phrase = new Phrase(label83.Text);
                    kk2.Phrase = new Phrase(label94.Text);
                    kk3.Phrase = new Phrase(label139.Text);
                    kk4.Phrase = new Phrase(e1);
                    K.AddCell(kk1);
                    K.AddCell(kk2);
                    K.AddCell(kk3);
                    K.AddCell(kk4);

                    //proteccion contra el acceso a las partes activas

                    kk1.Phrase = new Phrase(label168.Text);
                    kk2.Phrase = new Phrase(label167.Text);
                    kk3.Phrase = new Phrase(label166.Text);
                    kk4.Phrase = new Phrase(e2);
                    K.AddCell(kk1);
                    K.AddCell(kk2);
                    K.AddCell(kk3);
                    K.AddCell(kk4);

                    //potencia y corriente 

                    kk1.Phrase = new Phrase(label171.Text);
                    kk2.Phrase = new Phrase(label170.Text);
                    kk3.Phrase = new Phrase(label169.Text);
                    kk4.Phrase = new Phrase(e3);
                    K.AddCell(kk1);
                    K.AddCell(kk2);
                    K.AddCell(kk3);
                    K.AddCell(kk4);

                    documento.Add(K);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");

            }


            //documento.Add(a);
            //documento.Add(a);
            //documento.Add(a);
            //////nuevas tablas

            //PdfPTable q = new PdfPTable(new float[] { 60f, 60f, 60f }) { WidthPercentage = 100f, HorizontalAlignment = Element.ALIGN_CENTER };

            //var qq1 = new PdfPCell(new Phrase("Marcado")) { HorizontalAlignment = Element.ALIGN_LEFT };
            //var qq2 = new PdfPCell(new Phrase("Caracteristicas")) { HorizontalAlignment = Element.ALIGN_LEFT };
            //var qq3 = new PdfPCell(new Phrase("Valor de prueba")) { HorizontalAlignment = Element.ALIGN_LEFT };
            //q.AddCell(qq1);
            //q.AddCell(qq2);
            //q.AddCell(qq3);

            //qq1.Phrase = new Phrase("Tensión Nominal");
            //qq2.Phrase = new Phrase("2");
            //qq3.Phrase = new Phrase("3");
            //q.AddCell(qq1);
            //q.AddCell(qq2);
            //q.AddCell(qq3);

            //qq1.Phrase = new Phrase("Potencia");
            //qq2.Phrase = new Phrase("2");
            //qq3.Phrase = new Phrase("3");
            //q.AddCell(qq1);
            //q.AddCell(qq2);
            //q.AddCell(qq3);

            //qq1.Phrase = new Phrase("Corriente");
            //qq2.Phrase = new Phrase("2");
            //qq3.Phrase = new Phrase("3");
            //q.AddCell(qq1);
            //q.AddCell(qq2);
            //q.AddCell(qq3);

            //documento.Add(q);

            //documento.Add(a);
            //documento.Add(a);

            //PdfPTable u = new PdfPTable(new float[] { 60f, 60f }) { WidthPercentage = 100f, HorizontalAlignment = Element.ALIGN_CENTER };

            //var uu1 = new PdfPCell(new Phrase("Resistencia de Aislación")) { HorizontalAlignment = Element.ALIGN_LEFT };
            //var uu2 = new PdfPCell(new Phrase("(infinito)")) { HorizontalAlignment = Element.ALIGN_LEFT };
            //u.AddCell(uu1);
            //u.AddCell(uu2);

            //uu1.Phrase = new Phrase("Rigidez dieléctrica");
            //uu2.Phrase = new Phrase("2");
            //u.AddCell(uu1);
            //u.AddCell(uu2);

            //uu1.Phrase = new Phrase("Corriente de Fuga");
            //uu2.Phrase = new Phrase("2");
            //u.AddCell(uu1);
            //u.AddCell(uu2);

            //uu1.Phrase = new Phrase("Puesta a Tierra");
            //uu2.Phrase = new Phrase("2");
            //u.AddCell(uu1);
            //u.AddCell(uu2);

            //documento.Add(u);

            //documento.Add(a);
            //documento.Add(a);

            //PdfPTable l = new PdfPTable(new float[] { 60f, 60f, 60f }) { WidthPercentage = 100f, HorizontalAlignment = Element.ALIGN_CENTER };

            //var ll1 = new PdfPCell(new Phrase("Ensayo de marcado")) { HorizontalAlignment = Element.ALIGN_LEFT };
            //var ll2 = new PdfPCell(new Phrase("Tiempo de apliación")) { HorizontalAlignment = Element.ALIGN_LEFT };
            //var ll3 = new PdfPCell(new Phrase("Resultado Test")) { HorizontalAlignment = Element.ALIGN_LEFT };
            //l.AddCell(ll1);
            //l.AddCell(ll2);
            //l.AddCell(ll3);

            //ll1.Phrase = new Phrase("Tiempo de Aplicación (agua)");
            //ll2.Phrase = new Phrase("15 s.");
            //ll3.Phrase = new Phrase("2");
            //l.AddCell(ll1);
            //l.AddCell(ll2);
            //l.AddCell(ll3);

            //ll1.Phrase = new Phrase("Tiempo de Aplicación (hexano)");
            //ll2.Phrase = new Phrase("15 s.");
            //ll3.Phrase = new Phrase("2");
            //l.AddCell(ll1);
            //l.AddCell(ll2);
            //l.AddCell(ll3);


            //documento.Add(l);


            documento.Add(a);
            documento.Add(a);

            //tabla de ingreso de información de imagenes a informe

            PdfPTable C = new PdfPTable(new float[] { 60f, 10f, 60f, 10f, 60f }) { WidthPercentage = 100f };

            var cc1 = new PdfPCell(new Phrase(label1.Text)) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0 };
            var cc2 = new PdfPCell(new Phrase(" ")) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0 };
            var cc3 = new PdfPCell(new Phrase(label28.Text)) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0 };
            var cc4 = new PdfPCell(new Phrase(" ")) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0 };
            var cc5 = new PdfPCell(new Phrase(label29.Text)) { HorizontalAlignment = Element.ALIGN_CENTER, Border = 0 };
            C.AddCell(cc1);
            C.AddCell(cc2);
            C.AddCell(cc3);
            C.AddCell(cc4);
            C.AddCell(cc5);

            documento.Add(C);

            documento.Add(a);


            //ingreso de imagenes a informe

            PdfPTable C2 = new PdfPTable(3);

            string connetionStringg = null;
            connetionStringg = "Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$";
            SqlConnection conn = new SqlConnection(connetionStringg);
            conn.Open();

            string prueba = "select count (*) from INFORME_PRUEBA where n_planilla = @id;";

            SqlCommand pruebas = new SqlCommand(prueba, conn);
            pruebas.Parameters.AddWithValue("@id", codigocompleto);
            int cantidadprueba = Convert.ToInt32(pruebas.ExecuteScalar());

            conn.Close();

            if (cantidadprueba == 0)
            {

            }
            else
            {
                iTextSharp.text.Image imga = iTextSharp.text.Image.GetInstance(GetImage(modelo + "''" + codigo2));

                C2.AddCell(imga);



                iTextSharp.text.Image imga1 = iTextSharp.text.Image.GetInstance(GetImage2(modelo + "''" + codigo2));

                C2.AddCell(imga1);


                iTextSharp.text.Image imga2 = iTextSharp.text.Image.GetInstance(GetImage3(modelo + "''" + codigo2));

                C2.AddCell(imga2);
            }





            //documento.Add(TN);

            documento.Add(C2);
            documento.Add(a);


            //ingreso de datos de usuario y coordinador de cocina

            PdfPTable TB = new PdfPTable(new float[] { 60f, 10f, 60f }) { WidthPercentage = 100f };

            var c1 = new PdfPCell(new Phrase(label25.Text)) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
            var c2 = new PdfPCell(new Phrase(" ")) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
            var c3 = new PdfPCell(new Phrase(label26.Text)) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
            TB.AddCell(c1);
            TB.AddCell(c2);
            TB.AddCell(c3);

            documento.Add(TB);

            documento.Add(a);

            PdfPTable TC = new PdfPTable(new float[] { 60f, 10f, 60f }) { WidthPercentage = 100f };

            var c4 = new PdfPCell(new Phrase(richTextBox1.Text)) { HorizontalAlignment = Element.ALIGN_LEFT };
            var c5 = new PdfPCell(new Phrase(" ")) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
            var c6 = new PdfPCell(new Phrase(richTextBox1.Text)) { HorizontalAlignment = Element.ALIGN_LEFT };
            TC.AddCell(c4);
            TC.AddCell(c5);
            TC.AddCell(c6);

            documento.Add(TC);

            documento.Add(a);
            documento.Add(a);


            PdfPTable TD = new PdfPTable(new float[] { 60f, 10f, 60f }) { WidthPercentage = 100f };

            var c7 = new PdfPCell(new Phrase(label54.Text)) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
            var c8 = new PdfPCell(new Phrase(" ")) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
            var c9 = new PdfPCell(new Phrase(label55.Text)) { HorizontalAlignment = Element.ALIGN_LEFT, Border = 0 };
            TD.AddCell(c7);
            TD.AddCell(c8);
            TD.AddCell(c9);

            c7.Phrase = new Phrase(label21.Text);
            c8.Phrase = new Phrase(" ");
            c9.Phrase = new Phrase(label23.Text);
            TD.AddCell(c7);
            TD.AddCell(c8);
            TD.AddCell(c9);

            c7.Phrase = new Phrase(label22.Text);
            c8.Phrase = new Phrase(" ");
            c9.Phrase = new Phrase(label24.Text);
            TD.AddCell(c7);
            TD.AddCell(c8);
            TD.AddCell(c9);

            documento.Add(TD);


           
            documento.Close();


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void FormInformePDF_Load(object sender, EventArgs e)
        {


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }




        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll_1(object sender, ScrollEventArgs e)
        {



        }

        private void vScrollBar1_Leave(object sender, EventArgs e)
        {



        }

        private void vScrollBar1_Scroll_2(object sender, ScrollEventArgs e)
        {

        }

        private void vScrollBar1_Scroll_3(object sender, ScrollEventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click_1(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label54_Click(object sender, EventArgs e)
        {

        }

        private void label55_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }


        private void label53_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label56_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label57_Click(object sender, EventArgs e)
        {

        }

        private void label51_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label52_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label28_Click_1(object sender, EventArgs e)
        {

        }

        private void FormInformePDF_Leave(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormInformePDF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FormInformePDF_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

