using SimplificarExpressao;
using System.Collections;

class Program
{

    public static void Main()
    {
        //LerArquivo leitor = new();
        Console.WriteLine("Digite o nome do arquivo:");
        string caminhoArquivo = Console.ReadLine();

        var watch = System.Diagnostics.Stopwatch.StartNew();
        Console.WriteLine("Comecou");
        
        List<long> list = LerArquivo.LerMlongermos(caminhoArquivo, 1);
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine(i + ": " + list[i]);
            Console.WriteLine(list[i] < list[i + 1]);
        }
        FinalExpression ef = new FinalExpression(new SimplifiedExpression(new Expression(list)));
        watch.Stop();
        var elapsedMs = watch.ElapsedMilliseconds;
        Console.WriteLine(elapsedMs.ToString());

        Prlong.ExpressaoFinal(ef);
    }

}
