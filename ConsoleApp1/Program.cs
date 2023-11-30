using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    class Program
    {
        // Apparition interface intuitive avec 3 choix
        static void Main()
        {
            bool quizRunning = true;
            while (quizRunning)
            {
                Console.WriteLine("Bienvenue au Quiz !");
                Console.WriteLine("Que voulez-vous faire ?");
                Console.WriteLine("1. Démarrer le quiz");
                Console.WriteLine("2. Choisir une catégorie");
                Console.WriteLine("3. Quitter");

                string userInput = Console.ReadLine();

                // Permet de faire un choix en inscrivant les valeurs de 1 à 3 sinon rien ne se passe
                switch (userInput)
                {
                    case "1":
                        StartQuiz();
                        quizRunning = false;
                        break;
                    case "2":
                        ChooseCategory();
                        quizRunning = false;
                        break;
                    case "3":
                        quizRunning = false;
                        Console.WriteLine("Merci d'avoir joué au Quiz. À bientôt !");
                        break;
                    default:
                        Console.WriteLine("Veuillez entrer un choix valide.");
                        break;
                }
            }
        }
        static void StartQuiz()
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

            // Accueillir l'utilisateur et lui laisser 3 choix entre Démarrer le quizz, Choisir la catégorie et quitter 

            // Fait appel à la colonne 0 pour appeler les questions dans les lignes
            for (int questionsAnswers = 0; questionsAnswers < rowCsv.Length; questionsAnswers++)
            {
                string[] columnData = rowCsv[questionsAnswers].Split(';');

                questions.Add(columnData[0]);
                answers.Add(columnData[1]);

                // Convertir la dernière colonne en int pour avoir la réponse correcte
                correctAnswers.Add(int.Parse(columnData[2]));
            }

            Console.WriteLine("Attention, c'est parti !");
            Thread.Sleep(3000); // Patiente 3 secondes
            Console.WriteLine("Question pour un champion :");

            // Affiche les questions du csv
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

                // Saisie de l'utilisateur
                bool validInput = false;
                while (!validInput)
                {
                    string userInput = Console.ReadLine();

                    if (!int.TryParse(userInput, out int userAnswer))
                    {
                        Console.WriteLine("Veuillez entrer un nombre entre 1 et 4 correspondant à la réponse.");
                    }
                    else if (userAnswer >= 1 && userAnswer <= 4)
                    {
                        // Validation de la réponse de l'utilisateur
                        if (userAnswer == correctAnswers[questionsAnswers])
                        {
                            Console.WriteLine("Bonne réponse !");
                            score++; // Incrémenter le score si la réponse est correcte
                        }
                        else
                        {
                            Console.WriteLine("Ce n'est pas la bonne réponse.");
                        }

                        // Affichage de la réponse correcte après avoir parcouru toutes les propositions
                        Console.WriteLine($"La réponse correcte est : {correctAnswers[questionsAnswers]}");

                        validInput = true; // Sortie de la boucle après traitement de la réponse
                    }
                    else
                    {
                        Console.WriteLine("Veuillez entrer un nombre entre 1 et 4 correspondant à la réponse.");
                    }
                }

                // Afficher le score à la fin du jeu
                Console.WriteLine($"Votre score final est : {score}/{questions.Count}");
                
                Console.WriteLine("Merci d'avoir joué au Quiz. À bientôt !");

            }
        }

        static void ChooseCategory()
        {
            Console.WriteLine("Je fonctionne aussi, mais je ne possède rien pour le moment.");
        }
    }


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