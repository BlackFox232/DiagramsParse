using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace DiagramsParse
{
    internal class LogParser : IWorkWithLog
    {
        Regex regexOpen = new Regex("Open");
        Regex regexClose = new Regex("Close");

        public List<string> ReadLog(string logAdress)
        {
            List<string> log = new List<string>();
            int cnt = 0;
            using (StreamReader sr = new StreamReader(logAdress, Encoding.GetEncoding(1251)))
                //log = sr.ReadToEnd();
                while (sr.EndOfStream != true)
                {
                    log.Add(sr.ReadLine());
                    cnt++;
                }
            return log;
        }//прочитать лог

        public List<string> FindWorkSections(List<string> log)
        {

            List<string> workSections = new List<string>();

            foreach (var item in log)
            {
                if (regexOpen.IsMatch(item) || regexClose.IsMatch(item))
                {
                    workSections.Add(item);
                }
            }
            return workSections;
        }//вырезка Open/Close из всего лога  

        public string[] GetPoints(List<string> workSections)
        {
            List<int> GraphPoints = new List<int>();

            string[] points = new string[9];
            int time = 8;

            for (int i = 0; i < points.Length;i++)
            {
                points[i] = $"{time}.00-{time + 1}.00,calls:";
            }

            time = 8;

            

            return points;
        } // 

        public List<DateTime> ParseTime(List<string> workSections)
        {
            List<DateTime> currentTime = new List<DateTime>();

            regexOpen = new Regex("[0-9]{2}" + ":" + "[0-9]{2}" + ":" + "[0-9]{2}");

            foreach (var item in workSections)
            {
                var mt = regexOpen.Match(item);

                if (mt.Success)
                {
                    currentTime.Add(Convert.ToDateTime((mt.Value)));
                }
            }

            return currentTime;
        }//Вырезка времени из лога

        public string[] GetNumberCalls(string[] timeCall,List<string> workSections) // Получаем количество вызовов
        {
            string[] calls = new string[9];

            int current;

            int cnt = 0;

            for (int i = 0; i < calls.Length; i++)
            {
                calls[i] = "Time: =";
            }

            for (int i = 0; i < workSections.Count; i++)
            {
                if (regexOpen.IsMatch(workSections[i]))
                {

                }
            }

            return calls;
        }

        public string[] GetTimeCall(string[] numberCall,List<string> workSections)
        {
            string[] calls = new string[9];

            for (int i = 0; i < calls.Length; i++)
            {
                calls[i] = "";       
            }

            return calls;
        } // Время вызовов
        
    }
}