using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using static System.Formats.Asn1.AsnWriter;

namespace QuizApp
{
    class Program
    {
        // Interface utilisateur avec 3 choix
        static void Main() // Correspond à une fonction
        {
            bool quizRunning = true; // Valeur booléenne pour commencer le quiz (Introduction) 
            while (quizRunning)
            {
                Console.WriteLine("Bienvenue au Quiz !");
                Console.WriteLine("Que voulez-vous faire ?");
                Console.WriteLine("1. Le quiz !");
                Console.WriteLine("2. Quitter");

                string userInput = Console.ReadLine();

                // Effectuer un choix (valeurs 1 à 3) sinon rien ne se passe
                switch (userInput)
                {
                    case "1":
                        StartQuiz(); // Démarrer le quiz général
                        quizRunning = false;
                        break;
                    case "2":
                        quizRunning = false; // Fermer le Quiz
                        Console.WriteLine("Merci d'avoir joué au Quiz. À bientôt !");
                        break;
                    default:
                        Console.WriteLine("Veuillez entrer un choix valide.");
                        break;
                }
            }
        }

        // Fonction qui permet de choisir entre un quiz aléatoire ou un quiz par catégorie
        static void StartQuiz()
        {

            Console.WriteLine("Quel est ton choix ?");
            Console.WriteLine("1. Démarrer le quiz aléatoire !");
            Console.WriteLine("2. Choisir une catégorie");

            string userInput = Console.ReadLine();

            // Vérifie l'entrée de la valeur par l'uilisateur

            switch (userInput)
            {
                case "1":
                    StartRandomQuiz(); // Démarrer le quiz 
                    break;
                case "2":
                    ChooseCategory(); // Choisir les questions en fonction de la catégorie
                    break;
                default:
                    Console.WriteLine("Veuillez entrer un choix valide.");
                    break;
            }
        }

        // Fonction qui permet de dérouler le Quiz aléatoirement 
        static void StartRandomQuiz()
        {

            // Charger les questions du fichier CSV
            string wayCsv = @"C:\Users\Utilisateur\source\repos\Test-NET\ConsoleApp1\QuestionsExample.csv";
            string[] rowCsv = File.ReadAllLines(wayCsv);

            var questions = new List<string>(); // Liste des questions
            var answers = new List<string>(); // Liste des réponses
            var correctAnswers = new List<int>(); // Liste des bonnes réponses
            var categories = new List<string>(); // Liste des catégories
            int score = 0; // Initialiser le score à zéro

            // Remplir les listes à partir du fichier CSV
            for (int questionsAnswers = 0; questionsAnswers < rowCsv.Length; questionsAnswers++)
            {
                string[] columnData = rowCsv[questionsAnswers].Split(';');
                questions.Add(columnData[0]);
                answers.Add(columnData[1]);
                correctAnswers.Add(int.Parse(columnData[2]));
                categories.Add(columnData[3]);
            }

            Console.WriteLine("Attention, c'est parti !");
            Thread.Sleep(3000);
            Console.WriteLine("Question pour un champion :");

            // Générer un ordre aléatoire pour les questions
            List<int> randomQuestionOrder = Enumerable.Range(0, questions.Count).OrderBy(x => Guid.NewGuid()).ToList();

            // Afficher les questions du CSV dans un ordre aléatoire
            foreach (int questionIndex in randomQuestionOrder)
            {
                Console.WriteLine($"{questionIndex + 1}) {questions[questionIndex]}");
                string[] possibleAnswers = answers[questionIndex].Split('/');
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
                        if (userAnswer == correctAnswers[questionIndex])
                        {
                            Console.WriteLine("Bonne réponse !");
                            score++;
                        }
                        else
                        {
                            Console.WriteLine("Ce n'est pas la bonne réponse.");
                        }

                        Console.WriteLine($"La réponse correcte est : {correctAnswers[questionIndex]}");
                        validInput = true;
                    }
                }
            }

            Console.WriteLine($"Votre score final est : {score}/{questions.Count}");
            Console.WriteLine("Merci d'avoir joué au Quiz. À bientôt !");
        }

        // Fonction qui permet e choisir la catégorie des questions 
        static void ChooseCategory()
        {
            string wayCsv = @"C:\Users\Utilisateur\source\repos\Test-NET\ConsoleApp1\QuestionsExample.csv";
            string[] rowCsv = File.ReadAllLines(wayCsv);

            Console.WriteLine("Choisissez une catégorie :");
            // Création d'un HashSet pour stocker les catégories uniques
            HashSet<string> uniqueCategories = new HashSet<string>();

            // Parcours de chaque ligne du fichier CSV pour extraire les catégories uniques
            foreach (string row in rowCsv)
            {
                // Séparation des données de la ligne par le point-virgule
                string[] columnData = row.Split(';');

                // Ajout de la quatrième colonne (indice 3) à la liste des catégories uniques
                uniqueCategories.Add(columnData[3]);
            }

            // Affichage des catégories uniques avec un numéro d'index
            int count = 1;

            foreach (var category in uniqueCategories)
            {
                Console.WriteLine($"{count++}. {category}");
            }

            // Initialisation de la variable pour stocker l'index de la catégorie choisie par l'utilisateur
            int chosenCategoryIndex = 0;

            // Vérification de l'entrée utilisateur pour sélectionner une catégorie
            bool isValidInput = false;
            while (!isValidInput)
            {
                Console.WriteLine("Entrez le nombre correspondant à la catégorie :");
                string userInput = Console.ReadLine();

                // Vérification si l'entrée est un nombre et est dans la plage des catégories disponibles
                if (!int.TryParse(userInput, out chosenCategoryIndex) || chosenCategoryIndex < 1 || chosenCategoryIndex > uniqueCategories.Count)
                {
                    Console.WriteLine("Veuillez entrer un nombre correspondant à la catégorie.");
                }
                else
                {
                    isValidInput = true; // Sortie de la boucle si l'entrée est valide
                }
            }

            string chosenCategory = uniqueCategories.ElementAt(chosenCategoryIndex - 1);

            // Charger les données de la catégorie sélectionnée
            var quizData = LoadQuizData(wayCsv, chosenCategory);

            // Vérifier si les données sont valides
            if (quizData != null && quizData.ContainsKey("questions") && quizData.ContainsKey("answers") &&
                quizData.ContainsKey("correctAnswers") && quizData.ContainsKey("categories"))
            {
                var questions = quizData["questions"];
                var answers = quizData["answers"];
                var correctAnswers = quizData["correctAnswers"];
                var categories = quizData["categories"];

                // Commencer le quiz pour la catégorie sélectionnée
                StartQuizForCategory(questions, answers, correctAnswers, categories);
            }
            else
            {
                Console.WriteLine("Impossible de charger les données pour cette catégorie.");
            }
        }

        // Fonction démarrer le quiz pour une catégorie spécifique
        // Calclue le score et affiche le score final après avoir parcourur toutes les questions 
        static void StartQuizForCategory(List<string> questions, List<string> answers, List<string> correctAnswers, List<string> categories)
        {
            int score = 0;

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
                        if (userAnswer == int.Parse(correctAnswers[questionsAnswers]))
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

        static Dictionary<string, List<string>> LoadQuizData(string filePath, string selectedCategory)
        {
            try
            {
                // Lecture de toutes les lignes du fichier spécifié
                string[] rows = File.ReadAllLines(filePath);

                // Initialisation d'un dictionnaire pour stocker les données du quiz
                var quizData = new Dictionary<string, List<string>>()
        {
            // Initialisation de quatre listes vides pour les différentes données du quiz
            {"questions", new List<string>()},
            {"answers", new List<string>()},
            {"correctAnswers", new List<string>()},
            {"categories", new List<string>()}
        };

                // Parcours de chaque ligne du fichier
                foreach (var row in rows)
                {
                    // Séparation des données de la ligne par le point-virgule
                    string[] columns = row.Split(';');

                    // Vérification si la ligne a au moins 4 colonnes et que la catégorie correspond à celle sélectionnée
                    if (columns.Length >= 4 && columns[3] == selectedCategory)
                    {
                        // Ajout des données de cette ligne dans les listes correspondantes du dictionnaire
                        quizData["questions"].Add(columns[0]);
                        quizData["answers"].Add(columns[1]);
                        quizData["correctAnswers"].Add(columns[2]);
                        quizData["categories"].Add(columns[3]);
                    }
                }

                // Renvoi du dictionnaire contenant les données du quiz pour la catégorie sélectionnée
                return quizData;
            }
            catch (Exception ex)
            {
                // Gestion des exceptions : affichage du message d'erreur en cas d'échec de lecture du fichier
                Console.WriteLine($"Une erreur s'est produite : {ex.Message}");

                // Renvoi de null en cas d'erreur pour signaler qu'il y a eu un problème
                return null;
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