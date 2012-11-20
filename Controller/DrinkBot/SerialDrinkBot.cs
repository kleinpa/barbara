using DrinkBotLib.Model;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkBotLib
{
    public class SerialDrinkBot : DrinkMaker
    {
        private static SerialDrinkBot local = null;
        public static SerialDrinkBot Local
        {
            get
            {
                if (local == null)
                {
                    var ingredients = new string[]{"Gin", "Tonic Water", "Wine"};
                    using(var db = new DrinkBotEntities())
                    {
                        local = new SerialDrinkBot("COM3", ingredients.Select(name => db.Ingredients.Single(i => i.Name == name)));
                    }
                }
                return local;
            }

        }

        public Dictionary<Ingredient, byte> Ingredients { get; set; }

        private SerialPort serialPort;

        private double unitSize = 0.125; // 1/8 of an ounce;

        private int UnitTime 
        {
            set
            {
                this.Send(Command.SetUnitSize(value));
            }

        }

        public SerialDrinkBot(string portName, IEnumerable<Ingredient> ingredients, int unitTime = 1400)
        {
            int i = 0;
            var ingredientList = new Dictionary<Ingredient, byte>();
            foreach (var ingredient in ingredients)
            {
                ingredientList[ingredient] = (byte)i++;
            }
            this.Ingredients = ingredientList;


            serialPort = new SerialPort(portName, 9600);
            serialPort.Open();
            Reset();

            this.UnitTime = unitTime;
        }

        public override void Dispense(IEnumerable<KeyValuePair<Ingredient, double>> recipe)
        {
            foreach (var kv in recipe)
            {
                Dispense(kv.Key, kv.Value);
            }
        }

        private void Dispense(Ingredient ingredient, double amount)
        {
            
            this.Send(Command.Dispense(Ingredients.Single(kv => kv.Key.ID == ingredient.ID).Value, (byte)(amount/unitSize)));
        }

        private void Reset()
        {
            
            this.Send(Command.Reset());
        }

        private void SetUnitSize(int size)
        {
            
        }

        private void Send(Command c)
        {
            serialPort.Write(c.GetBytes(), 0, 3);
        }

        private struct Command
        {
            public byte Type, Param1, Param2;

            public Command(byte type, byte param1 = 0, byte param2 = 0)
            {
                this.Type = type;
                this.Param1 = param1;
                this.Param2 = param2;
            }

            public byte[] GetBytes()
            {
                return new byte[]{Type, Param1, Param2};
            }

            public static Command Reset()
            {
                return new Command(114);
            }

            public static Command StartPour(byte d)
            {
                return new Command(111, d);
            }

            public static Command StopPour(byte d)
            {
                return new Command(99, d);
            }

            public static Command Dispense(byte d, byte amount)
            {
                return new Command(100, d, amount);
            }

            public static Command SetUnitSize(int i)
            {
                return new Command(117, 0, (byte)i);
            }
        }
    }
}
