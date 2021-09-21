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
using System.IO;

namespace LR7
{
    public partial class Form1 : Form
    {
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
                for (int i = index + 1, j = index; i <= this.size; i++, j++)
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

            public void SaveFigures(string filename)//сохранение данных о фигурах в текстовый файл
            {              
                StreamWriter writer = new StreamWriter(filename, true, System.Text.Encoding.Default); //создаем «потоковый писатель» и связываем его с файловым потоком
                writer.WriteLine(size); //записываем в файл с добавлением новой строки

                for (int i = 0; i < size; ++i)
                    objects[i].Save(writer);
                writer.Close(); //закрываем поток. Не закрыв поток, в файл ничего не запишется
            }
            public void ReadFigures(string filename)//чтение из текстового файла
            {
                List<string> list = File.ReadAllLines("C:/Users/User/Desktop/учеба/2 КУРС/ООП/1/LR7/LR7/bin/Debug/Figures.txt").ToList();                              
                int count = Int32.Parse(list[0]);
                list.RemoveAt(0);
                for (int i = 0; i < count; ++i)
                {
                   objects[i] = SwitchFigure(ref list);
                    size++;
                    // SwitchFigure(ref reader);
                }


            }
        };
       

        }
}
