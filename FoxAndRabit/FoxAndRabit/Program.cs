using FoxAndRabit;

class MainClass
{
    static void Main()
    {
        Field field = new Field();
        Console.WriteLine(field.ToStringCert());
        field.StageField();
        Console.WriteLine(field.ToString());
    }
}