using System;
using System.Collections.Generic;
using System.IO;

public static class LerArquivo
{
    public static List<long> LerMlongermos(string caminhoArquivo, long indiceSaida)
    {
        List<long> mlongermos = new List<long>();
        long i = 0;
        try
        {
            foreach (string linha in File.ReadLines(caminhoArquivo))
            {
                if (linha.StartsWith(".") || string.IsNullOrWhiteSpace(linha))
                    continue;

                string[] partes = linha.Trim().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (partes[indiceSaida].Length > 0)
                {

                    //Console.WriteLine(partes[indiceSaida]);
                    if (partes[indiceSaida] == "1")
                    {
                        string entradaBinaria = partes[0];
                        
                        if (!entradaBinaria.Contains("-"))
                        {
                            try
                            {
                                long valorDecimal = Convert.ToInt64(entradaBinaria, 2);
                                mlongermos.Add(valorDecimal);
                            }
                            catch (FormatException)
                            {
                                Console.Error.WriteLine($"Formato inválido na linha: {linha}");
                            }
                        }
                    }
                }
            }
        }
        catch (IOException ex)
        {
            Console.Error.WriteLine("Erro ao ler o arquivo: " + ex.Message);
        }

        return mlongermos;
    }
}
