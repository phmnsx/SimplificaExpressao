class Program
{
    public static void Main()
    {
        List<int> array = [3, 4 , 5];
        Expression teste = new(array);
        Console.WriteLine(teste.Groups[1][1]);
    }
}