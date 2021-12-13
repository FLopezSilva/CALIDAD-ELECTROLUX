using Domain;
using Presentation.Helpers;
using Presentation.Informe;
using Presentation.Opcion.MenuEnsayosIndi.Pruebas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Opcion.MenuEnsayosIndi
{
    public partial class FormPruebaIndi : Form
    {
        string inicio = DateTime.Now.ToString("HH:mm:ss");
        Stopwatch stopwatch = new Stopwatch();

        
        
        private DragControl dragControl;//Permite arrastrar el formulario.       


        public FormPruebaIndi()
        {
            InitializeComponent();

            string asd = txtCodigo.Text;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            dragControl = new DragControl(panel1, this);

            stopwatch.Start();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de cerrar la aplicación?", "Mensaje",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Application.Exit();//Cierra toda la aplicación finalizando todos los procesos.
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var userModel = new UserModel();//Devuelve un objeto UserModel como resultado.

            if (MessageBox.Show("¿Está seguro de volver?", "Mensaje",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)

                this.Close();
            Form FormOpcion;
            FormOpcion = new FormOpcion(userModel);
            FormOpcion.Show();
        }

        private void btnGuardarCondicion_Click(object sender, EventArgs e)
        {
            try
            {
                string connetionString = null;
                connetionString = "Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$";
                SqlConnection conn = new SqlConnection(connetionString);
                conn.Open();
                SqlCommand comm = conn.CreateCommand();


                string a = DateTime.Now.ToString("HH:mm:ss");
                string b = DateTime.Now.ToString("dd/MM/yyyy");

                comm.CommandText = "INSERT INTO prueba(fec_pruebas,hora_inicio_p,hora_termino_p,tiem_prueba,id_combu,id_electr,id_termo,id_retencion,id_basc,id_resist,id_trab,id_nivelac,id_condicion,id_fuga,n_planilla,id_c_llama) VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16)";

                comm.Parameters.AddWithValue("@p1", DateTime.Now);
                comm.Parameters.AddWithValue("@p2", inicio);
                comm.Parameters.AddWithValue("@p3", DateTime.Now.ToString("HH:mm:ss"));

                stopwatch.Stop();

                comm.Parameters.AddWithValue("@p4", stopwatch.Elapsed);
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
                comm.Parameters.AddWithValue("@p13", comm.CommandText = "select id_condicion from CONDICION_ENSAYO where cod_cocina = '" + codigo1 + "''" + codigo2 + "';");
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




                FormInformePDF informe = new FormInformePDF();

                informe.Show();

                this.Close();
                //Form FormOpcion;
                //FormOpcion = new FormOpcion(userModel);
                //FormOpcion.Show();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void btnCondiciones_Click(object sender, EventArgs e)
        {
            FormCondicionEnsayoIndi manual = new FormCondicionEnsayoIndi() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            manual.TopLevel = false;
            manual.AutoScroll = true;
            this.panelOpciones.Controls.Add(manual);


            label1.Text = "Condicion Ensayo";
            manual.txtCodCocina.Text = txtCodigo.Text;

            manual.Show();
            manual.BringToFront();

        }

        private void btnCombustion_Click(object sender, EventArgs e)
        {
            FormEnsayoCombustionIndi combustion = new FormEnsayoCombustionIndi() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            combustion.TopLevel = false;
            combustion.AutoScroll = true;
            this.panelOpciones.Controls.Add(combustion);

            label1.Text = "Ensayo Combustion";
            //AbrirFormHija(new FormEnsayoFugaGas());
            FormEnsayoCombustionIndi.asd4 = txtCodigo.Text;

            combustion.Show();
            combustion.BringToFront();
        }

        private void btnElectrico_Click(object sender, EventArgs e)
        {
            FormEnsayoElectricoIndi electrico = new FormEnsayoElectricoIndi() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            electrico.TopLevel = false;
            electrico.AutoScroll = true;
            this.panelOpciones.Controls.Add(electrico);

            label1.Text = "Ensayo Electrico";
            //AbrirFormHija(new FormEnsayoFugaGas());
            FormEnsayoElectricoIndi.asd6 = txtCodigo.Text;

            electrico.Show();
            electrico.BringToFront();
        }

        private void btnFugaGas_Click(object sender, EventArgs e)
        {
            FormEnsayoFugaGasIndi fugagas = new FormEnsayoFugaGasIndi() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            fugagas.TopLevel = false;
            fugagas.AutoScroll = true;
            this.panelOpciones.Controls.Add(fugagas);

            label1.Text = "Ensayo Fuga de Gas";
            //AbrirFormHija(new FormEnsayoFugaGas());
            FormEnsayoFugaGasIndi.asd3 = txtCodigo.Text;

            fugagas.Show();
            fugagas.BringToFront();
        }

        private void btnManuales_Click(object sender, EventArgs e)
        {
            FormEnsayoManualIndi manual = new FormEnsayoManualIndi() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            manual.TopLevel = false;
            manual.AutoScroll = true;
            this.panelOpciones.Controls.Add(manual);
            //label1.Text = "Ensayos Manuales";
            //AbrirFormHija(new FormEnsayoManual());
            label1.Text = "Ensayo Manuales";
            FormEnsayoManualIndi.asd = txtCodigo.Text;

            manual.Show();
            manual.BringToFront();
        }

        private void btnNivelacion_Click(object sender, EventArgs e)
        {
            FormEnsayoNivelacionIndi nivelacion = new FormEnsayoNivelacionIndi() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            nivelacion.TopLevel = false;
            nivelacion.AutoScroll = true;
            this.panelOpciones.Controls.Add(nivelacion);

            label1.Text = "Ensayo Nivelación";
            //AbrirFormHija(new FormEnsayoNivelacion());
            FormEnsayoNivelacionIndi.asd2 = txtCodigo.Text;

            nivelacion.Show();
            nivelacion.BringToFront();
        }

        private void btnObservacion_Click(object sender, EventArgs e)
        {
            FormEnsayoObservacionNotaIndi notas = new FormEnsayoObservacionNotaIndi() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            notas.TopLevel = false;
            notas.AutoScroll = true;
            this.panelOpciones.Controls.Add(notas);

            label1.Text = "Obersarvaciones y notas";
            //AbrirFormHija(new FormEnsayoFugaGas());
            FormEnsayoObservacionNotaIndi.asd7 = txtCodigo.Text;
            notas.txtrut.Text = txtrut.Text;



            notas.Show();
            notas.BringToFront();
        }

        private void btnTermocupla_Click(object sender, EventArgs e)
        {
            FormEnsayoTermocuplaIndi termocupla = new FormEnsayoTermocuplaIndi() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            termocupla.TopLevel = false;
            termocupla.AutoScroll = true;
            this.panelOpciones.Controls.Add(termocupla);

            label1.Text = "Ensayo Termocupla";
            //AbrirFormHija(new FormEnsayoFugaGas());
            FormEnsayoTermocuplaIndi.asd5 = txtCodigo.Text;

            termocupla.Show();
            termocupla.BringToFront();
        }

        private void btnGuardarCondicion_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=10.130.14.248;Initial Catalog=NuevaQA;User ID=NRFT;Password=Nrft2019$");
            con.Open();

          

            //////////////////////////////////// CONDICION ENSAYO ///////////////////////////////////////

            string query9 = "select COUNT(*) from CONDICION_ENSAYO where cod_cocina = @id;";
            SqlCommand cmd10 = new SqlCommand(query9, con);
            cmd10.Parameters.AddWithValue("@id", txtCodigo.Text);
            int cant9 = Convert.ToInt32(cmd10.ExecuteScalar());

            if (cant9 == 0)
            {
                MessageBox.Show("SIN DATOS REGISTRADOS EN CONDICION DE ENSAYO, INGRESE PRUEBA", "ALERTA");
            }

            
           

            /////////////////////////////////////////////////////////////////////////////////////////////////


            try
            {
                if (cant9 == 0)
                {
                    MessageBox.Show("INGRESE DATOS CORRESPONDIENTES", "ALERTA");

                }
                else
                {
                    string connetionString = null;
                    connetionString = "Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$";
                    SqlConnection conn = new SqlConnection(connetionString);
                    conn.Open();

                    string prueba = "select count (*) from prueba a inner join CONDICION_ENSAYO b on a.id_condicion = b.id_condicion where b.cod_cocina = @id;";
                    SqlCommand pruebas = new SqlCommand(prueba, con);
                    pruebas.Parameters.AddWithValue("@id", txtCodigo.Text);
                    int cantidadprueba = Convert.ToInt32(pruebas.ExecuteScalar());

                    if (cantidadprueba == 0)
                    {
                        SqlCommand comm = conn.CreateCommand();

                        string a = DateTime.Now.ToString("HH:mm:ss");
                        string b = DateTime.Now.ToString("dd/MM/yyyy");

                        string codigo1 = txtCodigo.Text.Substring(0, txtCodigo.Text.IndexOf("'"));
                        string codigo2 = txtCodigo.Text.Substring(txtCodigo.Text.IndexOf("'") + 1);

                        comm.CommandText = "INSERT INTO prueba(fec_pruebas,hora_inicio_p,hora_termino_p,tiem_prueba,id_combu,id_electr,id_termo,id_retencion,id_basc,id_resist,id_trab,id_nivelac,id_condicion,id_fuga,n_planilla,id_c_llama) VALUES(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16)";

                        comm.Parameters.AddWithValue("@p1", DateTime.Now);
                        comm.Parameters.AddWithValue("@p2", inicio);
                        comm.Parameters.AddWithValue("@p3", DateTime.Now.ToString("HH:mm:ss"));

                        stopwatch.Stop();

                        comm.Parameters.AddWithValue("@p4", stopwatch.Elapsed); // ver esto

                        string B = "select count(*) from ENSAYO_COMB where id_combu = '" + codigo1 + "''" + codigo2 + "'";
                        string C = "select count(*) from ENSAYO_ELECTR where id_electr = '" + codigo1 + "''" + codigo2 + "'";
                        string D = "select count(*) from ENSAYO_TERMOCUP where id_termo = '" + codigo1 + "''" + codigo2 + "'";
                        string E = "select count(*) from ENSAYO_RETENCION where id_retencion = '" + codigo1 + "''" + codigo2 + "'";
                        string F = "select count(*) from ENSAYO_BASCUL where id_basc = '" + codigo1 + "''" + codigo2 + "'";
                        string G = "select count(*) from ENSAYO_RESIST where id_resist = '" + codigo1 + "''" + codigo2 + "'";
                        string H = "select count(*) from ENSAYO_TRABAM where id_trab = '" + codigo1 + "''" + codigo2 + "'";
                        string I = "select count(*) from ENSAYO_NIVELAC where id_nivelac = '" + codigo1 + "''" + codigo2 + "'";
                        string J = "select count(*) from ENSAYO_FUGA_G where id_fuga = '" + codigo1 + "''" + codigo2 + "'";
                        string K = "select count(*) from INFORME_PRUEBA where n_planilla = '" + codigo1 + "''" + codigo2 + "'";
                        string L = "select count(*) from ENSAYO_C_LLAMA where id_c_llama = '" + codigo1 + "''" + codigo2 + "'";

                        SqlCommand cmd2 = new SqlCommand(B, conn);
                        SqlCommand cmd3 = new SqlCommand(C, conn);
                        SqlCommand cmd4 = new SqlCommand(D, conn);
                        SqlCommand cmd5 = new SqlCommand(E, conn);
                        SqlCommand cmd6 = new SqlCommand(F, conn);
                        SqlCommand cmd7 = new SqlCommand(G, conn);
                        SqlCommand cmd8 = new SqlCommand(H, conn);
                        SqlCommand cmd9 = new SqlCommand(I, conn);
                        SqlCommand cmd11 = new SqlCommand(J, conn);
                        SqlCommand cmd12 = new SqlCommand(K, conn);
                        SqlCommand cmd13 = new SqlCommand(L, conn);


                        int combu = (int)cmd2.ExecuteScalar();
                        int electro = (int)cmd3.ExecuteScalar();
                        int termo = (int)cmd4.ExecuteScalar();
                        int retencion = (int)cmd5.ExecuteScalar();
                        int bascu = (int)cmd6.ExecuteScalar();
                        int resist = (int)cmd7.ExecuteScalar();
                        int traba = (int)cmd8.ExecuteScalar();
                        int nivelacion = (int)cmd9.ExecuteScalar();
                        int fuga = (int)cmd11.ExecuteScalar();
                        int planilla = (int)cmd12.ExecuteScalar();
                        int llama = (int)cmd13.ExecuteScalar();


                        //////////////////// combustion ///////////////////
                        if (combu == 0)
                        {

                            string aa = "Consumo Total";
                            string bb = "Consumo medio (1/2)";

                            string q = "Quemador";

                            string[] quem = { q+" Trasero Derecho", q+" Trasero Izquierdo", q+" Delantero Izquierdo",
                                     q+" Delantero Derecho", q+" Central Delantero", q+" Central Trasero",
                                     q+" Central", "Horno", "Todos los "+q+"es" };



                            comm.CommandText = "if not EXISTS (select * from ENSAYO_COMB where id_combu = @comb1) INSERT INTO ENSAYO_COMB (id_combu,cumple_comb,fecha_ec,hora_inicio_c,hora_termino_c) VALUES(@comb1,@comb2,@comb3,@comb4,@comb5) else update ENSAYO_COMB set id_combu = @comb1, cumple_comb = @comb2, fecha_ec = @comb3 , hora_inicio_c = @comb4 , hora_termino_c = @comb5 where id_combu = @comb1";

                            comm.Parameters.AddWithValue("@comb1", txtCodigo.Text); //valor que debe cambiarse por un dato que sea autoincrementable
                            bool asd = false;
                            comm.Parameters.AddWithValue("@comb2", asd); // cambiar
                            comm.Parameters.AddWithValue("@comb3", DateTime.Now/*.ToString("dd/MM/yyyy")*/);
                            comm.Parameters.AddWithValue("@comb4", inicio);
                            comm.Parameters.AddWithValue("@comb5", DateTime.Now.ToString("HH:mm:ss")/*.ToString("HH:mm:ss")*/);


                            comm.ExecuteNonQuery();

                            // 1


                            comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c2 and nom_posicion = @c3 and id_combu = @c8) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c2,@c3,@c4,@c5,@c6,@c7,@c8) else update COMBU set nom_quemador = @c2, nom_posicion = @c3, co = @c4, co_2 = @c5, co_n = @c6, cumple_comb = @c7, id_combu = @c8 where nom_quemador = @c2 and nom_posicion = @c3 and id_combu = @c8";

                            comm.Parameters.AddWithValue("@c2", quem[0]);
                            comm.Parameters.AddWithValue("@c3", aa);
                            comm.Parameters.AddWithValue("@c4", 0);
                            comm.Parameters.AddWithValue("@c5", 0);
                            comm.Parameters.AddWithValue("@c6", 0);
                            comm.Parameters.AddWithValue("@c7", false);
                            comm.Parameters.AddWithValue("@c8", txtCodigo.Text);

                            comm.ExecuteNonQuery();


                            //2
                            comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c10 and nom_posicion = @c11 and id_combu = @c16) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c10,@c11,@c12,@c13,@c14,@c15,@c16) else update COMBU set nom_quemador = @c10, nom_posicion = @c11, co = @c12, co_2 = @c13, co_n = @c14, cumple_comb = @c15, id_combu = @c16 where nom_quemador = @c10 and nom_posicion = @c11 and id_combu = @c16";

                            comm.Parameters.AddWithValue("@c10", quem[0]);
                            comm.Parameters.AddWithValue("@c11", bb);
                            comm.Parameters.AddWithValue("@c12", 0);
                            comm.Parameters.AddWithValue("@c13", 0);
                            comm.Parameters.AddWithValue("@c14", 0);
                            comm.Parameters.AddWithValue("@c15", false);
                            comm.Parameters.AddWithValue("@c16", txtCodigo.Text);

                            comm.ExecuteNonQuery();

                            //3

                            comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c18 and nom_posicion = @c19 and id_combu = @c24) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c18,@c19,@c20,@c21,@c22,@c23,@c24) else update COMBU set nom_quemador = @c18, nom_posicion = @c19, co = @c20, co_2 = @c21, co_n = @c22, cumple_comb = @c23, id_combu = @c24 where nom_quemador = @c18 and nom_posicion = @c19 and id_combu = @c24";

                            comm.Parameters.AddWithValue("@c18", quem[1]);
                            comm.Parameters.AddWithValue("@c19", aa);
                            comm.Parameters.AddWithValue("@c20", 0);
                            comm.Parameters.AddWithValue("@c21", 0);
                            comm.Parameters.AddWithValue("@c22", 0);
                            comm.Parameters.AddWithValue("@c23", false);
                            comm.Parameters.AddWithValue("@c24", txtCodigo.Text);

                            comm.ExecuteNonQuery();


                            //4


                            comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c26 and nom_posicion = @c27 and id_combu = @c32) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c26,@c27,@c28,@c29,@c30,@c31,@c32) else update COMBU set nom_quemador = @c26, nom_posicion = @c27, co = @c28, co_2 = @c29, co_n = @c30, cumple_comb = @c31, id_combu = @c32 where nom_quemador = @c26 and nom_posicion = @c27 and id_combu = @c32";

                            comm.Parameters.AddWithValue("@c26", quem[1]);
                            comm.Parameters.AddWithValue("@c27", bb);
                            comm.Parameters.AddWithValue("@c28", 0);
                            comm.Parameters.AddWithValue("@c29", 0);
                            comm.Parameters.AddWithValue("@c30", 0);
                            comm.Parameters.AddWithValue("@c31", false);
                            comm.Parameters.AddWithValue("@c32", txtCodigo.Text);

                            comm.ExecuteNonQuery();


                            //5


                            comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c34 and nom_posicion = @c35 and id_combu = @c40) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c34,@c35,@c36,@c37,@c38,@c39,@c40) else update COMBU set nom_quemador = @c34, nom_posicion = @c35, co = @c36, co_2 = @c37, co_n = @c38, cumple_comb = @c39, id_combu = @c40 where nom_quemador = @c34 and nom_posicion = @c35 and id_combu = @c40";

                            comm.Parameters.AddWithValue("@c34", quem[2]);
                            comm.Parameters.AddWithValue("@c35", aa);
                            comm.Parameters.AddWithValue("@c36", 0);
                            comm.Parameters.AddWithValue("@c37", 0);
                            comm.Parameters.AddWithValue("@c38", 0);
                            comm.Parameters.AddWithValue("@c39", false);
                            comm.Parameters.AddWithValue("@c40", txtCodigo.Text);

                            comm.ExecuteNonQuery();


                            //6


                            comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c42 and nom_posicion = @c43 and id_combu = @c48) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c42,@c43,@c44,@c45,@c46,@c47,@c48) else update COMBU set nom_quemador = @c42, nom_posicion = @c43, co = @c44, co_2 = @c45, co_n = @c46, cumple_comb = @c47, id_combu = @c48 where nom_quemador = @c42 and nom_posicion = @c43 and id_combu = @c48";

                            comm.Parameters.AddWithValue("@c42", quem[2]);
                            comm.Parameters.AddWithValue("@c43", bb);
                            comm.Parameters.AddWithValue("@c44", 0);
                            comm.Parameters.AddWithValue("@c45", 0);
                            comm.Parameters.AddWithValue("@c46", 0);
                            comm.Parameters.AddWithValue("@c47", false);
                            comm.Parameters.AddWithValue("@c48", txtCodigo.Text);

                            comm.ExecuteNonQuery();

                            //7


                            comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c50 and nom_posicion = @c51 and id_combu = @c56) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c50,@c51,@c52,@c53,@c54,@c55,@c56) else update COMBU set nom_quemador = @c50, nom_posicion = @c51, co = @c52, co_2 = @c53, co_n = @c54, cumple_comb = @c55, id_combu = @c56 where nom_quemador = @c50 and nom_posicion = @c51 and id_combu = @c56";

                            comm.Parameters.AddWithValue("@c50", quem[3]);
                            comm.Parameters.AddWithValue("@c51", aa);
                            comm.Parameters.AddWithValue("@c52", 0);
                            comm.Parameters.AddWithValue("@c53", 0);
                            comm.Parameters.AddWithValue("@c54", 0);
                            comm.Parameters.AddWithValue("@c55", false);
                            comm.Parameters.AddWithValue("@c56", txtCodigo.Text);

                            comm.ExecuteNonQuery();


                            //8


                            comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c58 and nom_posicion = @c59 and id_combu = @c64) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c58,@c59,@c60,@c61,@c62,@c63,@c64) else update COMBU set nom_quemador = @c58, nom_posicion = @c59, co = @c60, co_2 = @c61, co_n = @c62, cumple_comb = @c63, id_combu = @c64 where nom_quemador = @c58 and nom_posicion = @c59 and id_combu = @c64";

                            comm.Parameters.AddWithValue("@c58", quem[3]);
                            comm.Parameters.AddWithValue("@c59", bb);
                            comm.Parameters.AddWithValue("@c60", 0);
                            comm.Parameters.AddWithValue("@c61", 0);
                            comm.Parameters.AddWithValue("@c62", 0);
                            comm.Parameters.AddWithValue("@c63", false);
                            comm.Parameters.AddWithValue("@c64", txtCodigo.Text);

                            comm.ExecuteNonQuery();

                            //9


                            comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c66 and nom_posicion = @c67 and id_combu = @c72) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c66,@c67,@c68,@c69,@c70,@c71,@c72) else update COMBU set nom_quemador = @c66, nom_posicion = @c67, co = @c68, co_2 = @c69, co_n = @c70, cumple_comb = @c71, id_combu = @c72 where nom_quemador = @c66 and nom_posicion = @c67 and id_combu = @c72";

                            comm.Parameters.AddWithValue("@c66", quem[4]);
                            comm.Parameters.AddWithValue("@c67", aa);
                            comm.Parameters.AddWithValue("@c68", 0);
                            comm.Parameters.AddWithValue("@c69", 0);
                            comm.Parameters.AddWithValue("@c70", 0);
                            comm.Parameters.AddWithValue("@c71", false);
                            comm.Parameters.AddWithValue("@c72", txtCodigo.Text);

                            comm.ExecuteNonQuery();

                            //10/////////


                            comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c74 and nom_posicion = @c75 and id_combu = @c80) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c74,@c75,@c76,@c77,@c78,@c79,@c80) else update COMBU set nom_quemador = @c74, nom_posicion = @c75, co = @c76, co_2 = @c77, co_n = @c78, cumple_comb = @c79, id_combu = @c80 where nom_quemador = @c74 and nom_posicion = @c75 and id_combu = @c80";

                            comm.Parameters.AddWithValue("@c74", quem[4]);
                            comm.Parameters.AddWithValue("@c75", bb);
                            comm.Parameters.AddWithValue("@c76", 0);
                            comm.Parameters.AddWithValue("@c77", 0);
                            comm.Parameters.AddWithValue("@c78", 0);
                            comm.Parameters.AddWithValue("@c79", false);
                            comm.Parameters.AddWithValue("@c80", txtCodigo.Text);

                            comm.ExecuteNonQuery();


                            //11


                            comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c82 and nom_posicion = @c83 and id_combu = @c88) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c82,@c83,@c84,@c85,@c86,@c87,@c88) else update COMBU set nom_quemador = @c82, nom_posicion = @c83, co = @c84, co_2 = @c85, co_n = @c86, cumple_comb = @c87, id_combu = @c88 where nom_quemador = @c82 and nom_posicion = @c83 and id_combu = @c88";

                            comm.Parameters.AddWithValue("@c82", quem[5]);
                            comm.Parameters.AddWithValue("@c83", aa);
                            comm.Parameters.AddWithValue("@c84", 0);
                            comm.Parameters.AddWithValue("@c85", 0);
                            comm.Parameters.AddWithValue("@c86", 0);
                            comm.Parameters.AddWithValue("@c87", false);
                            comm.Parameters.AddWithValue("@c88", txtCodigo.Text);

                            comm.ExecuteNonQuery();

                            //12


                            comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c90 and nom_posicion = @c91 and id_combu = @c96) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c90,@c91,@c92,@c93,@c94,@c95,@c96) else update COMBU set nom_quemador = @c90, nom_posicion = @c91, co = @c92, co_2 = @c93, co_n = @c94, cumple_comb = @c95, id_combu = @c96 where nom_quemador = @c90 and nom_posicion = @c91 and id_combu = @c96";

                            comm.Parameters.AddWithValue("@c90", quem[5]);
                            comm.Parameters.AddWithValue("@c91", bb);
                            comm.Parameters.AddWithValue("@c92", 0);
                            comm.Parameters.AddWithValue("@c93", 0);
                            comm.Parameters.AddWithValue("@c94", 0);
                            comm.Parameters.AddWithValue("@c95", false);
                            comm.Parameters.AddWithValue("@c96", txtCodigo.Text);

                            comm.ExecuteNonQuery();

                            //13


                            comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c98 and nom_posicion = @c99 and id_combu = @c104) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c98,@c99,@c100,@c101,@c102,@c103,@c104) else update COMBU set nom_quemador = @c98, nom_posicion = @c99, co = @c100, co_2 = @c101, co_n = @c102, cumple_comb = @c103, id_combu = @c104 where nom_quemador = @c98 and nom_posicion = @c99 and id_combu = @c104";

                            comm.Parameters.AddWithValue("@c98", quem[6]);
                            comm.Parameters.AddWithValue("@c99", aa);
                            comm.Parameters.AddWithValue("@c100", 0);
                            comm.Parameters.AddWithValue("@c101", 0);
                            comm.Parameters.AddWithValue("@c102", 0);
                            comm.Parameters.AddWithValue("@c103", false);
                            comm.Parameters.AddWithValue("@c104", txtCodigo.Text);

                            comm.ExecuteNonQuery();

                            //14


                            comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c106 and nom_posicion = @c107 and id_combu = @c112) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c106,@c107,@c108,@c109,@c110,@c111,@c112) else update COMBU set nom_quemador = @c106, nom_posicion = @c107, co = @c108, co_2 = @c109, co_n = @c110, cumple_comb = @c111, id_combu = @c112 where nom_quemador = @c106 and nom_posicion = @c107 and id_combu = @c112";

                            comm.Parameters.AddWithValue("@c106", quem[6]);
                            comm.Parameters.AddWithValue("@c107", bb);
                            comm.Parameters.AddWithValue("@c108", 0);
                            comm.Parameters.AddWithValue("@c109", 0);
                            comm.Parameters.AddWithValue("@c110", 0);
                            comm.Parameters.AddWithValue("@c111", false);
                            comm.Parameters.AddWithValue("@c112", txtCodigo.Text);

                            comm.ExecuteNonQuery();


                            //15


                            comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c114 and nom_posicion = @c115 and id_combu = @c120) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c114,@c115,@c116,@c117,@c118,@c119,@c120) else update COMBU set nom_quemador = @c114, nom_posicion = @c115, co = @c116, co_2 = @c117, co_n = @c118, cumple_comb = @c119, id_combu = @c120 where nom_quemador = @c114 and nom_posicion = @c115 and id_combu = @c120";

                            comm.Parameters.AddWithValue("@c114", quem[7]);
                            comm.Parameters.AddWithValue("@c115", aa);
                            comm.Parameters.AddWithValue("@c116", 0);
                            comm.Parameters.AddWithValue("@c117", 0);
                            comm.Parameters.AddWithValue("@c118", 0);
                            comm.Parameters.AddWithValue("@c119", false);
                            comm.Parameters.AddWithValue("@c120", txtCodigo.Text);

                            comm.ExecuteNonQuery();


                            //16


                            comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c122 and nom_posicion = @c123 and id_combu = @c128) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c122,@c123,@c124,@c125,@c126,@c127,@c128) else update COMBU set nom_quemador = @c122, nom_posicion = @c123, co = @c124, co_2 = @c125, co_n = @c126, cumple_comb = @c127, id_combu = @c128 where nom_quemador = @c122 and nom_posicion = @c123 and id_combu = @c128";

                            comm.Parameters.AddWithValue("@c122", quem[7]);
                            comm.Parameters.AddWithValue("@c123", bb);
                            comm.Parameters.AddWithValue("@c124", 0);
                            comm.Parameters.AddWithValue("@c125", 0);
                            comm.Parameters.AddWithValue("@c126", 0);
                            comm.Parameters.AddWithValue("@c127", false);
                            comm.Parameters.AddWithValue("@c128", txtCodigo.Text);

                            comm.ExecuteNonQuery();

                            comm.Parameters.AddWithValue("@p5", txtCodigo.Text);


                        }
                        else
                        {
                            comm.Parameters.AddWithValue("@p5", txtCodigo.Text);
                        }
                        //////////////////// electrico ///////////////////

                        if (electro == 0)
                        {

                            comm.CommandText = "INSERT INTO ensayo_electr(id_electr,marc_instrucc,pr_part_activa,potencia,corriente,continuidad,aislamiento,rig_dielect,cumple_v_numeric,cumple_electr,fecha_electr,hora_inicio_e,hora_termino_e) VALUES(@elec1, @elec2, @elec3, @elec4, @elec5, @elec6, @elec7, @elec8, @elec9,@elec10,@elec11,@elec12,@elec13)";

                            comm.Parameters.AddWithValue("@elec1", txtCodigo.Text); //valor que debe cambiarse por un dato que sea autoincrementable
                            comm.Parameters.AddWithValue("@elec2", false);
                            comm.Parameters.AddWithValue("@elec3", false);
                            comm.Parameters.AddWithValue("@elec4", 0);
                            comm.Parameters.AddWithValue("@elec5", 0);
                            comm.Parameters.AddWithValue("@elec6", 0);
                            comm.Parameters.AddWithValue("@elec7", 0);
                            comm.Parameters.AddWithValue("@elec8", 0);
                            comm.Parameters.AddWithValue("@elec9", false);
                            comm.Parameters.AddWithValue("@elec10", false);
                            comm.Parameters.AddWithValue("@elec11", DateTime.Now);
                            comm.Parameters.AddWithValue("@elec12", inicio);
                            comm.Parameters.AddWithValue("@elec13", DateTime.Now.ToString("HH:mm:ss"));

                            comm.ExecuteNonQuery();

                            comm.Parameters.AddWithValue("@p6", txtCodigo.Text);
                        }
                        else
                        {
                            comm.Parameters.AddWithValue("@p6", txtCodigo.Text);
                        }

                        //////////////////// termo ///////////////////

                        if (termo == 0)
                        {
                            string p = "Perrilla ";

                            string[] pieza = { p+"QTD", p+"QDD", p+"QTI", p+"QDI", p+"Horno", p+"QC", p+"QCD", p+"QCT"
                                      , "Tirador puerta", "Conexión boquilla","Frente llaves","Piso panel"
                                      , "Panel lateral", "Panel posterior","Costado libre","Centro horno"
                                      , "Puerta vidrio", "Paredes flexibles"};


                            string aaa = "Ta+";
                            string bbb = "C°";

                            //8

                            string[] ta = { aaa + "60" + bbb, aaa + "45" + bbb, aaa + "30" + bbb, aaa + "80" + bbb, aaa + "70" + bbb, aaa + "100" + bbb, "T° 200" + bbb + "+4/-0" };


                            comm.CommandText = "INSERT INTO ensayo_termocup(id_termo,cumple_termo,fecha_termo,hora_inicio_t,hora_termino_t) VALUES(@termo1, @termo2, @termo3,@termo4,@termo5)";
                            comm.Parameters.AddWithValue("@termo1", txtCodigo.Text); //cambiar parametro
                            comm.Parameters.AddWithValue("@termo2", false); // cambiar parametro
                            comm.Parameters.AddWithValue("@termo3", DateTime.Now/*.ToString("dd/MM/yyyy")*/);
                            comm.Parameters.AddWithValue("@termo4", inicio);
                            comm.Parameters.AddWithValue("@termo5", DateTime.Now.ToString("HH:mm:ss")/*.ToString("HH:mm:ss")*/);

                            comm.ExecuteNonQuery();

                            //1

                            comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t2,@t3,@t4,@t5,@t6)";
                            comm.Parameters.AddWithValue("@t2", pieza[0]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t3", 0);
                            comm.Parameters.AddWithValue("@t4", false);
                            comm.Parameters.AddWithValue("@t5", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@t6", ta[0]);

                            comm.ExecuteNonQuery();

                            //2


                            comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t8,@t9,@t10,@t11,@t12)";
                            comm.Parameters.AddWithValue("@t8", pieza[1]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t9", 0);
                            comm.Parameters.AddWithValue("@t10", false);
                            comm.Parameters.AddWithValue("@t11", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@t12", ta[0]);

                            comm.ExecuteNonQuery();

                            //3


                            comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t14,@t15,@t16,@t17,@t18)";
                            comm.Parameters.AddWithValue("@t14", pieza[2]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t15", 0);
                            comm.Parameters.AddWithValue("@t16", false);
                            comm.Parameters.AddWithValue("@t17", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@t18", ta[0]);

                            comm.ExecuteNonQuery();

                            //4


                            comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t20,@t21,@t22,@t23,@t24)";
                            comm.Parameters.AddWithValue("@t20", pieza[3]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t21", 0);
                            comm.Parameters.AddWithValue("@t22", false);
                            comm.Parameters.AddWithValue("@t23", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@t24", ta[0]);

                            comm.ExecuteNonQuery();


                            //5


                            comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t26,@t27,@t28,@t29,@t30)";
                            comm.Parameters.AddWithValue("@t26", pieza[4]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t27", 0);
                            comm.Parameters.AddWithValue("@t28", false);
                            comm.Parameters.AddWithValue("@t29", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@t30", ta[0]);

                            comm.ExecuteNonQuery();

                            //6


                            comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t32,@t33,@t34,@t35,@t36)";
                            comm.Parameters.AddWithValue("@t32", pieza[5]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t33", 0);
                            comm.Parameters.AddWithValue("@t34", false);
                            comm.Parameters.AddWithValue("@t35", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@t36", ta[0]);

                            comm.ExecuteNonQuery();

                            //7


                            comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t38,@t39,@t40,@t41,@t42)";
                            comm.Parameters.AddWithValue("@t38", pieza[6]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t39", 0);
                            comm.Parameters.AddWithValue("@t40", false);
                            comm.Parameters.AddWithValue("@t41", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@t42", ta[0]);

                            comm.ExecuteNonQuery();

                            //8


                            comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t44,@t45,@t46,@t47,@t48)";
                            comm.Parameters.AddWithValue("@t44", pieza[7]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t45", 0);
                            comm.Parameters.AddWithValue("@t46", false);
                            comm.Parameters.AddWithValue("@t47", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@t48", ta[0]);

                            comm.ExecuteNonQuery();

                            //9


                            comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t50,@t51,@t52,@t53,@t54)";
                            comm.Parameters.AddWithValue("@t50", pieza[8]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t51", 0);
                            comm.Parameters.AddWithValue("@t52", false);
                            comm.Parameters.AddWithValue("@t53", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@t54", ta[1]);

                            comm.ExecuteNonQuery();

                            //10


                            comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t56,@t57,@t58,@t59,@t60)";
                            comm.Parameters.AddWithValue("@t56", pieza[9]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t57", 0);
                            comm.Parameters.AddWithValue("@t58", false);
                            comm.Parameters.AddWithValue("@t59", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@t60", ta[2]);

                            comm.ExecuteNonQuery();

                            //11


                            comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t62,@t63,@t64,@t65,@t66)";
                            comm.Parameters.AddWithValue("@t62", pieza[10]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t63", 0);
                            comm.Parameters.AddWithValue("@t64", false);
                            comm.Parameters.AddWithValue("@t65", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@t66", ta[0]);

                            comm.ExecuteNonQuery();

                            //12


                            comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t68,@t69,@t70,@t71,@t72)";
                            comm.Parameters.AddWithValue("@t68", pieza[11]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t69", 0);
                            comm.Parameters.AddWithValue("@t70", false);
                            comm.Parameters.AddWithValue("@t71", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@t72", ta[3]);

                            comm.ExecuteNonQuery();

                            //13


                            comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t74,@t75,@t76,@t77,@t78)";
                            comm.Parameters.AddWithValue("@t74", pieza[12]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t75", 0);
                            comm.Parameters.AddWithValue("@t76", false);
                            comm.Parameters.AddWithValue("@t77", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@t78", ta[3]);

                            comm.ExecuteNonQuery();

                            //14


                            comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t80,@t81,@t82,@t83,@t84)";
                            comm.Parameters.AddWithValue("@t80", pieza[13]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t81", 0);
                            comm.Parameters.AddWithValue("@t82", false);
                            comm.Parameters.AddWithValue("@t83", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@t84", ta[5]);

                            comm.ExecuteNonQuery();

                            //15


                            comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t86,@t87,@t88,@t89,@t90)";
                            comm.Parameters.AddWithValue("@t86", pieza[14]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t87", 0);
                            comm.Parameters.AddWithValue("@t88", false);
                            comm.Parameters.AddWithValue("@t89", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@t90", ta[0]);

                            comm.ExecuteNonQuery();

                            //16


                            comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t92,@t93,@t94,@t95,@t96)";
                            comm.Parameters.AddWithValue("@t92", pieza[15]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t93", 0);
                            comm.Parameters.AddWithValue("@t94", false);
                            comm.Parameters.AddWithValue("@t95", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@t96", ta[6]);

                            comm.ExecuteNonQuery();

                            //17


                            comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t98,@t99,@t100,@t101,@t102)";
                            comm.Parameters.AddWithValue("@t98", pieza[16]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t99", 0);
                            comm.Parameters.AddWithValue("@t100", false);
                            comm.Parameters.AddWithValue("@t101", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@t102", ta[0]);

                            comm.ExecuteNonQuery();

                            //18


                            comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t104,@t105,@t106,@t107,@t108)";
                            comm.Parameters.AddWithValue("@t104", pieza[17]); // cambiar parametro
                            comm.Parameters.AddWithValue("@t105", 0);
                            comm.Parameters.AddWithValue("@t106", false);
                            comm.Parameters.AddWithValue("@t107", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@t108", ta[4]);

                            comm.ExecuteNonQuery();


                            comm.Parameters.AddWithValue("@p7", txtCodigo.Text);
                        }
                        else
                        {
                            comm.Parameters.AddWithValue("@p7", txtCodigo.Text);
                        }

                        //////////////////// retencion ///////////////////

                        if (retencion == 0)
                        {
                            comm.CommandText = "INSERT INTO ensayo_retencion(id_retencion,tiem_retencion,tiem_inercia,cumple_inercia,cumple_retencion,cumple_reten,fecha_ret,hora_inicio_ret,hora_termino_ret) VALUES(@ret1,@ret2, @ret3, @ret4, @ret5, @ret6, @ret7,@ret8,@ret9)";
                           
                            comm.Parameters.AddWithValue("@ret1", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@ret2", 0);
                            comm.Parameters.AddWithValue("@ret3", 0);
                            comm.Parameters.AddWithValue("@ret4", 0);//valor que debe cambiarse (generar funcion para ver si la prueba aprobo o no)
                            comm.Parameters.AddWithValue("@ret5", 0);//valor que debe cambiarse (generar funcion para ver si la prueba aprobo o no)
                            comm.Parameters.AddWithValue("@ret6", 0);//valor que debe cambiarse (generar funcion para ver si la prueba aprobo o no)
                            comm.Parameters.AddWithValue("@ret7", DateTime.Now);

                            comm.Parameters.AddWithValue("@ret8", inicio);//valor que debe ser cambiado (cuando se abra la ventana se debe recien tener una variable que indique la toma de hora)
                            comm.Parameters.AddWithValue("@ret9", DateTime.Now);

                            comm.ExecuteNonQuery();


                            comm.Parameters.AddWithValue("@p8", txtCodigo.Text);
                        }
                        else
                        {
                            comm.Parameters.AddWithValue("@p8", txtCodigo.Text);
                        }

                        //////////////////// basculamiento ///////////////////

                        if (bascu == 0)
                        {
                            comm.CommandText = "INSERT INTO ENSAYO_BASCUL (id_basc,cumple_basc,fecha_bas,hora_inicio_b,hora_termino_b) VALUES(@bas1,@bas2, @bas3, @bas4, @bas5)";
                            string tiem_inicio = DateTime.Now.ToString("HH:mm:ss");
                            string tiempoBascul = DateTime.Now.ToString("HH:mm:ss");


                            comm.Parameters.AddWithValue("@bas1", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@bas2", false);
                            comm.Parameters.AddWithValue("@bas3", DateTime.Now);
                            comm.Parameters.AddWithValue("@bas4", tiem_inicio);//valor que debe ser cambiado (cuando se abra la ventana se debe recien tener una variable que indique la toma de hora)
                            comm.Parameters.AddWithValue("@bas5", tiempoBascul);

                            comm.ExecuteNonQuery();

                            comm.Parameters.AddWithValue("@p9", txtCodigo.Text);
                        }
                        else
                        {
                            comm.Parameters.AddWithValue("@p9", txtCodigo.Text);
                        }

                        //////////////////// resistencia ///////////////////

                        if (resist == 0)
                        {
                            comm.CommandText = "INSERT INTO ensayo_resist(id_resist,resist_puerta,cumple_resis,fecha_resis,hora_inicio_res,hora_termino_res) VALUES(@resis1, @resis2, @resis3,@resis4,@resis5,@resis6)";

                            comm.Parameters.AddWithValue("@resis1", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@resis2", 0);

                            comm.Parameters.AddWithValue("@resis3", false); //valor que debe cambiarse (generar funcion para ver si la prueba aprobo o no)
                            comm.Parameters.AddWithValue("@resis4", DateTime.Now);
                            comm.Parameters.AddWithValue("@resis5", DateTime.Now.ToString("HH:mm:ss"));//valor que debe ser cambiado (cuando se abra la ventana se debe recien tener una variable que indique la toma de hora)
                            comm.Parameters.AddWithValue("@resis6", DateTime.Now.ToString("HH:mm:ss"));

                            comm.ExecuteNonQuery();

                            comm.Parameters.AddWithValue("@p10", txtCodigo.Text);
                        }
                        else
                        {
                            comm.Parameters.AddWithValue("@p10", txtCodigo.Text);
                        }

                        //////////////////// trabamiento ///////////////////

                        if (traba == 0)
                        {
                            comm.CommandText = "INSERT INTO ensayo_trabam(id_trab,cumple_trab,fecha_trab,hora_inicio_tr,hora_termino_tr) VALUES(@trab1,@trab2, @trab3, @trab4, @trab5)";

                            comm.Parameters.AddWithValue("@trab1", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@trab2", false); //valor que debe cambiarse (generar funcion para ver si la prueba aprobo o no)
                            comm.Parameters.AddWithValue("@trab3", DateTime.Now);
                            comm.Parameters.AddWithValue("@trab4", DateTime.Now.ToString("HH:mm:ss"));//valor que debe ser cambiado (cuando se abra la ventana se debe recien tener una variable que indique la toma de hora)
                            comm.Parameters.AddWithValue("@trab5", DateTime.Now.ToString("HH:mm:ss"));

                            comm.ExecuteNonQuery();

                            comm.Parameters.AddWithValue("@p11", txtCodigo.Text);

                        }
                        else
                        {
                            comm.Parameters.AddWithValue("@p11", txtCodigo.Text);
                        }

                        //////////////////// nivelacion ///////////////////

                        if (nivelacion == 0)
                        {
                            comm.CommandText = "INSERT INTO ensayo_nivelac(id_nivelac,niv_puerta_sp,niv_puerta_cp,cumple_nivelam,fecha_nivelac,hora_inicio_n,hora_termino_n) VALUES(@niv7,@niv1, @niv2, @niv3, @niv4, @niv5, @niv6)";

                            comm.Parameters.AddWithValue("@niv7", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@niv1", 0); //valor que debe cambiarse por un dato que sea autoincrementable
                            comm.Parameters.AddWithValue("@niv2", 0);
                            comm.Parameters.AddWithValue("@niv3", 0);
                            comm.Parameters.AddWithValue("@niv4", DateTime.Now); //valor que debe cambiarse (generar funcion para ver si la prueba aprobo o no)
                            comm.Parameters.AddWithValue("@niv5", DateTime.Now.ToString("HH:mm:ss"));
                            comm.Parameters.AddWithValue("@niv6", DateTime.Now.ToString("HH:mm:ss"));

                            comm.ExecuteNonQuery();

                            comm.Parameters.AddWithValue("@p12", txtCodigo.Text);
                        }
                        else
                        {
                            comm.Parameters.AddWithValue("@p12", txtCodigo.Text);
                        }

                        // ver el id de condicion tambien
                        int testeo;
                        string A = "select id_condicion from CONDICION_ENSAYO where cod_cocina = '" + codigo1 + "''" + codigo2 + "'";
                        SqlCommand cmd = new SqlCommand(A, conn);

                        testeo = (int)cmd.ExecuteScalar();
                        comm.Parameters.AddWithValue("@p13", testeo);

                        //////////////////// fuga ///////////////////

                        if (fuga == 0)
                        {
                            comm.CommandText = "INSERT INTO ensayo_fuga_g(id_fuga,est_conj_gas,est_indiv_gas,conexion,cumple_fuga_g,fecha_fug,hora_inicio_f,hora_termino_f) VALUES(@fug1,@fug2, @fug3, @fug4, @fug5, @fug6,@fug7,@fug8)";

                            comm.Parameters.AddWithValue("@fug1", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@fug2", 0);
                            comm.Parameters.AddWithValue("@fug3", 0);
                            comm.Parameters.AddWithValue("@fug4", 0);

                            comm.Parameters.AddWithValue("@fug5", 0);
                            comm.Parameters.AddWithValue("@fug6", DateTime.Now); //valor que debe cambiarse (generar funcion para ver si la prueba aprobo o no)
                            comm.Parameters.AddWithValue("@fug7", DateTime.Now.ToString("HH:mm:ss"));
                            comm.Parameters.AddWithValue("@fug8", DateTime.Now.ToString("HH:mm:ss"));

                            comm.ExecuteNonQuery();

                            comm.Parameters.AddWithValue("@p14", txtCodigo.Text);
                        }
                        else
                        {
                            comm.Parameters.AddWithValue("@p14", txtCodigo.Text);
                        }

                        //////////////////// planilla ///////////////////

                        if (planilla == 0)
                        {
                            comm.CommandText = "INSERT INTO informe_prueba(n_planilla,fecha_docum,observacion,nota,foto_1,foto_2,foto_3,rut_usuario) VALUES(@i1,@i2,@i3,@i4,@i5,@i6,@i7,@i8)";

                            comm.Parameters.AddWithValue("@i1", txtCodigo.Text); //valor que debe cambiarse por un dato que sea autoincrementable
                            comm.Parameters.AddWithValue("@i2", DateTime.Now);
                            comm.Parameters.AddWithValue("@i3", "N/A");
                            comm.Parameters.AddWithValue("@i4", "N/A");
                            comm.Parameters.AddWithValue("@i5", System.Data.SqlDbType.Image);
                            comm.Parameters.AddWithValue("@i6", System.Data.SqlDbType.Image);
                            comm.Parameters.AddWithValue("@i7", System.Data.SqlDbType.Image);
                            comm.Parameters.AddWithValue("@i8", txtrut.Text);

                            System.IO.MemoryStream ms = new System.IO.MemoryStream();
                            System.IO.MemoryStream mt = new System.IO.MemoryStream();
                            System.IO.MemoryStream mu = new System.IO.MemoryStream();


                            pictureBox2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            pictureBox2.Image.Save(mt, System.Drawing.Imaging.ImageFormat.Jpeg);
                            pictureBox2.Image.Save(mu, System.Drawing.Imaging.ImageFormat.Jpeg);

                            comm.Parameters["@i5"].Value = ms.GetBuffer();
                            comm.Parameters["@i6"].Value = mt.GetBuffer();
                            comm.Parameters["@i7"].Value = mu.GetBuffer();

                            comm.ExecuteNonQuery();

                            comm.Parameters.AddWithValue("@p15", txtCodigo.Text);
                        }
                        else
                        {
                            comm.Parameters.AddWithValue("@p15", txtCodigo.Text);
                        }

                        //////////////////// llama ///////////////////

                        if (llama == 0)
                        {
                            comm.CommandText = "INSERT INTO ensayo_c_llama(id_c_llama,disp_c_llama_f,disp_c_llama_c,encend_interc,cumple_control_llama,fecha_disp_llama,hora_inicio_dcl,hora_termino_dcl) VALUES(@llama1,@llama2, @llama3, @llama4, @llama5, @llama6, @llama7,@llama8)";


                            comm.Parameters.AddWithValue("@llama1", txtCodigo.Text);
                            comm.Parameters.AddWithValue("@llama2", 0);
                            comm.Parameters.AddWithValue("@llama3", 0);
                            comm.Parameters.AddWithValue("@llama4", 0);
                            comm.Parameters.AddWithValue("@llama5", 0);
                            comm.Parameters.AddWithValue("@llama6", DateTime.Now);
                            comm.Parameters.AddWithValue("@llama7", inicio);
                            comm.Parameters.AddWithValue("@llama8", DateTime.Now.ToString("HH:mm:ss"));


                            comm.Parameters.AddWithValue("@p16", txtCodigo.Text);
                        }
                        else
                        {
                            comm.Parameters.AddWithValue("@p16", txtCodigo.Text);
                        }

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
                        FormInformePDF.opcion = 1;


                        FormInformePDF informe = new FormInformePDF();

                        informe.Show();

                        this.Close();
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Datos ingresados ya existentes, ¿ desea actualizarlos ?", "Datos existentes", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            try
                            {
                                SqlCommand comm = conn.CreateCommand();

                                string a = DateTime.Now.ToString("HH:mm:ss");
                                string b = DateTime.Now.ToString("dd/MM/yyyy");

                                string codigo1 = txtCodigo.Text.Substring(0, txtCodigo.Text.IndexOf("'"));
                                string codigo2 = txtCodigo.Text.Substring(txtCodigo.Text.IndexOf("'") + 1);

                                comm.CommandText = "update u set u.fec_pruebas = @p1,u.hora_inicio_p = @p2,u.hora_termino_p = @p3,u.tiem_prueba = @p4,u.id_combu = @p5 ,u.id_electr= @p6,u.id_termo= @p7,u.id_retencion= @p8,u.id_basc= @p9,u.id_resist= @p10,u.id_trab= @p11,u.id_nivelac= @p12,u.id_condicion= @p13,u.id_fuga= @p14,u.n_planilla= @p15,u.id_c_llama= @p16 from prueba u inner join CONDICION_ENSAYO a on u.id_condicion = a.id_condicion where a.cod_cocina = @p666";
                                comm.Parameters.AddWithValue("@p666", txtCodigo.Text);
                                comm.Parameters.AddWithValue("@p1", DateTime.Now);
                                comm.Parameters.AddWithValue("@p2", inicio);
                                comm.Parameters.AddWithValue("@p3", DateTime.Now.ToString("HH:mm:ss"));

                                stopwatch.Stop();

                                comm.Parameters.AddWithValue("@p4", stopwatch.Elapsed); // ver esto


                                string B = "select count(*) from ENSAYO_COMB where id_combu = '" + codigo1 + "''" + codigo2 + "'";
                                string C = "select count(*) from ENSAYO_ELECTR where id_electr = '" + codigo1 + "''" + codigo2 + "'";
                                string D = "select count(*) from ENSAYO_TERMOCUP where id_termo = '" + codigo1 + "''" + codigo2 + "'";
                                string E = "select count(*) from ENSAYO_RETENCION where id_retencion = '" + codigo1 + "''" + codigo2 + "'";
                                string F = "select count(*) from ENSAYO_BASCUL where id_basc = '" + codigo1 + "''" + codigo2 + "'";
                                string G = "select count(*) from ENSAYO_RESIST where id_resist = '" + codigo1 + "''" + codigo2 + "'";
                                string H = "select count(*) from ENSAYO_TRABAM where id_trab = '" + codigo1 + "''" + codigo2 + "'";
                                string I = "select count(*) from ENSAYO_NIVELAC where id_nivelac = '" + codigo1 + "''" + codigo2 + "'";
                                string J = "select count(*) from ENSAYO_FUGA_G where id_fuga = '" + codigo1 + "''" + codigo2 + "'";
                                string K = "select count(*) from INFORME_PRUEBA where n_planilla = '" + codigo1 + "''" + codigo2 + "'";
                                string L = "select count(*) from ENSAYO_C_LLAMA where id_c_llama = '" + codigo1 + "''" + codigo2 + "'";

                                SqlCommand cmd2 = new SqlCommand(B, conn);
                                SqlCommand cmd3 = new SqlCommand(C, conn);
                                SqlCommand cmd4 = new SqlCommand(D, conn);
                                SqlCommand cmd5 = new SqlCommand(E, conn);
                                SqlCommand cmd6 = new SqlCommand(F, conn);
                                SqlCommand cmd7 = new SqlCommand(G, conn);
                                SqlCommand cmd8 = new SqlCommand(H, conn);
                                SqlCommand cmd9 = new SqlCommand(I, conn);
                                SqlCommand cmd11 = new SqlCommand(J, conn);
                                SqlCommand cmd12 = new SqlCommand(K, conn);
                                SqlCommand cmd13 = new SqlCommand(L, conn);


                                int combu = (int)cmd2.ExecuteScalar();
                                int electro = (int)cmd3.ExecuteScalar();
                                int termo = (int)cmd4.ExecuteScalar();
                                int retencion = (int)cmd5.ExecuteScalar();
                                int bascu = (int)cmd6.ExecuteScalar();
                                int resist = (int)cmd7.ExecuteScalar();
                                int traba = (int)cmd8.ExecuteScalar();
                                int nivelacion = (int)cmd9.ExecuteScalar();
                                int fuga = (int)cmd11.ExecuteScalar();
                                int planilla = (int)cmd12.ExecuteScalar();
                                int llama = (int)cmd13.ExecuteScalar();


                                //////////////////// combustion ///////////////////
                                if (combu == 0)
                                {
                                    string aa = "Consumo Total";
                                    string bb = "Consumo medio (1/2)";

                                    string q = "Quemador";

                                    string[] quem = { q+" Trasero Derecho", q+" Trasero Izquierdo", q+" Delantero Izquierdo",
                                     q+" Delantero Derecho", q+" Central Delantero", q+" Central Trasero",
                                     q+" Central", "Horno", "Todos los "+q+"es" };



                                    comm.CommandText = "if not EXISTS (select * from ENSAYO_COMB where id_combu = @comb1) INSERT INTO ENSAYO_COMB (id_combu,cumple_comb,fecha_ec,hora_inicio_c,hora_termino_c) VALUES(@comb1,@comb2,@comb3,@comb4,@comb5) else update ENSAYO_COMB set id_combu = @comb1, cumple_comb = @comb2, fecha_ec = @comb3 , hora_inicio_c = @comb4 , hora_termino_c = @comb5 where id_combu = @comb1";

                                    comm.Parameters.AddWithValue("@comb1", txtCodigo.Text); //valor que debe cambiarse por un dato que sea autoincrementable
                                    bool asd = false;
                                    comm.Parameters.AddWithValue("@comb2", asd); // cambiar
                                    comm.Parameters.AddWithValue("@comb3", DateTime.Now/*.ToString("dd/MM/yyyy")*/);
                                    comm.Parameters.AddWithValue("@comb4", inicio);
                                    comm.Parameters.AddWithValue("@comb5", DateTime.Now.ToString("HH:mm:ss")/*.ToString("HH:mm:ss")*/);


                                    comm.ExecuteNonQuery();

                                    // 1


                                    comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c2 and nom_posicion = @c3 and id_combu = @c8) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c2,@c3,@c4,@c5,@c6,@c7,@c8) else update COMBU set nom_quemador = @c2, nom_posicion = @c3, co = @c4, co_2 = @c5, co_n = @c6, cumple_comb = @c7, id_combu = @c8 where nom_quemador = @c2 and nom_posicion = @c3 and id_combu = @c8";

                                    comm.Parameters.AddWithValue("@c2", quem[0]);
                                    comm.Parameters.AddWithValue("@c3", aa);
                                    comm.Parameters.AddWithValue("@c4", 0);
                                    comm.Parameters.AddWithValue("@c5", 0);
                                    comm.Parameters.AddWithValue("@c6", 0);
                                    comm.Parameters.AddWithValue("@c7", false);
                                    comm.Parameters.AddWithValue("@c8", txtCodigo.Text);

                                    comm.ExecuteNonQuery();


                                    //2
                                    comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c10 and nom_posicion = @c11 and id_combu = @c16) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c10,@c11,@c12,@c13,@c14,@c15,@c16) else update COMBU set nom_quemador = @c10, nom_posicion = @c11, co = @c12, co_2 = @c13, co_n = @c14, cumple_comb = @c15, id_combu = @c16 where nom_quemador = @c10 and nom_posicion = @c11 and id_combu = @c16";

                                    comm.Parameters.AddWithValue("@c10", quem[0]);
                                    comm.Parameters.AddWithValue("@c11", bb);
                                    comm.Parameters.AddWithValue("@c12", 0);
                                    comm.Parameters.AddWithValue("@c13", 0);
                                    comm.Parameters.AddWithValue("@c14", 0);
                                    comm.Parameters.AddWithValue("@c15", false);
                                    comm.Parameters.AddWithValue("@c16", txtCodigo.Text);

                                    comm.ExecuteNonQuery();

                                    //3

                                    comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c18 and nom_posicion = @c19 and id_combu = @c24) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c18,@c19,@c20,@c21,@c22,@c23,@c24) else update COMBU set nom_quemador = @c18, nom_posicion = @c19, co = @c20, co_2 = @c21, co_n = @c22, cumple_comb = @c23, id_combu = @c24 where nom_quemador = @c18 and nom_posicion = @c19 and id_combu = @c24";

                                    comm.Parameters.AddWithValue("@c18", quem[1]);
                                    comm.Parameters.AddWithValue("@c19", aa);
                                    comm.Parameters.AddWithValue("@c20", 0);
                                    comm.Parameters.AddWithValue("@c21", 0);
                                    comm.Parameters.AddWithValue("@c22", 0);
                                    comm.Parameters.AddWithValue("@c23", false);
                                    comm.Parameters.AddWithValue("@c24", txtCodigo.Text);

                                    comm.ExecuteNonQuery();


                                    //4


                                    comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c26 and nom_posicion = @c27 and id_combu = @c32) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c26,@c27,@c28,@c29,@c30,@c31,@c32) else update COMBU set nom_quemador = @c26, nom_posicion = @c27, co = @c28, co_2 = @c29, co_n = @c30, cumple_comb = @c31, id_combu = @c32 where nom_quemador = @c26 and nom_posicion = @c27 and id_combu = @c32";

                                    comm.Parameters.AddWithValue("@c26", quem[1]);
                                    comm.Parameters.AddWithValue("@c27", bb);
                                    comm.Parameters.AddWithValue("@c28", 0);
                                    comm.Parameters.AddWithValue("@c29", 0);
                                    comm.Parameters.AddWithValue("@c30", 0);
                                    comm.Parameters.AddWithValue("@c31", false);
                                    comm.Parameters.AddWithValue("@c32", txtCodigo.Text);

                                    comm.ExecuteNonQuery();


                                    //5


                                    comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c34 and nom_posicion = @c35 and id_combu = @c40) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c34,@c35,@c36,@c37,@c38,@c39,@c40) else update COMBU set nom_quemador = @c34, nom_posicion = @c35, co = @c36, co_2 = @c37, co_n = @c38, cumple_comb = @c39, id_combu = @c40 where nom_quemador = @c34 and nom_posicion = @c35 and id_combu = @c40";

                                    comm.Parameters.AddWithValue("@c34", quem[2]);
                                    comm.Parameters.AddWithValue("@c35", aa);
                                    comm.Parameters.AddWithValue("@c36", 0);
                                    comm.Parameters.AddWithValue("@c37", 0);
                                    comm.Parameters.AddWithValue("@c38", 0);
                                    comm.Parameters.AddWithValue("@c39", false);
                                    comm.Parameters.AddWithValue("@c40", txtCodigo.Text);

                                    comm.ExecuteNonQuery();


                                    //6


                                    comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c42 and nom_posicion = @c43 and id_combu = @c48) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c42,@c43,@c44,@c45,@c46,@c47,@c48) else update COMBU set nom_quemador = @c42, nom_posicion = @c43, co = @c44, co_2 = @c45, co_n = @c46, cumple_comb = @c47, id_combu = @c48 where nom_quemador = @c42 and nom_posicion = @c43 and id_combu = @c48";

                                    comm.Parameters.AddWithValue("@c42", quem[2]);
                                    comm.Parameters.AddWithValue("@c43", bb);
                                    comm.Parameters.AddWithValue("@c44", 0);
                                    comm.Parameters.AddWithValue("@c45", 0);
                                    comm.Parameters.AddWithValue("@c46", 0);
                                    comm.Parameters.AddWithValue("@c47", false);
                                    comm.Parameters.AddWithValue("@c48", txtCodigo.Text);

                                    comm.ExecuteNonQuery();

                                    //7


                                    comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c50 and nom_posicion = @c51 and id_combu = @c56) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c50,@c51,@c52,@c53,@c54,@c55,@c56) else update COMBU set nom_quemador = @c50, nom_posicion = @c51, co = @c52, co_2 = @c53, co_n = @c54, cumple_comb = @c55, id_combu = @c56 where nom_quemador = @c50 and nom_posicion = @c51 and id_combu = @c56";

                                    comm.Parameters.AddWithValue("@c50", quem[3]);
                                    comm.Parameters.AddWithValue("@c51", aa);
                                    comm.Parameters.AddWithValue("@c52", 0);
                                    comm.Parameters.AddWithValue("@c53", 0);
                                    comm.Parameters.AddWithValue("@c54", 0);
                                    comm.Parameters.AddWithValue("@c55", false);
                                    comm.Parameters.AddWithValue("@c56", txtCodigo.Text);

                                    comm.ExecuteNonQuery();


                                    //8


                                    comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c58 and nom_posicion = @c59 and id_combu = @c64) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c58,@c59,@c60,@c61,@c62,@c63,@c64) else update COMBU set nom_quemador = @c58, nom_posicion = @c59, co = @c60, co_2 = @c61, co_n = @c62, cumple_comb = @c63, id_combu = @c64 where nom_quemador = @c58 and nom_posicion = @c59 and id_combu = @c64";

                                    comm.Parameters.AddWithValue("@c58", quem[3]);
                                    comm.Parameters.AddWithValue("@c59", bb);
                                    comm.Parameters.AddWithValue("@c60", 0);
                                    comm.Parameters.AddWithValue("@c61", 0);
                                    comm.Parameters.AddWithValue("@c62", 0);
                                    comm.Parameters.AddWithValue("@c63", false);
                                    comm.Parameters.AddWithValue("@c64", txtCodigo.Text);

                                    comm.ExecuteNonQuery();

                                    //9


                                    comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c66 and nom_posicion = @c67 and id_combu = @c72) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c66,@c67,@c68,@c69,@c70,@c71,@c72) else update COMBU set nom_quemador = @c66, nom_posicion = @c67, co = @c68, co_2 = @c69, co_n = @c70, cumple_comb = @c71, id_combu = @c72 where nom_quemador = @c66 and nom_posicion = @c67 and id_combu = @c72";

                                    comm.Parameters.AddWithValue("@c66", quem[4]);
                                    comm.Parameters.AddWithValue("@c67", aa);
                                    comm.Parameters.AddWithValue("@c68", 0);
                                    comm.Parameters.AddWithValue("@c69", 0);
                                    comm.Parameters.AddWithValue("@c70", 0);
                                    comm.Parameters.AddWithValue("@c71", false);
                                    comm.Parameters.AddWithValue("@c72", txtCodigo.Text);

                                    comm.ExecuteNonQuery();

                                    //10/////////


                                    comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c74 and nom_posicion = @c75 and id_combu = @c80) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c74,@c75,@c76,@c77,@c78,@c79,@c80) else update COMBU set nom_quemador = @c74, nom_posicion = @c75, co = @c76, co_2 = @c77, co_n = @c78, cumple_comb = @c79, id_combu = @c80 where nom_quemador = @c74 and nom_posicion = @c75 and id_combu = @c80";

                                    comm.Parameters.AddWithValue("@c74", quem[4]);
                                    comm.Parameters.AddWithValue("@c75", bb);
                                    comm.Parameters.AddWithValue("@c76", 0);
                                    comm.Parameters.AddWithValue("@c77", 0);
                                    comm.Parameters.AddWithValue("@c78", 0);
                                    comm.Parameters.AddWithValue("@c79", false);
                                    comm.Parameters.AddWithValue("@c80", txtCodigo.Text);

                                    comm.ExecuteNonQuery();


                                    //11


                                    comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c82 and nom_posicion = @c83 and id_combu = @c88) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c82,@c83,@c84,@c85,@c86,@c87,@c88) else update COMBU set nom_quemador = @c82, nom_posicion = @c83, co = @c84, co_2 = @c85, co_n = @c86, cumple_comb = @c87, id_combu = @c88 where nom_quemador = @c82 and nom_posicion = @c83 and id_combu = @c88";

                                    comm.Parameters.AddWithValue("@c82", quem[5]);
                                    comm.Parameters.AddWithValue("@c83", aa);
                                    comm.Parameters.AddWithValue("@c84", 0);
                                    comm.Parameters.AddWithValue("@c85", 0);
                                    comm.Parameters.AddWithValue("@c86", 0);
                                    comm.Parameters.AddWithValue("@c87", false);
                                    comm.Parameters.AddWithValue("@c88", txtCodigo.Text);

                                    comm.ExecuteNonQuery();

                                    //12


                                    comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c90 and nom_posicion = @c91 and id_combu = @c96) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c90,@c91,@c92,@c93,@c94,@c95,@c96) else update COMBU set nom_quemador = @c90, nom_posicion = @c91, co = @c92, co_2 = @c93, co_n = @c94, cumple_comb = @c95, id_combu = @c96 where nom_quemador = @c90 and nom_posicion = @c91 and id_combu = @c96";

                                    comm.Parameters.AddWithValue("@c90", quem[5]);
                                    comm.Parameters.AddWithValue("@c91", bb);
                                    comm.Parameters.AddWithValue("@c92", 0);
                                    comm.Parameters.AddWithValue("@c93", 0);
                                    comm.Parameters.AddWithValue("@c94", 0);
                                    comm.Parameters.AddWithValue("@c95", false);
                                    comm.Parameters.AddWithValue("@c96", txtCodigo.Text);

                                    comm.ExecuteNonQuery();
                                    //13


                                    comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c98 and nom_posicion = @c99 and id_combu = @c104) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c98,@c99,@c100,@c101,@c102,@c103,@c104) else update COMBU set nom_quemador = @c98, nom_posicion = @c99, co = @c100, co_2 = @c101, co_n = @c102, cumple_comb = @c103, id_combu = @c104 where nom_quemador = @c98 and nom_posicion = @c99 and id_combu = @c104";

                                    comm.Parameters.AddWithValue("@c98", quem[6]);
                                    comm.Parameters.AddWithValue("@c99", aa);
                                    comm.Parameters.AddWithValue("@c100", 0);
                                    comm.Parameters.AddWithValue("@c101", 0);
                                    comm.Parameters.AddWithValue("@c102", 0);
                                    comm.Parameters.AddWithValue("@c103", false);
                                    comm.Parameters.AddWithValue("@c104", txtCodigo.Text);

                                    comm.ExecuteNonQuery();

                                    //14


                                    comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c106 and nom_posicion = @c107 and id_combu = @c112) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c106,@c107,@c108,@c109,@c110,@c111,@c112) else update COMBU set nom_quemador = @c106, nom_posicion = @c107, co = @c108, co_2 = @c109, co_n = @c110, cumple_comb = @c111, id_combu = @c112 where nom_quemador = @c106 and nom_posicion = @c107 and id_combu = @c112";

                                    comm.Parameters.AddWithValue("@c106", quem[6]);
                                    comm.Parameters.AddWithValue("@c107", bb);
                                    comm.Parameters.AddWithValue("@c108", 0);
                                    comm.Parameters.AddWithValue("@c109", 0);
                                    comm.Parameters.AddWithValue("@c110", 0);
                                    comm.Parameters.AddWithValue("@c111", false);
                                    comm.Parameters.AddWithValue("@c112", txtCodigo.Text);

                                    comm.ExecuteNonQuery();


                                    //15


                                    comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c114 and nom_posicion = @c115 and id_combu = @c120) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c114,@c115,@c116,@c117,@c118,@c119,@c120) else update COMBU set nom_quemador = @c114, nom_posicion = @c115, co = @c116, co_2 = @c117, co_n = @c118, cumple_comb = @c119, id_combu = @c120 where nom_quemador = @c114 and nom_posicion = @c115 and id_combu = @c120";

                                    comm.Parameters.AddWithValue("@c114", quem[7]);
                                    comm.Parameters.AddWithValue("@c115", aa);
                                    comm.Parameters.AddWithValue("@c116", 0);
                                    comm.Parameters.AddWithValue("@c117", 0);
                                    comm.Parameters.AddWithValue("@c118", 0);
                                    comm.Parameters.AddWithValue("@c119", false);
                                    comm.Parameters.AddWithValue("@c120", txtCodigo.Text);

                                    comm.ExecuteNonQuery();


                                    //16


                                    comm.CommandText = "if not EXISTS (select * from COMBU where nom_quemador = @c122 and nom_posicion = @c123 and id_combu = @c128) INSERT INTO COMBU(nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu) VALUES (@c122,@c123,@c124,@c125,@c126,@c127,@c128) else update COMBU set nom_quemador = @c122, nom_posicion = @c123, co = @c124, co_2 = @c125, co_n = @c126, cumple_comb = @c127, id_combu = @c128 where nom_quemador = @c122 and nom_posicion = @c123 and id_combu = @c128";

                                    comm.Parameters.AddWithValue("@c122", quem[7]);
                                    comm.Parameters.AddWithValue("@c123", bb);
                                    comm.Parameters.AddWithValue("@c124", 0);
                                    comm.Parameters.AddWithValue("@c125", 0);
                                    comm.Parameters.AddWithValue("@c126", 0);
                                    comm.Parameters.AddWithValue("@c127", false);
                                    comm.Parameters.AddWithValue("@c128", txtCodigo.Text);

                                    comm.ExecuteNonQuery();

                                    comm.Parameters.AddWithValue("@p5", txtCodigo.Text);
                                }
                                else
                                {
                                    comm.Parameters.AddWithValue("@p5", txtCodigo.Text);
                                }
                                //////////////////// electrico ///////////////////

                                if (electro == 0)
                                {


                                    comm.CommandText = "INSERT INTO ensayo_electr(id_electr,marc_instrucc,pr_part_activa,potencia,corriente,continuidad,aislamiento,rig_dielect,cumple_v_numeric,cumple_electr,fecha_electr,hora_inicio_e,hora_termino_e) VALUES(@elec1, @elec2, @elec3, @elec4, @elec5, @elec6, @elec7, @elec8, @elec9,@elec10,@elec11,@elec12,@elec13)";

                                    comm.Parameters.AddWithValue("@elec1", txtCodigo.Text); //valor que debe cambiarse por un dato que sea autoincrementable
                                    comm.Parameters.AddWithValue("@elec2", false);
                                    comm.Parameters.AddWithValue("@elec3", false);
                                    comm.Parameters.AddWithValue("@elec4", 0);
                                    comm.Parameters.AddWithValue("@elec5", 0);
                                    comm.Parameters.AddWithValue("@elec6", 0);
                                    comm.Parameters.AddWithValue("@elec7", 0);
                                    comm.Parameters.AddWithValue("@elec8", 0);
                                    comm.Parameters.AddWithValue("@elec9", false);
                                    comm.Parameters.AddWithValue("@elec10", false);
                                    comm.Parameters.AddWithValue("@elec11", DateTime.Now);
                                    comm.Parameters.AddWithValue("@elec12", inicio);
                                    comm.Parameters.AddWithValue("@elec13", DateTime.Now.ToString("HH:mm:ss"));

                                    comm.ExecuteNonQuery();

                                    comm.Parameters.AddWithValue("@p6", txtCodigo.Text);


                                }
                                else
                                {
                                    comm.Parameters.AddWithValue("@p6", txtCodigo.Text);
                                }

                                //////////////////// termo ///////////////////

                                if (termo == 0)
                                {
                                    string p = "Perrilla ";

                                    string[] pieza = { p+"QTD", p+"QDD", p+"QTI", p+"QDI", p+"Horno", p+"QC", p+"QCD", p+"QCT"
                                      , "Tirador puerta", "Conexión boquilla","Frente llaves","Piso panel"
                                      , "Panel lateral", "Panel posterior","Costado libre","Centro horno"
                                      , "Puerta vidrio", "Paredes flexibles"};


                                    string aaa = "Ta+";
                                    string bbb = "C°";

                                    //8

                                    string[] ta = { aaa + "60" + bbb, aaa + "45" + bbb, aaa + "30" + bbb, aaa + "80" + bbb, aaa + "70" + bbb, aaa + "100" + bbb, "T° 200" + bbb + "+4/-0" };


                                    comm.CommandText = "INSERT INTO ensayo_termocup(id_termo,cumple_termo,fecha_termo,hora_inicio_t,hora_termino_t) VALUES(@termo1, @termo2, @termo3,@termo4,@termo5)";
                                    comm.Parameters.AddWithValue("@termo1", txtCodigo.Text); //cambiar parametro
                                    comm.Parameters.AddWithValue("@termo2", false); // cambiar parametro
                                    comm.Parameters.AddWithValue("@termo3", DateTime.Now/*.ToString("dd/MM/yyyy")*/);
                                    comm.Parameters.AddWithValue("@termo4", inicio);
                                    comm.Parameters.AddWithValue("@termo5", DateTime.Now.ToString("HH:mm:ss")/*.ToString("HH:mm:ss")*/);

                                    comm.ExecuteNonQuery();

                                    //1

                                    comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t2,@t3,@t4,@t5,@t6)";
                                    comm.Parameters.AddWithValue("@t2", pieza[0]); // cambiar parametro
                                    comm.Parameters.AddWithValue("@t3", 0);
                                    comm.Parameters.AddWithValue("@t4", false);
                                    comm.Parameters.AddWithValue("@t5", txtCodigo.Text);
                                    comm.Parameters.AddWithValue("@t6", ta[0]);

                                    comm.ExecuteNonQuery();

                                    //2


                                    comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t8,@t9,@t10,@t11,@t12)";
                                    comm.Parameters.AddWithValue("@t8", pieza[1]); // cambiar parametro
                                    comm.Parameters.AddWithValue("@t9", 0);
                                    comm.Parameters.AddWithValue("@t10", false);
                                    comm.Parameters.AddWithValue("@t11", txtCodigo.Text);
                                    comm.Parameters.AddWithValue("@t12", ta[0]);

                                    comm.ExecuteNonQuery();

                                    //3


                                    comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t14,@t15,@t16,@t17,@t18)";
                                    comm.Parameters.AddWithValue("@t14", pieza[2]); // cambiar parametro
                                    comm.Parameters.AddWithValue("@t15", 0);
                                    comm.Parameters.AddWithValue("@t16", false);
                                    comm.Parameters.AddWithValue("@t17", txtCodigo.Text);
                                    comm.Parameters.AddWithValue("@t18", ta[0]);

                                    comm.ExecuteNonQuery();

                                    //4


                                    comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t20,@t21,@t22,@t23,@t24)";
                                    comm.Parameters.AddWithValue("@t20", pieza[3]); // cambiar parametro
                                    comm.Parameters.AddWithValue("@t21", 0);
                                    comm.Parameters.AddWithValue("@t22", false);
                                    comm.Parameters.AddWithValue("@t23", txtCodigo.Text);
                                    comm.Parameters.AddWithValue("@t24", ta[0]);

                                    comm.ExecuteNonQuery();


                                    //5


                                    comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t26,@t27,@t28,@t29,@t30)";
                                    comm.Parameters.AddWithValue("@t26", pieza[4]); // cambiar parametro
                                    comm.Parameters.AddWithValue("@t27", 0);
                                    comm.Parameters.AddWithValue("@t28", false);
                                    comm.Parameters.AddWithValue("@t29", txtCodigo.Text);
                                    comm.Parameters.AddWithValue("@t30", ta[0]);

                                    comm.ExecuteNonQuery();

                                    //6


                                    comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t32,@t33,@t34,@t35,@t36)";
                                    comm.Parameters.AddWithValue("@t32", pieza[5]); // cambiar parametro
                                    comm.Parameters.AddWithValue("@t33", 0);
                                    comm.Parameters.AddWithValue("@t34", false);
                                    comm.Parameters.AddWithValue("@t35", txtCodigo.Text);
                                    comm.Parameters.AddWithValue("@t36", ta[0]);

                                    comm.ExecuteNonQuery();

                                    //7


                                    comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t38,@t39,@t40,@t41,@t42)";
                                    comm.Parameters.AddWithValue("@t38", pieza[6]); // cambiar parametro
                                    comm.Parameters.AddWithValue("@t39", 0);
                                    comm.Parameters.AddWithValue("@t40", false);
                                    comm.Parameters.AddWithValue("@t41", txtCodigo.Text);
                                    comm.Parameters.AddWithValue("@t42", ta[0]);

                                    comm.ExecuteNonQuery();

                                    //8


                                    comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t44,@t45,@t46,@t47,@t48)";
                                    comm.Parameters.AddWithValue("@t44", pieza[7]); // cambiar parametro
                                    comm.Parameters.AddWithValue("@t45", 0);
                                    comm.Parameters.AddWithValue("@t46", false);
                                    comm.Parameters.AddWithValue("@t47", txtCodigo.Text);
                                    comm.Parameters.AddWithValue("@t48", ta[0]);

                                    comm.ExecuteNonQuery();

                                    //9


                                    comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t50,@t51,@t52,@t53,@t54)";
                                    comm.Parameters.AddWithValue("@t50", pieza[8]); // cambiar parametro
                                    comm.Parameters.AddWithValue("@t51", 0);
                                    comm.Parameters.AddWithValue("@t52", false);
                                    comm.Parameters.AddWithValue("@t53", txtCodigo.Text);
                                    comm.Parameters.AddWithValue("@t54", ta[1]);

                                    comm.ExecuteNonQuery();

                                    //10


                                    comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t56,@t57,@t58,@t59,@t60)";
                                    comm.Parameters.AddWithValue("@t56", pieza[9]); // cambiar parametro
                                    comm.Parameters.AddWithValue("@t57", 0);
                                    comm.Parameters.AddWithValue("@t58", false);
                                    comm.Parameters.AddWithValue("@t59", txtCodigo.Text);
                                    comm.Parameters.AddWithValue("@t60", ta[2]);

                                    comm.ExecuteNonQuery();

                                    //11


                                    comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t62,@t63,@t64,@t65,@t66)";
                                    comm.Parameters.AddWithValue("@t62", pieza[10]); // cambiar parametro
                                    comm.Parameters.AddWithValue("@t63", 0);
                                    comm.Parameters.AddWithValue("@t64", false);
                                    comm.Parameters.AddWithValue("@t65", txtCodigo.Text);
                                    comm.Parameters.AddWithValue("@t66", ta[0]);

                                    comm.ExecuteNonQuery();

                                    //12


                                    comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t68,@t69,@t70,@t71,@t72)";
                                    comm.Parameters.AddWithValue("@t68", pieza[11]); // cambiar parametro
                                    comm.Parameters.AddWithValue("@t69", 0);
                                    comm.Parameters.AddWithValue("@t70", false);
                                    comm.Parameters.AddWithValue("@t71", txtCodigo.Text);
                                    comm.Parameters.AddWithValue("@t72", ta[3]);

                                    comm.ExecuteNonQuery();

                                    //13


                                    comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t74,@t75,@t76,@t77,@t78)";
                                    comm.Parameters.AddWithValue("@t74", pieza[12]); // cambiar parametro
                                    comm.Parameters.AddWithValue("@t75", 0);
                                    comm.Parameters.AddWithValue("@t76", false);
                                    comm.Parameters.AddWithValue("@t77", txtCodigo.Text);
                                    comm.Parameters.AddWithValue("@t78", ta[3]);

                                    comm.ExecuteNonQuery();

                                    //14


                                    comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t80,@t81,@t82,@t83,@t84)";
                                    comm.Parameters.AddWithValue("@t80", pieza[13]); // cambiar parametro
                                    comm.Parameters.AddWithValue("@t81", 0);
                                    comm.Parameters.AddWithValue("@t82", false);
                                    comm.Parameters.AddWithValue("@t83", txtCodigo.Text);
                                    comm.Parameters.AddWithValue("@t84", ta[5]);

                                    comm.ExecuteNonQuery();

                                    //15


                                    comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t86,@t87,@t88,@t89,@t90)";
                                    comm.Parameters.AddWithValue("@t86", pieza[14]); // cambiar parametro
                                    comm.Parameters.AddWithValue("@t87", 0);
                                    comm.Parameters.AddWithValue("@t88", false);
                                    comm.Parameters.AddWithValue("@t89", txtCodigo.Text);
                                    comm.Parameters.AddWithValue("@t90", ta[0]);

                                    comm.ExecuteNonQuery();

                                    //16


                                    comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t92,@t93,@t94,@t95,@t96)";
                                    comm.Parameters.AddWithValue("@t92", pieza[15]); // cambiar parametro
                                    comm.Parameters.AddWithValue("@t93", 0);
                                    comm.Parameters.AddWithValue("@t94", false);
                                    comm.Parameters.AddWithValue("@t95", txtCodigo.Text);
                                    comm.Parameters.AddWithValue("@t96", ta[6]);

                                    comm.ExecuteNonQuery();

                                    //17


                                    comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t98,@t99,@t100,@t101,@t102)";
                                    comm.Parameters.AddWithValue("@t98", pieza[16]); // cambiar parametro
                                    comm.Parameters.AddWithValue("@t99", 0);
                                    comm.Parameters.AddWithValue("@t100", false);
                                    comm.Parameters.AddWithValue("@t101", txtCodigo.Text);
                                    comm.Parameters.AddWithValue("@t102", ta[0]);

                                    comm.ExecuteNonQuery();

                                    //18


                                    comm.CommandText = "INSERT INTO termoc(descrip_pieza,temp_pieza,cumple_term,id_termo,temp_norma) VALUES(@t104,@t105,@t106,@t107,@t108)";
                                    comm.Parameters.AddWithValue("@t104", pieza[17]); // cambiar parametro
                                    comm.Parameters.AddWithValue("@t105", 0);
                                    comm.Parameters.AddWithValue("@t106", false);
                                    comm.Parameters.AddWithValue("@t107", txtCodigo.Text);
                                    comm.Parameters.AddWithValue("@t108", ta[4]);

                                    comm.ExecuteNonQuery();

                                    comm.Parameters.AddWithValue("@p7", txtCodigo.Text);
                                }
                                else
                                {
                                    comm.Parameters.AddWithValue("@p7", txtCodigo.Text);
                                }

                                //////////////////// retencion ///////////////////

                                if (retencion == 0)
                                {
                                    comm.CommandText = "INSERT INTO ensayo_retencion(id_retencion,tiem_retencion,tiem_inercia,cumple_inercia,cumple_retencion,cumple_reten,fecha_ret,hora_inicio_ret,hora_termino_ret) VALUES(@ret1,@ret2, @ret3, @ret4, @ret5, @ret6, @ret7,@ret8,@ret9)";

                                    comm.Parameters.AddWithValue("@ret1", txtCodigo.Text);
                                    comm.Parameters.AddWithValue("@ret2", 0);
                                    comm.Parameters.AddWithValue("@ret3", 0);
                                    comm.Parameters.AddWithValue("@ret4", 0);//valor que debe cambiarse (generar funcion para ver si la prueba aprobo o no)
                                    comm.Parameters.AddWithValue("@ret5", 0);//valor que debe cambiarse (generar funcion para ver si la prueba aprobo o no)
                                    comm.Parameters.AddWithValue("@ret6", 0);//valor que debe cambiarse (generar funcion para ver si la prueba aprobo o no)
                                    comm.Parameters.AddWithValue("@ret7", DateTime.Now);

                                    comm.Parameters.AddWithValue("@ret8", inicio);//valor que debe ser cambiado (cuando se abra la ventana se debe recien tener una variable que indique la toma de hora)
                                    comm.Parameters.AddWithValue("@ret9", DateTime.Now);

                                    comm.ExecuteNonQuery();


                                    comm.Parameters.AddWithValue("@p8", txtCodigo.Text);

                                }
                                else
                                {
                                    comm.Parameters.AddWithValue("@p8", txtCodigo.Text);
                                }

                                //////////////////// basculamiento ///////////////////

                                if (bascu == 0)
                                {
                                    comm.CommandText = "INSERT INTO ENSAYO_BASCUL (id_basc,cumple_basc,fecha_bas,hora_inicio_b,hora_termino_b) VALUES(@bas1,@bas2, @bas3, @bas4, @bas5)";
                                    string tiem_inicio = DateTime.Now.ToString("HH:mm:ss");
                                    string tiempoBascul = DateTime.Now.ToString("HH:mm:ss");


                                    comm.Parameters.AddWithValue("@bas1", txtCodigo.Text);
                                    comm.Parameters.AddWithValue("@bas2", false);
                                    comm.Parameters.AddWithValue("@bas3", DateTime.Now);
                                    comm.Parameters.AddWithValue("@bas4", tiem_inicio);//valor que debe ser cambiado (cuando se abra la ventana se debe recien tener una variable que indique la toma de hora)
                                    comm.Parameters.AddWithValue("@bas5", tiempoBascul);

                                    comm.ExecuteNonQuery();

                                    comm.Parameters.AddWithValue("@p9", txtCodigo.Text);
                                }
                                else
                                {
                                    comm.Parameters.AddWithValue("@p9", txtCodigo.Text);
                                }

                                //////////////////// resistencia ///////////////////

                                if (resist == 0)
                                {
                                    comm.CommandText = "INSERT INTO ensayo_resist(id_resist,resist_puerta,cumple_resis,fecha_resis,hora_inicio_res,hora_termino_res) VALUES(@resis1, @resis2, @resis3,@resis4,@resis5,@resis6)";

                                    comm.Parameters.AddWithValue("@resis1", txtCodigo.Text);
                                    comm.Parameters.AddWithValue("@resis2", 0);

                                    comm.Parameters.AddWithValue("@resis3", false); //valor que debe cambiarse (generar funcion para ver si la prueba aprobo o no)
                                    comm.Parameters.AddWithValue("@resis4", DateTime.Now);
                                    comm.Parameters.AddWithValue("@resis5", DateTime.Now.ToString("HH:mm:ss"));//valor que debe ser cambiado (cuando se abra la ventana se debe recien tener una variable que indique la toma de hora)
                                    comm.Parameters.AddWithValue("@resis6", DateTime.Now.ToString("HH:mm:ss"));

                                    comm.ExecuteNonQuery();

                                    comm.Parameters.AddWithValue("@p10", txtCodigo.Text);
                                }
                                else
                                {
                                    comm.Parameters.AddWithValue("@p10", txtCodigo.Text);
                                }

                                //////////////////// trabamiento ///////////////////

                                if (traba == 0)
                                {
                                    comm.CommandText = "INSERT INTO ensayo_trabam(id_trab,cumple_trab,fecha_trab,hora_inicio_tr,hora_termino_tr) VALUES(@trab1,@trab2, @trab3, @trab4, @trab5)";

                                    comm.Parameters.AddWithValue("@trab1", txtCodigo.Text);
                                    comm.Parameters.AddWithValue("@trab2", false); //valor que debe cambiarse (generar funcion para ver si la prueba aprobo o no)
                                    comm.Parameters.AddWithValue("@trab3", DateTime.Now);
                                    comm.Parameters.AddWithValue("@trab4", DateTime.Now.ToString("HH:mm:ss"));//valor que debe ser cambiado (cuando se abra la ventana se debe recien tener una variable que indique la toma de hora)
                                    comm.Parameters.AddWithValue("@trab5", DateTime.Now.ToString("HH:mm:ss"));

                                    comm.ExecuteNonQuery();

                                    comm.Parameters.AddWithValue("@p11", txtCodigo.Text);

                                }
                                else
                                {
                                    comm.Parameters.AddWithValue("@p11", txtCodigo.Text);
                                }

                                //////////////////// nivelacion ///////////////////

                                if (nivelacion == 0)
                                {
                                    comm.CommandText = "INSERT INTO ensayo_nivelac(id_nivelac,niv_puerta_sp,niv_puerta_cp,cumple_nivelam,fecha_nivelac,hora_inicio_n,hora_termino_n) VALUES(@niv7,@niv1, @niv2, @niv3, @niv4, @niv5, @niv6)";

                                    comm.Parameters.AddWithValue("@niv7", txtCodigo.Text);
                                    comm.Parameters.AddWithValue("@niv1", 0); //valor que debe cambiarse por un dato que sea autoincrementable
                                    comm.Parameters.AddWithValue("@niv2", 0);
                                    comm.Parameters.AddWithValue("@niv3", 0);
                                    comm.Parameters.AddWithValue("@niv4", DateTime.Now); //valor que debe cambiarse (generar funcion para ver si la prueba aprobo o no)
                                    comm.Parameters.AddWithValue("@niv5", DateTime.Now.ToString("HH:mm:ss"));
                                    comm.Parameters.AddWithValue("@niv6", DateTime.Now.ToString("HH:mm:ss"));

                                    comm.ExecuteNonQuery();

                                    comm.Parameters.AddWithValue("@p12", txtCodigo.Text);
                                }
                                else
                                {
                                    comm.Parameters.AddWithValue("@p12", txtCodigo.Text);
                                }

                                // ver el id de condicion tambien
                                int testeo;
                                string A = "select id_condicion from CONDICION_ENSAYO where cod_cocina = '" + codigo1 + "''" + codigo2 + "'";
                                SqlCommand cmd = new SqlCommand(A, conn);

                                testeo = (int)cmd.ExecuteScalar();
                                comm.Parameters.AddWithValue("@p13", testeo);

                                //////////////////// fuga ///////////////////

                                if (fuga == 0)
                                {
                                    comm.CommandText = "INSERT INTO ensayo_fuga_g(id_fuga,est_conj_gas,est_indiv_gas,conexion,cumple_fuga_g,fecha_fug,hora_inicio_f,hora_termino_f) VALUES(@fug1,@fug2, @fug3, @fug4, @fug5, @fug6,@fug7,@fug8)";

                                    comm.Parameters.AddWithValue("@fug1", txtCodigo.Text);
                                    comm.Parameters.AddWithValue("@fug2", 0);
                                    comm.Parameters.AddWithValue("@fug3", 0);
                                    comm.Parameters.AddWithValue("@fug4", 0);

                                    comm.Parameters.AddWithValue("@fug5", 0);
                                    comm.Parameters.AddWithValue("@fug6", DateTime.Now); //valor que debe cambiarse (generar funcion para ver si la prueba aprobo o no)
                                    comm.Parameters.AddWithValue("@fug7", DateTime.Now.ToString("HH:mm:ss"));
                                    comm.Parameters.AddWithValue("@fug8", DateTime.Now.ToString("HH:mm:ss"));

                                    comm.ExecuteNonQuery();

                                    comm.Parameters.AddWithValue("@p14", txtCodigo.Text);
                                }
                                else
                                {
                                    comm.Parameters.AddWithValue("@p14", txtCodigo.Text);
                                }

                                //////////////////// planilla ///////////////////

                                if (planilla == 0)
                                {
                                    comm.CommandText = "INSERT INTO informe_prueba(n_planilla,fecha_docum,observacion,nota,foto_1,foto_2,foto_3,rut_usuario) VALUES(@i1,@i2,@i3,@i4,@i5,@i6,@i7,@i8)";

                                    comm.Parameters.AddWithValue("@i1", txtCodigo.Text); //valor que debe cambiarse por un dato que sea autoincrementable
                                    comm.Parameters.AddWithValue("@i2", DateTime.Now);
                                    comm.Parameters.AddWithValue("@i3", "N/A");
                                    comm.Parameters.AddWithValue("@i4", "N/A");
                                    comm.Parameters.AddWithValue("@i5", System.Data.SqlDbType.Image);
                                    comm.Parameters.AddWithValue("@i6", System.Data.SqlDbType.Image);
                                    comm.Parameters.AddWithValue("@i7", System.Data.SqlDbType.Image);
                                    comm.Parameters.AddWithValue("@i8", txtrut.Text);

                                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                                    System.IO.MemoryStream mt = new System.IO.MemoryStream();
                                    System.IO.MemoryStream mu = new System.IO.MemoryStream();


                                    pictureBox2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    pictureBox2.Image.Save(mt, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    pictureBox2.Image.Save(mu, System.Drawing.Imaging.ImageFormat.Jpeg);

                                    comm.Parameters["@i5"].Value = ms.GetBuffer();
                                    comm.Parameters["@i6"].Value = mt.GetBuffer();
                                    comm.Parameters["@i7"].Value = mu.GetBuffer();

                                    comm.ExecuteNonQuery();

                                    comm.Parameters.AddWithValue("@p15", txtCodigo.Text);
                                }
                                else
                                {
                                    comm.Parameters.AddWithValue("@p15", txtCodigo.Text);
                                }

                                //////////////////// llama ///////////////////

                                if (llama == 0)
                                {
                                    comm.CommandText = "INSERT INTO ensayo_c_llama(id_c_llama,disp_c_llama_f,disp_c_llama_c,encend_interc,cumple_control_llama,fecha_disp_llama,hora_inicio_dcl,hora_termino_dcl) VALUES(@llama1,@llama2, @llama3, @llama4, @llama5, @llama6, @llama7,@llama8)";


                                    comm.Parameters.AddWithValue("@llama1", txtCodigo.Text);
                                    comm.Parameters.AddWithValue("@llama2", 0);
                                    comm.Parameters.AddWithValue("@llama3", 0);
                                    comm.Parameters.AddWithValue("@llama4", 0);
                                    comm.Parameters.AddWithValue("@llama5", 0);
                                    comm.Parameters.AddWithValue("@llama6", DateTime.Now);
                                    comm.Parameters.AddWithValue("@llama7", inicio);
                                    comm.Parameters.AddWithValue("@llama8", DateTime.Now.ToString("HH:mm:ss"));


                                    comm.Parameters.AddWithValue("@p16", txtCodigo.Text);
                                }
                                else
                                {
                                    comm.Parameters.AddWithValue("@p16", txtCodigo.Text);
                                }

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
                                FormInformePDF.opcion = 1;


                                FormInformePDF informe = new FormInformePDF();

                                informe.Show();

                                this.Close();

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "ERROR");

                            }
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

        private void btnCondiciones_Click_1(object sender, EventArgs e)
        {
            

            btnCondiciones.BackColor = Color.Green;
            btnManuales.BackColor = Color.FromArgb(33, 53, 73);
            btnNivelacion.BackColor = Color.FromArgb(33, 53, 73);
            btnFugaGas.BackColor = Color.FromArgb(33, 53, 73);
            btnCombustion.BackColor = Color.FromArgb(33, 53, 73);
            btnTermocupla.BackColor = Color.FromArgb(33, 53, 73);
            btnElectrico.BackColor = Color.FromArgb(33, 53, 73);
            btnObservacion.BackColor = Color.FromArgb(33, 53, 73);

            FormCondicionEnsayoIndi manual = new FormCondicionEnsayoIndi() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
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

        private void btnManuales_Click_1(object sender, EventArgs e)
        {
            //FormEnsayoManual manual = new FormEnsayoManual() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            //manual.FormBorderStyle = FormBorderStyle.None;
            //this.panelOpciones.Controls.Add(manual);

            btnCondiciones.BackColor = Color.FromArgb(33, 53, 73);
            btnManuales.BackColor = Color.Green;
            btnNivelacion.BackColor = Color.FromArgb(33, 53, 73);
            btnFugaGas.BackColor = Color.FromArgb(33, 53, 73);
            btnCombustion.BackColor = Color.FromArgb(33, 53, 73);
            btnTermocupla.BackColor = Color.FromArgb(33, 53, 73);
            btnElectrico.BackColor = Color.FromArgb(33, 53, 73);
            btnObservacion.BackColor = Color.FromArgb(33, 53, 73);

            FormEnsayoManualIndi manual = new FormEnsayoManualIndi() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            manual.FormBorderStyle = FormBorderStyle.None;
            this.panelOpciones.Controls.Add(manual);
            label1.Text = "Pruebas Manuales";
            FormEnsayoManualIndi.asd = txtCodigo.Text;

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

        private void btnNivelacion_Click_1(object sender, EventArgs e)
        {
            //FormEnsayoNivelacion nivelacion = new FormEnsayoNivelacion() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            //manual.FormBorderStyle = FormBorderStyle.None;
            //this.panelOpciones.Controls.Add(manual);

            btnCondiciones.BackColor = Color.FromArgb(33, 53, 73);
            btnManuales.BackColor = Color.FromArgb(33, 53, 73);
            btnNivelacion.BackColor = Color.Green;
            btnFugaGas.BackColor = Color.FromArgb(33, 53, 73);
            btnCombustion.BackColor = Color.FromArgb(33, 53, 73);
            btnTermocupla.BackColor = Color.FromArgb(33, 53, 73);
            btnElectrico.BackColor = Color.FromArgb(33, 53, 73);
            btnObservacion.BackColor = Color.FromArgb(33, 53, 73);




            FormEnsayoNivelacionIndi nivelacion = new FormEnsayoNivelacionIndi() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            nivelacion.TopLevel = false;
            nivelacion.AutoScroll = true;
            this.panelOpciones.Controls.Add(nivelacion);

            label1.Text = "Ensayo Nivelación";
            //AbrirFormHija(new FormEnsayoNivelacion());

            FormEnsayoNivelacionIndi.asd2 = txtCodigo.Text;

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
            con.Close();

        }

        private void btnFugaGas_Click_1(object sender, EventArgs e)
        {
            //FormEnsayoFugaGas fugagas = new FormEnsayoFugaGas() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            //manual.FormBorderStyle = FormBorderStyle.None;
            //this.panelOpciones.Controls.Add(manual);

            btnCondiciones.BackColor = Color.FromArgb(33, 53, 73);
            btnManuales.BackColor = Color.FromArgb(33, 53, 73);
            btnNivelacion.BackColor = Color.FromArgb(33, 53, 73);
            btnFugaGas.BackColor = Color.Green;
            btnCombustion.BackColor = Color.FromArgb(33, 53, 73);
            btnTermocupla.BackColor = Color.FromArgb(33, 53, 73);
            btnElectrico.BackColor = Color.FromArgb(33, 53, 73);
            btnObservacion.BackColor = Color.FromArgb(33, 53, 73);


            FormEnsayoFugaGasIndi fugagas = new FormEnsayoFugaGasIndi() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            fugagas.TopLevel = false;
            fugagas.AutoScroll = true;
            this.panelOpciones.Controls.Add(fugagas);

            label1.Text = "Ensayo Fuga de Gas";

            FormEnsayoFugaGasIndi.asd3 = txtCodigo.Text;

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

        private void btnCombustion_Click_1(object sender, EventArgs e)
        {
            //FormEnsayoCombustion combustion = new FormEnsayoCombustion() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            //manual.FormBorderStyle = FormBorderStyle.None;
            //this.panelOpciones.Controls.Add(manual);

            btnCondiciones.BackColor = Color.FromArgb(33, 53, 73);
            btnManuales.BackColor = Color.FromArgb(33, 53, 73);
            btnNivelacion.BackColor = Color.FromArgb(33, 53, 73);
            btnFugaGas.BackColor = Color.FromArgb(33, 53, 73);
            btnCombustion.BackColor = Color.Green;
            btnTermocupla.BackColor = Color.FromArgb(33, 53, 73);
            btnElectrico.BackColor = Color.FromArgb(33, 53, 73);
            btnObservacion.BackColor = Color.FromArgb(33, 53, 73);


            FormEnsayoCombustionIndi combustion = new FormEnsayoCombustionIndi() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            combustion.TopLevel = false;
            combustion.AutoScroll = true;
            this.panelOpciones.Controls.Add(combustion);

            label1.Text = "Ensayo Combustion";
            //AbrirFormHija(new FormEnsayoFugaGas());

            FormEnsayoCombustionIndi.asd4 = txtCodigo.Text;

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
            catch (Exception)
            {

            }
        }

        private void btnTermocupla_Click_1(object sender, EventArgs e)
        {
            //FormEnsayoTermocupla termocupla = new FormEnsayoTermocupla() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            //manual.FormBorderStyle = FormBorderStyle.None;
            //this.panelOpciones.Controls.Add(manual);

            btnCondiciones.BackColor = Color.FromArgb(33, 53, 73);
            btnManuales.BackColor = Color.FromArgb(33, 53, 73);
            btnNivelacion.BackColor = Color.FromArgb(33, 53, 73);
            btnFugaGas.BackColor = Color.FromArgb(33, 53, 73);
            btnCombustion.BackColor = Color.FromArgb(33, 53, 73);
            btnTermocupla.BackColor = Color.Green;
            btnElectrico.BackColor = Color.FromArgb(33, 53, 73);
            btnObservacion.BackColor = Color.FromArgb(33, 53, 73);



            FormEnsayoTermocuplaIndi termocupla = new FormEnsayoTermocuplaIndi() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            termocupla.TopLevel = false;
            termocupla.AutoScroll = true;
            this.panelOpciones.Controls.Add(termocupla);

            label1.Text = "Ensayo Termocupla";
            //AbrirFormHija(new FormEnsayoFugaGas());

            FormEnsayoTermocuplaIndi.asd5 = txtCodigo.Text;

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

        private void btnElectrico_Click_1(object sender, EventArgs e)
        {
            //FormEnsayoElectrico electrico = new FormEnsayoElectrico() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            //manual.FormBorderStyle = FormBorderStyle.None;
            //this.panelOpciones.Controls.Add(manual);

            btnCondiciones.BackColor = Color.FromArgb(33, 53, 73);
            btnManuales.BackColor = Color.FromArgb(33, 53, 73);
            btnNivelacion.BackColor = Color.FromArgb(33, 53, 73);
            btnFugaGas.BackColor = Color.FromArgb(33, 53, 73);
            btnCombustion.BackColor = Color.FromArgb(33, 53, 73);
            btnTermocupla.BackColor = Color.FromArgb(33, 53, 73);
            btnElectrico.BackColor = Color.Green;
            btnObservacion.BackColor = Color.FromArgb(33, 53, 73);




            FormEnsayoElectricoIndi electrico = new FormEnsayoElectricoIndi() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            electrico.TopLevel = false;
            electrico.AutoScroll = true;
            this.panelOpciones.Controls.Add(electrico);

            label1.Text = "Ensayo Electrico";
            //AbrirFormHija(new FormEnsayoFugaGas());

            FormEnsayoElectricoIndi.asd6 = txtCodigo.Text;


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

        private void button1_Click_1(object sender, EventArgs e)
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

        private void btnObservacion_Click_1(object sender, EventArgs e)
        {
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



            FormEnsayoObservacionNotaIndi notas = new FormEnsayoObservacionNotaIndi() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };

            notas.TopLevel = false;
            notas.AutoScroll = true;
            this.panelOpciones.Controls.Add(notas);

            label1.Text = "Observaciones y notas";
            //AbrirFormHija(new FormEnsayoFugaGas());

            FormEnsayoObservacionNotaIndi.asd7 = txtCodigo.Text;
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
    }
}
