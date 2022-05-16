using System;
using System.Text.RegularExpressions;

namespace ValidadorPeon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tu Peon esta en B1");
            Console.WriteLine("Escribe la serie de movimientos del peon separados por espcios");
            //Aqui le solicitamos al usuario que ingrese la lista de movimientos
            string movimientos = Console.ReadLine();
            //Con fines de simplificar el funcionamiento, convertimos a mayusculas la entrada, asi tenemos una cadena uniforme
            movimientos = movimientos.ToUpper();
            //Esta propiedad nos va a indicar si la cadena es valida o invalida
            bool valido = false;
            bool posicionfinal = false;

            //Aqui dividimos la cadena larga, en movimientos separados, para trabajar movimiento por movimiento (palabra por palabra) 
            string[] arreglo = movimientos.Split(' ');

            //En este for iremos recorriendo cada palabra por palabra para revisar si es valida o  no
            foreach (var item in arreglo)
            {
                //En caso de que el largo de cada palabra sea mayor a 2, el programa se rompe y no seria valido
                if (item.Length != 2)
                {
                    valido = false;
                    break;
                }

                //Aqui con expresiones regulares validamos las palabras
                if (Regex.IsMatch(item, "^[A-F]{1}[1-6]{1}"))
                    valido = true;
                else
                    valido = false;
            }

            //Aqui si termina el programa, si es valido o no se nos dira al final
            Console.WriteLine(valido);

            if (valido)
            {
                //Tenemos que definir un tama;o para el for pero este tiene que ser menor al tama;o del arreglo ya que tenemos que validar
                //la posicion final
                for (int i = 0; i < arreglo.Length - 1; i++)
                {
                    var actual = arreglo[i];


                    if (i == 0 && (actual == "B2" || actual == "B3"))
                        posicionfinal = true;

                    if (arreglo[0] == "B1")
                    {
                        posicionfinal = false;
                        break;
                    }



                    if (actual == "B2")
                    {
                        if (arreglo[i + 1] == "B3")
                            posicionfinal = true;
                        else
                            posicionfinal = false;
                    }


                    if (actual == "B3")
                    {
                        if(arreglo[i + 1]==)
                    }
                }
            }

            Console.WriteLine(posicionfinal);

        }
    }
}
