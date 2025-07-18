using SimplificarExpressao;

class Program
{
    public static void Main()
    {
        List<int> array = [2,3,5];
        Expression teste = new(array);
        SimplifiedExpression teste2 = new(teste);
        Console.WriteLine("a");
        for (int i = 0; i < teste.Expressions.Count; i++)
        {
            Console.WriteLine(teste.Expressions[i]); //Da as expressoes q dão verdade "cruas"
        }
        Console.WriteLine("b");
        for (int i = 0; i < teste2.AllExpressions.Count; i++)
        {
           Console.WriteLine(teste2.AllExpressions[i]); //Da as expressoes q dão verdade com os valores q não importam sendo '-', ou seja, (0100 or 0101) = (010-)
        }
    }
}