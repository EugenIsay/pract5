using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avto_Gruz
{
    internal class Input
    {
        ConsoleKeyInfo key;
        private string read;
        private bool dot;
        public void read_show(out float arg0)
        {
            arg0 = read_key();
            Console.WriteLine(" ");
        }
        public void read_show_without_dot(out float arg0)
        {
            arg0 = read_key_without_dot();
            Console.WriteLine(" ");
        }
        private float read_key()
        {
            read = "";
            dot = false;
            while (true)
            {
                key = Console.ReadKey(true);
                switch (key.Key.ToString())
                {
                    case "D1":
                    case "D2":
                    case "D3":
                    case "D4":
                    case "D5":
                    case "D6":
                    case "D7":
                    case "D8":
                    case "D9":
                    case "D0":
                        read += key.Key.ToString().Remove(0, 1);
                        Console.Write(key.Key.ToString().Remove(0, 1));
                        break;
                    case "OemComma":
                        if (dot == false)
                        {
                            read += ",";
                            dot = true;
                            Console.Write(",");
                        }
                        break;
                    case "Enter":
                    case "Spacebar":
                        if (read.Length > 0 && float.Parse(read) > 0)
                        {
                            Console.Write(" ");
                            goto end;
                        }
                        break;
                    case "Backspace":
                        if (read.Length > 0)
                        {
                            if (read.Substring(read.Length - 1) == ",")
                                dot = false;
                            read = read.Remove(read.Length - 1, 1);
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                            Console.Write(" ");
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        }
                        break;
                    default:
                        break;
                }
            }
        end:;
            return float.Parse(read);
        }
        private float read_key_without_dot()
        {
            read = "";
            dot = false;
            while (true)
            {
                key = Console.ReadKey(true);
                switch (key.Key.ToString())
                {
                    case "D1":
                    case "D2":
                    case "D3":
                    case "D4":
                    case "D5":
                    case "D6":
                    case "D7":
                    case "D8":
                    case "D9":
                    case "D0":
                        read += key.Key.ToString().Remove(0, 1);
                        Console.Write(key.Key.ToString().Remove(0, 1));
                        break;
                    case "Enter":
                    case "Spacebar":
                        if (read.Length > 0 && float.Parse(read) > 0)
                        {
                            Console.Write(" ");
                            goto end;
                        }
                        break;
                    case "Backspace":
                        if (read.Length > 0)
                        {
                            read = read.Remove(read.Length - 1, 1);
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                            Console.Write(" ");
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                            Console.WriteLine($" {read} ");
                        }
                        break;
                    default:
                        break;
                }
            }
        end:;
            return float.Parse(read);
        }
        public bool check_speed(float arg0, string transport)
        {
            if (transport == "B" && arg0 < 100 && arg0 > 20) return true;
            else if (transport == "T" && arg0 < 90 && arg0 > 30) { return true; }
            else { Console.WriteLine("Неправильная скорость. Введите заново"); return false; }
        }
    }
}


