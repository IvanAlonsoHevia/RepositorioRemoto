using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Socket server;
        bool registered = false; //bolean que nos permite saber si el usuario esta registrado o no en la base de datos.
        bool connected = false; //bolean que nos permite saber si nos hemos conectado o no a la base de datos.
        bool salida = true; //bolean que nos permite saber si el usuario ha salido o no.
        public Form1()
        {
            InitializeComponent();
        }
        
        //Este boton nos conecta con la base de datos, y si lo hace bien, nos cambia el color del fondo a verde.
        //Sino, nos sale un mensaje para avisarnos que no se ha podido realizar.
        //Este boton introduce en la base de datos, el username y la password que el usuario ha tecleado
        //Si el username esta cogido ya (introducido previamente en la base de datos), saldra un mensaje que nos indicara que escojamos otro.
        private void registrar_Click(object sender, EventArgs e)
        {
            //El ususario no se puede conectar sin introducir el nombre de usuario y su respectiva contraseña.
            if ((connected == false) && (Username.Text != "") && (Password.Text != "")) {
                //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
                //al que deseamos conectarnos
                IPAddress direc = IPAddress.Parse("192.168.56.102");
                //Nos conectamos al mismo puerto que en el servidor.
                IPEndPoint ipep = new IPEndPoint(direc, 9040);


                //Creamos el socket 
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    server.Connect(ipep);//Intentamos conectar el socket
                    this.BackColor = Color.Green;
                    MessageBox.Show("Conectado");

                }
                catch (SocketException ex)
                {
                    //Si hay excepcion imprimimos error y salimos del programa con return 
                    MessageBox.Show("No he podido conectar con el servidor");
                    return;
                }

                connected = true;

                string mensaje = "1/" + Username.Text + "/" + Password.Text;
                // Enviamos al servidor el username y password tecleadas.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                if (mensaje == "SI")
                    MessageBox.Show("El usuario: " + Username.Text + ", se ha registrado correctamente.");
                else
                    MessageBox.Show("El usuario: " + Username.Text + ", ya está cogido.");
           }

            //El ususario no puede realizar la petición sin introducir el nombre de usuario y su respectiva contraseña.
            if ((Username.Text != "") && (Password.Text != ""))
            {
                string mensaje = "1/" + Username.Text + "/" + Password.Text;
                // Enviamos al servidor el username y password tecleadas.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                if (mensaje == "SI")
                    MessageBox.Show("El usuario: " + Username.Text + ", se ha registrado correctamente.");
                else
                    MessageBox.Show("El usuario: " + Username.Text + ", ya está cogido.");
            }
            else
                MessageBox.Show("Introduzca un usuario y/o contraseña válidos");




        }

        //Este boton nos conecta con la base de datos, si no se ha registrado antes el usuario, si lo ha hecho
        //ya estará conectado y por tanto no hará falta volverlo a hacer. Se pondrá de color verde si se conecta.
        //Este boton permite conectar a un usuario ya registrado en la base de datos 
        //Si el usuario no existe o la contraseña es incorrecta, debera registrarse para realizar las consultas.
        private void login_Click(object sender, EventArgs e)
        {
            if (salida == true)
            {
                //El ususario no se puede conectar sin introducir el nombre de usuario y su respectiva contraseña.
                if ((connected == false) && (Username.Text != "") && (Password.Text != ""))
                {
                    //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
                    //al que deseamos conectarnos
                    IPAddress direc = IPAddress.Parse("192.168.56.102");
                    //Nos conectamos al mismo puerto que en el servidor.
                    IPEndPoint ipep = new IPEndPoint(direc, 9040);


                    //Creamos el socket 
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    try
                    {
                        server.Connect(ipep);//Intentamos conectar el socket
                        this.BackColor = Color.Green;
                        MessageBox.Show("Conectado");

                    }
                    catch (SocketException ex)
                    {
                        //Si hay excepcion imprimimos error y salimos del programa con return 
                        MessageBox.Show("No he podido conectar con el servidor");
                        return;
                    }

                    connected = true;

                }

                //El ususario no puede realizar la petición sin introducir el nombre de usuario y su respectiva contraseña.
                if ((Username.Text != "") && (Password.Text != ""))
                {
                    string mensaje = "2/" + Username.Text + "/" + Password.Text;
                    // Enviamos al servidor el username y password tecleadas. // 
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    string mensaje2 = mensaje.Split('/')[0];
                    string mensaje3 = mensaje.Split('/')[1];

                    if (mensaje2 == "SI")
                    {
                        MessageBox.Show(mensaje3);
                        MessageBox.Show("Ya puedes realizar la consulta.");
                        registered = true;
                    }
                    else
                        MessageBox.Show("La contraseña o nombre de usuario no son correctos o el usuario ya esta conectado en otro dispositivo");

                    //Si el Check Box esta marcado, entonces la grid view muestra la lista de conectados.
                    if (CheckConectados.Checked == true)
                    {
                        string newmensaje = "6/";
                        //Enviamos al servidor la orden de tambien mirar en la lista de conectados.
                        byte[] newmsg = System.Text.Encoding.ASCII.GetBytes(newmensaje);
                        server.Send(newmsg);
                        //Recibimos la respuesta del servidor y la tratamos.
                        byte[] newmsg2 = new byte[80];
                        server.Receive(newmsg2);
                        newmensaje = Encoding.ASCII.GetString(newmsg2).Split('\0')[0];
                        ListaConectados.Rows.Clear();
                        ListaConectados.ColumnCount = 1;
                        ListaConectados.ColumnHeadersVisible = true;
                        if (newmensaje != null)
                        {
                            string newmensaje2 = newmensaje.Split('/')[0];
                            NumConn.Text = newmensaje2;
                            int nm = Convert.ToInt32(newmensaje2);
                            int i;
                            for (i = 1; i <= nm; i++)
                            {
                                newmensaje2 = newmensaje.Split('/')[i];
                                ListaConectados.Rows.Add(newmensaje2);
                            }
                            ListaConectados.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                        }
                        else
                            NumConn.Text = "0";
                    }
                }
                else
                    MessageBox.Show("Introduzca un usuario y/o contraseña válidos");
            }

            else
                MessageBox.Show("Debes hacer Log Out antes de hacer Log In con otro usuario"); 


            salida = false;



        }

        //Este boton tiene la funcion de enviar la consulta que seleccionamos con los respectivos parametros de esta introducidos por teclado.
        private void enviar_Click(object sender, EventArgs e)
        {
            if (Ivan.Checked && registered) //CONSULTA1 (solo se realizara si se ha identificado el usuario previamente)
            {
                string mensaje = "3/" + PerdedorBox.Text + "/" + PosicionBox.Text + "/" + PuntuacionBox.Text;
                // Enviamos al servidor los parametros introducidos por teclado para realizar la consulta.
                if ((PerdedorBox.Text == "") || (PosicionBox.Text == "") || (PuntuacionBox.Text == ""))
                {
                    MessageBox.Show("Consulta mal formulada.");
                }
                else
                {
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    MessageBox.Show(mensaje);
                }
            }
            else if (Edgar.Checked && registered) //CONSULTA2 (solo se realizara si se ha identificado el usuario previamente)
            {
                string mensaje = "4/" + UsernameConsultaBox.Text;
                // Enviamos al servidor el username tecleado
                if (UsernameConsultaBox.Text == "")
                {
                    MessageBox.Show("Consulta mal formulada.");
                }
                else
                {
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    if (mensaje == "")
                        MessageBox.Show("Consulta mal formulada.");
                    else
                        MessageBox.Show(mensaje);
                }
            }

            else if (Omar.Checked && registered) //CONSULTA3 (solo se realizara si se ha identificado el usuario previamente)
            {
                string mensaje = "5/" + NumJugadoresBox.Text + "/" + PuntuacionBox.Text + "/" + FechaBox.Text;
                // Enviamos al servidor los parametros introducidos por teclado para realizar la consulta.
                if ((NumJugadoresBox.Text == "") || (PuntuacionBox.Text == "") || (FechaBox.Text == ""))
                {
                    MessageBox.Show("Consulta mal formulada.");
                }
                else
                {
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    if (mensaje == "")
                        MessageBox.Show("Consulta mal formulada.");
                    else
                        MessageBox.Show(mensaje);
                }
            }
            else
                //En el caso de no haberse identificado, se exige haberlo hecho antes de pedir la consulta.
                MessageBox.Show("Se debe loguear antes de realizar la consulta.");
        
        }

        //Este boton nos permite finalizar la conexion con la base de datos.
        //Una vez hecha la desconexion, cambia el color del fondo a gris.
        //Aparte hace un log out de la sesión.
        private void logout_Click(object sender, EventArgs e)
        {
            //Cuando el ususario se desconecta, la grid view esta vacia y además cambia el fondo a gris.
            salida = true;
            ListaConectados.Rows.Clear();
            CheckConectados.Checked = false;
            NumConn.Text = "0";
            registered = false;
            //Mensaje de desconexión
            string mensaje = "0/";

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Nos desconectamos
            this.BackColor = Color.Gray;
            connected = false;
            ListaConectados.Rows.Clear();
            
        }

        private void CheckConectados_CheckedChanged(object sender, EventArgs e)
        {
            //Si la Check Box esta marcada, entonces la grid view te enseña la lista de conectados.
            if (CheckConectados.Checked == true)
            {
                string newmensaje = "6/";
                //Enviamos al servidor la orden de tambien mirar en la lista de conectados.
                byte[] newmsg = System.Text.Encoding.ASCII.GetBytes(newmensaje);
                server.Send(newmsg);
                //Recibimos la respuesta del servidor y la tratamos.
                byte[] newmsg2 = new byte[80];
                server.Receive(newmsg2);
                newmensaje = Encoding.ASCII.GetString(newmsg2).Split('\0')[0];
                ListaConectados.Rows.Clear();
                ListaConectados.ColumnCount = 1;
                ListaConectados.ColumnHeadersVisible = true;
                if (newmensaje != null)
                {
                    string newmensaje2 = newmensaje.Split('/')[0];
                    NumConn.Text = newmensaje2;
                    int nm = Convert.ToInt32(newmensaje2);
                    int i;
                    for (i = 1; i <= nm; i++)
                    {
                        newmensaje2 = newmensaje.Split('/')[i];
                        ListaConectados.Rows.Add(newmensaje2);
                    }
                    ListaConectados.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    //dataGridView1.Columns.Add("Column",mensaje[0]);
                    //connlbl.Text = mensaje;
                }
                else
                    NumConn.Text = "0";
            }


            else
                ListaConectados.Rows.Clear();
        }





    }
}
