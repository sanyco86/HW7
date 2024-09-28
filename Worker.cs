using System;

namespace HW7
{
    /// <summary>
    /// ��������� Worker ������������ ������ � ����������.
    /// </summary>
    struct Worker
    {
        #region ��������

        /// <summary>
        /// �������������.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ����� ���������� ������.
        /// </summary>
        public DateTime AddedTime { get; set; }

        /// <summary>
        /// �������, ���, ��������.
        /// </summary>
        public string FIO { get; set; }

        /// <summary>
        /// �������.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// ����.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// ���� ��������.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// ����� ��������.
        /// </summary>
        public string BirthPlace { get; set; }

        #endregion

        #region �����������

        /// <summary>
        /// ����������� ��� �������� ������ ������� Worker � �������������� ���� �����.
        /// </summary>
        /// <param name="id">�������������.</param>
        /// <param name="addedTime">����� ���������� ������.</param>
        /// <param name="fio">�������, ���, ��������.</param>
        /// <param name="age">�������.</param>
        /// <param name="height">����.</param>
        /// <param name="birthDate">���� ��������.</param>
        /// <param name="birthPlace">����� ��������.</param>
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

        #region ������

        /// <summary>
        /// ��������������� ������ ToString ��� ������ ���������� � ���������.
        /// </summary>
        /// <returns>������, ���������� ���������� � ��������� � ������� CSV.</returns>
        public override string ToString()
        {
            return $"{Id};{AddedTime:dd.MM.yyyy HH:mm};{FIO};{Age};{Height};{BirthDate:dd.MM.yyyy};{BirthPlace}";
        }

        /// <summary>
        /// ����� ��� �������� ������� Worker �� ������ CSV.
        /// </summary>
        /// <param name="csvLine">������ CSV � ������� � ���������.</param>
        /// <returns>����� ������ Worker.</returns>
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
        /// ����� ��� ����������� ������� Worker � ������ CSV.
        /// </summary>
        /// <returns>������ CSV � ������� � ���������.</returns>
        public string ToCsvString()
        {
            return $"{Id};{AddedTime:dd.MM.yyyy HH:mm};{FIO};{Age};{Height};{BirthDate:dd.MM.yyyy};{BirthPlace}";
        }

        #endregion
    }
}