using System;

namespace Teste2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entre com os parâmetros no formato <QtdProp> <ValorAluguel> <TaxaAdm>: "); //Teste: 2 2000 10; 1 3500 8
            string parm = Console.ReadLine();

            Console.WriteLine(ValorProprietario(parm));
        }

        static string ValorProprietario(string parm)
        {
            string[] subs = parm.Split(' ');

            int qtdProp = Int32.Parse(subs[0]);
            float aluguelTotal = float.Parse(subs[1]);
            float txAdmin = float.Parse(subs[2]);

            float aliq = 0;
            float ded = 0;

            //Cálculo da Taxa de Administração
            float dTxAdmin = aluguelTotal * (txAdmin / 100);

            //Verificando a tabela de alíquota e dedução de imposto de renda (por proprietário)  
            float valPorProp = aluguelTotal / qtdProp;
            switch (valPorProp)
            {
                case float n when (n <= 1903.98):
                    aliq = 0;
                    ded = 0;
                    break;
                case float n when (n >= 1903.99 & n <= 2826.65):
                    aliq = 0.075f;
                    ded = 142.80f;
                    break;
                case float n when (n >= 2826.66 & n <= 3751.05):
                    aliq = 0.15f;
                    ded = 354.80f;
                    break;
                case float n when (n >= 3751.06 & n <= 4664.68):
                    aliq = 0.225f;
                    ded = 636.13f;
                    break;
                case float n when (n >= 4664.69):
                    aliq = 0.275f;
                    ded = 869.36f;
                    break;
            }

            //Calculo do desconto do imposto de renda
            float IRcDed = valPorProp * (aliq) - ded;

            //Valor recebido por proprietário
            float valProp = (valPorProp - (dTxAdmin/qtdProp) - IRcDed);

            //Escrevendo o valor de saída no formato solicitado
            string ret = "";
            for (int i = 1; i <= qtdProp; i++)
            {
                ret = ret + string.Format("{0:N2}", valProp) + " ";
            }

            return ret;
        }
    }
}
