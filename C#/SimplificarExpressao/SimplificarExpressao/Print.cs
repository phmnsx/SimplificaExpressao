using System;
namespace SimplificarExpressao
{ 
	public static class Prlong
	{
		public static void ExpressaoFinal(FinalExpression expression)
		{
			for (int i = 0; i < expression.Expression.Count; i++)
			{
				for (int j = 0; j < expression.Expression[i].Length; j++)
				{
					if(expression.Expression[i][j] != '-')
					{
						if (expression.Expression[i][j] == '0')
						{
                            Console.Write("!");
                        }
                        Console.Write("v");
                        Console.Write(j);
                    }
				}
                Console.Write(" + ");
            }
		}
	}
}
