using System;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string cadenaA = "   if if  ";
        //Me da miedo lo que pase con la ñ entons no lo pongo jasdjasdj
        //string Alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        //string numeros = "1234567890";
        //string [] TablaTokens=new String[3];
        byte[] buff1 = Encoding.ASCII.GetBytes(cadenaA);
        byte[] buff2 = new byte[20];

        //Palabras reservadas
        byte[] resIf = Encoding.ASCII.GetBytes("if ");
        byte[] resElse = Encoding.ASCII.GetBytes("else ");

        int inLex = 0, ava = 0,contIf=0, contElse=0;
        
            while (inLex<=cadenaA.Length-1) 
            {
                buff2[ava] = buff1[inLex + ava];
            //Si la cadena tiene un espacio
                if (buff2[ava]==32)
                {
                    Console.WriteLine("Espacio owo");
                    inLex++;
                }
                else
                {
                    for (ava = 0; ava < resIf.Length; ava++)
                    {
                        buff2[ava] = buff1[inLex + ava];
                        if (buff2[ava] == buff1[inLex + ava])
                        {
                            Console.WriteLine(buff2[ava]);
                            contIf++;
                        }
                        else
                            break;
                    }
                if (contIf == 3)
                {
                    Console.WriteLine("If detectado");
                    inLex = inLex + ava;
                    ava = 0;
                    contIf = 0;
                    Array.Clear(buff2, 0, 1);
                }
            }
        }    
    }
}