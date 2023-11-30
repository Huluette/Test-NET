using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace QuizApp
{
    class Program
    {
        // Interface utilisateur avec 3 choix
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

                // Effectuer un choix (valeurs 1 à 3) sinon rien ne se passe
                switch (userInput)
                {
                    case "1":
                        StartQuiz(); // Démarrer le quiz général
                        quizRunning = false;
                        break;
                    case "2":
                        ChooseCategory(); // Choisir une catégorie spécifique
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

        static void StartQuiz(List<string> selectedQuestions = null)
        {
            // Charger les questions du fichier CSV
            string wayCsv = @"C:\Users\Utilisateur\source\repos\Test-NET\ConsoleApp1\QuestionsExample.csv";
            string[] rowCsv = File.ReadAllLines(wayCsv);

            var questions = new List<string>(); // Liste des questions
            var answers = new List<string>(); // Liste des réponses
            var correctAnswers = new List<int>(); // Liste des bonnes réponses
            int score = 0; // Initialiser le score à zéro

            // Remplir les listes à partir du fichier CSV
            for (int questionsAnswers = 0; questionsAnswers < rowCsv.Length; questionsAnswers++)
            {
                string[] columnData = rowCsv[questionsAnswers].Split(';');
                questions.Add(columnData[0]);
                answers.Add(columnData[1]);
                correctAnswers.Add(int.Parse(columnData[2]));
            }

            Console.WriteLine("Attention, c'est parti !");
            Thread.Sleep(3000);
            Console.WriteLine("Question pour un champion :");

            // Afficher les questions du CSV
            for (int questionsAnswers = 0; questionsAnswers < questions.Count; questionsAnswers++)
            {
                Console.WriteLine($"{questionsAnswers + 1}) {questions[questionsAnswers]}");
                string[] possibleAnswers = answers[questionsAnswers].Split('/');
                for (int i = 0; i < possibleAnswers.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {possibleAnswers[i]}");
                }

                // Demander la réponse
                Console.WriteLine("Ecrivez votre réponse :");

                // Attendre une réponse valide
                bool validInput = false;
                while (!validInput)
                {
                    string userInput = Console.ReadLine();

                    if (!int.TryParse(userInput, out int userAnswer) || userAnswer < 1 || userAnswer > 4)
                    {
                        Console.WriteLine("Veuillez entrer un nombre entre 1 et 4 correspondant à la réponse.");
                    }
                    else
                    {
                        // Valider la réponse de l'utilisateur
                        if (userAnswer == correctAnswers[questionsAnswers])
                        {
                            Console.WriteLine("Bonne réponse !");
                            score++;
                        }
                        else
                        {
                            Console.WriteLine("Ce n'est pas la bonne réponse.");
                        }

                        Console.WriteLine($"La réponse correcte est : {correctAnswers[questionsAnswers]}");
                        validInput = true;
                    }
                }
            }

            Console.WriteLine($"Votre score final est : {score}/{questions.Count}");
            Console.WriteLine("Merci d'avoir joué au Quiz. À bientôt !");
        }

        static void ChooseCategory()
        {
            ChooseCategory categoryChooser = new ChooseCategory(@"C:\Users\Utilisateur\source\repos\Test-NET\ConsoleApp1\QuestionsExample.csv");
            categoryChooser.DisplayCategories();

            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("Choisissez une catégorie :");
                string chosenCategory = Console.ReadLine();
                string selectedCategory = null;

                switch (chosenCategory)
                {
                    case "1":
                        selectedCategory = "Catégorie 1";
                        break;
                    case "2":
                        selectedCategory = "Catégorie 2";
                        break;
                    case "3":
                        selectedCategory = "Quelle commande permet de vérifier la version installée du sdk de .net ?";
                        break;
                    default:
                        Console.WriteLine("Veuillez entrer un nombre entre 1 et 3.");
                        break;
                }

                List<string> selectedQuestions = categoryChooser.GetQuestionsByCategory(selectedCategory);

                if (selectedQuestions.Count > 0)
                {
                    Console.WriteLine($"Catégorie sélectionnée : {selectedCategory}");
                    StartQuiz(selectedQuestions); // Démarrer le quiz avec la catégorie sélectionnée
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Cette catégorie n'a pas de questions associées.");
                }
            }
        }
    }

    public class ChooseCategory
    {
        private Dictionary<string, List<string>> questionsByCategory;

        public ChooseCategory(string filePath)
        {
            questionsByCategory = new Dictionary<string, List<string>>();
            LoadQuestions(filePath);
        }

        private void LoadQuestions(string filePath)
        {
            string[] rows = File.ReadAllLines(filePath);

            foreach (string row in rows)
            {
                string[] columns = row.Split(';');
                string question = columns[0];
                string answer = columns[1];
                string category = columns[2];

                if (!questionsByCategory.ContainsKey(category))
                {
                    questionsByCategory[category] = new List<string>();
                }

                questionsByCategory[category].Add($"{question} - Réponse : {answer}");
            }
        }

        public void DisplayCategories()
        {
            Console.WriteLine("Catégories disponibles : ");
            foreach (string category in questionsByCategory.Keys)
            {
                Console.WriteLine(category);
            }
        }

        public List<string> GetQuestionsByCategory(string category)
        {
            if (questionsByCategory.ContainsKey(category))
            {
                return questionsByCategory[category];
            }
            else
            {
                return new List<string>();
            }
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