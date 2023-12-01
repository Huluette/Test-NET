# Projet Quiz

Bienvenue ! Installe confortablement et prends le temps de lire ce Readme.md ! 

## > Installer les outils n�cessaires 

### 1. Visual Studio (ou Visual Studio Code):
a. Visual Studio
	> T�l�chargement : Rends-toi sur le site officiel de [![Visual Studio](https://visualstudio.microsoft.com/fr/)](https://visualstudio.microsoft.com/fr/) et t�l�charge la version la plus r�cente (Community, Professional, ou Enterprise).
	> Installation : Lance les programme d'installation et s�lectionne les composants n�cessaires pour le d�veloppement en C#. Assure-toi d'inclure la charge de travail "D�veloppement.NET".

b. Visual Studio Code 
	> T�l�chargement : Acc�de au site de [![Visual Studio Code](https://code.visualstudio.com/)](https://code.visualstudio.com/) et t�l�charge la version correspondant � ton syst�me d'exploitation.
	> Extensions : Dans VS Code, installe l'extension "C# for Visual Studio Code" pour obtenir le support de base de d�veloppement C#.
	 
	
### 2. .NET SDK:
a. Que faire ?
   > T�l�chargement : Clique sur le lien pour aller sur le site officiel de [![.NET](https://dotnet.microsoft.com/en-us/download)](https://dotnet.microsoft.com/en-us/download) pour t�l�charger le SDK (.NET Software Development Kit) le plus r�cent ou une version plus ancienne. 
   > Installation : Lance le programme d'installation et suis les instructions pour installer le SDK. V�rifie que la variable d'environnement PATH est configur�e correctement apr�s l'installation. 
	
b. Comment v�rifier la configuration du PATH ?
	
	#### Sous Windows : 
	> 1. Ouvrir les variables d'environnement : 
	> � Clique avec le bouton droit sur "Ce PC" ou "Ordinateur" (selon la version de Windows) et S�lectionne "Propri�t�s". 
	> � Clique sur "Param�tres syst�me avanc�s" ou "Param�tres syst�me avanc�s" dans le panneau de gauche.
	> � Clique sur le bouton "Variables d'environnement".
		
	> 2. V�rifier la variable PATH:
	> � Dans la section "Variables syst�me" ou "Variables utilisateur", cherche la variable nomm�e "Path" ou "PATH".
	> � S�lectionne-la et clique sur "Modifier".
	
	> 3. V�rifier la pr�sence du chemin .NET :
	> � V�rifie que le chemin vers le r�pertoire d'installation du SDK .NET est inclus dans la liste des chemins. Par exemple, il pourrait ressembler � quelque chose comme : C:\Program Files\dotnet\
	
	#### Sous Mac ou Linux (en th�orie) :
	> 1. Utiliser le terminal:
	> � Ouvre un terminal.
	> � Tape la commande echo $PATH et appuie sur Entr�e. Cela affichera la liste des chemins inclus dans la variable PATH.
		
	> 2. V�rfier la pr�sence du chein .NET:
	> Regarde dans la sortie de la commande echo $PATH pour voir si le chemin vers le r�pertoire d'installation du SDK .NET est inclus. Par exemple, il pourrait ressembler � quelque chose comme /usr/local/share/dotnet.
	
### 3. Choix d'un �diteur de texte ou d'un terminal: 
> �diteur de texte: 
> Si tu pr�f�res un �diteur autre que Visual Studio ou VS Code, des �diteurs comme Sublime Text, Atom ou Notepad++ peuvent �galement �tre utilis�s pour �crire du code C#.

> Terminal : 
> Tu peux utiliser le terminal de ton choix pour ex�cuter les commandes li�es � la compilation et � l'ex�cution des programmes C#. Sur Windows, PowerShell ou le CMD peut �tre utilis�.

### Conclusion 
Une fois que tu as install� Visual Studio (ou Visual Studio Code), le SDK .NET, et �ventuellement un �diteur alternatif, tu seras pr�t � cr�er et ex�cuter des programmes en C#. N'oublie pas de v�rifier les mises � jour r�guli�res des
outils pour b�n�ficier des derni�res fonctionnalit�s et correctifs de s�curit� !
	
## > R�cup�rer le projet

Bienvenue, pour r�cup�rer le projet il suffit d'utiliser le c�l�bre git clone :
> git clone https://github.com/simplon-lille-csharp-dotnet/quiz_LB.git

Dans ton nouveau r�pertoire que tu nommeras comme tu le souhaite ! Le choix t'appartient ! 

## > Lancer le projet

### Instructions d'ex�cution: 
Pour Lancer ton projet assure toi d'�tre dans ton r�pertoire avec un cd nomdetonprojet :
> cd nomdetonprojet

Puis de compiler et d'�xecuter le projet avec les commandes suivantes : 
> dotnet build
> dotnet run

Et pour finir, suivez les instructions s�cifiques au projet, c'est-�-dire que si votre projet a des conigurationes suppl�mentaires ou des �tapes sp�cifiques pour lancer certaines fonctionnalit�s, assurez-vous de les mentionner.

### D�tails suppl�mentaires:
> � Si ton projet a des d�pendances sp�cifiques ou n�cessite des configurations suppl�mentaires, assure-toi de les inclure dans les instructions d'ex�cution.
> � Si tu utilises un IDE sp�cifique comme Visual Studio, tu pourrais �galement fournir des �tapes pour ouvrir et ex�cuter le projet � l'int�rieur de cet IDE.
> � N'oublie pas d'inclure tout autre d�tail important, comme les param�tres sp�cifiques � fournir lors de l'ex�cution du projet ou les fonctionnalit�s disponibles une fois que le projet est lanc�.

## > Comprendre le projet

Pour comprendre le projet il suffit de suivre les �tapes du jeu de Quizz.

Pour bien d�buter, on va tout d'abord commencer avec une seule cat�gorie au d�but. Chaque titre et sous titre de ce readme.md doit �tre transfom� en m�thode. 

## > Ecrire les questions en 'dur' dans le code 

3 questions r�cup�r�es en 'dur' dans un premier temps :

- ```var questionUne = "Hey ! Salut, ca va l'ami.e ?"```
- ```var ReponseUne = "Je p�te le feu et toi ?!"```
- ```var ReponseDeux = "!j'ai connu des jours meilleurs..."```
- ```var ReponseTrois = "Je suis grave dans la m*** !"```

## Depuis un fichier dans un second temps
	
On peut utiliser le fichier.... et l'importer de ka mani�re suivante : 

```Blabla code, blabla code```

### R�cup�rer la premi�re ligne du fichier CSV

Il faut utiliser la m�thoe ... pour pouvoir r�cup�rer "S�parer les champs"...

### R�cup�rer la liste des questions

Quelle est la structure de ma liste de questions ? 
> **Les diff�rents type de collection**
> 1. List <>
> 2. Dictionnary<>
> 3. string[]

Si on fait un tableau de string pour lister les intitul�s, comment lier chaque question � ses r�ponses ?
Il est temps de construire des classes : une classe Question qui contient une liste de r�ponse.

## Accueillir le joueur 

## Demander la cat�gorie (dans un second temps) et filtrer la liste des questions 

## Parcourir les questions (boucle)

>Pour chacune d'entre elles 
>1. **Poser la question**
>2. **Donner les r�ponses possibles**
>3. **V�rifier si la r�ponse est bonne/mauvaise/une erreur**
>4. **Informer l'utilisateur du r�sultat et afficher son score**
>5. **Boucler**

## Afficher un message d'au revoir avec le score lorsque l'ensemble des questions ont �t� pos�es 