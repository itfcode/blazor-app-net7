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
            var sbLW = new StringBuilder();
            var sbLV = new StringBuilder();

            int wordId = 0;
            int verbId = 0;

            foreach (var row in rows)
            {
                var words = row.Split("\t");
                Console.WriteLine(new string('-', 100));
                Console.WriteLine($"Lit: {words[0]}");

                var forms = words[0].Replace("(", ",")
                    .Replace(")", "")
                    .Split(",")
                    .Select(x => x.Trim())
                    .ToArray();

                foreach (var form in forms)
                {
                    Console.WriteLine($"Form: {form}");
                }

                sbLW.AppendLine($"('{++wordId}','{forms[0]}', '{words[1]}')");
                if (forms.Length == 3)
                    sbLW.AppendLine($"({++verbId},{wordId},'{forms[1]}','{forms[2]}','','','')");
                else
                    sbLW.AppendLine($"({++verbId},{wordId},'{forms[1]}','{forms[2]}','{forms[3]}','{forms[4]}','{forms[5]}')");

                //Console.WriteLine($"Rus: {words[1]}");
            }



            return (sbLW.ToString(), sbLV.ToString());
        }
    }
}