using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace gestionnaire_de_téléchargement
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex rgx = new Regex(@"/((http|https)://)*[a-zA-Z0-9\.\-_]+\.[a-z0-9]+/([a-zA-Z0-9\.\-_]+/)*[a-zA-Z0-9\.\-_]+\.[a-z0-9]+(\?[a-zA-Z0-9\.\-_=&:]*)*");
            List<string> listeUrls = new List<string>();

            // si args contient une ou des string
            if (args.Count() > 0)
            {
                foreach (string url in args)
                {
                    if (rgx.IsMatch(url))
                    {
                        listeUrls.Add(url);
                    }
                    else
                    {
                        Console.WriteLine($"L'url {url} n'est pas valide, le téléchargement de ce fichier est impossible.");
                    }
                }
            } 
            // si args est vide
            else 
            {
                Console.WriteLine("Entrez des url séparés par des espaces. Quand vous avez fini, appuyez sur \"Entrer\" pour lancer les téléchargements.\n");

                string urls = Console.ReadLine();
                string[] tabUrls = urls.Split(' ');

                foreach (string url in tabUrls)
                {
                    if (rgx.IsMatch(url)) {
                        listeUrls.Add(url);
                    }
                    else
                    {
                        Console.WriteLine($"L'url {url} n'est pas valide, le téléchargement de ce fichier est impossible.");
                    }
                }
            }

            // téléchargement des fichiers de manière asynchrone
            if (listeUrls.Count() > 0)
            {
                var t = new Telechargement();
                Console.WriteLine("\nTéléchargement asynchrone de fichiers :");
                var taches = listeUrls.Select(url => t.TelechargementFichier(url)).ToArray();
                Task.WaitAll(taches);
            }
        }
    }
}
