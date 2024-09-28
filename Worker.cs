using System;

namespace HW7
{
    /// <summary>
    /// Структура Worker представляет данные о сотруднике.
    /// </summary>
    struct Worker
    {
        #region Свойства

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Время добавления записи.
        /// </summary>
        public DateTime AddedTime { get; set; }

        /// <summary>
        /// Фамилия, Имя, Отчество.
        /// </summary>
        public string FIO { get; set; }

        /// <summary>
        /// Возраст.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Рост.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Место рождения.
        /// </summary>
        public string BirthPlace { get; set; }

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор для создания нового объекта Worker с инициализацией всех полей.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="addedTime">Время добавления записи.</param>
        /// <param name="fio">Фамилия, Имя, Отчество.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="height">Рост.</param>
        /// <param name="birthDate">Дата рождения.</param>
        /// <param name="birthPlace">Место рождения.</param>
        public Worker(int id, DateTime addedTime, string fio, int age, int height, DateTime birthDate, string birthPlace)
        {
            Id = id;
            AddedTime = addedTime;
            FIO = fio;
            Age = age;
            Height = height;
            BirthDate = birthDate;
            BirthPlace = birthPlace;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Переопределение метода ToString для вывода информации о работнике.
        /// </summary>
        /// <returns>Строка, содержащая информацию о работнике в формате CSV.</returns>
        public override string ToString()
        {
            return $"{Id};{AddedTime:dd.MM.yyyy HH:mm};{FIO};{Age};{Height};{BirthDate:dd.MM.yyyy};{BirthPlace}";
        }

        /// <summary>
        /// Метод для создания объекта Worker из строки CSV.
        /// </summary>
        /// <param name="csvLine">Строка CSV с данными о работнике.</param>
        /// <returns>Новый объект Worker.</returns>
        public static Worker FromCsvString(string csvLine)
        {
            string[] values = csvLine.Split(';');
            int id = int.Parse(values[0]);
            DateTime addedTime = DateTime.Parse(values[1]);
            string fio = values[2];
            int age = int.Parse(values[3]);
            int height = int.Parse(values[4]);
            DateTime birthDate = DateTime.Parse(values[5]);
            string birthPlace = values[6];

            return new Worker(id, addedTime, fio, age, height, birthDate, birthPlace);
        }

        /// <summary>
        /// Метод для конвертации объекта Worker в строку CSV.
        /// </summary>
        /// <returns>Строка CSV с данными о работнике.</returns>
        public string ToCsvString()
        {
            return $"{Id};{AddedTime:dd.MM.yyyy HH:mm};{FIO};{Age};{Height};{BirthDate:dd.MM.yyyy};{BirthPlace}";
        }

        #endregion
    }
}