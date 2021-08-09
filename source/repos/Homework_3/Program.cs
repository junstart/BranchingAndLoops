using System;

namespace Homework_3
{
    class Program
    {
        static int gameNumber;//переменная для хранения случайного числа
        static int start_gameNumber, end_gameNumber;//переменные для хранения диапазона чисел
        static Random randomize = new Random();//создание переменной для случайного числа из заданного диапазона
        static Random intellect = new Random();//игрок - компьютер
        static int userTry, maxuserTry, minuserTry;//переменная для хранения числа пользователя
        static string userName1, userName2;//переменные для имен игроков
        static string currentUser;//переменная для хранения имени игрока

        /// <summary>
        /// Метод обработки ввода пользователем шагов игры
        /// </summary>
        /// <param name="temp"></param>
        /// <param name="Error_message"></param>
        /// <returns></returns>
        static int EnterStep(int temp, string Error_message)
        {
            string step;
            do
            {
                step = Console.ReadLine();
                if (!int.TryParse(step, out temp)) Console.WriteLine(Error_message);
            }
            while (!int.TryParse(step, out temp));
            return temp;
        }

        static void Main(string[] args)
        {
            int temp = 0;//временная переменная
            
            ConsoleKeyInfo input_key;//обработка нажатия клавиши на клавиатуре
            //вывод на экран правил игры
            Console.WriteLine("Правила игры:");
            //Console.WriteLine("Игроки выбирают число от 1 до 4. Если после хода игрока случайное число равняется нулю, то походивший игрок оказывается победителем");
            Console.WriteLine("Игроки задают минимальное и максимальное значение шага, Игроки задают диапазон чисел для игры. Генерится случайное число в указанном игроками диапазоне.");
            Console.WriteLine("Для игры с компьютером введите имя второго игрока - компьютер");
            //
            Console.WriteLine("Введите минимальный шаг");          
            minuserTry = EnterStep(temp, "Неверный формат ввода, Повторите ввод минимального шага");
            //
            Console.WriteLine("Введите максимальный шаг");
            maxuserTry = EnterStep(temp, "Неверный формат ввода, Повторите ввод максимального шага");
            //
            Console.WriteLine("Введите начало диапазона");
            start_gameNumber = int.Parse(Console.ReadLine().ToString());
            //
            Console.WriteLine("Введите конец диапазона");
            end_gameNumber = int.Parse(Console.ReadLine().ToString()); ;
            //ввод имен игроков
            Console.WriteLine("Игрок 1 введите свое имя");
            userName1 = Console.ReadLine();
            Console.WriteLine("Игрок 2 введите свое имя");
            userName2 = Console.ReadLine();

            do
            {
                gameNumber = randomize.Next(start_gameNumber, end_gameNumber);//генерация случайного числа

                
                    //Код игры
                    currentUser = userName1;
                    //выполняем цикл пока число не станет меньше 0
                    do
                    {
                                if (currentUser == "компьютер")
                                {
                                    temp = intellect.Next(minuserTry, maxuserTry);
                                }
                                else
                                {
                                     Console.WriteLine("Игрок: " + currentUser + " введите номер: ");
                                     temp = Convert.ToInt16(Console.ReadLine());
                                     while (temp < minuserTry || temp > maxuserTry)
                                     {
                                         Console.WriteLine("Ошибка. Введены не корректные данные. Повторите ввод: ");
                                         temp = Convert.ToByte(Console.ReadLine());
                                     }

                                }
      
                    userTry = temp;
                    gameNumber -= userTry;

                    Console.WriteLine("Текушее число: " + gameNumber);//вывод на экран

                    currentUser = userName2;
                            
                    }
                    while (gameNumber > 0);
                //Поздравление игроку
                Console.WriteLine("Игрок: " + currentUser + " выиграл. Поздравляю!");
                //Запрос на продолжение
                Console.WriteLine("Хотите ли повторить игру? Да - нажмите <Enter>, Нет - нажмите <ESC>");
                input_key = Console.ReadKey();
                //обрабатываем выбор пользователя
                while (input_key.Key != ConsoleKey.Enter && input_key.Key != ConsoleKey.Escape)
                {
                    Console.WriteLine("Неверный ввод. Повторите");
                    input_key = Console.ReadKey();
                };                

            }
            while(input_key.Key != ConsoleKey.Escape);
           
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();


        }
    }
}
