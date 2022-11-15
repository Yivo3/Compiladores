using System;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string cadenaA = " if else id1 estonoesunaprueba var num 88888 if else";
        
        byte[] buff1 = Encoding.ASCII.GetBytes(cadenaA);
        byte[] buff2 = new byte[20];

        //Palabras reservadas
        byte[] resIf = Encoding.ASCII.GetBytes("if ");
        byte[] resElse = Encoding.ASCII.GetBytes("else ");

        int inLex = 0, ava = 0,contIf, contElse;
        
        while (inLex<cadenaA.Length){   
     
        buff2[ava] = buff1[inLex + ava];
            //Si el inicio del lexema tiene un espacio
            if (buff2[ava] == 32){
                    //Console.WriteLine("Espacio detectado");
                    inLex++;
            }
            else
            //Si el inicio del lexema tiene una I    
            if (buff2[ava]==105){
                contIf = 0;
                for (ava = 0; ava < resIf.Length; ava++){
                    buff2[ava] = buff1[inLex + ava];
                    //Console.WriteLine("CARACTER LEIDO {0}", buff2[ava]);
                    //Si el IF esta al final de la cadena
                    if (buff2[ava] == 102 && cadenaA.EndsWith("f") && contIf == 1 && inLex == cadenaA.Length - 2){
                        ava = 2;
                        contIf = 3;
                        break;
                    }
                    if (buff2[ava] == resIf[ava])
                        contIf++;
                    if (buff2[ava] != resIf[ava])
                            break;
                    }
                //Se encontró la palabra?
                if (contIf == 3)
                {
                    Console.WriteLine("If detectado");
                    inLex = inLex + ava;
                    ava = 0;
                    contIf = 0;
                }
            }
            else
            //Si el inicio del lexema tiene una E
            if (buff2[ava] == 101){
                contElse = 0;
                for (ava = 0; ava < resElse.Length; ava++){
                    buff2[ava] = buff1[inLex + ava];
                    //Console.WriteLine("CARACTER LEIDO {0}", buff2[ava]);
                    //Si el ELSE esta al final de la cadena
                    if (buff2[ava] == 101 && cadenaA.EndsWith("e") && contElse == 3 && inLex == cadenaA.Length - 4){
                        ava = 4;
                        contElse = 5;
                        break;
                    }
                    if (buff2[ava] == resElse[ava])
                        contElse++;
                    if (buff2[ava] != resElse[ava])
                        break;
                }
                if (contElse == 5){
                    Console.WriteLine("Else detectado");
                    inLex = inLex + ava;
                    ava = 0;
                    contElse = 0;
                }
            }
            else
            //Si el inicio del lexema es una letra del Alfabeto
            if ((buff2[ava] >= 97 && buff2[ava] <= 122) || (buff2[ava] >= 65 && buff2[ava] <= 90)){
                while (buff2[ava]!= 32)
                {
                    //Console.WriteLine("Caracter Leido: {0} Avance actual: {1}", buff2[ava],ava);
                    ava++;
                    buff2[ava] = buff1[inLex + ava];
                }
                Console.WriteLine("Identificador detectado");
                inLex = inLex + ava;
                ava = 0;
            }
            else
            //Si el inicio del lexema es un numero
            if (buff2[ava]>=48 && buff2[ava]<=57){
                while (buff2[ava] != 32 && (buff2[ava] >= 48 && buff2[ava] <= 57))
                {
                    //Console.WriteLine("Caracter Leido: {0} Avance actual: {1}", buff2[ava],ava);
                    ava++;
                    buff2[ava] = buff1[inLex + ava];
                }
                Console.WriteLine("Numero detectado");
                inLex = inLex + ava;
                ava = 0;
            }
            //Si el inicio del lexema es cualquier otra cosa
            else{
                Console.WriteLine("Cadena no valida");
                break;
            }    
        }
    }
}