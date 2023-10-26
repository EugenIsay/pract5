using Avto_Gruz;
class Programm
{
    public static void Main()
    {
        Random rnd = new Random();
        Bus bus = new Bus();
        Truck truck = new Truck();
        Input read = new Input();
        ConsoleKeyInfo key;
    start:
        Console.WriteLine("Выберите транспортное средство");
        key = Console.ReadKey(true);
        if (key.Key.ToString() != "B" && key.Key.ToString() != "T")
            goto start;
        Console.WriteLine("Введите объём бака");
        read.read_show(out float V);
        Console.WriteLine("Введите потребление бака л/ч км");
        read.read_show(out float P);
        Console.WriteLine("Введите максимальную скорость машины");
        read.read_show(out float S);
        switch (key.Key.ToString())
        {
            case "B":
                Console.WriteLine("Количество пассажиров");
                read.read_show(out float People);
                bus.Info(V, P, S, People);
                break;    
            case "T":
                Console.WriteLine("Массу перевозимого груза");
                read.read_show(out float Kg);
                truck.Info(V, P, S, Kg);
                break;
        }
        while (true)
        {
            if (key.Key.ToString() == "B")
            {
                bus.Move(rnd.Next(1, 200));
            }
            else if (key.Key.ToString() == "T")
            {
                truck.Move(rnd.Next(1, 200));
            }
            else break;

            Console.WriteLine("Нажмите на любую кнопку чтобы продолжить");
            Console.ReadKey();
        }
    }
}