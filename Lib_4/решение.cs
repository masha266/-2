
using System.Data;

namespace Lib_10
{
    public static class VisualArray
    {

        public static DataTable ToDataTable<T>(this T[] arr) // заполнение датагрида
        {
            var res = new DataTable();
            if (arr != null)
            {

            for (int i = 0; i < arr.Length; i++) //цикл
            {
                res.Columns.Add("Ёлемент є" + (i + 1), typeof(T)); // название столбцов
            }
            var row = res.NewRow();
            for (int i = 0; i < arr.Length; i++) //цикл
            {
                row[i] = arr[i]; // заполнение датагрида
            }
            res.Rows.Add(row);
            }
            return res;
        }

        public static List<double> CalculatorFunkcion(int[] mas) // решение
        {
            List<double> rez = new List<double>(); //создание листа с результатом. List<double> - показывает что список будет содержать дробные значени€

            if (mas != null)
            {
                for (int i = 0; i < mas.Length; i++) //цикл
                {
                    if (mas[i] > 0) // условие, что ввели число больше 0
                    {
                        double rezult = Math.Sqrt(mas[i]); //возведение числа под корень
                        rez.Add(rezult); // получаем результат
                    }
                }
            }
                return rez; // возвращает результат
        }
    }
}
