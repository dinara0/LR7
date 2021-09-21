using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            colorDialog1.FullOpen = true;
        }
        bool fl = false;// нужно для отрисовки линии
        bool select = false;// для выделения объекта
        Graphics g;
        /*bool drawSquare = false;    //
        bool drawTriangle = false;
        bool drawCircle = false;
        bool drawLine = false;*/
        protected Point p1 = new Point(0, 0);
        protected Point p2 = new Point(0, 0);
        protected Color ChooseColor = Color.LightBlue;// цыет объектов по умолчанию

        //Инициализация необходимых переменных
        Array storage = new Array(100);


        //Функция обработки получения координат XY события передвижения курсора по панели
        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Coord_label.Text = "X: " + e.X + " Y: " + e.Y;
        }


        //Функция обработки события передвижения курсора по форме(очищение метки)
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Coord_label.Text = "";
        }

        



        private void buttonSquare_Click(object sender, EventArgs e)
        {
            buttonSquare.Enabled = true;
            buttonLine.Enabled = false;
            buttonCircle.Enabled = false;
            buttonTriangle.Enabled = false;
        }

        private void buttonCircle_Click(object sender, EventArgs e)
        {
            buttonCircle.Enabled = true;
            buttonLine.Enabled = false;
            buttonSquare.Enabled = false;
            buttonTriangle.Enabled = false;
        }

        private void buttonTriangle_Click(object sender, EventArgs e)
        {
            buttonTriangle.Enabled = true;
            buttonLine.Enabled = false;
            buttonCircle.Enabled = false;
            buttonSquare.Enabled = false;
        }

        private void buttonLine_Click(object sender, EventArgs e)
        {
            buttonLine.Enabled = true;
            buttonSquare.Enabled = false;
            buttonCircle.Enabled = false;
            buttonTriangle.Enabled = false;
        }

        
        //Обработчик события Click кнопки "Выбрать цвет" 
        private void ShowColor_button_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // установка цвета объекта
            ChooseColor = colorDialog1.Color;
        }
        // нажатие копки выделения объекта
        private void button2_Click(object sender, EventArgs e)
        {
            SelectionRemove(ref storage);
            select = true;
        }


        private void buttonCGroup_Click(object sender, EventArgs e)
        {
            /*int count = 0;
            if (storage.get_count() != 0)
                for (int i = 0; i < storage.get_count(); ++i)
                { //Если объект существует и окрашен в цвет выбранных объектов,то происходит..
                    if (storage.Empty(i) == false && storage.get_value(i).IsSelect())
                    {

                        count++;

                    }
                }*/
            Figure group = new CGroup(100);
            //int j = 0;
            if (storage.get_count() != 0)
                for (int i = 0; i <= storage.get_count(); ++i)
                { //Если объект существует и окрашен в цвет выбранных объектов,то происходит..
                    if (storage.Empty(i) == false && storage.get_value(i).IsSelect())
                    {
                        ((CGroup)group).AddFigure(storage.get_value(i));

                        storage.delete_value(i);
                        i--;
                        
                    }
                }
            storage.set_value(ref group);
            SelectionRemove(ref storage);
        }

        //Функция обработки события нажатия курсора на панель

        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (select)//если нажата кнопка выделения объекта/ов
            {
                int check = CheckFigure(ref storage, storage.get_count(), e.X, e.Y);// вызываем функцию,
                                                                                    // возвращающую индекс объекта, на который кликнула мышь
                if (check != -1)// если кликнули на объект
                {
                    storage.objects[check].LineColor = Color.Red;// цвет объекта меняется на красный
                    storage.objects[check].IsSelect(true);
                    RedrawFigures(ref storage);// перерисовывем
                }
                //Если нажат ctrl, выделяем несколько объектов
                if (Control.ModifierKeys != Keys.Control)
                    select = false;
            }
            else
            {
                Figure figure = new Figure();// создаем объект класса Figure
                // создаем объект, смотря какая кнопка была нажата 
                if (buttonSquare.Enabled)//
                    figure = new Square(e.X, e.Y, 50, ChooseColor);
                if (buttonTriangle.Enabled)
                    figure = new Triangle(e.X, e.Y, 50, ChooseColor);
                if (buttonCircle.Enabled)
                    figure = new Circle(e.X, e.Y, 50, ChooseColor);
                if (buttonLine.Enabled)
                {
                    if (fl)//нужно два нажатия, при первом образуются координаты первой точки, при втором - второй
                    {
                        p2 = new Point(e.X, e.Y);
                        fl = false;
                    }
                    else
                    {
                        p1 = new Point(e.X, e.Y);
                        fl = true;
                        goto metka; // прыгаем к метке
                    }
                    figure = new Line(p1, p2, Color.Black);
                }
                if (!figure.IsBlackboard())
                    return;
                //Добавляем окружность в хранилище
                storage.set_value(ref figure);
                // включаем возможность взаимодействия с кнопками
                buttonTriangle.Enabled = true;
                buttonLine.Enabled = true;
                buttonCircle.Enabled = true;
                buttonSquare.Enabled = true;

                //Снимаем выделение всех объектов хранилища
                SelectionRemove(ref storage);

                //Устанавливаем цвет выделяемого объекта на новый добавленный
                storage.objects[storage.get_count() - 1].LineColor = Color.Red;
                storage.objects[storage.get_count() - 1].IsSelect(true);

                //Отрисовываем фигуру
                figure.Draw(g);

            }
        metka:;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (storage.get_count() != 0)
                for (int i = 0; i < storage.get_count(); ++i)
                { //Если объект существует и окрашен в цвет выбранных объектов,то происходит..
                    if (storage.Empty(i) == false && storage.get_value(i).IsSelect())
                    {
                        switch (e.KeyData)
                        {
                            case (Keys.Delete):
                                storage.delete_value(i); //удаление объекта из хранилища
                                i--;
                                break;
                            case (Keys.W)://двигаем вверх
                                if (storage.objects[i].IsBlackboard())
                                    storage.objects[i].Move(0, -1);
                                break;
                            case (Keys.A)://двигаем влево
                                if (storage.objects[i].IsBlackboard())
                                    storage.objects[i].Move(-1, 0);
                                break;
                            case (Keys.S)://двигаем вниз
                                if (storage.objects[i].IsBlackboard())
                                    storage.objects[i].Move(0, 1);
                                break;
                            case (Keys.D)://двигаем вправо
                                if (storage.objects[i].IsBlackboard())
                                    storage.objects[i].Move(1, 0);
                                break;
                            case (Keys.Q)://увеличиваем размер объекта
                                if (storage.objects[i].IsBlackboard())
                                    storage.objects[i].Resize(1);
                                break;
                            case (Keys.E)://уменьшаем размер объекта
                                if (storage.objects[i].IsBlackboard())
                                    storage.objects[i].Resize(-1);
                                break;
                        }
                        RedrawFigures(ref storage);//перерисовываем 
                    }
                }
            //RedrawFigures(ref storage);//перерисовываем 


        }

        private void buttonSave_Click(object sender, EventArgs e)// сохранить объекты в файл
        {
            //for(int i=0; i<storage.get_count; i++)
            storage.SaveFigures("Figures.txt");
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            storage.ReadFigures("Figures.txt");
            RedrawFigures(ref storage);//перерисовываем 
        }
    }
}
