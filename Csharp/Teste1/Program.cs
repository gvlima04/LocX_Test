using System;

namespace Teste1
{
    class Program
    {
        static void Main(string[] args)
        {
            int sec;

            Console.WriteLine("Digite o tempo em segundos: ");
            bool cvOk = Int32.TryParse((Console.ReadLine()), out sec);

            if (cvOk)
            {
                Sec2hour(sec);
            }
            else
            {
                Console.WriteLine("Não foi possível converter o valor informado para inteiro.");
            }

        }

        static void Sec2hour(int sec)
        {
            int h = (int)sec / 3600; //O tempo em horas (h) será dado pelo valor inteiro da divisão do valor de entrada por 3600 (1 hora = 3600 segundos)

            int hResto = sec % 3600; //O resto da divisão corresponde aos minutos e segundo restantes

            int m = (int)hResto / 60; // O valor da inteiro de h_resto/60 será o tempo em minuto 
            int s = hResto % 60; //O resto da divisão será o tempo em segundos

            Console.WriteLine("{0}:{1}:{2}", h, m, s);
        }
    }
}
