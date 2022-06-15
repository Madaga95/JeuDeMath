using System;

namespace JeudeMath
{
    internal class Program
    {
        enum e_Operateur
        {
            ADDITION = 1,
            MULTIPLICATION = 2,
            SOUSTRACTION = 3
        }
        static bool PoserQuestion(int min, int max)
        {
            Random rand = new Random();

            int reponseInt = 0;
   
            while (true)
            {
                int a = rand.Next(min, max+1);
                int b = rand.Next(min, max+1);
                e_Operateur o = (e_Operateur)rand.Next(1, 4);
                int resultatAttendu;
                // o => 1 ou 2
                // 1 -> addition
                // 2 -> multiplication

                if(o == e_Operateur.ADDITION)
                {
                    Console.Write(a + " + " + b + " = ");
                    resultatAttendu = a + b;
                }
                else if (o == e_Operateur.MULTIPLICATION)
                {
                    Console.Write(a + " x " + b + " = ");
                    resultatAttendu = a * b;
                }
                else if (o == e_Operateur.SOUSTRACTION)
                {
                    Console.Write(a + " - " + b + " = ");
                    resultatAttendu = a - b;
                }
                else
                {
                    // cas inconnu
                    Console.WriteLine("ERREUR : operateur inconnu");
                    return false;
                }

                string reponse = Console.ReadLine();
                try
                {
                    reponseInt = int.Parse(reponse);
                    if(reponseInt == resultatAttendu)
                    {
                        return true; 
                    }
                    return false;
                }
                catch
                {
                    Console.WriteLine("Erreur : Vous devez rentrer un nombre");
                }

            }
        }
        static void Main(string[] args)
        {
            const int NBR_MIN = 1;
            const int NBR_MAX = 10;
            const int NB_QUESTIONS = 5;

            int points = 0;

            for(int i = 0; i < NB_QUESTIONS; i++)
            {
                Console.WriteLine("Question numéro : " + (i+1) + " / " + NB_QUESTIONS);
                bool bonneReponse = PoserQuestion(NBR_MIN, NBR_MAX);
                if (bonneReponse)
                {
                    Console.WriteLine("Bravo!!");
                    points++;
                }
                else
                {
                    Console.WriteLine("Mauvaise reponse");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Nombre de point :" + points + "/" + NB_QUESTIONS);

            int moyenne = NB_QUESTIONS / 2;

            if(points == NB_QUESTIONS)
            {
                Console.WriteLine("Propre !!");
            }
            else if(points == 0)
            {
                Console.WriteLine("Aie !! Révise tes maths !!");
            }
            else if(points > moyenne)
            {
                Console.WriteLine("Pas mal !! Tu gére !!");
            }
            else
            {
                Console.WriteLine("Peut vraiment mieux faire !!");
            }
        }
    }
}
