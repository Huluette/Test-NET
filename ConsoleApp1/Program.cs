using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    class Program
    {
        static void Main()
        {

            // Lire le contenant du fichier CSV 
            string wayCsv = @"C:\Users\Utilisateur\source\repos\Test-NET\ConsoleApp1\QuestionsExample.csv";
            string[] rowCsv = System.IO.File.ReadAllLines(wayCsv);
     
            // Créer des variables qui correspondent aux listes du fichier csv 
            var questions = new List<string>(); // Créer la liste des questions
            int questionsNumber = 1; // Initialiser le numéro de la question à 1
            var answers = new List<string>(); // Créer la liste des réponses
            var correctAnswers = new List<int>(); // Créer la liste des bonnes réponses
            int score = 0; // Initialiser le score à zéro

            // Fait appel à la colonne 0 pour appeler les questions dans les lignes
            for (int questionsAnswers = 0; questionsAnswers < rowCsv.Length; questionsAnswers++)
            {
                string[] columnData = rowCsv[questionsAnswers].Split(';');

                questions.Add(columnData[0]);
                answers.Add(columnData[1]);

                // Convertir la dernière colonne en int pour avoir la réponse correcte
                correctAnswers.Add(int.Parse(columnData[2]));
            }

            // 
            Console.WriteLine("Question pour un champion :");

            for (int questionsAnswers = 0; questionsAnswers < questions.Count; questionsAnswers++)
            {
                Console.WriteLine($"{questionsNumber}) " + questions[questionsAnswers]);
                questionsNumber++;

                string[] possibleAnswers = answers[questionsAnswers].Split('/'); // Séparer les réponses
                int answerNumber = 1; // Initialiser le numéro de réponse à 1
                foreach (string answer in possibleAnswers)
                {
                    Console.WriteLine($"{answerNumber}. {answer}"); // Afficher le numéro de réponse suivi de la réponse
                    answerNumber++; // Incrémenter le numéro de réponse pour la prochaine réponse
                }
                
                // Ecrire la réponse
                Console.WriteLine("Ecrivez votre réponse :");
                Console.ReadLine();

                // Afficher la réponse correcte après avoir parcouru toutes les propositions
                Console.WriteLine($"La réponse correcte est : {correctAnswers[questionsAnswers]}");
            }


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///// Ecriture en 'brut' 
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //// Création des questions
            //string[] questions =
            //{
            //    "Quel est l'animal le plus rapide au monde ?",
            //    "Qui bas le record du monde de jeu de fléchettes ?",
            //    "En quelle année est décédée Elizabeth II ?"
            //};

            //// Création des réponses
            //string[] answers =
            //{
            //    "A. HamsterZila \nB. BrebisPhaon \nC. SanglierBinouz",
            //    "A. Jean-Jacques Coldman \nB. Mylène Fermière \nC. Renault la voiture \nD. Dieu pas donné",
            //    "A. 2022 \nB. 2023 \nC. 2024"
            //};

            //// Equivault aux bonnes réponses 
            //int[] correctAnswers =
            //{
            //    1, 3, 0 
            //};

            //// Valeur du score du joueur par défaut
            //int playerScore = 0;


            //Console.WriteLine("Bienvenue dans la meilleure application de Quizz claquée au sol ! :)");

            //// Boucle permettant de modifier le score du joueur
            //for (int iplayerScore= 0;  iplayerScore<questions.Length; iplayerScore++)
            //{
            //    Console.WriteLine("Questions " + (iplayerScore + 1));
            //    Console.WriteLine(questions[iplayerScore]);
            //    Console.WriteLine(answers[iplayerScore]);
            //    Console.WriteLine("S'il vous plait, entrez votre réponse ('A', 'B', 'C' ou 'D'): ");
            //    string playerAnswer = Console.ReadLine();

            //    // Valider les réponses
            //    if(string.Equals(playerAnswer, "A", StringComparison.OrdinalIgnoreCase) && correctAnswers[iplayerScore] == 0)
            //    {
            //        playerScore++;
            //    }
            //    else if(string.Equals(playerAnswer, "B", StringComparison.OrdinalIgnoreCase) && correctAnswers[iplayerScore] == 1)
            //    {
            //        playerScore++;
            //    }
            //    else if(string.Equals(playerAnswer, "C", StringComparison.OrdinalIgnoreCase) && correctAnswers[iplayerScore] == 2)
            //    {
            //        playerScore++;
            //    }
            //    else if(string.Equals(playerAnswer, "D", StringComparison.OrdinalIgnoreCase) && correctAnswers[iplayerScore] == 3)
            //    {
            //        playerScore++;
            //    }
            //}

            //// Afficher le score de l'utilisateur
            //Console.WriteLine("Le Quizz est terminé !");
            //Console.WriteLine("Bravo ! Ton score est de : " + playerScore + "/" + questions.Length);

        }
    }
}