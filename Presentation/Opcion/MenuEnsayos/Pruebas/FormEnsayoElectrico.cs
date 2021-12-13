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
using System.IO.Ports;
using System.IO;
using System.Xml;
using SerialPortListener.Serial;

namespace Presentation.Opcion.MenuEnsayos.Pruebas
{
    public partial class FormEnsayoElectrico : Form
    {

        //public string data { get; set; }
        //int graph_scaler = 500;
        //int send_repeat_counter = 0;
        //bool send_data_flag = false;
        //bool plotter_flag = false;
        //System.IO.StreamWriter out_file;
        //System.IO.StreamReader in_file;
        //static SerialPort _serialPort;

        string inicio = DateTime.Now.ToString("HH:mm:ss");
        SerialPortManager _spManager;


        public FormEnsayoElectrico()
        {
            InitializeComponent();
            UserInitialization();
            button1.Enabled = false;

        }

        public void UserInitialization()

        {


            _spManager = new SerialPortManager();
            SerialSettings mySerialSettings = _spManager.CurrentSerialSettings;
            serialSettingsBindingSource.DataSource = mySerialSettings;
            portNameComboBox.DataSource = mySerialSettings.PortNameCollection;
            baudRateComboBox.DataSource = mySerialSettings.BaudRateCollection;
            dataBitsComboBox.DataSource = mySerialSettings.DataBitsCollection;
            parityComboBox.DataSource = Enum.GetValues(typeof(System.IO.Ports.Parity));
            stopBitsComboBox.DataSource = Enum.GetValues(typeof(System.IO.Ports.StopBits));



            _spManager.NewSerialDataRecieved += new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved);
            this.FormClosing += new FormClosingEventHandler(FormEnsayoElectrico_FormClosing);





        }
        void _spManager_NewSerialDataRecieved(object sender, SerialDataEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // Using this.Invoke causes deadlock when closing serial port, and BeginInvoke is good practice anyway.
                this.BeginInvoke(new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved), new object[] { sender, e });
                return;
            }

            int maxTextLength = 1000; // maximum text length in text box
            if (tbData.TextLength > maxTextLength)
                tbData.Text = tbData.Text.Remove(0, tbData.TextLength - maxTextLength);

            // This application is connected to a GPS sending ASCCI characters, so data is converted to text
            string str = Encoding.ASCII.GetString(e.Data);
            tbData.AppendText(str);
            tbData.ScrollToCaret();

        }



        public static string asd6 = "";
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox3.Checked = false;
            }
            else
            {
                checkBox3.Checked = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox2.Checked = false;
            }
            else
            {
                checkBox2.Checked = true;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                checkBox5.Checked = false;
            }
            else
            {
                checkBox5.Checked = true;
            }
        }
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                checkBox4.Checked = false;
            }
            else
            {
                checkBox4.Checked = true;
            }
        }


        public bool marcado()
        {

            if (checkBox2.Checked == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool proteccion()
        {

            if (checkBox4.Checked == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool electr()
        {

            if (checkBox2.Checked == true && checkBox4.Checked == true && numericPotencia.Value < 60 && numericCorriente.Value < 60)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=10.130.14.248;Initial Catalog=NuevaQA;User ID=NRFT;Password=Nrft2019$");
            con.Open();

            if ((checkBox2.Checked == false && checkBox3.Checked == false) || (checkBox4.Checked == false && checkBox5.Checked == false) || numericCorriente.Value == 0 || numericPotencia.Value == 0)
            {
                MessageBox.Show("Ingrese los datos correspondientes");
            }
            else
            {
                try
                {

                    string query1 = "select COUNT(*) from ensayo_electr where id_electr = @id;";
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    cmd1.Parameters.AddWithValue("@id", asd6);
                    int cant1 = Convert.ToInt32(cmd1.ExecuteScalar());
                    if (cant1 == 0)
                    {
                        string connetionString = null;
                        connetionString = "Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$";
                        SqlConnection conn = new SqlConnection(connetionString);
                        conn.Open();
                        SqlCommand comm = conn.CreateCommand();

                        comm.CommandText = "INSERT INTO ensayo_electr(id_electr,marc_instrucc,pr_part_activa,potencia,corriente,continuidad,aislamiento,rig_dielect,cumple_v_numeric,cumple_electr,fecha_electr,hora_inicio_e,hora_termino_e) VALUES(@elec1, @elec2, @elec3, @elec4, @elec5, @elec6, @elec7, @elec8, @elec9,@elec10,@elec11,@elec12,@elec13)";

                        comm.Parameters.AddWithValue("@elec1", asd6); //valor que debe cambiarse por un dato que sea autoincrementable
                        comm.Parameters.AddWithValue("@elec2", marcado());
                        comm.Parameters.AddWithValue("@elec3", proteccion());
                        comm.Parameters.AddWithValue("@elec4", numericPotencia.Value);
                        comm.Parameters.AddWithValue("@elec5", numericCorriente.Value);
                        comm.Parameters.AddWithValue("@elec6", numericUpDown2.Value);
                        comm.Parameters.AddWithValue("@elec7", numericUpDown1.Value);
                        comm.Parameters.AddWithValue("@elec8", numericUpDown3.Value);
                        bool ensayo;
                        if (checkBox6.Checked == true)
                        {
                            ensayo = true;
                        }
                        else
                        {
                            ensayo = false;
                        }
                        comm.Parameters.AddWithValue("@elec9", electr());
                        comm.Parameters.AddWithValue("@elec10", ensayo);
                        comm.Parameters.AddWithValue("@elec11", DateTime.Now);
                        comm.Parameters.AddWithValue("@elec12", inicio);
                        comm.Parameters.AddWithValue("@elec13", DateTime.Now.ToString("HH:mm:ss"));

                        comm.ExecuteNonQuery();
                        conn.Close();

                        var w = new Form() { Size = new Size(0, 0) };
                        Task.Delay(TimeSpan.FromSeconds(3))
                               .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                        MessageBox.Show("Ensayo Electrico registrado satisfactoriamente");



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
                            conn.Open();
                            SqlCommand comm = conn.CreateCommand();

                            comm.CommandText = "UPDATE ensayo_electr SET id_electr = @elec1,marc_instrucc = @elec2 ,pr_part_activa = @elec3,potencia = @elec4,corriente = @elec5,continuidad = @elec6,aislamiento = @elec7,rig_dielect = @elec8,cumple_v_numeric = @elec9,cumple_electr = @elec10,fecha_electr = @elec11,hora_inicio_e = @elec12 ,hora_termino_e = @elec13 WHERE id_electr = @elec1";

                            comm.Parameters.AddWithValue("@elec1", asd6); //valor que debe cambiarse por un dato que sea autoincrementable
                            comm.Parameters.AddWithValue("@elec2", marcado());
                            comm.Parameters.AddWithValue("@elec3", proteccion());
                            comm.Parameters.AddWithValue("@elec4", numericPotencia.Value);
                            comm.Parameters.AddWithValue("@elec5", numericCorriente.Value);
                            comm.Parameters.AddWithValue("@elec6", numericUpDown2.Value);
                            comm.Parameters.AddWithValue("@elec7", numericUpDown1.Value);
                            comm.Parameters.AddWithValue("@elec8", numericUpDown3.Value);
                            bool ensayo = true;
                            if (checkBox6.Checked == true)
                            {
                                ensayo = true;
                            }
                            else
                            {
                                ensayo = false;
                            }
                            comm.Parameters.AddWithValue("@elec9", electr());
                            comm.Parameters.AddWithValue("@elec10", ensayo);
                            comm.Parameters.AddWithValue("@elec11", DateTime.Now);
                            comm.Parameters.AddWithValue("@elec12", inicio);
                            comm.Parameters.AddWithValue("@elec13", DateTime.Now.ToString("HH:mm:ss"));

                            comm.ExecuteNonQuery();
                            conn.Close();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(3))
                                   .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            MessageBox.Show("Pruebas Ensayo Electrico actualizada satisfactoriamente");



                            this.Close();
                        }
                        else
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




        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void serial_options_group_Enter(object sender, EventArgs e)
        {

        }

        private void connect_Click(object sender, EventArgs e)
        {
            try
            {
                if (portNameComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione un puerto COM");
                }
                else
                {
                    _spManager.StartListening();
                    button1.Enabled = true;
                    connect.Enabled = false;
                    portNameComboBox.Enabled = false;
                    baudRateComboBox.Enabled = false;
                    dataBitsComboBox.Enabled = false;
                    parityComboBox.Enabled = false;
                    stopBitsComboBox.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
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
                checkBox7.Checked = false;
            }
            else
            {

                checkBox7.Checked = true;
            }
        }

        private void FormEnsayoElectrico_Leave(object sender, EventArgs e)
        {
            _spManager.Dispose();
            this.Close();
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            tbData.Clear();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                _spManager.StopListening();
                connect.Enabled = true;
                button1.Enabled = false;
                portNameComboBox.Enabled = true;
                baudRateComboBox.Enabled = true;
                dataBitsComboBox.Enabled = true;
                parityComboBox.Enabled = true;
                stopBitsComboBox.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void FormEnsayoElectrico_FormClosing(object sender, FormClosingEventArgs e)
        {

        }


    }
}
