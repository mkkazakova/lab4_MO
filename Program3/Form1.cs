using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Program3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Считываем значения x и y из текстовых полей
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);

            // Выбираем столбцы x и y из matrix0
            int[] columnX = new int[4];
            int[] columnY = new int[4];
            for (int i = 0; i < 4; i++)
            {
                columnX[i] = initialdata.matrix0[i, x - 1];
                columnY[i] = initialdata.matrix0[i, y - 1];
            }

            // Строим график
            Chart chart1 = new Chart();
            chart1.Size = new Size(500, 500);
            chart1.ChartAreas.Add(new ChartArea());
            
            // Добавление грида
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisY.Interval = 1;

            chart1.ChartAreas[0].AxisX.Title = GetAxisTitle(x);
            chart1.ChartAreas[0].AxisY.Title = GetAxisTitle(y);


            // Добавление точек
            Series series = chart1.Series.Add("Data");
            chart1.Series["Data"].ChartType = SeriesChartType.Point;
            for (int i = 0; i < 4; i++)
            {
                chart1.Series["Data"].Points.AddXY(columnX[i], columnY[i]);
                chart1.Series["Data"].Points[i].Label = WriteCountry(i); // Добавляем подпись для каждой точки
            }
            chart1.Series["Data"].MarkerSize = 10;
            chart1.Series["Data"].Font = new Font("Arial", 10, FontStyle.Bold);

            // Добавление точки на график
            chart1.Series.Add("Marker");
            chart1.Series["Marker"].ChartType = SeriesChartType.Point;
            chart1.Series["Marker"].Points.AddXY(10, 10);
            chart1.Series["Marker"].MarkerSize = 10;
            chart1.Series["Marker"].Label = "Точка утопии";
            chart1.Series["Marker"].Font = new Font("Arial", 12, FontStyle.Bold);
            

            // Добавление графика на форму
            Controls.Add(chart1);

            // Все расстояния в квадрате
            double MinDistance = 200;
            double DistanceToPoint = 0;
            int IndexStr = 0;
            for (int i = 0; i < 4; i++)
            {
                DistanceToPoint = Math.Pow(10 - initialdata.matrix0[i, x - 1], 2) + Math.Pow(10 - initialdata.matrix0[i, y - 1], 2);
                if (DistanceToPoint < MinDistance)
                {
                    MinDistance = DistanceToPoint;
                    IndexStr = i;
                }
            }

            myLabel.Text = "Ответ: " + WriteCountry(IndexStr);
            
            // Массив строк для заголовков столбцов таблицы
            string[] columnHeaders = { "Страна", GetAxisTitle(x), GetAxisTitle(y) };

            // Установите массивы данных и заголовков столбцов в DataGridView
            dataGrid1.ColumnCount = 3;
            dataGrid1.RowCount = 4;

            for (int i = 0; i < 3; i++) dataGrid1.Columns[i].HeaderText = columnHeaders[i];
            for (int i = 0; i < 4; i++)
            {
                dataGrid1.Rows[i].Cells[0].Value = WriteCountry(i);
                dataGrid1.Rows[i].Cells[1].Value = columnX[i].ToString();
                dataGrid1.Rows[i].Cells[2].Value = columnY[i].ToString();
            }

            // Отображение таблицы
            dataGrid1.RowHeadersVisible = false;
            dataGrid1.Visible = true;
        }
        private string GetAxisTitle(int axis)
        {
            switch (axis)
            {
                case 1:
                    return "Цена";
                case 2:
                    return "Удалённость";
                case 3:
                    return "Пляж";
                case 4:
                    return "Достопримеч";
                default:
                    return "";
            }
        }
        public class initialdata
        {
            static int[,] GetMatrix()
            {
                int[,] matrix0 = new int[4, 4]
                {
                    { 5, 6, 4, 10 },
                    { 6, 7, 3, 2 },
                    { 3, 2, 9, 5 },
                    { 2, 1, 10, 4 }
                };
                return matrix0;
            }
            public static int[,] matrix0 = GetMatrix();
        }

        private string WriteCountry(int i)
        {
            switch (i)
            {
                case 0:
                    return "Испания";
                case 1:
                    return "Турция";
                case 2:
                    return "Куба";
                case 3:
                    return "Индонезия";
                default:
                    return "arror in country";
            }
        }
    }
}
