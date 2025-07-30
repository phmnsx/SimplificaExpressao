using SimplificarExpressao;
using System.Collections;


class Program
{
    public static void Main()
    {
        List<int> array = [2, 3, 5];
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
        
       Console.WriteLine("c");
       ArrayList tabela = Cobertura.GerarTabela(teste2.AllExpressions, teste.Expressions);
       
        //Percorre os grupos e imprime o implicante seguido pelos mintermos que ele cobre
        foreach (ArrayList grupo in tabela)
        {
            Console.Write(grupo[0] + " cobre:\n");
            for (int i = 1; i < grupo.Count; i++)
            {
                Console.Write(grupo[i] + " ");
            }
            Console.WriteLine();
        }

    }
}