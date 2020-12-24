using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPvar1
{
    using System;

    namespace OOP_lab
    {
        // Базовый класс
        abstract class DataStrorage
        {
            protected int capacity;

            public int pCapacity
            {
                get { return capacity; }

                set { capacity = value; }
            }

            public abstract void START();
            public abstract void STOP();

            public virtual void PrintInfo()
            {
                Console.WriteLine("Capacity:\t" + capacity + " GB");
            }

            public DataStrorage()
            {
                capacity = 0;
            }

            public DataStrorage(int capacity1)
            {
                capacity = capacity1;
            }
        }



        //первая ветка
        class RemovableDisk : DataStrorage
        {
            public string Model { get; set; }

            public override void START()
            {
                Console.WriteLine(Model + " connected");
            }

            public override void STOP()
            {
                Console.WriteLine(Model + " disconnected");
            }

            public override void PrintInfo()
            {
                Console.WriteLine("************************");
                Console.WriteLine("Removable Disk");
                base.PrintInfo();
                Console.WriteLine("Model:\t" + Model);
                Console.WriteLine("************************");
            }

            public RemovableDisk() : base()
            {
                Model = "";
            }

            public RemovableDisk(string model1, int capacity1)
            : base(capacity1)
            {
                Model = model1;
            }

        }


        //вторая ветка, родительский класс
        abstract class LocalDrive : DataStrorage
        {
            public bool MovingParts{ get; set; }
            public string Model { get; set; }
            public int Price { get; set; }

            public override void START()
            {
                Console.WriteLine(Model + " started working");
            }

            public override void STOP()
            {
                Console.WriteLine(" It's time to STOP! ");
            }

            public abstract void Age();

            public override void PrintInfo()
            {

                base.PrintInfo();
                Console.WriteLine("Model:\t" + Model);
                Console.WriteLine("Price:\t" + Price);
                Console.WriteLine("Is there any moving parts?");
                Console.WriteLine(MovingParts ? "Yes" : "No");  
            }

            public LocalDrive() : base()
            {
                Model = "";
                Price = 0;
                MovingParts = true;
            }

            public LocalDrive(string model1, bool movingparts1, int price1, int capacity1)
            : base(capacity1)
            {
                Model = model1;
                MovingParts = movingparts1;
                Price = price1;
            }

        }

        //Первый класс-наследник
        class SSD : LocalDrive
        {

            public override void Age()
            {
                Console.WriteLine("I am a young technology!");
            }

            public override void PrintInfo()
            {
                Console.WriteLine("************************");
                Console.WriteLine("SSD");
                base.PrintInfo();
                Console.WriteLine("************************");
            }

            public SSD() : base() { }

            public SSD(string model1, bool movingparts1, int price1, int capacity1)
            : base(model1,movingparts1, price1,capacity1) { }
        }

        //Второй класс-наследник
        class HardDrive : LocalDrive
        {
            public override void Age()
            {
                Console.WriteLine(Model + " i am an old technology!");
            }

            public override void PrintInfo()
            {
                Console.WriteLine("************************");
                Console.WriteLine("HDD");
                base.PrintInfo();
                Console.WriteLine("************************");
            }

            public HardDrive() : base() { }

            public HardDrive(string model1, bool movingparts1, int price1, int capacity1)
            : base(model1, movingparts1, price1, capacity1) { }
        }


        //третья ветка
        class Web : DataStrorage
        {
            public string localStorage { get; set; }
            public string sessionStorage { get; set; }

            public override void START()
            {
                Console.WriteLine("localStorage and sessionStorage are ready!");
            }

            public override void STOP()
            {
                Console.WriteLine("localStorage: the stored data is saved across browser sessions");
                Console.WriteLine("sessionStorage: data is cleared when the page session ends.");
            }

            public override void PrintInfo()
            {
                Console.WriteLine("************************");
                Console.WriteLine("Web Data Storage");
                base.PrintInfo();
                Console.WriteLine("localStorage:\t" + localStorage);
                Console.WriteLine("sessionStorage:\t" + sessionStorage);
                Console.WriteLine("************************");
            }

            public Web() : base()
            {
                localStorage = "";
                sessionStorage = "";
            }

            public Web(string localStorage1, string sessionStorage1, int capacity1)
            : base(capacity1)
            {
                localStorage = localStorage1;
                sessionStorage = sessionStorage1;
            }

        }


        class Program
        {
            static void Main(string[] args)
            {
                SSD s1 = new SSD("Samsung 970 Pro ",false,4500,512);
                s1.PrintInfo();
                s1.START();
                s1.STOP();
                s1.Age();

                Console.Write("\n\n\n");

                RemovableDisk USB1 = new RemovableDisk("Kingston DataTraveler SE9", 16);
                USB1.PrintInfo();
                USB1.START();
                USB1.STOP();

                Console.Write("\n\n\n");

                Web w1 = new Web();
                w1.PrintInfo();
                w1.START();
                w1.STOP();

                Console.ReadKey();
            }
        }


    }
}

