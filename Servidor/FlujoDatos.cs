using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.IO; //espacio de nombres para enviar/recibir datos

//esta clase será la encargada de enviar y recibir datos
//esto, para evitar escribir código repetitivo
namespace Servidor
{
    class FlujoDatos
    {
        //flujo de datos de red
        public NetworkStream clienteStream;

        //método para enviar un mensaje al cliente
        public void enviarMensaje(TcpClient cliente, string mensaje)
        {
            //obtiene el flujo de datos del cliente
            clienteStream = cliente.GetStream();
            //se crea el escritor del mensaje
            BinaryWriter escritor = new BinaryWriter(clienteStream);
            escritor.Write(mensaje);
        }

        //método para recibir un mensaje del cliente (string)
        public string recibirMensaje(TcpClient cliente)
        {
            try
            {
                //obtiene el flujo de datos del cliente
                clienteStream = cliente.GetStream();
                //se crea el lector del mensaje
                BinaryReader lector = new BinaryReader(clienteStream);
                //lee el mensaje y se lo asigna a un string
                string mensaje = lector.ReadString();
                //retorna el mensaje
                return mensaje;
            }
            //si el mensaje es nulo supone que el usuario se desconectó
            catch(IOException ex)
            {
                //le indica al servidor el error en concreto
                return "Desconectado";
            }
        }

        //método para recibir un mensaje del cliente(int)
        public int recibirMensajeInt(TcpClient cliente)
        {
            //obtiene el flujo de datos del cliente
            clienteStream = cliente.GetStream();
            //se crea el lector del mensaje
            BinaryReader lector = new BinaryReader(clienteStream);
            //lee el mensaje y se lo asigna a un entero
            int mensaje = lector.ReadInt32();
            //retorna el número
            return mensaje;
        }
    }
}
