using System;
using System.IO;
using System.Linq;

namespace HW7
{
    /// <summary>
    /// Главный класс для управления записями о работниках.
    /// </summary>
    internal class Program
    {
        #region Main

        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        /// <param name="args">Аргументы командной строки.</param>
        static void Main(string[] args)
        {
            string fileName = @"workers.csv";
            Repository repository = new Repository(fileName);

            while (true)
            {
                PrintMenu();

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        GetAllWorkers(repository);
                        break;
                    case "2":
                        GetWorkerById(repository);
                        break;
                    case "3":
                        AddWorker(repository);
                        break;
                    case "4":
                        DeleteWorker(repository);
                        break;
                    case "5":
                        GetWorkersBetweenTwoDates(repository);
                        break;
                    case "6":
                        OrderWorkers(repository);
                        break;
                    case "0":
                        Console.WriteLine("Программа завершена.");
                        return;
                }
            }
        }

        #endregion

        #region Меню

        /// <summary>
        /// Выводит меню программы.
        /// </summary>
        static void PrintMenu()
        {
            Console.WriteLine("1. Просмотр всех записей");
            Console.WriteLine("2. Просмотр записи по ID");
            Console.WriteLine("3. Добавить запись");
            Console.WriteLine("4. Удалить запись");
            Console.WriteLine("5. Загрузка записей в диапазоне дат");
            Console.WriteLine("6. Сортировка записей");
            Console.WriteLine("0. Выход");
        }

        #endregion

        #region Операции с работниками

        /// <summary>
        /// Получает и выводит всех работников из репозитория.
        /// </summary>
        /// <param name="repository">Репозиторий с записями о работниках.</param>
        static void GetAllWorkers(Repository repository)
        {
            var allWorkers = repository.GetAllWorkers();
            foreach (var worker in allWorkers)
            {
                Console.WriteLine(worker);
            }
        }

        /// <summary>
        /// Получает работника по его ID и выводит информацию о нем.
        /// </summary>
        /// <param name="repository">Репозиторий с записями о работниках.</param>
        static void GetWorkerById(Repository repository)
        {
            Console.Write("Введите ID: ");
            int id = int.Parse(Console.ReadLine());
            var workerById = repository.GetWorkerById(id);
            if (workerById.Id != 0)
            {
                Console.WriteLine(workerById);
            }
            else
            {
                Console.WriteLine("Запись не найдена.");
            }
        }

        /// <summary>
        /// Добавляет нового работника в репозиторий.
        /// </summary>
        /// <param name="repository">Репозиторий с записями о работниках.</param>
        static void AddWorker(Repository repository)
        {
            Console.Write("Введите ФИО: ");
            string fio = Console.ReadLine();
            int age = ParseInt("Введите возраст: ");
            int height = ParseInt("Введите рост: ");
            DateTime birthDate = ParseDateTime("Введите дату рождения (дд.мм.гггг): ");
            Console.Write("Введите место рождения: ");
            string birthPlace = Console.ReadLine();

            repository.AddWorker(new Worker(0, DateTime.Now, fio, age, height, birthDate, birthPlace));
        }

        /// <summary>
        /// Удаляет запись о работнике по его ID.
        /// </summary>
        /// <param name="repository">Репозиторий с записями о работниках.</param>
        static void DeleteWorker(Repository repository)
        {
            Console.Write("Введите ID для удаления: ");
            int deleteId = int.Parse(Console.ReadLine());
            repository.DeleteWorker(deleteId);
        }

        /// <summary>
        /// Получает и выводит работников, добавленных в заданном диапазоне дат.
        /// </summary>
        /// <param name="repository">Репозиторий с записями о работниках.</param>
        static void GetWorkersBetweenTwoDates(Repository repository)
        {
            Console.Write("Введите дату начала (дд.мм.гггг): ");
            DateTime dateFrom = DateTime.Parse(Console.ReadLine());
            Console.Write("Введите дату конца (дд.мм.гггг): ");
            DateTime dateTo = DateTime.Parse(Console.ReadLine());
            var workersInRange = repository.GetWorkersBetweenTwoDates(dateFrom, dateTo);
            foreach (var worker in workersInRange)
            {
                Console.WriteLine(worker);
            }
        }

        /// <summary>
        /// Сортирует работников по выбранному полю.
        /// </summary>
        /// <param name="repository">Репозиторий с записями о работниках.</param>
        static void OrderWorkers(Repository repository)
        {
            Console.WriteLine("1. Сортировка по ID");
            Console.WriteLine("2. Сортировка по ФИО");
            Console.WriteLine("3. Сортировка по дате добавления");
            string sortChoice = Console.ReadLine();
            var sortedWorkers = repository.GetAllWorkers();
            switch (sortChoice)
            {
                case "1":
                    sortedWorkers = sortedWorkers.OrderBy(w => w.Id).ToArray();
                    break;
                case "2":
                    sortedWorkers = sortedWorkers.OrderBy(w => w.FIO).ToArray();
                    break;
                case "3":
                    sortedWorkers = sortedWorkers.OrderBy(w => w.AddedTime).ToArray();
                    break;
            }
            foreach (var worker in sortedWorkers)
            {
                Console.WriteLine(worker);
            }
        }

        #endregion

        #region Вспомогательные методы

        /// <summary>
        /// Парсит целое число с консоли.
        /// </summary>
        /// <param name="prompt">Сообщение для ввода.</param>
        /// <returns>Целое число.</returns>
        static int ParseInt(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Неверный формат. Пожалуйста, введите число.");
                }
            }
        }

        /// <summary>
        /// Парсит дату с консоли.
        /// </summary>
        /// <param name="prompt">Сообщение для ввода.</param>
        /// <returns>Дата в формате DateTime.</returns>
        static DateTime ParseDateTime(string prompt)
        {
            DateTime result;
            while (true)
            {
                Console.Write(prompt);
                if (DateTime.TryParse(Console.ReadLine(), out result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты. Пожалуйста, введите дату в формате дд.мм.гггг.");
                }
            }
        }

        #endregion
    }
}
