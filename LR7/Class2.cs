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

        //Функция, убирающая выделение объектов
        private void SelectionRemove(ref Array storage)
        {
            for (int i = 0; i < storage.get_count(); ++i)
                //Если хранилище не пусто, то происходит..
                if (!storage.Empty(i))
                {
                    storage.objects[i].LineColor = Color.Black; //установка стандартного цвета
                    RedrawFigures(ref storage);// перерисовываем
                }
        }
        // функция перерисовки объектов
        private void RedrawFigures(ref Array storage)
        {
            panel1.Refresh();// очищаем панель
            for (int i = 0; i < storage.get_count(); i++)
            {
                storage.objects[i].Draw(g);// вызываем метод draw  у объекта
            }
        }
        //Функция, возвращающая индекс объекта
        private int CheckFigure(ref Array storage, int Size, int x, int y)
        {
            Point p = new Point(x, y);
            if (storage.get_count() != 0)
            {
                for (int i = 0; i < Size; ++i)
                {
                    if (storage.objects[i].HitTest(p))// вызываем функцию проверки находится ли курсор внутри контура объекта
                        return i;// возвращает индекс объекта
                }
            }
            return -1;// возвращает -1 если такого объекта не нашлось
        }


    }
}
