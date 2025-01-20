using System;

namespace CompactarLogsAtestadoDigital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("É necessário informar paramentros de inicialização.");
                Console.WriteLine("1º parametro: Local do Log");
                Console.WriteLine("Exemplo: 'C:\\AtestadoDigital\\Log'");
                Console.WriteLine("2º e 3º parametro opcional: para deletar os arquivos mais antigos");
                Console.WriteLine("Exemplo: 'del 30' ira deletar os arquivos com mais de 30 dias");
                Console.WriteLine("Exemplo Completo: 'C:\\AtestadoDigital\\Log del 30' ira compactar os arquivos e deletar os arquivos com mas de 30 dias");

                Console.ReadKey();
            }

            ValidationArgs.Validation(args);
        }
    }
}
