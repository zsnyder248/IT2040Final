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
            string result = "Music Playlist Analyzer\n";

            result += "\nSongs that have received more than 200 plays: ";
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
