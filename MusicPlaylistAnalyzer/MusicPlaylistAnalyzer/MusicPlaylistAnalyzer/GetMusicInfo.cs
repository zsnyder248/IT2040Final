using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MusicPlaylistAnalyzer
{
    public static class GetMusicInfo
    {
        public static List<Info> GetData(string csvFile)
        {
            List<Info> musicInfoList = new List<Info>();

            int NumOfData = 8;
            try
            {
                using (StreamReader file = new StreamReader(csvFile))
                {
                    int NumOfLines = 0;
                    while (!file.EndOfStream)
                    {
                        var row = file.ReadLine();
                        NumOfLines++;
                        if (NumOfLines > 1)
                        {
                            var data = row.Split('\t');
                            if (data.Length != NumOfData)
                            {
                                throw new Exception("Records doesn't contain the correct amount of data elements");
                            }
                            try
                            {
                                string name = (data[0]);
                                string artist = (data[1]);
                                string album = (data[2]);
                                string genre = (data[3]);
                                int size = Int32.Parse(data[4]);
                                int time = Int32.Parse(data[5]);
                                int year = Int32.Parse(data[6]);
                                int plays = Int32.Parse(data[7]);
                                Info musicInfo = new Info(name, artist, album, genre, size, time, year, plays);
                                musicInfoList.Add(musicInfo);
                            }
                            catch (FormatException)
                            {
                                throw new Exception("Records contains data that is not of the correct type");
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Loading info Exception: " + e.Message);
            }
                return musicInfoList;
            }
    }
}
