namespace VRPool_d00
{
    public static partial class Subject
    {
        private static void WriteInFile(string fileName, string content)
        {
            if (fileName == null || content == null)
                throw new System.ArgumentNullException("fileName or content is null.");
            if (!System.IO.File.Exists(fileName))
                throw new System.IO.FileNotFoundException(fileName + " doesn't exist.");
        }

        public class Weapon
        {
            public Weapon(int damage)
            {
                _damage = damage;
            }

            public int _damage { private set; get; }
        }
    }
}