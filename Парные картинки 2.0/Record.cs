using System;
using System.Linq;
using System.IO;
using System.Globalization;

namespace Парные_картинки_2._0
{
    class Record
    {
        static string FileName;

        /// <summary>
        /// Метод записи Рекорда в файл, зависящий от выбранной сложности игры.
        /// </summary>
        /// <param name="moves"> Колличество ходов </param>
        /// <param name="complexity"> Сложность </param>
        public Record(int moves, string complexity)
        {
            if (complexity == "Легко")
            {
                FileName = "RecordEasy.txt";
            }
            if (complexity == "Нормально")
            {
                FileName = "RecordNormal.txt";
            }
            if (complexity == "Сложно")
            {
                FileName = "RecordHard.txt";
            }
            StreamWriter f = new StreamWriter(FileName, true);
            f.WriteLine(moves);
            f.Close();
        }

        public static int record_max()
        {
            var numbers = File.ReadLines(FileName).Select(s => Convert.ToDecimal(s, CultureInfo.InvariantCulture)).ToList();
            var max = numbers.Max();
            return Convert.ToInt32(max);
        }
        public static int record_min()
        {
            var numbers = File.ReadLines(FileName).Select(s => Convert.ToDecimal(s, CultureInfo.InvariantCulture)).ToList();
            var min = numbers.Min();
            return Convert.ToInt32(min);
        }


    }
}