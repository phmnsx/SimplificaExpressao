using System.Collections;
using System.Collections.Generic;

public class Minimizador
{
    public static string MinimizarExpressao(ArrayList tabela, List<string> mintermosOriginais)
    {
        ArrayList implicantesSelecionados = new ArrayList();
        ArrayList mintermsRestantes = new ArrayList(mintermosOriginais);

        //seleciona implicantes essenciais
while (mintermsRestantes.Count > 0)
{
    string melhorImplicante = null;
    int maxCobertura = 0;

    foreach (ArrayList grupo in tabela)
    {
        string implicante = (string)grupo[0];
        if (implicantesSelecionados.Contains(implicante)) continue;

        int cobertura = 0;
        foreach (string minterm in grupo.GetRange(1, grupo.Count - 1))
        {
            if (mintermsRestantes.Contains(minterm))
            {
                cobertura++;
            }
        }

        if (cobertura > maxCobertura)
        {
            maxCobertura = cobertura;
            melhorImplicante = implicante;
        }
    }

    if (melhorImplicante != null)
    {
        implicantesSelecionados.Add(melhorImplicante);

        foreach (ArrayList grupo in tabela)
        {
            if ((string)grupo[0] == melhorImplicante)
            {
                foreach (string minterm in grupo.GetRange(1, grupo.Count - 1))
                {
                    mintermsRestantes.Remove(minterm);
                }
                break;
            }
        }
    }
    else
    {
        break; // Nenhum implicante cobre os mintermos restantes
    }
}

        // montagem da expressão booleana
        ArrayList termos = new ArrayList();
        for (int i = 0; i < implicantesSelecionados.Count; i++)
        {
            string implicante = (string)implicantesSelecionados[i];
            string literal = BinarioParaLiteral(implicante);
            if (!string.IsNullOrEmpty(literal))
            {
                termos.Add(literal);
            }
        }
        return "Y = " + string.Join(" + ", termos.ToArray());
    }

    private static string BinarioParaLiteral(string binario)
    {
        string[] variaveis = new string[] { "F", "M", "J" };
        string resultado = "";

        for (int i = 0; i < binario.Length; i++)
        {
            if (binario[i] == '1')
            {
                resultado += variaveis[i];
            }
            else if (binario[i] == '0')
            {
                resultado += variaveis[i] + "~";
            }
        }

        return resultado;
    }
}
