using System;

namespace QuizApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Création des questions
            string[] questions =
            {
                "Quel est l'animal le plus rapide au monde ?",
                "Qui bas le record du monde de jeu de fléchettes ?",
                "En quelle année est décédée Elizabeth II ?"
            };

            string[] answers =
            {
                "A. HamsterZila \nB. BrebisPhaon \nC. SanglierBinouz",
                "A. Jean-Jacques Coldman \nB. Mylène Fermière \nC. Renault la voiture \nD. Dieu pas donné",
                "A. 2022 \nB. 2023 \nC. 2024"
            };

            int[] correctAnswers =
            {
                1, 3, 0 
            };
            int playerScore = 0;


            Console.WriteLine("Bienvenue dans la meilleure application de Quizz claquée au sol ! :)");
            for (int iplayerScore= 0;  iplayerScore<questions.Length; iplayerScore++)
            {
                Console.WriteLine("Questions " + (iplayerScore + 1));
                Console.WriteLine(questions[iplayerScore]);
                Console.WriteLine(answers[iplayerScore]);
                Console.WriteLine("S'il vous plait, entrez votre réponse ('A', 'B', 'C' ou 'D'): ");
                string playerAnswer = Console.ReadLine();

                // Valider les réponses

                if(string.Equals(playerAnswer, "A", StringComparison.OrdinalIgnoreCase) && correctAnswers[iplayerScore] == 0)
                {
                    playerScore++;
                }
                else if(string.Equals(playerAnswer, "B", StringComparison.OrdinalIgnoreCase) && correctAnswers[iplayerScore] == 1)
                {
                    playerScore++;
                }
                else if(string.Equals(playerAnswer, "C", StringComparison.OrdinalIgnoreCase) && correctAnswers[iplayerScore] == 2)
                {
                    playerScore++;
                }
                else if(string.Equals(playerAnswer, "D", StringComparison.OrdinalIgnoreCase) && correctAnswers[iplayerScore] == 3)
                {
                    playerScore++;
                }
            }

            // Afficher le score de l'utilisateur
            Console.WriteLine("Le Quizz est terminé !");
            Console.WriteLine("Bravo ! Ton score est de : " + playerScore + "/" + questions.Length);

        }
    }
}