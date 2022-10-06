using System;
using BusinessLogic;

namespace ConsoleView
{
    class Program
    {
        static void Main(string[] args)
        {
            Logic BL = new Logic();
            while (true)
            {
                Console.WriteLine(ShowAllStudents("ФИО студента", "Специальность", "Группа", BL));

                ConsoleKey key = GetKey();

                if (key == ConsoleKey.Enter) ifKeyAdd();
                else ifKeyDelete();

                key = Escape();

                if (key == ConsoleKey.Escape)
                {
                    break;
                }
            }
            string ShowAllStudents(string name, string speciality, string group, Logic BL)
            {
                string all = "";

                all += $"{name,-20}     {speciality,-20}{group,-20}\n\n";
                for (int i = 0; i < BL.ListOfStudents().Count; i += 3)
                {
                    all += $"{((i + 4) / 3),3}." +
                        $" {BL.ListOfStudents()[i],-20}{BL.ListOfStudents()[i + 1],-20}" +
                        $"{BL.ListOfStudents()[i + 2],-20}\n";
                }
                return all;
            }

            ConsoleKey GetKey()
            {
                Console.WriteLine("Выберите, что вы желаете сделать: Добавить(кнопка Enter) или Удалить(кнопка Delete) студента");

                ConsoleKey key = Console.ReadKey().Key;

                while (key != ConsoleKey.Enter && key != ConsoleKey.Delete)
                {
                    Console.WriteLine("\n\nВыберите одну из предложенных кнопок!");
                    key = Console.ReadKey().Key;
                }

                if (BL.ListOfStudents().Count == 0 && key == ConsoleKey.Delete)
                {
                    key = ConsoleKey.Enter;
                    Console.WriteLine("Сейчас вы можете только добавлять, поскольку список пуст!\nМы вынужденно меняем ваш выбор");
                }

                return key;
            }

            void ifKeyAdd()
            {
                Console.WriteLine("Напишите имя студента");
                string name = Console.ReadLine();
                Console.WriteLine("Напишите специальность студента");
                string speciality = Console.ReadLine();
                Console.WriteLine("Напишите группу студента");
                string group = Console.ReadLine();


                BL.AddStudent(name, speciality, group);
            }

            void ifKeyDelete()
            {
                Console.WriteLine("Напишите номер студента");

                int number = Convert.ToInt32(Console.ReadLine());

                while (number <= 0 || number > (BL.ListOfStudents().Count / 3))
                {
                    Console.WriteLine("\n\nВведите допустимое значение!");
                    number = Convert.ToInt32(Console.ReadLine());
                }
                BL.DeleteStudent(number - 1);
            }

            ConsoleKey Escape()
            {
                Console.WriteLine("Для выхода нажмите Esc, для продолжения любую кнопку");

                ConsoleKey key = Console.ReadKey().Key;

                return key;
            }
        }

    }
}
