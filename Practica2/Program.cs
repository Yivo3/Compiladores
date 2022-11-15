using System;
using System.Text;

internal class Program
{

    private static void Main(string[] args)
    {
        //Cadena que se busca analizar
        //Si es un caacter solo como <> debe ponerse un espacio al final de la cadena
        String cadena = " != ==";
        //Buffers
        byte[] buff1 = Encoding.ASCII.GetBytes(cadena);
        byte[] buff2 = new byte[20];
        //Variables que servirán para el corrimiento de la cadena
        int ava = 0, inLex = 0;
        int estado = 1;
        //Recorrer toda la cadena
        while (inLex < cadena.Length)
        {
            Console.WriteLine("Estado {0}", estado);
            buff2[ava] = buff1[inLex + ava];
            //Ver cual es el primer caracter
            //Console.WriteLine("Caracter Inicial: {0}", buff2[ava]);
            //Siempre empieza en el estado 1
            switch (estado)
            {
                case 1:
                    estado = CompMenor(buff2[ava], estado);
                    break;
                case 2:
                    //La cadena tiene que avanza dado que solo se entra a este estado si se reconoció el primer caracter
                    ava++;
                    buff2[ava] = buff1[inLex + ava];
                    estado = CompMenorIgual(buff2[ava], estado);
                    inLex = inLex + ava;
                    break;
                case 4:
                    estado = CompMayor(buff2[ava], estado);
                    break;
                case 5:
                    //La cadena tiene que avanza dado que solo se entra a este estado si se reconoció el primer caracter
                    ava++;
                    buff2[ava] = buff1[inLex + ava];
                    estado = CompMayorIgual(buff2[ava], estado);
                    inLex = inLex + ava;
                    break;
                case 7:
                    estado = Igual(buff2[ava], estado);
                    break;
                case 8:
                    //La cadena tiene que avanza dado que solo se entra a este estado si se reconoció el primer caracter
                    ava++;
                    buff2[ava] = buff1[inLex + ava];
                    estado = IgualIgual(buff2[ava], estado);
                    inLex = inLex + ava;
                    break;
                case 9:
                    estado = SignoAd(buff2[ava], estado);
                    break;
                case 10:
                    //La cadena tiene que avanza dado que solo se entra a este estado si se reconoció el primer caracter
                    ava++;
                    buff2[ava] = buff1[inLex + ava];
                    estado = Diferente(buff2[ava], estado);
                    inLex = inLex + ava;
                    break;
                case 11:
                    //La cadena tiene que avanza dado que solo se entra a este estado cuando se reconoció que el primer caracter no es valido
                    //se reinicia el estado y se pasa al siguiente caracter
                    ava++;
                    buff2[ava] = buff1[inLex + ava];
                    Console.WriteLine("Caracter no reconocido");
                    inLex = inLex + ava;
                    estado = 1;
                    break;
                case 12:
                    //Se reconoce el patron y da a lugar un estado de aceptación, se reinicia el estado a 1 para que pueda seguir 
                    //analizando el resto de la cadena si es que hay 
                    ava++;
                    Console.WriteLine("Estado de aceptación");
                    inLex = inLex + ava;
                    estado = 1;
                    break;
            }
            ava = 0;
           
        }

    }

    //Estado: 1
    public static int CompMenor(Byte caracter, int estado)
    {
        if (caracter== 60){
            return 2;
        }
        else { 
            return 4; 
        }

    }
    //Estado: 2
    public static int CompMenorIgual(Byte caracter, int estado)
    {
        if (caracter==61)
        {
            Console.WriteLine("Token <OPRCOMP, MENORIGUAL>");
            return 12;
        }
        else
        {

            Console.WriteLine("Token <OPRCOMP, MENOR>");
            return 12;
        }

    }
    //Estado 4
    public static int CompMayor(Byte caracter, int estado)
    {
        if (caracter==62)
        {
            return 5;
        }
        else
            return 7;
    }
    //Estado 5
    public static int CompMayorIgual(Byte caracter, int estado)
    {
        if (caracter==61)
        {
            Console.WriteLine("Token <OPRCOMP, MAYORIGUAL>");
            return 12;
        }
        else
        {
            Console.WriteLine("Token <OPRCOMP, MAYOR>");
            return 12;
        }
    }
    //Estado 7
    public static int Igual(Byte caracter, int estado)
    {
        if (caracter==61)
        {
            return 8;
        }
        else
            return 9;
    }
    //Estado 8
    public static int IgualIgual(Byte caracter, int estado)
    {
        if (caracter==61)
        {
            Console.WriteLine("Token <OPRCOMP, IGUALDAD>");
            return 12;
        }
        else
            return 11;
    }
    //Estado 9
    public static int SignoAd(Byte caracter, int estado)
    {
        if (caracter==33)
        {
            return 10;
        }
        else
            return 11;
    }
    //Estado 10
    public static int Diferente(Byte caracter, int estado)
    {
        if (caracter==61)
        {
            Console.WriteLine("Token <OPRCOMP, DIFERENCIA>");
            return 12;
        }
        else
            return 11;
    }
}
