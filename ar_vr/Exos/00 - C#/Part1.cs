namespace VRPool_d00
{
    public static partial class Subject
    {
        public static string Add(string a, string b)
        {
            throw new System.NotImplementedException();
        }

        public static uint GetNbOccurance(string str, char c)
        {
            throw new System.NotImplementedException();
        }

        public static string PublicWriteInFile(string fileName, string content)
        {
            throw new System.NotImplementedException();
        }

        public static string[] MakeArray(string val1, string val2, string val3)
        {
            throw new System.NotImplementedException();
        }

        public static System.Collections.Generic.List<string> AddIntToStringList(System.Collections.Generic.List<string> strList, int val)
        {
            throw new System.NotImplementedException();
        }

        public static void Swap(ref int a, ref int b)
        {
            throw new System.NotImplementedException();
        }

        public static uint NbStrstr(string a, string b)
        {
            throw new System.NotImplementedException();
        }

        public static string AddInf(string a, string b)
        {
            throw new System.NotImplementedException();
        }

        public static string Definition(string japaneseWord)
        {
            throw new System.NotImplementedException();
        }

        public static string[] GetWeaponDescription(string weaponName)
        {
            throw new System.NotImplementedException();
        }

        public class Character
        {
            public Character(string name, int hp = 100)
            {
            }

            private void TakeDamage(int value)
            {
            }

            public void Attack(Character target)
            {
            }

            public override string ToString()
            {
                throw new System.NotImplementedException();
            }

#pragma warning disable 0169
            public string _name { private set; get; }
            private int _hp, _hpMax;
            private Weapon w;
#pragma warning restore 0169
        };

        public abstract class Ship
        {
            protected Ship(string name, int hp, int torpedoes, int depthCharge, int antiAir, int firePower)
            {
            }

#pragma warning disable 0169
            protected int _hp { private set; get; }
            private int _hpMax;
            private int _torpedoes, _depthCharge, _firePower;
            public int _antiAir { private set; get; }
            private string _name;
#pragma warning restore 0169

            public void TakeDamage(int value)
            {
            }

            public virtual void Attack(Ship target)
            {
            }

            public abstract string GetShipType();

            public override string ToString()
            {
                throw new System.NotImplementedException();
            }
        }

        public class Destroyer : Ship
        {
            public Destroyer(string name) : base(null, 0, 0, 0, 0, 0)
            { }

            public override string GetShipType()
            {
                throw new System.NotImplementedException();
            }
        }

        public class Submarine : Ship
        {
            public Submarine(string name) : base(null, 0, 0, 0, 0, 0)
            { }

            public override string GetShipType()
            {
                throw new System.NotImplementedException();
            }
        }

        public class AircraftCarrier : Ship
        {
            public AircraftCarrier(string name) : base(null, 0, 0, 0, 0, 0)
            {
            }

            public override string GetShipType()
            {
                throw new System.NotImplementedException();
            }
        }

        public class Battleship : Ship
        {
            public Battleship(string name) : base(null, 0, 0, 0, 0, 0)
            { }

            public override string GetShipType()
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
