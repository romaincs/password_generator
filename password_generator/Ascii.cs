using System;
namespace password_generator
{
    public class Ascii
    {
        public static bool EstChiffre(byte value)
        {
            return value >= 48 && value < 58;
        }

        public static bool EstMajuscule(byte value)
        {
            return value >= 65 && value < 91;
        }

        public static bool EstMinuscule(byte value)
        {
            return value >= 97 && value < 123;
        }
    }
}

