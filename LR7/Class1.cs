using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace LR7
{
    public partial class Form1 : Form
    {
        public class Figure
        {
            public int LineWidth = 2;
            public Color LineColor = Color.Black;
            public int x = 0;
            public int y = 0;//координаты 
            public Color color = Color.Black; //Установка цвета по умолчанию
            //public bool isSelect = false;
            protected bool isSelect = false;
            public virtual void IsSelect (bool fl){  }//проверка на попадание
                                                                   // public bool Is_Drawn = true; //Проверка на отрисовку окружности на панели
            public virtual bool IsSelect() { return isSelect; }//проверка на попадание
                                                                   // public bool Is_Drawn = true; //Проверка на отрисовку окружности на панели
            public virtual GraphicsPath GetPath()
            {//создание графического контура
                var path = new GraphicsPath();
                return path;
            }
            public virtual bool HitTest(Point p) { return false; }//проверка на попадание
            public virtual void Draw(Graphics g) { }//отрисовка 
            public virtual void Move(int a, int b) { }//движение объекта
            public virtual void Resize(int a) { }//изменение размера

            public virtual bool IsBlackboard() { return false; }// контроль выхода за рабочую область


        }

        public class CGroup : Figure
        {
            private int _maxcount;// максимальное количество объектов в группе
            private int _count;// текущее количество объектов в группе
            private Figure[] _figures;
            public CGroup(int maxcount)
            {
                _figures=new Figure[maxcount];
                _maxcount = maxcount;
                _count = 0;
                for (int i = 0; i < _maxcount; i++)
                    _figures[i] = null;
            }
            ~CGroup()
            {
                for (int i = 0; i < _count; i++) // очищаем массив ссылок
                    _figures[i] = null; //
                _figures = null;// очищаем сам массив
            }
            public override bool IsSelect(bool fl)
            {
                isSelect = fl;
                return true;

            }
            public bool AddFigure(Figure figure)
            {
                if (_count >= _maxcount)
                    return false;                
                _figures[_count] = figure;
                _count++;
                return true;

            }
            public override void Move(int a, int b)
            {
                for (int i = 0; i < _count; i++)
                    _figures[i].Move(a, b);
            }
            public override void Draw(Graphics g)
            {
                for (int i = 0; i < _count; i++)
                    _figures[i].Draw(g);
            }
            public override GraphicsPath GetPath()
            {
                var path2 = new GraphicsPath();
                for (int i = 0; i < _count; i++)
                    _figures[i].GetPath();
                return path2;
            }

            public override bool HitTest(Point p)
            {
                var result = false;
                for (int i = 0; i < _count; i++)
                    using (var path = _figures[i].GetPath())
                        if (result = path.IsVisible(p)) //если попали хотя бы в один объект
                            result = true;

                return result;
            }
            public override bool IsBlackboard()
            {
                for (int i = 0; i < _count; i++)
                    if (!(_figures[i].IsBlackboard()))// если хотя бы один объект вышел за пределы 
                        return false;
                return true;
            }

            public override void Resize(int a)
            {
                for (int i = 0; i < _count; i++)
                    _figures[i].Resize(a);
            }
        }

        public class Circle : Figure
        {
            public int D = 100; //Задаем диагональ


            public Circle() { FillColor = Color.LightBlue; }

            //Конструктор с параметрами
            public Circle(int x, int y, Color color)
            {
                this.x = x - D / 2;
                this.y = y - D / 2;
                FillColor = color;
            }

            public Color FillColor = Color.LightBlue;// цвет внутренней части фигуры
            public Point Center;//центр окружности
            public int Radious; //радиус
            public override GraphicsPath GetPath()
            {
                var path = new GraphicsPath();
                path.AddEllipse(x, y, D, D);
                return path;
            }

            public override bool HitTest(Point p)
            {
                var result = false;
                using (var path = GetPath())
                    result = path.IsVisible(p);
                return result;
            }
            public override void Draw(Graphics g)
            {
                using (var path = GetPath())
                {
                    using (var brush = new SolidBrush(FillColor))
                        g.FillPath(brush, path);
                    using (var pen = new Pen(LineColor, LineWidth))
                        g.DrawPath(pen, path);
                }


            }
            public override void Move(int a, int b)
            {
                Center = new Point(Center.X + a, Center.Y + b);
            }

            public override bool IsBlackboard()
            {
                if (x < 0 || y < 0 || (x + D) > 721 || (y + D) > 366)
                    return false;
                return true;
            }

            public override void Resize(int a)
            {
                D = D + 2 * a;
            }
            //Деструктор
            ~Circle() { }
        }

        public class Line : Figure
        {

            //Конструктор с параметрами
            public Line(Point p1, Point p2, Color color)
            {
                Point1 = p1;
                Point2 = p2;
                LineColor = color;
            }

            public Line() { LineWidth = 2; LineColor = Color.Black; }

            public PointF Point1;
            public PointF Point2;
            public override GraphicsPath GetPath()
            {
                var path = new GraphicsPath();
                path.AddLine(Point1, Point2);
                return path;
            }
            public override bool HitTest(Point p)
            {
                var result = false;
                using (var path = GetPath())
                using (var pen = new Pen(LineColor, LineWidth + 2))
                    result = path.IsOutlineVisible(p, pen);
                return result;
            }
            public override void Draw(Graphics g)
            {
                using (var path = GetPath())
                using (var pen = new Pen(LineColor, LineWidth))
                    g.DrawPath(pen, path);
            }
            public override void Move(int a, int b)
            {
                Point1 = new PointF(Point1.X + a, Point1.Y + b);
                Point2 = new PointF(Point2.X + a, Point2.Y + b);
            }
            public override bool IsBlackboard()
            {
                if (Point1.X < 0 || Point1.Y < 0 || Point1.X > 721 || Point1.Y > 366 || Point2.X < 0 || Point2.Y < 0 || Point2.X > 721 || Point2.Y > 366)
                    return false;
                return true;
            }
            public override void Resize(int a)
            {
                //Считаем вектор
                var v = new PointF(Point2.X - Point1.X, Point2.Y - Point1.Y);
                //Длина вектора
                var l = (float)Math.Sqrt(v.X * v.X + v.Y * v.Y);
                //Нормирование
                v = new PointF(v.X / l, v.Y / l);
                //Новые координаты отрезка
                Point1 = new PointF(Point1.X - v.X * a, Point1.Y - v.Y * a);
                Point2 = new PointF(Point2.X + v.X * a, Point2.Y + v.Y * a);
            }
            //Деструктор

            ~Line() { }
        }

        public class Square : Figure
        {
            public int A = 100; //Задаем постоянный радиус


            //Конструктор с параметрами
            public Square(int x, int y, Color color)
            {
                this.x = x - A / 2;
                this.y = y - A / 2;
                FillColor = color;
            }
            public Square() { LineWidth = 2; LineColor = Color.Black; }
            public Color FillColor = Color.LightBlue;
            public Point Point1;

            public override GraphicsPath GetPath()
            {
                var path = new GraphicsPath();
                Rectangle pathRect = new Rectangle(x, y, A, A);
                path.AddRectangle(pathRect);
                return path;
            }
            public override bool HitTest(Point p)
            {
                var result = false;
                using (var path = GetPath())
                using (var pen = new Pen(LineColor, LineWidth + 2))
                    result = path.IsVisible(p);
                return result;
            }
            public override void Draw(Graphics g)
            {
                using (var path = GetPath())
                {
                    using (var brush = new SolidBrush(FillColor))
                        g.FillPath(brush, path);
                    using (var pen = new Pen(LineColor, LineWidth))
                        g.DrawPath(pen, path);
                }
            }
            public override void Move(int a, int b)
            {
                x = x + a;
                y = y + b;
            }
            public override bool IsBlackboard()
            {
                if (x < 0 || y < 0 || x + A > 721 || y + A > 366)
                    return false;
                return true;
            }
            public override void Resize(int a)
            {
                A = A + a;
            }
            //Деструктор
            ~Square() { }
        }
        public class Triangle : Figure
        {
            public int H = 100; //Расстояние от центра до вершин
            public Point[] p = new Point[3];//создаем три вершины треугольника
            public float alpha;
            public float beta;
            public float gamma;
            //Конструктор с параметрами
            public Triangle(int x, int y, Color color)
            {

                FillColor = color;
                this.x = x;
                this.y = y;

                p[0].X = x;
                p[0].Y = y - 2 * H / 3;
                p[1].X = x - Convert.ToInt32(H / Math.Sqrt(3));
                p[1].Y = y + 1 * H / 3;
                p[2].X = x + Convert.ToInt32(H / Math.Sqrt(3));
                p[2].Y = y + 1 * H / 3;

            }
            public Triangle() { LineWidth = 2; LineColor = Color.Black; }
            public Color FillColor = Color.LightBlue;
            public Point Point1;

            public override GraphicsPath GetPath()
            {
                var path = new GraphicsPath();
                path.AddPolygon(p);
                return path;
            }
            public override bool HitTest(Point p)
            {
                var result = false;
                using (var path = GetPath())
                using (var pen = new Pen(LineColor, LineWidth + 2))
                    result = path.IsVisible(p);
                return result;
            }
            public override void Draw(Graphics g)
            {
                using (var path = GetPath())
                {
                    using (var brush = new SolidBrush(FillColor))
                        g.FillPath(brush, path);
                    using (var pen = new Pen(LineColor, LineWidth))
                        g.DrawPath(pen, path);
                }
            }
            public override void Move(int a, int b)
            {
                p[0].X = p[0].X + a;
                p[0].Y = p[0].Y + b;
                p[1].X = p[1].X + a;
                p[1].Y = p[1].Y + b;
                p[2].X = p[2].X + a;
                p[2].Y = p[2].Y + b;
            }

            public override bool IsBlackboard()
            {
                for (int i = 0; i < 3; i++)
                    if (p[i].X < 0 || p[i].Y < 0 || p[i].X > 721 || p[i].Y > 366)
                        return false;
                return true;
            }
            public override void Resize(int a)
            {
                H = H + a;
                p[0].X = x;
                p[0].Y = y - 2 * H / 3;
                p[1].X = x - Convert.ToInt32(H / Math.Sqrt(3));
                p[1].Y = y + 1 * H / 3;
                p[2].X = x + Convert.ToInt32(H / Math.Sqrt(3));
                p[2].Y = y + 1 * H / 3;

            }

            //Деструктор
            ~Triangle() { }
        }


        class Array
        {
            public Figure[] objects; // указатель на указатель объекта 
            private int maxsize = 0;//размер массива максимальный
            private int size = 0; // размер массива
            public Array(int maxsize)
            {// конструктор                 
                objects = new Figure[maxsize];// создаю массив из объектов
                for (int i = 0; i < maxsize; ++i)
                    objects[i] = null;

            }



            public void set_value(ref Figure value)//добавление объекта в хранилище
            {
                objects[size] = value;//добавляем объект в свободную ячейку
                size++;
                return;
            }


            public Figure get_value(int i)
            {
                return objects[i];//возвращаем объект по индексу
            }
            public int get_count()
            {
                return size;//возвращаем нынешний размер массива
            }
            public void delete_value(int index)
            {
                if (index < 0 || index >= size)
                {//если выходим за нынешний размер массива

                    return;
                }
                for (int i = index + 1, j = index; i < this.size; i++, j++)
                {

                    objects[j] = objects[i];//смещаем элементы, "затирая" элемент по индексу
                }
                this.size--;
            }

            public bool Empty(int CountElem)
            {
                if (objects[CountElem] == null)
                    return true;
                else return false;
            }
        };

    }
}
