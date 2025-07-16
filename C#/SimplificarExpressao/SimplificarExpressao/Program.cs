using SimplificarExpressao;

class Program
{
    public static void Main()
    {
        List<int> array = [1, 2 , 4, 5 ,6, 9, 12,18, 16, 19 , 24]; // 011 010 100
        Expression teste = new(array);
        SimplifiedExpression teste2 = new(teste);
        Console.WriteLine("a");
    
        Console.WriteLine("b");
        for (int i = 0; i < teste2.AllExpressions.Count; i++)
        {
            Console.WriteLine(teste2.AllExpressions[i]);
        }
    }
}