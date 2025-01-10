///////////   часть от первого задания   ///////////////
class MyExcept : Exception                            //
{                                                     //
    public override string Message => base.Message;   //
    public MyExcept() { }                             //
    public MyExcept(string message) : base(message)   //
    {
        Console.WriteLine("ups...");                  //
    }                                                 //
}
///////////   часть от первого задания   ///////////////

public delegate void Delega(string[] mass);

class Eventer
{
    public event Delega Sobytie;

    public void Met(string[] mass)
    {
        Sobytie.Invoke(mass);
    }
}

class Program
{
    static void Main()
    {
        string[] mass =
        {
            "петров",
            "иванов",
            "сидоров",
            "мрктчян",
            "алиев"
        };

        Eventer classEventer = new Eventer();
        int value = 0;
        bool vyh = true;
        while (vyh)
        {
            Console.WriteLine("введи 1 или 2 (сортировка по возрастанию или по убыванию)");
            try
            {
                value = int.Parse(Console.ReadLine());
                if (value != 1 && value != 2)
                {
                    throw new MyExcept("необходимо ввести 1 или 2");
                }
                else vyh = false;
            }
            catch (Exception oshibka) when (oshibka is MyExcept)
            {
                Console.WriteLine(oshibka.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("необходимо ввести 1 или 2");
            }
            finally
            {
                if (value == 1)
                {
                    classEventer.Sobytie += SortirovkaAsc;
                    classEventer.Sobytie += ShowFamilia;
                    classEventer.Met(mass);
                }
                else if (value == 2)
                {
                    classEventer.Sobytie += SortirovkaDesc;
                    classEventer.Sobytie += ShowFamilia;
                    classEventer.Met(mass);
                }
            }
        }
    }

    static void SortirovkaAsc(string[] mass)
    {
        for (int i = 0; i < mass.Length; i++)
        {
            for (int j = i; j < mass.Length; j++)
            {
                string buff = string.Empty;
                if (mass[i][0] > mass[j][0])
                {
                    buff = mass[i];
                    mass[i] = mass[j];
                    mass[j] = buff;
                }
            }
        }
    }

    static void SortirovkaDesc(string[] mass)
    {
        for (int i = 0; i < mass.Length; i++)
        {
            for (int j = i; j < mass.Length; j++)
            {
                string buff = string.Empty;
                if (mass[i][0] < mass[j][0])
                {
                    buff = mass[i];
                    mass[i] = mass[j];
                    mass[j] = buff;
                }
            }
        }
    }

    static void ShowFamilia(string[] mass)
    {
        for (int i = 0; i < mass.Length; i++) Console.WriteLine(mass[i]);
    }
}



/***************     первое задание     ********************/

/*
 
internal class Program
{
    private static void Main(string[] args)
    {
        Exception[] massExcept =
        {
            new MyExcept("произошла ошибка"),
            new StackOverflowException(),
            new DivideByZeroException(),
            new OverflowException(),
            new NullReferenceException()
        };

        for (int i = 0; i < massExcept.Length; i++)
        {
            try
            {
                throw massExcept[i];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("\nследующее исключение\n");
            }
        }
    }
}

*/
