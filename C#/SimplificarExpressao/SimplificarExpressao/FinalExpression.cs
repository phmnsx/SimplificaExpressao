using System;
using System.Text;


namespace SimplificarExpressao
{
	public class FinalExpression
	{
		public List<string> Expression { get; }

		public FinalExpression(SimplifiedExpression expression)
		{
			List<Termo> termos = new List<Termo>();
			Expression = new List<string>();

			for(int i = 0; i < expression.AllExpressions.Count; i++)
			{
				termos.Add(new Termo(expression.AllExpressions[i]));
			}

			List<long> TermosContados = new List<long>();

			for(int i = 0; i < termos.Count; i++)
			{
                
                for (int j = 0; j < termos[i].Termos.Count; j++)
				{
                    if (!TermosContados.Contains(termos[i].Termos[j]))
					{
						this.Expression.Add(termos[i].Expressao);
						TermosContados.AddRange(termos[i].Termos);
						break;
					}
				}
			}

		}

		private class Termo
		{
			public List<long> Termos { get; set; }
			public string Expressao;
			public Termo(string Expressao)
			{
				this.Expressao = Expressao;
				this.Termos = new List<long>();
				List<string> ExpressoesTemp = new List<string>();
				ExpressoesTemp.Add(Expressao);
				do
				{
                    List<string> tmpExpressoesTemp = new List<string>();
					for (int i = 0; i < ExpressoesTemp.Count; i++)
					{
						for (int j = 0;  j < ExpressoesTemp[i].Length; j++)
						{
							if (ExpressoesTemp[i][j] == '-')
							{
								char[] array = ExpressoesTemp[i].ToCharArray();
								array[j] = '0';
								tmpExpressoesTemp.Add(new string(array));
                                array[j] = '1';
                                tmpExpressoesTemp.Add(new string(array));
								break;
							}
						}
					}
					if (tmpExpressoesTemp.Count > 0)
					{
						ExpressoesTemp = tmpExpressoesTemp;
					}
				}
				while(hasBadCharacter(ExpressoesTemp));

                for (int i = 0;i < ExpressoesTemp.Count;i++)
				{
                    this.Termos.Add(Convert.ToInt64(ExpressoesTemp[i], 2));
				}
			}

			private bool hasBadCharacter(List<string >Expressao)
			{
				for(int i = 0;i < Expressao.Count;i++)
				{
					if (Expressao[i].Contains('-'))
					{
						return true;
					}
				}
				return false;
			}
		}
	}
}
