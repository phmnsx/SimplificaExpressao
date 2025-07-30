using System.Collections;

public class Cobertura
{
    public static ArrayList GerarTabela(List<string> implicantes, List<string> mintermosOriginais)
    {
        ArrayList tabela = new ArrayList();

        foreach (string implicante in implicantes)
        {
            if (!implicante.Contains("-")) continue;

            ArrayList grupo = new ArrayList();
            grupo.Add(implicante);

            foreach (string mintermo in mintermosOriginais)
            {
                // Se o implicante cobre o mintermo, adiciona ao grupo
                if (Cobre(implicante, mintermo))
                {
                    grupo.Add(mintermo);
                }
            }

            if (grupo.Count > 1)
            {
                tabela.Add(grupo);
            }
        }

        return tabela;
    }
    // Verifica se um implicante cobre um mintermo
    private static bool Cobre(string implicante, string mintermo)
    {
        for (int i = 0; i < implicante.Length; i++)
        {
            if (implicante[i] != '-' && implicante[i] != mintermo[i])
                return false;
        }
        return true;
    }
}
