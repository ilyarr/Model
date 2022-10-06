using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;
using ZedGraph;

namespace WinFormsView
{

    public partial class Form2 : Form
    {
        public Form2(Logic BL)
        {
            InitializeComponent();

            InitGraph(BL);
        }

        private void InitGraph(Logic BL)
        {
            GraphPane graphpane = zedGraphControl1.GraphPane;

            graphpane.CurveList.Clear();

            double[] values = new double[BL.GetSpeciality().Count];

            graphpane.Title.Text = "График распреления студентов по специальностям";

            graphpane.YAxis.Title.Text = "Количество студентов";

            for (int i = 0; i < BL.GetSpeciality().Count; i++)
            {
                int count = 0;
                for (int k = 0; k < BL.ListOfStudents().Count; k += 3)
                {
                    if (BL.ListOfStudents()[k + 1] == BL.GetSpeciality()[i])
                    {
                        count += 1;
                    }
                }
                values[i] = count;
            }


            // Создадим кривую-гистограмму
            // Первый параметр - название кривой для легенды
            // Второй параметр - значения для оси X, т.к. у нас по этой оси будет идти текст, а функция ожидает тип параметра double[], то пока передаем null
            // Третий параметр - значения для оси Y
            // Четвертый параметр - цвет
            BarItem curve = graphpane.AddBar("", null, values, Color.DarkViolet);

            // Настроим ось X так, чтобы она отображала текстовые данные
            graphpane.XAxis.Type = AxisType.Text;

            // Уставим для оси наши подписи
            graphpane.XAxis.Scale.TextLabels = BL.GetSpeciality().ToArray();

            // Вызываем метод AxisChange (), чтобы обновить данные об осях.
            zedGraphControl1.AxisChange();

            // Обновляем график
            zedGraphControl1.Invalidate();
        }
        public void UpdateGraphs(Logic BL)
        {
            if (this.Visible)
            {
                InitGraph(BL);
            }
        }
    }
}
