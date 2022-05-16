using System;
using System.Linq;
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
            bool espalabravalida = false;
            bool posicionfinal = false;

            //Aqui dividimos la cadena larga, en movimientos separados, para trabajar movimiento por movimiento (palabra por palabra) 
            string[] arreglo = movimientos.Split(' ').Where(x => x != "").ToArray();

            //En este for iremos recorriendo cada palabra por palabra para revisar si es valida o  no
            foreach (var item in arreglo)
            {
                //En caso de que el largo de cada palabra sea mayor a 2, el programa se rompe y no seria valido
                if (item.Length != 2)
                {
                    espalabravalida = false;
                    break;
                }

                //Aqui con expresiones regulares validamos las palabras
                if (Regex.IsMatch(item, "^[A-F]{1}[1-6]{1}"))
                    espalabravalida = true;
                else
                    espalabravalida = false;
            }

            //Aqui si termina el programa, si es valido o no se nos dira al final
            if (espalabravalida)
                Console.WriteLine("Palabra Valida");



            if (espalabravalida)
            {
                //Tenemos que definir un tama;o para el for pero este tiene que ser menor al tama;o del arreglo ya que tenemos que validar
                //la posicion final

                if (arreglo.Length == 1)
                {
                    var actual = arreglo[0];

                    if (actual == "B2" || actual == "B3")
                        posicionfinal = true;
                    else
                        posicionfinal = false;
                }

                else
                    for (int i = 0; i < arreglo.Length - 1; i++)
                    {
                        var actual = arreglo[i];


                        if (i == 0)
                        {
                            if (actual == "B2" || actual == "B3")
                                posicionfinal = true;
                            else
                                posicionfinal = false;
                        }


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
                            if (arreglo[i + 1] == "B4" || arreglo[i + 1] == "A4")
                                posicionfinal = true;
                            else
                                posicionfinal = false;
                        }

                        if (actual == "B4" || actual == "A4")
                        {
                            if (arreglo[i + 1] == "B5" || arreglo[i + 1] == "A5")
                                posicionfinal = true;
                            else
                                posicionfinal = false;
                        }

                        if (actual == "B5" || actual == "A5")
                        {
                            if (arreglo[i + 1] == "B6" || arreglo[i + 1] == "A6")
                                posicionfinal = true;
                            else
                                posicionfinal = false;
                        }

                        if (actual == "B6" || actual == "A6")
                        {
                            posicionfinal = false;
                        }

                        if (posicionfinal == false)
                            break;
                    }

                if (posicionfinal)
                {
                    //Si termina en el inicio dle oponente 
                    if (arreglo[arreglo.Length - 1] == "A6" || arreglo[arreglo.Length - 1] == "B6")
                        Console.WriteLine("Tu peon se ha convertido en una reina!");
                    //si termina en otro lugar
                    else
                        Console.WriteLine("Movimientos validos");
                }
                //si no fueron validos sus movimientos
                else
                    Console.WriteLine("Movimientos invalidos!");

            }



        }
    }
}
