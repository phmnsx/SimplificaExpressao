using System;
using System.Collections.Generic;
using System.IO;

public class LerArquivo
{
    public List<int> LerMintermos(string caminhoArquivo, int indiceSaida)
    {
        List<int> mintermos = new List<int>();

        try
        {
            foreach (string linha in File.ReadLines(caminhoArquivo))
            {
                if (linha.StartsWith(".") || string.IsNullOrWhiteSpace(linha))
                    continue;

                string[] partes = linha.Trim().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (partes.Length == 2 && partes[1].Length > indiceSaida)
                {
                    if (partes[1][indiceSaida] == '1')
                    {
                        string entradaBinaria = partes[0];

                        if (!entradaBinaria.Contains("-"))
                        {
                            try
                            {
                                int valorDecimal = Convert.ToInt32(entradaBinaria, 2);
                                mintermos.Add(valorDecimal);
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

        return mintermos;
    }
}
