using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            var file1 = new StreamProgressInfo(new File("file", 4, 10));
            var file2 = new StreamProgressInfo(new Music("artist", "album", 9, 50));
        }
    }
}
