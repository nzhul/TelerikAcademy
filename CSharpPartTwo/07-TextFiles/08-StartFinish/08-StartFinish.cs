
// The task is the same as the prev - 07
using System;
using System.IO;
using System.Text.RegularExpressions;

class StartFinish
{
    static void Main()
    {
        // NB! - First use GenerateLargeFile() Method to create the 100mb start.txt File
        //GenerateLargeFile();

        string fileContent = File.ReadAllText("../../start.txt");
        File.WriteAllText("../../finish.txt", Regex.Replace(fileContent, @"\bstart\b", "finish"));
        Console.WriteLine("Complete");
    }

    private static void GenerateLargeFile()
    {
        string inputPath = "../../start.txt";
        using (StreamWriter writer = new StreamWriter(inputPath))
        {
            long fileSize = 0;
            long maxSize = 100000000; // ~100 MB

            while (fileSize < maxSize)
            {
                writer.WriteLine(@"Definitions of start:
(n.) the beginning of anything

(n.) the time at which something is supposed to begin

(n.) a turn to be a starter (in a game at the beginning)

(n.) a sudden involuntary movement

(n.) the act of starting something

(n.) a line indicating the location of the start of a race or a game

(n.) a signal to begin (as in a race)

(n.) the advantage gained by beginning early (as in a race)

(v.) take the first step or steps in carrying out an action

(v.) set in motion, cause to start

(v.) leave

(v.) have a beginning, in a temporal, spatial, or evaluative sense

(v.) bring into being

(v.) get off the ground

(v.) move or jump suddenly, as if in surprise or alarm

(v.) get going or set in motion

(v.) begin or set in motion

(v.) begin work or acting in a certain capacity, office or job

(v.) play in the starting lineup

(v.) have a beginning characterized in some specified way

(v.) begin an event that is implied and limited by the nature or inherent function of the direct object

(v.) bulge outward");
                FileInfo file = new FileInfo("../../start.txt");
                fileSize = file.Length;
            }
        }
    }
}