﻿// See https://aka.ms/new-console-template for more information
using ITFCode.Lexicon.DataPreparer;
using System.Text.RegularExpressions;

Console.WriteLine("Hello, World!");

string currentDirectory = Directory.GetCurrentDirectory();
Console.WriteLine("Current Directory: " + currentDirectory);

string pattern = @"^(.*)\\bin\\";

Match match = Regex.Match(currentDirectory, pattern);

if (match.Success)
{
    string result = match.Groups[1].Value;
    var filePath = $@"{result}\Source\lit-rus.txt";

    var contents = File.ReadAllLines(filePath);

    var data = new GeneratorSqlStatements().GetLitVerbs(contents);

    File.WriteAllText($@"{result}\Dest\lit-words-verbs.sql", data.Item1);
    File.WriteAllText($@"{result}\Dest\lit-words-verb-forms.sql", data.Item2);

    Console.WriteLine(data.Item1);
    Console.WriteLine(data.Item2);
}