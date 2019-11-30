using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MusicPlaylistAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("MusicPlaylistAnalyzer <music_playlist_file_path> <report_file_path>");
                System.Environment.Exit(0);
            }

            string csvFile = args[0];
            string resultFile = args[1];


            List<Info> musicList = null;
            try
            {
                musicList = GetMusicInfo.GetData(csvFile);
            }
            catch (Exception e)
            {
                Console.WriteLine("Opening file Exception: " + e.Message);
                System.Environment.Exit(0);
            }

            var result = ResultStats.Results(musicList);

            try
            {
                StreamWriter outPut = new StreamWriter(resultFile);

                outPut.WriteLine(result);
                outPut.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Writing to file Exception: " + e.Message);
                System.Environment.Exit(0);
            }

            Console.WriteLine("The report was successfully created.");
        }
    }
}
