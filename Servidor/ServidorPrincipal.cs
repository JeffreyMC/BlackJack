using System;
using System.Collections.Generic;
using System.Threading;
//espacios de nombres para haer las conexiones necesarias
using System.Net.Sockets;
using System.Net;


namespace Servidor
{
    public class ServidorPrincipal
    {
        //componentes necesarios para realizar la conexión
        static string jugadorActual = "1";// el jugador 1 arranca por defecto
        static TcpListener servidor; //el oyente o servidor
        static TcpClient[] cliente; //cliente del que se enviará y recibirá datos
        static int contador = 1; //lleva la cuenta de los jugadores
        //establece el numero del jugador
        static int jugador1 = 0;
        static int jugador2 = 0;
        //sumatoria total de cada jugador
        static int totalJugador1 = 0;
        static int totalJugador2 = 0;


        //lleva la cuenta del total de los ases de cada jugador
        static int sumaAsesJugador1 = 0;
        static int sumaAsesJugador2 = 0;

        //se instancia la clase encargada de enviar/recibir datos
        FlujoDatos datos = new FlujoDatos();

        //se crea un stack que contendrá las cartas barajadas
        static Stack<int> mazo;

        Thread [] hiloCliente = new Thread[4];

        //public static void Main(string[] args)
        public static void Main(string[] args)
        {
            ServidorPrincipal c = new ServidorPrincipal(); //intancio progran para no hacer los métodos estáticos
           
            try
            {
               
                IPAddress ip = IPAddress.Parse("127.0.0.1"); //ip de la conexion
                int puerto = 6000; //puerto de la conexión
                //se conecta el servidor
                servidor = new TcpListener(ip, puerto);


                //crea un hilo para manejar los subprocesos
                //escucha = new Thread(new ThreadStart(c.clientes));
                //escucha.Start();
                c.clientes();

            }//fin try
            catch (SocketException ex)
            {
                Console.WriteLine("Error. No se pudo conectar el servidor\n",ex);
            }

        }//Fin del main

        //procesa todas las conexiones entrantes
        public void clientes()
        {
            Console.WriteLine("Conectando servidor...");
            //inicia el servidor // escucha a los clientes
            servidor.Start();
            Console.WriteLine("Servidor conectado. Esperando conexiones...");

            //se baraja el mazo para tenerlo listo
            llenarMazo();
            cliente = new TcpClient[4];
            //se crea un ciclo que acepta continuas conexiones
            while (true)
            {
                //se aceptan las conecciones entrantes
                cliente[contador] = servidor.AcceptTcpClient();

                //si el contador es 3 se envia un mensaje al cliente
                //de que el juego está lleno y debe cerrarse

                if (contador == 3)
                {
                    Console.WriteLine("Se acaba de bloquear un usuario");
                    //mensaje a enviar al cliente
                    string mensaje = "Juego lleno. Intente luego.";
                    //se envía el mensaje al cliente
                    datos.enviarMensaje(cliente[contador], mensaje);
                    //se termina la conexión
                    cliente[contador].Close();
                }
                else
                {
                    //Se le envia un mensaje al cliente para indicar que se conectó
                    string mensaje = "CONNECTED";
                    //se envia el mensaje
                    datos.enviarMensaje(cliente[contador], mensaje);

                    //crea un supproceso para iniciar el juego
                    hiloCliente[contador] = new Thread(new ThreadStart(jugadores));

                    //si el jugador 1 es igual a 0 se le asigana ese numero
                    //en caso contrario se le asigna el jugador2
                    if (jugador1 == 0)
                    {
                        jugador1++;
                        Console.WriteLine("Se conectó el jugador 1");
                        //se incrementa el contador
                        
                        //le coloca un nombre al hilo según el contador
                        hiloCliente[contador].Name = "1";
                        hiloCliente[contador].Start();
                        contador++;
                    }
                    else
                    {
                        jugador2++;
                        Console.WriteLine("Se conectó el jugador 2");
                        //se incrementa el contador
                        
                        //le coloca un nombre al hilo según el contador
                        hiloCliente[contador].Name = "2";
                        hiloCliente[contador].Start();
                        contador++;
                    }


                }//else exterior

            }//fin del while

        }//fin de la clase clientes

        //clase para comenzar el juego
        public void jugadores()
        {
            int jugador = int.Parse(Thread.CurrentThread.Name);
           // se crea un while que reciba mensajes constantemente
            while (true)
            {
                string peticion = datos.recibirMensaje(cliente[jugador]); //recibe el mensaje

                //si el mensaje indica que el cliente se desconectó lo indica
                if (peticion.Equals("Desconectado"))
                {
                    Console.WriteLine("Se desconectó el jugador " + Thread.CurrentThread.Name);
                    //disminuye el contador para aceptar jugadores
                    contador--;
                    //establece el numero de jugador por defecto para el siguiente cliente
                    if (Thread.CurrentThread.Name.Equals("1"))
                        jugador1 = 0;
                    else
                        jugador2 = 0;

                    //se cierra el cliente
                    cliente[jugador].Close();
                    //se sale del ciclo
                    break;
                }//fin del if

                //se crea un switch para procesar el mensaje
                //se procesa cuando se pide una carta, cuando pasa el turno o cuando gana/ pierde
                switch (peticion)
                {
                    case "solicitar_carta": pedirCarta();
                                            break;
                    case "pasar_turno":     pasarTurno();
                                            break;
                    case "gana":            ganaJuego();
                                            break;
                    case "pierde":          pierdeJuego();
                                            break;
                }//fin del switch

            }//fin del while

        }//fin del método jugadores

        //llena el mazo con números enteros del 1 al 52 (cada numero representa una imagen de carta)
        public void llenarMazo()
        {
            //crea un stack de que almacenará enteros aleatorios del 1 al 52 (números de las imágenes)
            mazo = new Stack<int>();

            Random aleatorio = new Random(); //genera numeros aleatorios
            int carta = aleatorio.Next(1, 53); //la variable carta guarda un entero aleatorio
            mazo.Push(carta);//se introduce el aleatorio en el stack mazo
       
            //se hace un ciclo de 51 posiciones (no son 52 puesto que ya agregue un número)
            for (int i = 1; i <= 51; i++)
            {
                carta = aleatorio.Next(1, 53);

                //mientras el numero aleatorio esté en el mazo se genera un aleatorio
                //cuando el numero no esté en el mazo sale del ciclo
                //para luego agregarlo al mazo
                while (mazo.Contains(carta))
                {
                    carta = aleatorio.Next(1, 53);
                }

                //se ingresa el número
                mazo.Push(carta);

            }//fin del for


        }

        //metodo que procesa la entrega de una carta
        public void pedirCarta()
        {
            int jugador = int.Parse(Thread.CurrentThread.Name);
            //si el mazo acabó las cartas, se baraja de nuevo
            if (mazo.Count == 0 || mazo == null)
            {
                llenarMazo();
            }

            //se reparte una carta y se elimina del stack
            int cartaDada = mazo.Pop();

            //se pasa la carta por mensaje al cliente
            datos.enviarMensaje(cliente[jugador], cartaDada.ToString());

            //se le suma la carta al total del jugador y se le envia por mensaje
            if (Thread.CurrentThread.Name.Equals("1"))
            {
                //se hace un switch para determinar la suma
                switch (cartaDada)
                {
                    case 1:
                    case 14:
                    case 27:
                    case 40:
                        //va a incrementar sumaAses para determinar la suma optima
                        sumaAsesJugador1++;
                        break;
                    case 2:
                    case 15:
                    case 28:
                    case 41: //suma 2 al total
                        totalJugador1 += 2;
                        break;
                    case 3:
                    case 16:
                    case 29:
                    case 42: //suma 3 al total
                        totalJugador1 += 3;
                        break;
                    case 4:
                    case 17:
                    case 30:
                    case 43: //suma 4 al total
                        totalJugador1 += 4;
                        break;
                    case 5:
                    case 18:
                    case 31:
                    case 44: //suma 5 al total
                        totalJugador1 += 5;
                        break;
                    case 6:
                    case 19:
                    case 32:
                    case 45: //suma 6 al total
                        totalJugador1 += 6;
                        break;
                    case 7:
                    case 20:
                    case 33:
                    case 46: //suma 7 al total
                        totalJugador1 += 7;
                        break;
                    case 8:
                    case 21:
                    case 34:
                    case 47: //suma 8 al total
                        totalJugador1 += 8;
                        break;
                    case 9:
                    case 22:
                    case 35:
                    case 48: //suma 9 al total
                        totalJugador1 += 9;
                        break;
                    default: //suma 10 al total
                        totalJugador1 += 10;
                        break;
                }
                //si suma ases es mayor que cero, se busca la suma óptima
                if (sumaAsesJugador1 > 0)
                {
                    //si se puede contar un as como 11 y el resto como uno se hace
                    //en caso contrario cuenta todos los ases como 1
                    if (totalJugador1 + 11 + (sumaAsesJugador1 - 1) <= 21)
                        totalJugador1 += 11 + (sumaAsesJugador1 - 1);
                    else
                        totalJugador1 += sumaAsesJugador1;
                }

                //se envía el mensaje con el total
                datos.enviarMensaje(cliente[jugador], totalJugador1.ToString());
                Console.WriteLine("Total del jugador 1: " + totalJugador1);
                //envia el total del oponente
                datos.enviarMensaje(cliente[jugador], totalJugador2.ToString());
                Console.WriteLine("Total del oponente: " + totalJugador2);
                Console.WriteLine("");

            }//fin de si es el jugador 1
            //si es el jugador 2
            else
            {
                //se hace un switch para determinar la suma
                switch (cartaDada)
                {
                    case 1:
                    case 14:
                    case 27:
                    case 40:
                        //va a incrementar sumaAses para determinar la suma optima
                        sumaAsesJugador2++;
                        break;
                    case 2:
                    case 15:
                    case 28:
                    case 41: //suma 2 al total
                        totalJugador2 += 2;
                        break;
                    case 3:
                    case 16:
                    case 29:
                    case 42: //suma 3 al total
                        totalJugador2 += 3;
                        break;
                    case 4:
                    case 17:
                    case 30:
                    case 43: //suma 4 al total
                        totalJugador2 += 4;
                        break;
                    case 5:
                    case 18:
                    case 31:
                    case 44: //suma 5 al total
                        totalJugador2 += 5;
                        break;
                    case 6:
                    case 19:
                    case 32:
                    case 45: //suma 6 al total
                        totalJugador2 += 6;
                        break;
                    case 7:
                    case 20:
                    case 33:
                    case 46: //suma 7 al total
                        totalJugador2 += 7;
                        break;
                    case 8:
                    case 21:
                    case 34:
                    case 47: //suma 8 al total
                        totalJugador2 += 8;
                        break;
                    case 9:
                    case 22:
                    case 35:
                    case 48: //suma 9 al total
                        totalJugador2 += 9;
                        break;
                    default: //suma 10 al total
                        totalJugador2 += 10;
                        break;
                }
                //si suma ases es mayor que cero, se busca la suma óptima
                if (sumaAsesJugador2 > 0)
                {
                    //se se puede contar un as como 11 y el resto como uno se hace
                    //en caso contrario cuenta todos los ases como 1
                    if (totalJugador2 + 11 + (sumaAsesJugador2 - 1) <= 21)
                        totalJugador2 += 11 + (sumaAsesJugador2 - 1);
                    else
                        totalJugador2 += sumaAsesJugador2;
                }

                //se envía el mensaje con el total
                datos.enviarMensaje(cliente[jugador], totalJugador2.ToString());
                Console.WriteLine("Total del jugador 2: " + totalJugador2);
                //envía el mensaje con el total del oponente
                datos.enviarMensaje(cliente[jugador], totalJugador1.ToString());
                Console.WriteLine("Total del oponente: " + totalJugador1);
                Console.WriteLine("");

            }


        }//fin del metodo pedir carta

        //metodo para pasar turno
        public void pasarTurno()
        {
            //nombre del hilo (1 o 2)
            string nombreHilo = Thread.CurrentThread.Name;
            //obtiene el valor del hilo en un entero
            int jugador = int.Parse(Thread.CurrentThread.Name);
            if (nombreHilo.Equals("1"))
            {
                Console.WriteLine("Es el turno del jugador 2");
                //pasa el turno al otro hilo
                jugadorActual = "2";
            }
            else
            {
                Console.WriteLine("Es el turno del jugador 1");
                //pasa el turno al otro hilo
                jugadorActual = "1";
            }

            while (nombreHilo.Equals(jugadorActual))
                Monitor.Wait(this);

            if (nombreHilo.Equals("1"))
                datos.enviarMensaje(cliente[jugador], totalJugador2.ToString());
            else
                datos.enviarMensaje(cliente[jugador], totalJugador1.ToString());

        }

        //metodo que indica si el jugador gana
        public void ganaJuego()
        {
            //muestra al servidor quién ganó
            string nombre = Thread.CurrentThread.Name;
            Console.WriteLine("Ganó el jugador " + nombre);

            //se reinician los contadores
            totalJugador1 = 0;
            totalJugador2 = 0;

            //se reinician los contadores de ases
            sumaAsesJugador1 = 0;
            sumaAsesJugador2 = 0;
        }

        //metodo que indica si el jugador pierde
        public void pierdeJuego()
        {
            //muestra al servidor quién ganó
            string nombre = Thread.CurrentThread.Name;
            Console.WriteLine("Perdió el jugador " + nombre);

            //se reinician los contadores
            totalJugador1 = 0;
            totalJugador2 = 0;

            //se reinician los contadores de ases
            sumaAsesJugador1 = 0;
            sumaAsesJugador2 = 0;
        }

    }//fin de la clase


 }

