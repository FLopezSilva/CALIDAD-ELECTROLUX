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
    public partial class FormEnsayoFugaGas : Form
    {


        SerialPortManager _spManager;


        string inicio = DateTime.Now.ToString("HH:mm:ss");
        public FormEnsayoFugaGas()
        {
            InitializeComponent();
            UserInitialization();
            btnStop.Enabled = false;

           
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
            this.FormClosing += new FormClosingEventHandler(FormEnsayoFugaGas_FormClosing);



             

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

    

        public static string asd3 = "";

        private void customInstaller1_AfterInstall(object sender, System.Configuration.Install.InstallEventArgs e)
        {

        }

        private void FormFugaGas_Load(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
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
            if (checkBox1.Checked == true)
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
                checkBox1.Checked = false;
            }
            else
            {
                checkBox1.Checked = true;
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        public bool conjunto()
        {
            bool conj = checkBox1.Checked;
            
            if (conj == true)
            {
                return false;
            }

            else
            {
                return true;                
            }
        }


        public bool individual() 
        { 
        
            bool ind = checkBox4.Checked;

            if (ind == true)
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        public bool todo() {

            if (individual() == true && conjunto() == true)
            {

                return true;
            }
            else {
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=10.130.14.248;Initial Catalog=NuevaQA;User ID=NRFT;Password=Nrft2019$");
            con.Open();

            if ((checkBox1.Checked == false && checkBox3.Checked == false) || (checkBox4.Checked == false && checkBox5.Checked == false))
            {
                MessageBox.Show("Ingrese los datos correspondientes");
            }
            else
            {
                try
                {
                    string query1 = "select COUNT(*) from ensayo_fuga_g where id_fuga = @id;";
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    cmd1.Parameters.AddWithValue("@id", asd3);
                    int cant1 = Convert.ToInt32(cmd1.ExecuteScalar());

                    if (cant1 == 0)
                    {
                        string connetionString = null;
                        connetionString = "Data Source = 10.130.14.248; Initial Catalog = NuevaQA; User ID = NRFT; Password = Nrft2019$";
                        SqlConnection conn = new SqlConnection(connetionString);
                        conn.Open();
                        SqlCommand comm = conn.CreateCommand();

                        comm.CommandText = "INSERT INTO ensayo_fuga_g(id_fuga,est_conj_gas,est_indiv_gas,conexion,cumple_fuga_g,fecha_fug,hora_inicio_f,hora_termino_f) VALUES(@fug1,@fug2, @fug3, @fug4, @fug5, @fug6,@fug7,@fug8)";

                        comm.Parameters.AddWithValue("@fug1", asd3);
                        comm.Parameters.AddWithValue("@fug2", individual());
                        comm.Parameters.AddWithValue("@fug3", conjunto());

                        bool conexion = false;
                        if (tbData.TextLength >= 1)
                        {
                            conexion = true;
                        }
                        else
                        {
                            conexion = false;
                        }
                        comm.Parameters.AddWithValue("@fug4", conexion);
                        bool asd = true;
                        if (checkBox3.Checked || checkBox5.Checked)
                        {
                            asd = true;
                        }
                        else
                        {
                            asd = false;
                        }
                        comm.Parameters.AddWithValue("@fug5", asd);
                        comm.Parameters.AddWithValue("@fug6", DateTime.Now); //valor que debe cambiarse (generar funcion para ver si la prueba aprobo o no)
                        comm.Parameters.AddWithValue("@fug7", inicio);
                        comm.Parameters.AddWithValue("@fug8", DateTime.Now.ToString("HH:mm:ss"));

                        comm.ExecuteNonQuery();
                        conn.Close();

                        var w = new Form() { Size = new Size(0, 0) };
                        Task.Delay(TimeSpan.FromSeconds(3))
                               .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                        MessageBox.Show("Ensayo de Fuga de gas registrado satisfactoriamente");


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

                            comm.CommandText = "update ensayo_fuga_g set id_fuga = @fug1 ,est_conj_gas = @fug2 ,est_indiv_gas = @fug3 ,conexion = @fug4 ,cumple_fuga_g = @fug5 ,fecha_fug = @fug6 ,hora_inicio_f = @fug7 ,hora_termino_f = @fug8 where id_fuga = @fug1";

                            comm.Parameters.AddWithValue("@fug1", asd3);
                            comm.Parameters.AddWithValue("@fug2", individual());
                            comm.Parameters.AddWithValue("@fug3", conjunto());

                            bool conexion = false;
                            if (tbData.TextLength >= 1)
                            {
                                conexion = true;
                            }
                            else
                            {
                                conexion = false;
                            }
                            comm.Parameters.AddWithValue("@fug4", conexion);
                            bool asd = true;
                            if (checkBox3.Checked || checkBox5.Checked)
                            {
                                asd = true;
                            }
                            else
                            {
                                asd = false;
                            }
                            comm.Parameters.AddWithValue("@fug5", asd);
                            comm.Parameters.AddWithValue("@fug6", DateTime.Now); //valor que debe cambiarse (generar funcion para ver si la prueba aprobo o no)
                            comm.Parameters.AddWithValue("@fug7", inicio);
                            comm.Parameters.AddWithValue("@fug8", DateTime.Now.ToString("HH:mm:ss"));

                            comm.ExecuteNonQuery();
                            conn.Close();

                            var w = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(3))
                                   .ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

                            MessageBox.Show("Ensayo de Fuga de gas actualizado satisfactoriamente");


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
                    this.Close();
                }
            }
        }


     
        private void rx_textarea_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

       
        private void alert(string text)
        {
            alert_messege.Icon = Icon;
            alert_messege.Visible = true;
            alert_messege.ShowBalloonTip(5000, "Serial Lab", text, ToolTipIcon.Error);
        }
        /*about box*/

        /* Close serial port when closing*/
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        private void tx_textarea_Click(object sender, EventArgs e)
        {
        }
        private void portConfig_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void graph_menu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void alert_messege_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tx_repeater_delay_Tick(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void port_label_Click(object sender, EventArgs e)
        {

        }

      

        private void serial_options_group_Enter(object sender, EventArgs e)
        {

        }

        private void parityConfig_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void stopbits_label_Click(object sender, EventArgs e)
        {

        }

        private void parity_label_Click(object sender, EventArgs e)
        {

        }

        private void flowconrol_label_Click(object sender, EventArgs e)
        {

        }

        private void flowcontrolConfig_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void stopbitsConfig_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnStart_Click_1(object sender, EventArgs e)
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
                    btnStop.Enabled = true;
                    btnStart.Enabled = false;
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

        private void btnStop_Click_1(object sender, EventArgs e)
        {
            try
            {
                _spManager.StopListening();
                btnStart.Enabled = true;
                btnStop.Enabled = false;
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

        private void FormEnsayoFugaGas_FormClosing(object sender, FormClosingEventArgs e)
        {
         

        }

        private void FormEnsayoFugaGas_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {

        }

        private void FormEnsayoFugaGas_Activated(object sender, EventArgs e)
        {

            
        }

        private void FormEnsayoFugaGas_Leave(object sender, EventArgs e)
        {
            _spManager.Dispose();
            this.Close();
        }
    }
}
