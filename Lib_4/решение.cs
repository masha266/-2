
using System.Data;

namespace Lib_10
{
    public static class VisualArray
    {

        public static DataTable ToDataTable<T>(this T[] arr) // ���������� ���������
        {
            var res = new DataTable();
            if (arr != null)
            {

            for (int i = 0; i < arr.Length; i++) //����
            {
                res.Columns.Add("������� �" + (i + 1), typeof(T)); // �������� ��������
            }
            var row = res.NewRow();
            for (int i = 0; i < arr.Length; i++) //����
            {
                row[i] = arr[i]; // ���������� ���������
            }
            res.Rows.Add(row);
            }
            return res;
        }

        public static List<double> CalculatorFunkcion(int[] mas) // �������
        {
            List<double> rez = new List<double>(); //�������� ����� � �����������. List<double> - ���������� ��� ������ ����� ��������� ������� ��������

            if (mas != null)
            {
                for (int i = 0; i < mas.Length; i++) //����
                {
                    if (mas[i] > 0) // �������, ��� ����� ����� ������ 0
                    {
                        double rezult = Math.Sqrt(mas[i]); //���������� ����� ��� ������
                        rez.Add(rezult); // �������� ���������
                    }
                }
            }
                return rez; // ���������� ���������
        }
    }
}
