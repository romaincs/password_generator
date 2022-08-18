using System;
using System.Text;

namespace password_generator
{
    public enum PasswordType
    {
        Simple = 1,
        Avance = 2,
        Complexe = 3,
        Expert = 4,
    }

    public class PasswordGenerator
    {
        private int _longeur;
        private PasswordType _type;

        public PasswordGenerator(int longeur, PasswordType type)
        {
            _longeur = longeur;
            _type = type;
        }

        public string Generer()
        {
            byte[] values = getAsciiValues();

            byte[] buffer = new byte[_longeur];
            for (int i = 0; i < _longeur; i++)
            {
                Random r = new Random();
                buffer[i] = values[r.Next(values.Length)];
            }

            return Encoding.ASCII.GetString(buffer);
        }

        private byte[] getAsciiValues()
        {
            List<byte> values = new List<byte>();
            for (byte i = 48; i < 123; i++)
            {
                if (_type == PasswordType.Expert)
                    values.Add(i);
                else
                {
                    if (_type == PasswordType.Avance && Ascii.EstChiffre(i))
                        values.Add(i);
                    else if (_type == PasswordType.Expert && Ascii.EstMajuscule(i))
                        values.Add(i);
                    else if (Ascii.EstMinuscule(i))
                        values.Add(i);
                }

            }
            return values.ToArray();
        }
    }
}

