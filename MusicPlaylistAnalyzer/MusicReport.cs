using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MusicPlaylistAnalyzer
{
    public static class MusicReport
    {
        public static string GenerateText(List<MusicCategories> musicCategoriesList)
        {
            string makeReport = "Music Playlist Report\n";
            makeReport += "\n";

            if (musicCategoriesList.Count() < 1)
            {
                makeReport += "No readable data.\n";
                return makeReport;
            }

            //DISREGARD
            /*
            var songNamePlayed200 = from musicCategories in musicCategoriesList where musicCategories.Time >= 200 select musicCategories.Name;
            var songArtistPlayed200 = from musicCategories in musicCategoriesList where musicCategories.Time >= 200 select musicCategories.Artist;
            var songAlbumPlayed200 = from musicCategories in musicCategoriesList where musicCategories.Time >= 200 select musicCategories.Album;
            var songGenrePlayed200 = from musicCategories in musicCategoriesList where musicCategories.Time >= 200 select musicCategories.Genre;
            var songSizePlayed200 = from musicCategories in musicCategoriesList where musicCategories.Time >= 200 select musicCategories.Size;
            var songTimePlayed200 = from musicCategories in musicCategoriesList where musicCategories.Time >= 200 select musicCategories.Time;
            var songYearPlayed200 = from musicCategories in musicCategoriesList where musicCategories.Time >= 200 select musicCategories.Year;
            var songPlaysPlayed200 = from musicCategories in musicCategoriesList where musicCategories.Time >= 200 select musicCategories.Plays;
            */
            //DISREGARD

            //Question 1: How many songs received 200 or more plays?
            var songPlayed200 = from musicCategories in musicCategoriesList where musicCategories.Plays >= 200 select musicCategories;
            makeReport += "Songs that received 200 or more plays:\n";
            foreach (var q1 in songPlayed200)
            {
                makeReport += "Name: " + q1.Name + ", " + "Artist: " + q1.Artist + ", " + "Album: " + q1.Album + ", " + "Genre: " + q1.Genre + ", " + "Size: " + q1.Size + ", " + "Time: " + q1.Time + ", " + "Year: " + q1.Year + ", " + "Plays: " + q1.Plays + "\n";
            }
            makeReport += "\n";

            //Question 2: How many songs are in the playlist with the Genre of "Alternative"?
            var numOfAlt = (from musicCategories in musicCategoriesList where musicCategories.Genre == "Alternative" select musicCategories.Name).Count();
            makeReport += $"Number of Alternative songs: {numOfAlt}\n";
            makeReport += "\n";

            //Question 3: How many songs are in the playlist with the Genre of "Hip-Hop/Rap"?
            var numOfHipHopRap = (from musicCategories in musicCategoriesList where musicCategories.Genre == "Hip-Hop/Rap" select musicCategories.Name).Count();
            makeReport += $"Number of Hip-Hop/Rap songs: {numOfHipHopRap}\n";
            makeReport += "\n";

            //Question 4: What songs are in the playlist from the album "Welcome to the Fishbowl"?
            var welcomeToTheFishbowl = from musicCategories in musicCategoriesList where musicCategories.Album == "Welcome to the Fishbowl" select musicCategories;
            makeReport += "Songs from the album \"Welcome to the Fishbowl\":\n";
            foreach (var q4 in welcomeToTheFishbowl)
            {
                makeReport += "Name: " + q4.Name + ", " + "Artist: " + q4.Artist + ", " + "Album: " + q4.Album + ", " + "Genre: " + q4.Genre + ", " + "Size: " + q4.Size + ", " + "Time: " + q4.Time + ", " + "Year: " + q4.Year + ", " + "Plays: " + q4.Plays + "\n";
            }
            makeReport += "\n";

            //Question 5: What are the songs in the playlist from before 1970?
            var songBefore1970 = from musicCategories in musicCategoriesList where musicCategories.Year < 1970 select musicCategories;
            makeReport += "Songs from before 1970:\n";
            foreach (var q5 in songBefore1970)
            {
                makeReport += "Name: " + q5.Name + ", " + "Artist: " + q5.Artist + ", " + "Album: " + q5.Album + ", " + "Genre: " + q5.Genre + ", " + "Size: " + q5.Size + ", " + "Time: " + q5.Time + ", " + "Year: " + q5.Year + ", " + "Plays: " + q5.Plays + "\n";
            }
            makeReport += "\n";

            //Question 6: What are the song names that are more then 85 characters long?
            var songCharMore85 = from musicCategories in musicCategoriesList where musicCategories.Name.Length > 85 select musicCategories;
            makeReport += "Song names longer than 85 characters:\n";
            foreach (var q6 in songCharMore85)
            {
                makeReport += q6.Name + "\n";
            }
            makeReport += "\n";

            //Question 7: What is the longest song? (Longest in Time)
            var songLongest = from musicCategories in musicCategoriesList where musicCategories.Time == (from Categories in musicCategoriesList select Categories.Time).Max() select musicCategories;
            makeReport += "Longest song:\n";
            foreach (var q7 in songLongest)
            {
                makeReport += "Name: " + q7.Name + ", " + "Artist: " + q7.Artist + ", " + "Album: " + q7.Album + ", " + "Genre: " + q7.Genre + ", " + "Size: " + q7.Size + ", " + "Time: " + q7.Time + ", " + "Year: " + q7.Year + ", " + "Plays: " + q7.Plays + "\n";
            }
            makeReport += "\n";

            return makeReport;
        }
    }
}
