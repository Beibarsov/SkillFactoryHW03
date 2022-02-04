using System;

public class Program
{

    public static void Main(string[] args)
    {
        

        Console.WriteLine("Эта программа написана под условия итогового задания пятого модуля. \n" +
            "И представляет собой анкету о пользователе. Для начала опроса нажмите любую клавишу");
        PrintInfo(GetInfo());
        Console.ReadKey();

    }
    static void PrintInfo((string name, string secondname, int age, bool isPets, int numPets, string[] petsName, int numFavColor, string[] favColors) user)
    {
        Console.WriteLine();
        Console.WriteLine("Вот что у нас получилось:");
        Console.WriteLine($"Имя пользователя: {user.name}");
        Console.WriteLine($"Фамилия пользователя: {user.secondname}");
        Console.WriteLine($"Возраст пользователя: {user.age}");
        Console.WriteLine($"Есть ли у пользователя питомцы: {user.isPets.ToString()}");
        if (user.isPets) {
            Console.WriteLine($"Питомцев у пользователя {user.numPets} и их зовут: ");
            foreach (string name in user.petsName)
            {
                Console.Write($"{name} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine($"У пользователя {user.numFavColor} любимых цветов, такие как: ");
        foreach (string color in user.favColors)
        {
            Console.Write($"{color} ");
        }

    }
    static (string, string, int, bool, int, string[], int, string[]) GetInfo()
    {

        (string name, string secondname, int age, bool isPets, int numPets, string[] petsName, int numFavColor, string[] favColors) user;
        //Так или иначе, необходимы какие-то базовые значения во избежания ошибки о неполных данных.
        user = (name: "default", secondname: "default", age: 0, isPets: false, numPets: 0, petsName: null, numFavColor: 0, favColors: null);

        Console.WriteLine("Сейчас мы будем вводить с клавиатуры данные пользователя. Завершайте ввод клавишей Enter для перехода к следующему вопросу.");
        Console.WriteLine("Введите имя:");
        user.name = Console.ReadLine();
        Console.WriteLine("Введите фамилию:");
        user.secondname = Console.ReadLine();
        Console.WriteLine("Введите возраст:");
        user.age = CorrectingPrint();
        Console.WriteLine("Есть ли питомцы? Для ответа ввести y или n для Да или Нет соответственно.");  
        switch (Console.ReadLine())
        {
            case ("y"):
                user.isPets = true;
                Console.WriteLine("А сколько питомцев? Просьба отвечать числом.");
                user.numPets = CorrectingPrint();
                if (user.numPets > 3) Console.WriteLine("Как много!");
                user.petsName = GetInfoPets(user.numPets);
                break;
            case ("n"):
                user.isPets = false;
                user.numPets = 0;
                break;
            default:
                Console.WriteLine("Будем считать, что питомцев нет.");
                user.isPets = false;
                user.numPets = 0;
                break;
        }
        Console.WriteLine("А сколько любимых цветов?");
        user.numFavColor = CorrectingPrint();
        user.favColors = GetInfoFavColors(user.numFavColor);

        return user;

    }
    static string[] GetInfoPets(int numPets)
    {
        string[] pets = new string[numPets];
        Console.WriteLine("А как их всех зовут?");
        for (int i = 0; i < numPets; i++)
        {
            Console.WriteLine($"Как зовут питомца №{i+1}?");
            pets[i] = Console.ReadLine();
        }
        return pets;
    }

    static string[] GetInfoFavColors(int numFavColor)
    {
        string[] favColors = new string[numFavColor];
        Console.WriteLine("А можешь перечислить все любимые цвета?");
        for(int i = 0;i < numFavColor; i++)
        {
            Console.WriteLine($"Какой любимый цвет #{i+1}?");
            favColors[i] = Console.ReadLine();
        }
        return favColors;
    }

    static int CorrectingPrint()
    {
        int result;
        bool isCorrect;
        do
        {
            isCorrect = int.TryParse(Console.ReadLine(), out result);
            if (isCorrect && result > 0) isCorrect = true;
            else
            {
                isCorrect = false;
                Console.WriteLine("Что-то не так. Введите еще раз. Обязательно числом.");
            }
        } while (isCorrect != true);
        
         return result;

    }


}


