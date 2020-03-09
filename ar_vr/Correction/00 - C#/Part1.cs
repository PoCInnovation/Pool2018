namespace VRPool_d00
{
    public static partial class Subject
    {
        public static string Add(string a, string b)
        {
            if (a == null)
                return (b);
            if (b == null)
                return (a);
            return (a + b);
        }

        public static uint GetNbOccurance(string str, char c)
        {
            if (str == null)
                throw new System.ArgumentNullException("str is null.");
            uint nb = 0;
            foreach (char cr in str)
            {
                if (cr == c)
                    nb++;
            }
            return (nb);
        }

        public static string PublicWriteInFile(string fileName, string content)
        {
            try
            {
                WriteInFile(fileName, content);
            }
            catch (System.ArgumentNullException)
            {
                return ("Argument is null");
            }
            catch (System.IO.FileNotFoundException)
            {
                return ("File not found");
            }
            return (null);
        }

        public static string[] MakeArray(string val1, string val2, string val3)
        {
            return (new string[] { val1, val2, val3 });
        }

        public static System.Collections.Generic.List<string> AddIntToStringList(System.Collections.Generic.List<string> strList, int val)
        {
            if (strList == null)
                return (null);
            strList.Add(val.ToString());
            return (strList);
        }

        public static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        public static uint NbStrstr(string a, string b)
        {
            if (a == null || b == null)
                throw new System.ArgumentNullException("Argument is null");
            uint result = 0;
            for (int i = 0; i < a.Length; i++)
            {
                for (int y = 0; y < b.Length; y++)
                {
                    if (i + y >= a.Length)
                        break;
                    if (a[i + y] != b[y])
                    {
                        break;
                    }
                    if (b.Length == y + 1)
                    {
                        result++;
                        break;
                    }
                }
            }
            return (result);
        }

        public static string AddInf(string a, string b)
        {
            if (a == null || b == null)
                return (null);
            int indexA = a.Length - 1;
            int indexB = b.Length - 1;
            string finalStr = "";
            int retenu = 0;
            while (indexA >= 0 || indexB >= 0)
            {
                char curr = (char)(((indexA >= 0) ? (a[indexA] - '0') : (0)) + ((indexB >= 0) ? (b[indexB] - '0') : (0)));
                curr += (char)retenu;
                retenu = 0;
                if (curr > 9)
                {
                    retenu = curr / 10;
                    curr = (char)(curr % 10);
                }
                finalStr = (char)(curr + '0') + finalStr;
                indexA--;
                indexB--;
            }
            finalStr = retenu.ToString() + finalStr;
            while (finalStr.Length > 1 && finalStr[0] == '0')
                finalStr = finalStr.Substring(1, finalStr.Length - 1);
            return (finalStr);
        }

        public static string Definition(string japaneseWord)
        {
            string url = "http://jisho.org/api/v1/search/words?keyword=" + japaneseWord;
            using (System.Net.WebClient w = new System.Net.WebClient())
            {
                string json = w.DownloadString(url);
                json = json.Split(new string[] { "english_definitions\":[\"" }, System.StringSplitOptions.None)[1];
                string finalWord = "";
                foreach (char c in json)
                {
                    if (c == '"')
                        break;
                    else
                        finalWord += c;
                }
                return (finalWord);
            }
        }

        public static string[] GetWeaponDescription(string weaponName)
        {
            string[] result = new string[] { "", "" };
            string url = "https://kancolle.wikia.com/api/v1/Search/List?query=" + weaponName + "&limit=1";
            using (System.Net.WebClient w = new System.Net.WebClient())
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                w.Encoding = System.Text.Encoding.UTF8;
                string json = w.DownloadString(url);
                json = json.Split(new string[] { "id\":" }, System.StringSplitOptions.None)[1];
                string id = "";
                foreach (char c in json)
                {
                    if (c == ',')
                        break;
                    else
                        id += c;
                }
                url = "http://kancolle.wikia.com/api/v1/Articles/AsSimpleJson?id=" + id;
                json = w.DownloadString(url);
                json = json.Split(new string[] { "\"title\":\"Introduction\"," }, System.StringSplitOptions.None)[1];
                string[] texts = json.Split(new string[] { "\"text\":\"" }, System.StringSplitOptions.None);
                char prev;
                for (int i = 0; i < 2; i++)
                {
                    prev = '\0';
                    foreach (char c in texts[i + 1])
                    {
                        if (c == '"' && prev != '\\')
                            break;
                        else
                            result[i] += c;
                        prev = c;
                    }
                    result[i] = System.Text.RegularExpressions.Regex.Replace(
                            result[i],
                            @"\\[Uu]([0-9A-Fa-f]{4})",
                            m => char.ToString(
                                (char)ushort.Parse(m.Groups[1].Value, System.Globalization.NumberStyles.AllowHexSpecifier)));
                    result[i] = result[i].Replace("\\n", "\n");
                    result[i] = result[i].Replace("\\\"", "\"");
                }
            }
            return (result);
        }

        public class Character
        {
            public Character(string name, int hp = 100)
            {
                _name = name;
                _hpMax = hp;
                _hp = hp;
                w = new Weapon(10);
            }

            private void TakeDamage(int value)
            {
                _hp -= value;
                if (_hp <= 0)
                    _hp = 0;
            }

            public void Attack(Character target)
            {
                if (target != null && _hp > 0)
                    target.TakeDamage(w._damage);
            }

            public override string ToString()
            {
                return (_name + " (" + (_hp * 100 / _hpMax) + "%)");
            }
            
            public string _name { private set; get; }
            private int _hp, _hpMax;
            private Weapon w;
        };

        public abstract class Ship
        {
            protected Ship(string name, int hp, int torpedoes, int depthCharge, int antiAir, int firePower)
            {
                _name = name;
                _hp = hp;
                _hpMax = _hp;
                _torpedoes = torpedoes;
                _depthCharge = depthCharge;
                _antiAir = antiAir;
                _firePower = firePower;
            }

            protected int _hp { private set; get; }
            private int _hpMax;
            private int _torpedoes, _depthCharge, _firePower;
            public int _antiAir { private set; get; }
            private string _name;

            public void TakeDamage(int value)
            {
                _hp -= value;
                if (_hp < 0)
                    _hp = 0;
            }

            public virtual void Attack(Ship target)
            {
                if (_hp <= 0)
                    return;
                if (target.GetShipType() == "SS")
                {
                    if (_depthCharge > 0)
                    {
                        _depthCharge--;
                        target.TakeDamage(80);
                    }
                }
                else
                {
                    if (_torpedoes > 0)
                    {
                        _torpedoes--;
                        target.TakeDamage(70);
                    }
                    else
                        target.TakeDamage(_firePower);
                }
            }

            public bool IsAlive()
            {
                return (_hp > 0);
            }

            public abstract string GetShipType();

            public override string ToString()
            {
                return (_name + " - " + GetShipType() + " (" + (_hp * 100 / _hpMax) + "%)");
            }
        }

        public class Destroyer : Ship
        {
            public Destroyer(string name) : base(name, 100, 2, 4, 1, 30)
            { }

            public override string GetShipType()
            {
                return ("DD");
            }
        }

        public class Submarine : Ship
        {
            public Submarine(string name) : base(name, 75, 5, 0, 0, 0)
            { }

            public override string GetShipType()
            {
                return ("SS");
            }
        }

        public class AircraftCarrier : Ship
        {
            public AircraftCarrier(string name) : base(name, 200, 0, 0, 1, 0)
            {
                nbPlanes = 25;
            }

            public override void Attack(Ship target)
            {
                if (_hp <= 0 || target.GetShipType() == "SS")
                    return;
                int currPlanes = (nbPlanes >= 5) ? (5) : (nbPlanes);
                if (currPlanes == 0)
                    return;
                nbPlanes -= currPlanes;
                if (target.IsAlive())
                    currPlanes -= target._antiAir;
                if (currPlanes <= 0)
                    return;
                target.TakeDamage(70 * currPlanes);
                if (target.IsAlive())
                    currPlanes -= target._antiAir;
                if (currPlanes <= 0)
                    return;
                nbPlanes += currPlanes;
            }

            private int nbPlanes;

            public override string GetShipType()
            {
                return ("CV");
            }
        }

        public class Battleship : Ship
        {
            public Battleship(string name) : base(name, 300, 0, 0, 3, 80)
            { }

            public override string GetShipType()
            {
                return ("BB");
            }
        }
    }
}
