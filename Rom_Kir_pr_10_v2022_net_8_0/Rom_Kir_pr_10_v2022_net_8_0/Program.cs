using System;

class Program
{
    static void Main(string[] args)
    {
        // Запрос выбора метода ввода координат
        Console.WriteLine("Выберите способ задания координат:");
        Console.WriteLine("1. Ввести координаты вручную");
        Console.WriteLine("2. Случайные координаты");
        string choice = Console.ReadLine();

        char letter1, letter2;
        int number1, number2;

        // Генератор случайных чисел
        Random random = new Random();

        if (choice == "1")
        {
            // Получение координат первого поля
            Console.WriteLine("Введите координаты первого поля (буква от a до h, цифра от 1 до 8):");
            string input1 = Console.ReadLine();
            letter1 = input1[0];
            number1 = int.Parse(input1.Substring(1));

            // Получение координат второго поля
            Console.WriteLine("Введите координаты второго поля (буква от a до h, цифра от 1 до 8):");
            string input2 = Console.ReadLine();
            letter2 = input2[0];
            number2 = int.Parse(input2.Substring(1));
        }
        else if (choice == "2")
        {
            // Случайные координаты
            letter1 = (char)('a' + random.Next(0, 8)); // Случайная буква от a до h
            number1 = random.Next(1, 9); // Случайное число от 1 до 8

            letter2 = (char)('a' + random.Next(0, 8)); // Случайная буква от a до h
            number2 = random.Next(1, 9); // Случайное число от 1 до 8

            Console.WriteLine($"Координаты первого поля: {letter1}{number1}");
            Console.WriteLine($"Координаты второго поля: {letter2}{number2}");
        }
        else
        {
            Console.WriteLine("Некорректный выбор.");
            return;
        }

        // Выбор фигуры
        Console.WriteLine("Введите название фигуры на первом поле (ладья, слон, король или ферзь):");
        string figure = Console.ReadLine();

        // Расчет угрозы в зависимости от фигуры путем передачи функции расчета угрозы для выбранной фигуры
        bool isValid = false;

        switch (figure)
        {
            case "ладья":
                isValid = !CheckRookThreat(letter1, number1, letter2, number2);
                break;
            case "слон":
                isValid = !CheckBishopThreat(letter1, number1, letter2, number2);
                break;
            case "король":
                isValid = !CheckKingMove(letter1, number1, letter2, number2);
                break;
            case "ферзь":
                isValid = !CheckQueenThreat(letter1, number1, letter2, number2);
                break;
            default:
                Console.WriteLine("Некорректное название фигуры.");
                return;
        }

        // Вывод результата
        if (isValid)
        {
            Console.WriteLine("Фигура на первом поле не угрожает второму полю.");
        }
        else
        {
            Console.WriteLine("Фигура на первом поле угрожает второму полю.");
        }
    }

    // Проверка угрозы от ладьи
    static bool CheckRookThreat(char letter1, int number1, char letter2, int number2)
    {
        return letter1 == letter2 || number1 == number2;
    }

    // Проверка угрозы от слона
    static bool CheckBishopThreat(char letter1, int number1, char letter2, int number2)
    {
        return Math.Abs(letter1 - letter2) == Math.Abs(number1 - number2);
    }

    // Проверка угрозы от короля
    static bool CheckKingMove(char letter1, int number1, char letter2, int number2)
    {
        return Math.Abs(letter1 - letter2) <= 1 && Math.Abs(number1 - number2) <= 1;
    }

    // Проверка угрозы от ферзя
    static bool CheckQueenThreat(char letter1, int number1, char letter2, int number2)
    {
        return CheckRookThreat(letter1, number1, letter2, number2) || CheckBishopThreat(letter1, number1, letter2, number2);
    }
}
