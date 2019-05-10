using System;
using System.Collections.Generic;
using System.IO;

namespace MusicPlaylistAnalyzer
{
    public static class MusicLoader
    {
        private static int NumItemInRow = 8;

        public static List<MusicCategories> Load(string musicFile)
        {
            List<MusicCategories> musicCategoriesList = new List<MusicCategories>();

            try
            {
                using(var reader = new StreamReader(musicFile))
                {
                    int lineNumber = 0;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        lineNumber++;
                        if (lineNumber == 1) continue;

                        var values = line.Split("\t");

                        if (values.Length != NumItemInRow)
                        {
                            throw new Exception($"Row {lineNumber} contains {values.Length} values. It should contain {NumItemInRow}.");
                        }

                        try
                        {
                            string name = values[0];
                            string artist = values[1];
                            string album = values[2];
                            string genre = values[3];
                            int size = Int32.Parse(values[4]);
                            int time = Int32.Parse(values[5]);
                            int year = Int32.Parse(values[6]);
                            int plays = Int32.Parse(values[7]);
                            MusicCategories musicCategories = new MusicCategories(name, artist, album, genre, size, time, year, plays);
                            musicCategoriesList.Add(musicCategories);
                        }

                        catch (FormatException e)
                        {
                            throw new Exception($"Row {lineNumber} contains invaild data. ({e.Message})");
                        }
                    }
                }
            }

            catch (Exception e)
            {
                throw new Exception($"Unable to open {musicFile} ({e.Message}).");
            }

            return musicCategoriesList;
        }
    }
}