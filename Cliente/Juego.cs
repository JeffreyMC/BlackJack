using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
//espacios de nombres para haer las conexiones necesarias
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace Cliente
{
    public partial class Juego : Form
    {
        private TcpClient cliente; //conexion con el servidor

        //instancia un objeto que envia y recibe datos
        FlujoDatos datos = new FlujoDatos();

        public Juego()
        {
            InitializeComponent();

        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            //se intenta conectar al servidor
            try
            {
                //se inicia la conexión
                cliente = new TcpClient();
                cliente.Connect("127.0.0.1", 6000);

                //recibe el mensaje del servidor y lo asiga a mensaje
                string mensaje = datos.recibirMensaje(cliente);
                

                //si el cliente se conecta

                if (mensaje.Equals("CONNECTED"))
                {
                    //se deshabilita el boton conectado y se habilia el de conectar
                    btnConectar.Enabled = false;
                    btnDesconectar.Enabled = true;

                    //se cambia el label a conectado (se hace visible)
                    labelConectado.Visible = true;
                    labelDesconectado.Visible = false;

                    //se hace visible el label de esperando jugador
                    labelEstadoJuego.Visible = true;
                    labelTurno.Visible = true;

                    //habilita los botones pedir carta y pasar turno
                    btnPedirCarta.Enabled = true;
                    btnQuedarse.Enabled = true;

                }
                else
                {
                    //muestra el mensaje de que el juego está lleno y luego, se cierra el formulario
                    MessageBox.Show(mensaje);
                    this.Close();
                }

            }
            catch(SocketException ex)
            {
                MessageBox.Show("ERROR. No se pudo conectar con el servidor\n" + ex.ToString());
            }
        }//fin del boton conectar

        
        private void Juego_Load(object sender, EventArgs e)
        {
            //cuando inicia el form se deshabilita el boton desconectar
            btnDesconectar.Enabled = false;
            labelConectado.Visible = false;
            //deshabilita el label del estado turno
            labelTurno.Visible = false;
            //deshabilita el label estado de juego
            labelEstadoJuego.Visible = false;
            //deshabilita los botones de pasar turno y pedir carta
            btnPedirCarta.Enabled = false;
            btnQuedarse.Enabled = false;
            //carta visible
            campoImagen.Visible = true;

        }


        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            //envía un mensaje al servidor indicando que el cliente se desconectó
            datos.enviarMensaje(cliente, "Desconectado");
            
            //desconecta la conexion con el servidor
            cliente.Close();
            //cierra el formulario
            this.Close();

        }

        private void btnPedirCarta_Click(object sender, EventArgs e)
        {
            //primeramente envia una petición al servidor para que le de una carta
            string peticion = "solicitar_carta";
            datos.enviarMensaje(cliente, peticion);
            //se recibe la carta dada y se convierte a un entero
            int carta = datos.recibirMensajeInt(cliente);
            //se recibe la suma total
            int total = datos.recibirMensajeInt(cliente);
            //se recibe el total del oponente
            int totalOponente = datos.recibirMensajeInt(cliente);
            //muestra el total en el textbox
            txtSumaCartas.Text = total.ToString();
            //muestra el total del oponente en el textbox
            txtSumaOponente.Text = totalOponente.ToString();

            //se busca la carta y se muestra
            campoImagen.Load(Application.StartupPath + "\\Cards\\" + carta + ".gif");

            //si total es 21 se muestra que ganó
            if (total == 21)
            {
                MessageBox.Show("HAS GANADO");
                //limpia el textbox
                txtSumaCartas.Text = "0";
                txtSumaOponente.Text = "0";
                //envia el mensaje al servidor para reinicializar contadores
                datos.enviarMensaje(cliente, "gana");
            }

            //Si el total es mas de 21 muestra que perdió
            if (total > 21)
            {
                MessageBox.Show("HAS PERDIDO, obtuviste " + total);
                //reinicia el marcador
                txtSumaCartas.Text = "0";
                txtSumaCartas.Text = "0";
                //envia el mensaje al servidor para inicializar los contadores
                datos.enviarMensaje(cliente, "pierde");
            }

            //si el total del oponente es 21 muestra que perdió
            if(totalOponente == 21)
            {
                MessageBox.Show("HAS PERDIDO, el oponente obtuvo " + totalOponente);
                //reinicia el marcador
                txtSumaCartas.Text = "0";
                txtSumaOponente.Text = "0";
                //envia el mensaje al servidor para inicializar los contadores
                datos.enviarMensaje(cliente, "pierde");
            }

            //muestra que ganó si el oponente se pasa de 21
            if(totalOponente > 21)
            {
                MessageBox.Show("HAS GANADO, el oponente obtuvo" + totalOponente);
                //limpia el textbox
                txtSumaCartas.Text = "0";
                txtSumaOponente.Text = "0";
                //envia el mensaje al servidor para reinicializar contadores
                datos.enviarMensaje(cliente, "gana");
            }

        }

        private void btnQuedarse_Click(object sender, EventArgs e)
        {
            //se le indica al servidor que el jugador pasó el turno
            datos.enviarMensaje(cliente, "pasar_turno");

            //indica que es el turno del otro jugador
            labelTurno.Text = "Esperando turno";

            int totalOponente = datos.recibirMensajeInt(cliente);
            txtSumaOponente.Text = totalOponente.ToString();
            //labelTurno.Text = "Tu turno";

        }
    }
}
