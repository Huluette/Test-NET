# Projet Quiz

Bienvenue ! Installe confortablement et prends le temps de lire ce Readme.md ! 

## > Installer les outils nécessaires 

### 1. Visual Studio (ou Visual Studio Code):
a. Visual Studio
	> Téléchargement : Rends-toi sur le site officiel de [![Visual Studio](https://visualstudio.microsoft.com/fr/)](https://visualstudio.microsoft.com/fr/) et télécharge la version la plus récente (Community, Professional, ou Enterprise).
	> Installation : Lance les programme d'installation et sélectionne les composants nécessaires pour le développement en C#. Assure-toi d'inclure la charge de travail "Développement.NET".

b. Visual Studio Code 
	> Téléchargement : Accède au site de [![Visual Studio Code](https://code.visualstudio.com/)](https://code.visualstudio.com/) et télécharge la version correspondant à ton système d'exploitation.
	> Extensions : Dans VS Code, installe l'extension "C# for Visual Studio Code" pour obtenir le support de base de développement C#.
	 
	
### 2. .NET SDK:
a. Que faire ?
   > Téléchargement : Clique sur le lien pour aller sur le site officiel de [![.NET](https://dotnet.microsoft.com/en-us/download)](https://dotnet.microsoft.com/en-us/download) pour télécharger le SDK (.NET Software Development Kit) le plus récent ou une version plus ancienne. 
   > Installation : Lance le programme d'installation et suis les instructions pour installer le SDK. Vérifie que la variable d'environnement PATH est configurée correctement après l'installation. 
	
b. Comment vérifier la configuration du PATH ?
	
	#### Sous Windows : 
	> 1. Ouvrir les variables d'environnement : 
	> ° Clique avec le bouton droit sur "Ce PC" ou "Ordinateur" (selon la version de Windows) et Sélectionne "Propriétés". 
	> ° Clique sur "Paramètres système avancés" ou "Paramètres système avancés" dans le panneau de gauche.
	> ° Clique sur le bouton "Variables d'environnement".
		
	> 2. Vérifier la variable PATH:
	> ° Dans la section "Variables système" ou "Variables utilisateur", cherche la variable nommée "Path" ou "PATH".
	> ° Sélectionne-la et clique sur "Modifier".
	
	> 3. Vérifier la présence du chemin .NET :
	> ° Vérifie que le chemin vers le répertoire d'installation du SDK .NET est inclus dans la liste des chemins. Par exemple, il pourrait ressembler à quelque chose comme : C:\Program Files\dotnet\
	
	#### Sous Mac ou Linux (en théorie) :
	> 1. Utiliser le terminal:
	> ° Ouvre un terminal.
	> ° Tape la commande echo $PATH et appuie sur Entrée. Cela affichera la liste des chemins inclus dans la variable PATH.
		
	> 2. Vérfier la présence du chein .NET:
	> Regarde dans la sortie de la commande echo $PATH pour voir si le chemin vers le répertoire d'installation du SDK .NET est inclus. Par exemple, il pourrait ressembler à quelque chose comme /usr/local/share/dotnet.
	
### 3. Choix d'un éditeur de texte ou d'un terminal: 
> Éditeur de texte: 
> Si tu préfères un éditeur autre que Visual Studio ou VS Code, des éditeurs comme Sublime Text, Atom ou Notepad++ peuvent également être utilisés pour écrire du code C#.

> Terminal : 
> Tu peux utiliser le terminal de ton choix pour exécuter les commandes liées à la compilation et à l'exécution des programmes C#. Sur Windows, PowerShell ou le CMD peut être utilisé.

### Conclusion 
Une fois que tu as installé Visual Studio (ou Visual Studio Code), le SDK .NET, et éventuellement un éditeur alternatif, tu seras prêt à créer et exécuter des programmes en C#. N'oublie pas de vérifier les mises à jour régulières des
outils pour bénéficier des dernières fonctionnalités et correctifs de sécurité !
	
## > Récupérer le projet

Bienvenue, pour récupérer le projet il suffit d'utiliser le célèbre git clone :
> git clone https://github.com/simplon-lille-csharp-dotnet/quiz_LB.git

Dans ton nouveau répertoire que tu nommeras comme tu le souhaite ! Le choix t'appartient ! 

## > Lancer le projet

### Instructions d'exécution: 
Pour Lancer ton projet assure toi d'être dans ton répertoire avec un cd nomdetonprojet :
> cd nomdetonprojet

Puis de compiler et d'éxecuter le projet avec les commandes suivantes : 
> dotnet build
> dotnet run

Et pour finir, suivez les instructions sécifiques au projet, c'est-à-dire que si votre projet a des conigurationes supplémentaires ou des étapes spécifiques pour lancer certaines fonctionnalités, assurez-vous de les mentionner.

### Détails supplémentaires:
> ° Si ton projet a des dépendances spécifiques ou nécessite des configurations supplémentaires, assure-toi de les inclure dans les instructions d'exécution.
> ° Si tu utilises un IDE spécifique comme Visual Studio, tu pourrais également fournir des étapes pour ouvrir et exécuter le projet à l'intérieur de cet IDE.
> ° N'oublie pas d'inclure tout autre détail important, comme les paramètres spécifiques à fournir lors de l'exécution du projet ou les fonctionnalités disponibles une fois que le projet est lancé.

## > Comprendre le projet

Pour comprendre le projet il suffit de suivre les étapes du jeu de Quiz.
Pour bien débuter, on va tout d'abord commencer en découpant le projet par étape. 

Attention : Chaque titre et sous titre de ce readme.md doit être transfomé en méthode. 

### > Ecrire les questions en 'dur' dans le code 

3 questions récupérées en 'dur' dans un premier temps :

- ```var questionUne = "Hey ! Salut, ca va l'ami.e ?"```
- ```var ReponseUne = "Je pète le feu et toi ?!"```
- ```var ReponseDeux = "!j'ai connu des jours meilleurs..."```
- ```var ReponseTrois = "Je suis grave dans la m*** !"```

### Depuis un fichier dans un second temps
	
On peut utiliser le fichier csv et l'importer de la manière suivante : 

```Charger les questions du fichier CSV```
```string filePath = @"C:\Users\Utilisateur\source\repos\Test-NET\ConsoleApp1\QuestionsExample.csv";```
```string[] nomFilePath = File.ReadAllLines(filePath);```

ou 

```string filePath = "chemin/vers/ton/fichier.csv";```

### Récupérer la première ligne du fichier CSV

Il faut utiliser la méthode StreamReader pour pouvoir récupérer la première ligne du fichier CSV : 

```// Vérifie si le fichier existe
        if (File.Exists(filePath))
	    {
            try
            {
                // Utilisation de StreamReader pour lire le fichier
                using (StreamReader sr = new StreamReader(filePath))
                {
                    // Lecture de la première ligne du fichier
                    string firstLine = sr.ReadLine();

                    // Affichage ou utilisation de la première ligne
                    Console.WriteLine("Première ligne du fichier CSV :");
                    Console.WriteLine(firstLine);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Une erreur est survenue : " + e.Message);
            }
        }
        else
        {
            Console.WriteLine("Le fichier n'existe pas.");
        }
    } 
```

### Récupérer la liste des questions

Quelle est la structure de ma liste de questions ? 
> **Les différents type de collection**
> 1. List <>
> 2. Dictionnary<>
> 3. string[]

Si on fait un tableau de string pour lister les intitulés, comment lier chaque question à ses réponses ?
Il est temps de construire des classes : une classe Question qui contient une liste de réponse.

``` public class Question {

		var questions = new List<string>(); // Liste des questions
		var answers = new List<string>(); // Liste des réponses

		// Remplir les listes à partir du fichier CSV
		 for (int questionsAnswers = 0; questionsAnswers < nomFilePath.Length; questionsAnswers++)
		{
		string[] columnData = nomFilePath[questionsAnswers].Split(';'); // La méthode Split permet de découper les colonnes du tableau csv avec le ;
		questions.Add(columnData[0]); // On revoit les colonnes du tableau csv en fonction de leur valeur attribuer ex: 0 ou 1
		answers.Add(columnData[1]);
		}
	}
```

## Accueillir le joueur 

Pour accueillir un joueur, on va créer une autre classe qui sera appelé dans le main !

``` public class homeUser {
		
}
```

## Demander la catégorie (dans un second temps) et filtrer la liste des questions 

## Parcourir les questions (boucle)

>Pour chacune d'entre elles 
>1. **Poser la question**
>2. **Donner les réponses possibles**
>3. **Vérifier si la réponse est bonne/mauvaise/une erreur**
>4. **Informer l'utilisateur du résultat et afficher son score**
>5. **Boucler**

## Afficher un message d'au revoir avec le score lorsque l'ensemble des questions ont été posées 