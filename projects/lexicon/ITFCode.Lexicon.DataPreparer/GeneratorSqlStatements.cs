using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITFCode.Lexicon.DataPreparer
{
    internal class GeneratorSqlStatements
    {
        public (string, string) GetLitVerbs(IEnumerable<string> rows)
        {
            var sbLW = new StringBuilder("SET IDENTITY_INSERT [dbo].[LithuanianWord] ON \r\n \r\n");
            var sbLV = new StringBuilder("SET IDENTITY_INSERT [dbo].[LithuanianVerbs] ON \r\n \r\n");

            sbLW.AppendLine("INSERT INTO [dbo].[LithuanianWord](\r\n" +
                "\t[Id],\r\n" +
                "\t[Name],\r\n" +
                "\t[PartsOfSpeech],\r\n" +
                "\t[OriginalLanguage],\r\n" +
                "\t[TranslationRu],\r\n" +
                "\t[TranslationUa])\r\n" +
                "VALUES");

            sbLV.AppendLine("INSERT INTO [dbo].[LithuanianVerbs](\r\n" +
                "\t[Id]\r\n," +
                "\t[PresentTense3rdPerson]\r\n" +
                "\t,[PastTense3rdPerson]\r\n" +
                "\t,[PresentTense1rdPerson]\r\n" +
                "\t,[PastTense1rdPerson]\r\n" +
                "\t,[FutureTense1rdPerson]\r\n" +
                "\t,[WordId])\r\n     " +
                "VALUES");

            int wordId = 0;
            int verbId = 0;

            foreach (var row in rows)
            {
                var words = row.Split("\t");
                //Console.WriteLine(new string('-', 100));
                //Console.WriteLine($"Lit: {words[0]}");

                var forms = words[0].Replace("(", ",")
                    .Replace(")", "")
                    .Split(",")
                    .Select(x => x.Trim())
                    .ToArray();

                sbLW.AppendLine($"\t({++wordId}, N'{forms[0]}', 30, 20, N'{words[1]}', ''),");
                
                if (forms.Length == 3)
                    sbLV.AppendLine($"({++verbId}, N'{forms[1]}', N'{forms[2]}','','','',{wordId}),");
                else
                    sbLV.AppendLine($"({++verbId}, N'{forms[1]}', N'{forms[2]}', N'{forms[3]}', N'{forms[4]}', N'{forms[5]}',{wordId}),");

                //Console.WriteLine($"Rus: {words[1]}");
            }
            sbLW.Remove(sbLW.Length - 3, 1);
            sbLV.Remove(sbLV.Length - 3, 1);

            sbLW.AppendLine("\r\nSET IDENTITY_INSERT [dbo].[LithuanianWord] OFF");
            sbLV.AppendLine("\r\nSET IDENTITY_INSERT [dbo].[LithuanianVerbs] OFF");

            return (sbLW.ToString(), sbLV.ToString());
        }
    }
}