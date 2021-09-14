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

            public void LoadFigures(char filename)//сохранение данных о фигурах в текстовый файл
            {
                //File.Create("C:/Users/User/Desktop/учеба/2 КУРС/ООП/1/LR7/LR7/Figures.txt");// создаем файл
                //File.AppendAllText("C:/Users/User/Desktop/учеба/2 КУРС/ООП/1/LR7/LR7/Figures.txt", size); //записываем в файл количество фигур хранилища
                //FileStream file1 = new FileStream("C:/Users/User/Desktop/учеба/2 КУРС/ООП/1/LR7/LR7/Figures.txt", FileMode.Append); //открытие файла на дозапись в конец файла
                StreamWriter writer = new StreamWriter("C:/Users/User/Desktop/учеба/2 КУРС/ООП/1/LR7/LR7/Figures.txt,", true, System.Text.Encoding.Default); //создаем «потоковый писатель» и связываем его с файловым потоком
                writer.WriteLine(size + '0'); //записываем в файл с добавлением новой строки

                for (int i = 0; i < size; ++i)
                    objects[i].Save(writer);
                writer.Close(); //закрываем поток. Не закрыв поток, в файл ничего не запишется
            }
            public void ReadFigures(char filename)//чтение из текстового файла
            {
                string line;
                StreamReader reader = new StreamReader("C:/Users/User/Desktop/учеба/2 КУРС/ООП/1/LR7/LR7/Figures.txt");
                line = reader.ReadLine();
                //Console.WriteLine(line);//считываем строку с колличеством объектов
                int count = Int32.Parse(line);//записываем количество фигур
                for (int i = 0; i < count; ++i)
                {
                    // Console.WriteLine(reader.ReadLine());//
                    line = reader.ReadLine();
                    Figure f;
                    switch (line)
                    {
                        case "C":
                            f = new Circle();
                            f.Load(reader.ReadLine());
                            break;
                        case "L":
                            f = new Line();
                            f.Load(reader.ReadLine());
                            break;
                        case "S":
                            f = new Square();
                            f.Load(reader.ReadLine());
                            break;
                        case "T":
                            f = new Triangle();
                            f.Load(reader.ReadLine());
                            break;

                    }
                    reader.Close();
                }


            }
        };
    }
    }
