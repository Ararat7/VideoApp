using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace VideoApp
{
    public static class VideoToImage
    {
        public static string ffmpegPath = @"ffmpeg.exe";
        public static string filePath = string.Empty;

        public static int VideoDurationInSeconds(this string filePath)
        {
            Process ffmpeg = new Process();
            int durationInSec = 0;

            try
            {
                string duration;
                string result;

                StreamReader errorReader;

                ffmpeg.StartInfo.UseShellExecute = false;
                ffmpeg.StartInfo.ErrorDialog = false;
                ffmpeg.StartInfo.RedirectStandardError = true;

                ffmpeg.StartInfo.FileName = ffmpegPath;
                ffmpeg.StartInfo.Arguments = "-i " + "\"" + filePath + "\"";

                ffmpeg.Start();

                errorReader = ffmpeg.StandardError;
                ffmpeg.WaitForExit(500);

                result = errorReader.ReadToEnd();

                duration = result.Substring(result.IndexOf("Duration: ") + ("Duration: ").Length, ("00:00:00").Length);

                //Console.WriteLine("Duration is: " + duration);

                string[] list = duration.Split(':', '.');
                int hours, minutes, seconds;
                int.TryParse(list[0], out hours);
                int.TryParse(list[1], out minutes);
                int.TryParse(list[2], out seconds);

                durationInSec = hours * 3600 + minutes * 60 + seconds;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                ffmpeg.Close();
            }

            return durationInSec;
        }

        public static void SplitVideoIntoImages(this string filePath)
        {
            Process ffmpeg = new Process();

            try
            {
                string[] splitedPath = filePath.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
                string nameWithExt = splitedPath[splitedPath.Length - 1];

                string name = Path.GetFileNameWithoutExtension(nameWithExt);

                //Creating Folder with the name of video
                string folderPath = splitedPath[0] + Path.DirectorySeparatorChar;
                for (int i = 1; i < splitedPath.Length - 1; i++)
                {
                    folderPath = Path.Combine(folderPath, splitedPath[i]);
                }
                folderPath = Path.Combine(folderPath, name);

                if ((folderPath.Length) > 0 && (!Directory.Exists(folderPath)))
                {
                    Directory.CreateDirectory(folderPath);
                }

                const int fps = 20;
                int numerOfFrames = fps * filePath.VideoDurationInSeconds();
                string numberOfDigits = numerOfFrames.ToString().Length.ToString();

                string commandParams = "-i " + "\"" + filePath + "\"" + " -r " + fps.ToString() + " -f image2 "
                    + "\"" + folderPath + "\\" + name + "-%0" + numberOfDigits + "d.jpg" + "\"";

                //Console.WriteLine(commandParams);
                ffmpeg.StartInfo.UseShellExecute = false;
                ffmpeg.StartInfo.ErrorDialog = false;
                ffmpeg.StartInfo.FileName = ffmpegPath;
                ffmpeg.StartInfo.Arguments = commandParams;
                ffmpeg.Start();
                ffmpeg.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                ffmpeg.Close();
            }
        }
    }
}