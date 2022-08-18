using System;
using System.Text;

namespace password_generator
{
    class Program
    {
        public static void Main(string[] args)
        {
            const int NB_MOT_DE_PASSE_GENERE = 5;

            int len = DemanderLongeurMdp();
            PasswordType mdpType = DemanderTypeMdp();

            for (int i = 0; i < NB_MOT_DE_PASSE_GENERE; i++)
            {
                PasswordGenerator passGen = new(len, mdpType);
                string mdp = passGen.Generer();

                Console.WriteLine(mdp);
            }

            Exit();
        }

        private static void Exit()
        {
            Console.WriteLine("Appuyez sur une touche pour quitter");
            Console.ReadLine();
        }

        private static PasswordType DemanderTypeMdp()
        {
            Console.WriteLine("Vous voulez un mot de passe avec: ");
            Console.WriteLine("1 - Uniquement des caractères en majuscule");
            Console.WriteLine("2 - Des caractères minuscules et majuscules");
            Console.WriteLine("3 - Des caractères et des chiffres");
            Console.WriteLine("4 - Caractères, chiffres et caractères spéciaux");


            int choixInt = 0;
            try
            {
                string? choix = Console.ReadLine();
                if (string.IsNullOrEmpty(choix))
                    throw new Exception();

                choixInt = int.Parse(choix);
                if (choixInt < 1 || choixInt > 4)
                    throw new Exception();
            }
            catch 
            {
                Console.WriteLine("Vous devez saisir un type de mot de passe valide (1, 2, 3 ou 4)");
            }

            return (PasswordType)choixInt;

        }

        private static int DemanderLongeurMdp()
        {
            Console.WriteLine("Longeur du mot de passe : ");

            int lenInt = 0;
            try
            {
                string? len = Console.ReadLine();
                if (string.IsNullOrEmpty(len))
                    throw new Exception();
                lenInt = int.Parse(len.ToString());
            }
            catch
            {
                Console.WriteLine("Vous devez saisir un entier valide pour la longeur du mot de passe");
            }

            return lenInt;
        }
    }
}