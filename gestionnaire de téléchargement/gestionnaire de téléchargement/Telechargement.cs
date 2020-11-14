using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System;

namespace gestionnaire_de_téléchargement
{
    class Telechargement
    {
        public async Task TelechargementFichier(string url)
        {
            using (var wc = new WebClient())
            {
                // récupérer le nom du fichier dans l'url
                string pattern = @"[a-zA-Z0-9\.\-_]+\.[a-z0-9]+";
                var nomFichier = url.Substring(url.LastIndexOf('/') + 1);
                MatchCollection mc = Regex.Matches(nomFichier, pattern);
                nomFichier = mc[0].ToString();
                string dossierTelechargement = @"C:\Users\nandi\Downloads\" + nomFichier;
                //

                Console.WriteLine($"    Téléchargement de {nomFichier} commencé.");
                await wc.DownloadFileTaskAsync(url, dossierTelechargement); // renvoie une Task
                Console.WriteLine($"    Téléchargement de {nomFichier} fini.");
            }
        }
    }
}
