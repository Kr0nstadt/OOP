using FoxAndRabit;

class MainClass
{
    static void Main()
    {
        Field field = new Field();
        int NamIteration = 1;
        Console.WriteLine(field.ToStringCert());
        for(int i = 0;i <16;i++)
        {
            field.StageField();
            Console.WriteLine("/" + NamIteration + "/\n" + field.ToStringCert() + "\n");
            NamIteration++;
        }
    }
}