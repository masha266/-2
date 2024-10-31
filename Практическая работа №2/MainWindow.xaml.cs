using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lib_10;
using LibMas;

namespace Практическая_работа__2
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();//😥
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // кнопочка выход
        }

        private void btnProgInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ввести n целых чисел. Вычислить для чисел > 0 \nфункцию √x. Результат обработки каждого \nчисла вывести на экран."); // кнопочка о программе
        }

        int[] mas;

        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(tbDiapozon.Text, out int randMax)&& randMax > 0) //проверка. если пользователь напишет некорректное значение диапозона, ему высветится окошко с просьбой написать корректное значение
            {
                randMax = Convert.ToInt32(tbDiapozon.Text);

            }
            else MessageBox.Show("Введите корректное значение!", "Ошибка:"); 
            if (Int32.TryParse(tbColumnCount.Text, out int count)) //проверка. если пользователь напишет некорректное значение кол-ва строк, ему высветится окошко с просьбой написать корректное значение
            {
                count = Convert.ToInt32(tbColumnCount.Text);

                Class1 fill = new Class1(); //создание переменной класса Class1
                mas = fill.FillIntArray(count,randMax); //заполнение массива 
                dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView; // визуальное оформление массива в датагрид
            }
            else MessageBox.Show("Введите корректное значение!", "Ошибка:");
        }

        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.Column is DataGridTextColumn) // кол-во колонок заполненных текстом
            {
                TextBox textBox = e.EditingElement as TextBox; // записание изменённых элементов 
                if (textBox != null) // условие, что элемент изменила
                {
                    if (int.TryParse(textBox.Text, out int value)) // проверка
                    {
                        int indexColumn = e.Column.DisplayIndex; // индексы колонок
                        mas[indexColumn] = value; // заполнение массива изменёнными значениями по индексу колонки
                    }
                    else MessageBox.Show("Введите корректное значение!", "Ошибка:");
                }
            }
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            listBoxRezult.Items.Clear(); // очищение листбокса, чтобы не оставались предыдущие результаты

            List<double> squareRoots = Lib_10.VisualArray.CalculatorFunkcion(mas); // создание листа, в который вкладывается другой лист
            for (int i = 0; i < squareRoots.Count; i++) // цикл
            {
                listBoxRezult.Items.Add(squareRoots[i]); // запись из листа squareRoots в листбокс
            } 
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Class1 clear = new Class1(); //создание переменной класса Class1
            clear.AllClear(dataGrid, mas, tbColumnCount, tbDiapozon, listBoxRezult); // очистка
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(tbColumnCount.Text, out int count)) // проверка
            {
                count = Convert.ToInt32(tbColumnCount.Text); // создание переменной с количеством колонок
                Class1 create = new Class1();//создание переменной класса Class1
                mas = create.CreateIntArray(count); //заполнение массива с помощью метода
                dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView; // заполнение датагрида
            }
            else MessageBox.Show("Введите кол-во колонок!", "Ошибка:"); // иначе
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Class1 SaveFileManager = new Class1(); //создание переменной класса Class1
            SaveFileManager.SaveDataToFile(dataGrid, mas); // сохранение
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            Class1 OpenFileMenedger = new Class1();//создание переменной класса Class1
            OpenFileMenedger.OpenDataToFile(dataGrid, mas); //чтение и открытие файла
            dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView; // заполнение датагрида
        }
    }
}