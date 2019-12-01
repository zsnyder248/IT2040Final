using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MusicPlaylistAnalyzer
{
	public static class ResultStats
    {
        public static string Results(List<Info> musicInfoList)
        {
            string result = "Music Playlist Report\n";

            result += "\nSongs that have received more than 200 plays: \n";
            var first = from musicInfo in musicInfoList where musicInfo.Plays > 200 select musicInfo;
            foreach (var record in first)
            {
                result += "Name: " + record.Name + ", Artist: " + record.Artist + ", Album: " + record.Album + ", Genre: " + record.Genre + ", Size: " + record.Size + ", Time: " + record.Time + ", Year: " + record.Year + ", Plays: " + record.Plays + "\n";
            }

            result += "\nNumber of Alternative songs: ";
            var second = from musicInfo in musicInfoList where musicInfo.Genre == "Alternative" select musicInfo.Genre;
            int num = 0;
            foreach (var record in second)
            {
                num++;
            }
            result += num;

            result += "\nNumber of Hip-Hop/Rap songs: ";
            var third = from musicInfo in musicInfoList where musicInfo.Genre == "Hip-Hop/Rap" select musicInfo.Genre;
            num = 0;
            foreach (var record in third)
            {
                num++;
            }
            result += num;

            result += "\n\nSongs from the album Welcome to the Fishbowl: \n";
            var fourth = from musicInfo in musicInfoList where musicInfo.Album == "Welcome to the Fishbowl" select musicInfo;
            foreach (var record in fourth)
            {
                result += "Name: " + record.Name + ", Artist: " + record.Artist + ", Album: " + record.Album + ", Genre: " + record.Genre + ", Size: " + record.Size + ", Time: " + record.Time + ", Year: " + record.Year + ", Plays: " + record.Plays + "\n";
            }

            result += "\nSongs from before 1970: \n";
            var fifth = from musicInfo in musicInfoList where musicInfo.Year < 1970 select musicInfo;
            foreach (var record in fifth)
            {
                result += "Name: " + record.Name + ", Artist: " + record.Artist + ", Album: " + record.Album + ", Genre: " + record.Genre + ", Size: " + record.Size + ", Time: " + record.Time + ", Year: " + record.Year + ", Plays: " + record.Plays + "\n";
            }

            result += "\nSong names longer than 85 characters: \n";
            var sixth = from musicInfo in musicInfoList where musicInfo.Name.Length > 85 select musicInfo;
            foreach (var record in sixth)
            {
                result += "Name: " + record.Name + "\n";
            }

            result += "\nLongest song: \n";
            var seventh = from musicInfo in musicInfoList where musicInfo.Time == ((from info in musicInfoList select info.Time).Max()) select musicInfo;
            foreach (var record in seventh)
            {
                result += "Name: " + record.Name + ", Artist: " + record.Artist + ", Album: " + record.Album + ", Genre: " + record.Genre + ", Size: " + record.Size + ", Time: " + record.Time + ", Year: " + record.Year + ", Plays: " + record.Plays + "\n";
            }
            return result;

            /*
            result += "\nRobberies per year > 500000: ";
            var records = from crimeStats in crimeStatsList where crimeStats.Robbery > 500000 select crimeStats;
            foreach (var record in records)
            {
                result += record.Year + " = " + record.Robbery + ",";
            }
            result.TrimEnd(',');
            return result;
            */
        }
    }
}
