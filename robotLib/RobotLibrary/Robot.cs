using System;
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading; 
using System.Threading.Tasks; 

namespace RobotLibrary // Объявление пространства имен RobotLibrary
{
    public class Robot // Объявление класса Robot
    {
        public string Name { get; private set; } 
        public Tuple<int, int> Position { get; private set; } 
        private Thread moveThread;

        private string directions2 = ""; 

        public Robot(string name, int x, int y) // Объявление конструктора класса Robot с параметрами name, x, y
        {
            Name = name; 
            Position = Tuple.Create(x, y); // Присвоение значению свойства Position кортежа с координатами x и y
            moveThread = new Thread(Move); 
        }

        public void StartMoving()
        {
            Thread moveThread = new Thread(Move); // Создание и инициализация объекта Thread
            moveThread.Start();
        }

        public void Move()
        {
            Random random = new Random(); 
            int direction = random.Next(4);

            switch (direction) // Оператор выбора в зависимости от значения direction
            {
                case 0: 
                    Position = Tuple.Create(Position.Item1, Position.Item2 + 1); // Изменение координаты Y на 1 (движение вперед)
                    directions2 = "вперед"; 
                    break; 
                case 1: 
                    Position = Tuple.Create(Position.Item1, Position.Item2 - 1); // Изменение координаты Y на -1 (движение назад)
                    directions2 = "назад"; 
                    break; 
                case 2:
                    Position = Tuple.Create(Position.Item1 - 1, Position.Item2); // Изменение координаты X на -1 (движение влево)
                    directions2 = "влево"; 
                    break;
                case 3:
                    Position = Tuple.Create(Position.Item1 + 1, Position.Item2); // Изменение координаты X на 1 (движение вправо)
                    directions2 = "вправо";
                    break; 
            }
            Thread.Sleep(1000); // Приостановка выполнения потока на 1 секунду
        }

        public string GetInfo()
        {
            return $"{Name} {directions2} ({Position.Item1}, {Position.Item2})"; // Возврат строки с информацией о роботе (имя, направление, координаты)
        }
    }
}