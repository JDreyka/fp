﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TagCloud.TextPreprocessor.TextRiders
{
    public class TextRiderConfig
    {
        internal readonly char[] WordsDelimiters = new[] {',', '.', '(', ')', ':', ';', ' ', '\t', '\n', '\r'};

        public string FilePath;
        public Func<string, string> GetCorrectWordFormat;
        public Func<string, bool> IsSkipWord;
        
        // Файл со словами, которые нужно пропускать лежит в папке TagCloud :)
        private static readonly string SkipWordsFilePath 
            = Path.Combine(Directory.GetCurrentDirectory(), "SkipWords.txt");
        public static HashSet<string> SkipWords 
            = GetSkipWords(SkipWordsFilePath).ToHashSet();

        public static TextRiderConfig Default()
        {
            return new TextRiderConfig()
            {
                FilePath = Path.Combine(Directory.GetCurrentDirectory(), "test2.txt"),
                GetCorrectWordFormat = word => word.Trim().ToLower(),
                IsSkipWord = word => SkipWords.Contains(word),
            };
        }
        
        private static IEnumerable<string> GetSkipWords(string filePath)
        {
            if (File.Exists(filePath))
                return new List<string>();

            using (var sr = new StreamReader(filePath))
            {
                return sr.ReadToEnd().Split();
            }
        }
    }
}