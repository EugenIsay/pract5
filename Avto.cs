using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avto_Gruz
{
    internal class Avto
    {
        Input read = new Input();
        ConsoleKeyInfo key;
        protected float speed;
        protected float capacity;
        protected float consumption;
        protected float amount;
        protected float allrunway = 0;
        protected float runway = 0;
        protected float time;
        protected float alltime;
        protected float weight;
        protected float temp0;
        protected float result;
        protected float way;
        public bool restart = false;
        public virtual void Info( float capacity, float consumption, float speed, float weight)
        {
            this.capacity = capacity;
            amount = capacity;
            this.consumption = consumption / 100;
            this.speed = speed;
        }
        public void Input_Distance(float distance)
        {
            Move(distance);
        }
        protected void Refueling(float amount)
        {
            if (amount + this.amount < capacity)
            {
                this.amount += amount;
            }
            else
            {
                Console.WriteLine("Ошибка ввода. Введите заново");
                read.read_show(out float A);
                Refueling(A);
            }
        }
        protected void Move(float distance)
        {
            Console.WriteLine(" ");
            Console.WriteLine($"Надо проехать {Math.Round(distance + runway, 2)}");
            if (Distance_pass(distance) < 0)
            {
                Not_enough_fuel(distance);
            }
            else
            {
                runway = 0;
                time = (distance - Acceleration_Distance(weight)) / speed + Acceleration_Time(weight);
                amount -= distance * consumption;
                alltime += time;
                allrunway += distance;
                Console.WriteLine($"Пройдено за этот раз {Math.Round(distance, 2)}");
                Show();
                time = 0;
            }
        }
        protected float Distance_pass(float distance)
        {
            distance -= Acceleration_Distance(weight);
            way = (amount - (Acceleration_Distance(weight) * consumption)) / consumption;
            result = way - distance;
            return result;
        }
        protected void Not_enough_fuel(float distance)
        {
            time = way / speed + Acceleration_Time(weight);
            way = Acceleration_Distance(weight) + time * speed;
            runway += way;
            alltime += time;
            allrunway += way;
            distance -= way;
            amount = 0;
            Console.WriteLine($"Пройдено за этот раз {Math.Round(way, 2)}");
            Show();
            Console.WriteLine("Топливо закончилось. Хотите заправить? Y/N");
        input:
            key = Console.ReadKey(true);
            switch (key.Key.ToString())
            {
                case "Y":
                    Console.WriteLine("Сколько вы хотите заправить?");
                    read.read_show(out float A);
                    Refueling(A);
                    Move(distance);
                    break;
                case "N":
                    Console.WriteLine("Вы хотите выйти или начать заново? E - выйти, R - начать заново");
                    key = Console.ReadKey(true);
                    switch (key.Key.ToString())
                    {
                        case "E":
                            Environment.Exit(0);
                            break;
                        case "R":
                            restart = true;
                            break;
                    }
                    break;
                default:
                    goto input;
            }
        }
        protected virtual float F()
        {
            result = speed * 18000 / temp0;
            return result;
        }
        protected float Acceleration_Distance(float weight)
        {
            result = ((float)Math.Pow(speed, 2) * weight) / (2 * F());
            return result;
        }
        protected float Acceleration_Time(float weight)
        {
            result = speed * weight /F();
            return result;
        }
        protected void Show()
        {
            Console.WriteLine($"Пройдено всего {Math.Round(allrunway, 2)}");
            Console.WriteLine($"Осталось топлива {Math.Round(amount, 2)}");
            Console.WriteLine($"Время всего пути {Math.Floor(alltime)} часов {Math.Round((Math.Round(alltime, 2) - Math.Floor(alltime)) * 60)} минуты");
            Console.WriteLine($"Время в этом пути {Math.Floor(time)} часов {Math.Round((Math.Round(time, 2) - Math.Floor(time)) * 60)} минуты");
        }
    }
}
