using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MusicPlaylistAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("MusicPlaylistAnalyzer <music_playlist_file_path> <report_file_path>");
                Environment.Exit(1);
            }

            string musicFile = args[0];
            string reportFile = args[1];

            List<MusicCategories> musicCategoriesList = null;

            try
            {
                musicCategoriesList = MusicLoader.Load(musicFile);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(2);
            }

            var makeReport = MusicReport.GenerateText(musicCategoriesList);

            try
            {
                System.IO.File.WriteAllText(reportFile, makeReport);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(3);
            }
        }
    }
}
