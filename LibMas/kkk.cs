
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace LibMas
{
    public class Class1
    {

        public void AllClear(DataGrid dataGrid, int [] mas, TextBox tbColumnCount, TextBox tbDiapozon, ListBox listBoxRezult) // �������
        {
            dataGrid.ItemsSource = null;
            mas = null;
            tbColumnCount.Clear();//������� ���-�� �������
            tbDiapozon.Clear();//������� ��������
            listBoxRezult.Items.Clear(); //������� ���������
        }

        public int [] CreateIntArray(int count) // �������� �������
        {
            int[] mas = new int[count];
            return mas;// ����������� �������
        }

        public int [] FillIntArray(int count, int diapozon) // ���������� �������
        {
            int[] mas = new int[count];
            Random Rand = new Random(); // �������� ���������� ������ ������
            for (int i = 0; i < mas.Length; i++) mas[i] = Rand.Next(diapozon); //���������� ���������
            return mas; // ����������� �������
        }

        public void SaveDataToFile(DataGrid dataGrid, int[] mas) // ����������
        {
            SaveFileDialog save = new SaveFileDialog // �������� ���������� ������ ����������
            { 
                DefaultExt = ".txt", // ��������� ������
                Filter = "��� ����� (*.*)|*.*|��������� �����|*.txt", // ����� ����� � �����
                FilterIndex = 2, // ���������� ������
                Title = "���������� �������" // �������� ����
            };

            if (dataGrid.ItemsSource != null) // ������� ��� ������� �� �����
            {
                if (save.ShowDialog() == true)  
                {
                     StreamWriter file = new StreamWriter(save.FileName);  // �������� ���������� ������ ���������
                     file.WriteLine(mas.Length); // ��������� ������� ������� � ������ ������
                     for (int i = 0; i < mas.Length; i++) // ����
                     {
                         file.WriteLine(mas[i]); // ��������� ������� � ������ ����� ������
                     }
                     file.Close(); // �������� 
                }
            }
            else // ����� ��������� ������
            {
                MessageBox.Show("��� ������ ��� ����������.\n������� ��������.", "������:");
            }
        }

        public void OpenDataToFile(DataGrid dataGrid, int[] mas) // �������� �����
        {
            OpenFileDialog open = new OpenFileDialog(); // �������� ���������� ������ ��������
            open.DefaultExt = ".txt"; // ��������� ������
            open.Filter = "��� ����� (*.*) | *.* |��������� ����� | *.txt"; // ����� ����� � �����
            open.FilterIndex = 2; // ���������� ������
            open.Title = "�������� �������"; // �������� ����

            if (open.ShowDialog() == true) // �������
            {
                StreamReader file = new StreamReader(open.FileName); // �������� ���������� ������ ������

                int len = Convert.ToInt32(file.ReadLine()); // �������� ����������, � ������� ������ ������ �����
                mas = new Int32[len]; // ������ �������
                for (int i = 0; i < mas.Length; i++) // ����
                {
                    mas[i] = Convert.ToInt32(file.ReadLine()); // ���������� ������� �� �����
                }
                file.Close(); // ��������
            }
        }
    }
}
