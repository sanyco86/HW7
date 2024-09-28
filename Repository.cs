using System;
using System.IO;
using System.Linq;

namespace HW7
{
    /// <summary>
    /// Класс репозиторий работников.
    /// </summary>
    internal class Repository
    {
        #region Поля

        /// <summary>
        /// Путь к файлу с записями работников.
        /// </summary>
        private readonly string filePath;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор, инициализирующий путь к файлу и проверяющий его существование.
        /// </summary>
        /// <param name="FileName">Имя файла для записей.</param>
        public Repository(string FileName)
        {
            this.filePath = Path.Combine("files", FileName);
            EnsureFileExists();
        }

        #endregion

        #region Операции с работниками

        /// <summary>
        /// Возвращает всех работников из файла.
        /// </summary>
        /// <returns>Массив работников.</returns>
        public Worker[] GetAllWorkers()
        {
            if (!File.Exists(filePath)) return new Worker[0];

            var lines = File.ReadAllLines(filePath);
            return lines.Select(Worker.FromCsvString).ToArray();
        }

        /// <summary>
        /// Возвращает работника по его ID.
        /// </summary>
        /// <param name="id">Идентификатор работника.</param>
        /// <returns>Найденный работник или null, если работник не найден.</returns>
        public Worker GetWorkerById(int id)
        {
            var workers = GetAllWorkers();
            return workers.FirstOrDefault(w => w.Id == id);
        }

        /// <summary>
        /// Удаляет работника по его ID.
        /// </summary>
        /// <param name="id">Идентификатор работника для удаления.</param>
        public void DeleteWorker(int id)
        {
            var workers = GetAllWorkers().Where(w => w.Id != id).ToArray();
            File.WriteAllLines(filePath, workers.Select(w => w.ToCsvString()));
        }

        /// <summary>
        /// Добавляет нового работника в файл. Присваивает уникальный ID.
        /// </summary>
        /// <param name="worker">Объект работника для добавления.</param>
        public void AddWorker(Worker worker)
        {
            var workers = GetAllWorkers();
            int newId = workers.Any() ? workers.Max(w => w.Id) + 1 : 1;
            worker.Id = newId;
            File.AppendAllText(filePath, worker.ToCsvString() + Environment.NewLine);
        }

        /// <summary>
        /// Возвращает работников, добавленных в указанный диапазон дат.
        /// </summary>
        /// <param name="dateFrom">Дата начала диапазона.</param>
        /// <param name="dateTo">Дата конца диапазона.</param>
        /// <returns>Массив работников, добавленных в указанный диапазон.</returns>
        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            return GetAllWorkers().Where(w => w.AddedTime >= dateFrom && w.AddedTime <= dateTo).ToArray();
        }

        #endregion

        #region Вспомогательные методы

        /// <summary>
        /// Проверяет существование файла и директории. Если файл или директория отсутствуют, они создаются.
        /// </summary>
        private void EnsureFileExists()
        {
            string directoryPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
        }
        #endregion
    }
}
