using System;
using System.Text;

internal class Program
{

    private static void Main(string[] args)
    {
        //Cadena que se busca analizar
        String cadena = "Id_1Valido";
        //Buffers
        byte[] buff1 = Encoding.ASCII.GetBytes(cadena);
        byte[] buff2 = new byte[20];
        //Variables que servirán para el corrimiento de la cadena
        int ava = 0, inLex = 0;
        int estado = 1;
        //Recorrer toda la cadena
        buff2[ava] = buff1[inLex + ava];
        
        while (ava < cadena.Length)
        {

            Console.WriteLine("Caracter: {0} Estado Inicial: {1}",cadena[ava], estado);
            //La idea general es que hay que revisar sí o sí las cadenas 
            

            if (inLex + ava == 0)
            {
                if (estado == 1)
                {
                    estado = Minusc1(buff2[ava], estado);
                }
                if (estado == 2)
                {
                    estado = 7;
                }
                if (estado == 3)
                {
                    estado = Mayusc1(buff2[ava], estado);
                }
                if (estado == 4)
                {
                    estado = 7;
                }
                if (estado == 5)
                {
                    estado = Guion1(buff2[ava], estado);
                }
                if (estado == 6)
                {
                    estado = 7;
                }
                if (estado == 7)
                {
                    Console.WriteLine("Estado 7");
                    if (cadena.Length==1)
                    {
                        estado = 18;
                    }
                    else
                    {
                        ava++;
                        buff2[ava] = buff1[inLex + ava];
                        Console.WriteLine("Caracter: {0} Estado Inicial: {1}", cadena[ava], estado);
                    }
                    
                }
            }
            
            if (ava > 0)
            {
                if (ava == cadena.Length)
                {
                    estado = 18;
                }
                    if (estado == 7)
                    {
                        estado = 8;
                    }
                    if (estado == 8)
                    {
                        Console.WriteLine("Estado 8");
                        estado = 9;
                    }
                    if (estado == 9)
                    {
                    Console.WriteLine("Estado 9");
                        estado = Minusc2(buff2[ava], estado);
                    }
                    if (estado == 10)
                    {
                        estado = 17;
                    }
                    if (estado == 11)
                    {
                        estado = Mayusc2(buff2[ava], estado);
                    }
                    if (estado == 12)
                    {
                        estado = 17;
                    }
                    if (estado == 13)
                    {
                        estado = Guion2(buff2[ava], estado);
                    }
                    if (estado == 14)
                    {
                        estado = 17;
                    }
                    if (estado == 15)
                    {
                        estado = Numero1(buff2[ava], estado);
                    }
                    if (estado == 16)
                    {
                        estado = 17;
                    }
                    if (estado == 17)
                    {
                        Console.WriteLine("Estado 17");
                        if (cadena.Length == ava+1)
                        {
                        estado = 18;
                        }
                        else
                        {
                            ava++;
                            buff2[ava] = buff1[inLex + ava];
                            estado = 8;
                        }

                    }
                
            }  
            if(estado == 18)
            {
                Console.WriteLine("Estado 18");
                estado = 19;
            }
            if (estado == 19)
            {
                Console.WriteLine("Estado 19");
                Console.WriteLine("ID Valido");
                return;
            }
            if (estado == 22)
            {
                Console.WriteLine("ESTEEstado de error");
                break;
            }
        }

    }

    //Estado: 1
    public static int Minusc1(Byte caracter, int estado)
    {
        //Poner que debe ser una letra minuscula
        if (caracter >= 97 && caracter<=122)
        {
            Console.WriteLine("Estado 2");
            return 2;
        }
        else
        {
            Console.WriteLine("Estado 3");
            return 3;
        }

    }

    //Estado: 3
    public static int Mayusc1(Byte caracter, int estado)
    {
        //Poner que debe ser una letra mayuscula
        if (caracter >= 65 && caracter <= 90)
        {
            Console.WriteLine("Estado 4");
            return 4;
        }
        else
        {
            Console.WriteLine("Estado 5");
            return 5;
        }

    }
    //Estado 5
    public static int Guion1(Byte caracter, int estado)
    {
        //Poner que sea igual al guion bajo
        if (caracter == 95)
        {
            Console.WriteLine("Estado 6");
            return 6;
        }
        else
            //Mandar estado de error
        return 22;
    }
    //Estado 9
    public static int Minusc2(Byte caracter, int estado)
    {
        //Poner que debe ser una letra minuscula
        if (caracter >= 97 && caracter <= 122)
        {
            Console.WriteLine("Estado 10");
            return 10;
        }
        else
        {
            Console.WriteLine("Estado 11");
            return 11;
        }

    }

    //Estado: 11
    public static int Mayusc2(Byte caracter, int estado)
    {
        //Poner que debe ser una letra mayuscula
        if (caracter >= 65 && caracter <= 90)
        {
            Console.WriteLine("Estado 12");
            return 12;
        }
        else
        {
            Console.WriteLine("Estado 13");
            return 13;
        }

    }
    //Estado 13
    public static int Guion2(Byte caracter, int estado)
    {
        //Poner que sea igual al guion bajo
        if (caracter == 95)
        {
            Console.WriteLine("Estado 14");
            return 14;
        }
        else
        {
            Console.WriteLine("Estado 15");
            return 15;
        }
           
    }
    //Estado 15
    public static int Numero1(Byte caracter, int estado)
    {
        //Poner que sea igual a un numero
        if (caracter >= 48 && caracter <= 57)
        {
            Console.WriteLine("Estado 16");
            return 16;
        }
        else
        {
            Console.WriteLine("");
            return 22;
        }
    }
}
