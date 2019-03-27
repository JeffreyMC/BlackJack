using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servidor
{
    //clase encargada de llenar y revolver el mazo
    class Mazo
    {
        //llena el mazo con números enteros del 1 al 52
        public void llenarMazo()
        {
            //crea un stack de enteros
            Stack<int> mazo = new Stack<int>();

            Random aleatorio = new Random(); //genera numeros aleatorios
            int carta = aleatorio.Next(1, 52); //la variable carta guarda un entero aleatorio
            mazo.Push(carta);//se introduce el aleatorio en el stack mazo

            //se hace un ciclo de 51 posiciones (no son 52 puesto que ya agregue un número)
            for(int i = 0; i < 51; i++)
            {
                carta = aleatorio.Next(1, 52);

                //mientras el numero aleatorio esté en el mazo se genera un aleatorio
                //cuando el numero no esté en el mazo sale del ciclo
                //para luego agregarlo al mazo
                while(mazo.Contains(carta))
                {
                    carta = aleatorio.Next(1, 52);
                }

                //se ingresa el número
                mazo.Push(carta);
            }//fin del for

            
        }
    }
}
