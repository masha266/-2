
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace LibMas
{
    public class Class1
    {

        public void AllClear(DataGrid dataGrid, int [] mas, TextBox tbColumnCount, TextBox tbDiapozon, ListBox listBoxRezult) // очистка
        {
            dataGrid.ItemsSource = null;
            mas = null;
            tbColumnCount.Clear();//очищаем кол-во колонок
            tbDiapozon.Clear();//очищаем диапазон
            listBoxRezult.Items.Clear(); //очищаем результат
        }

        public int [] CreateIntArray(int count) // создание массива
        {
            int[] mas = new int[count];
            return mas;// возвращение массива
        }

        public int [] FillIntArray(int count, int diapozon) // заполнение массива
        {
            int[] mas = new int[count];
            Random Rand = new Random(); // создание переменной класса рандом
            for (int i = 0; i < mas.Length; i++) mas[i] = Rand.Next(diapozon); //заполнение диапозона
            return mas; // возвращение массива
        }

        public void SaveDataToFile(DataGrid dataGrid, int[] mas) // сохранение
        {
            SaveFileDialog save = new SaveFileDialog // создание переменной класса сохранени€
            { 
                DefaultExt = ".txt", // текстовый формат
                Filter = "¬се файлы (*.*)|*.*|“екстовые файлы|*.txt", // выбор файла в папке
                FilterIndex = 2, // количество выбора
                Title = "—охранение таблицы" // название окна
            };

            if (dataGrid.ItemsSource != null) // услови€ что таблица не пуста
            {
                if (save.ShowDialog() == true)  
                {
                     StreamWriter file = new StreamWriter(save.FileName);  // создание переменной класса написани€
                     file.WriteLine(mas.Length); // записание размера массива в первую сторку
                     for (int i = 0; i < mas.Length; i++) // цикл
                     {
                         file.WriteLine(mas[i]); // записание массива в каждую новую строку
                     }
                     file.Close(); // закрытие 
                }
            }
            else // иначе выводитс€ ошибка
            {
                MessageBox.Show("Ќет данных дл€ сохранени€.\n¬ведите значени€.", "ќшибка:");
            }
        }

        public void OpenDataToFile(DataGrid dataGrid, int[] mas) // открытие файла
        {
            OpenFileDialog open = new OpenFileDialog(); // создание переменной класса открыти€
            open.DefaultExt = ".txt"; // текстовый формат
            open.Filter = "¬се файлы (*.*) | *.* |“екстовые файлы | *.txt"; // выбор файла в папке
            open.FilterIndex = 2; // количество выбора
            open.Title = "ќткрытие таблицы"; // название окна

            if (open.ShowDialog() == true) // условие
            {
                StreamReader file = new StreamReader(open.FileName); // создание переменной класса чтени€

                int len = Convert.ToInt32(file.ReadLine()); // создание переменной, в которой перва€ строка файла
                mas = new Int32[len]; // размер массива
                for (int i = 0; i < mas.Length; i++) // цикл
                {
                    mas[i] = Convert.ToInt32(file.ReadLine()); // заполнение массива из файла
                }
                file.Close(); // закрытие
            }
        }
    }
}
