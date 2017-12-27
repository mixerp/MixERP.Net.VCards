using System.Collections.Generic;
using System.IO;
using MixERP.Net.VCards.Extensions;
using MixERP.Net.VCards.Models;
using System.Text.RegularExpressions;
using System.Linq;

namespace MixERP.Net.VCards.Parser
{
    public static class TokenParser
    {
        private static Dictionary<string, string> GetAdditionalKeyMembers(string data)
        {
            var members = new Dictionary<string, string>();

            if (string.IsNullOrWhiteSpace(data))
            {
                return members;
            }

            var candidates = data.Split(';');
            foreach (string candidate in candidates)
            {
                if (string.IsNullOrWhiteSpace(candidate))
                {
                    continue;
                }

                string key = string.Empty;
                string value = string.Empty;

                var splitted = candidate.Split(new[] { '=' }, 2);

                if (splitted.Length >= 1)
                {
                    key = splitted[0];
                }

                if (splitted.Length == 2)
                {
                    value = splitted[1].Trim('"').Trim('\'');
                }
				if (members.ContainsKey(key)){
					members.Add(key, value);
				}
            }

            return members;
        }

        private static List<string> GetKeySections(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return new List<string>();
            }

            var sections = new List<string> { "", "" };
            var splitted = key.Split(new[] { ';' }, 2);

            if (splitted.Length >= 1)
            {
                sections[0] = splitted[0];
            }

            if (splitted.Length == 2)
            {
                sections[1] = splitted[1];
            }

            return sections;
        }

        private static KeyValuePair<string, string> GetEntry(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                return new KeyValuePair<string, string>();
            }

            string key = string.Empty;
            string value = string.Empty;

            var expression = new Regex("(?!\\B\" | '[^\"]*):(?![^\"]*\"|'\\B)");
            var sections = expression.Split(line, 2);
            //var sections = line.Split(new[] {':'}, 2);
            if (sections.Length >= 1)
            {
                key = sections[0];
            }

            if (sections.Length == 2)
            {
                value = sections[1];
            }

            return new KeyValuePair<string, string>(key.ToUpperInvariant(), value);
        }

        private static Token GetToken(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                return new Token();
            }

            var entry = GetEntry(line);
            var keySections = GetKeySections(entry.Key);
            var additionalKeyMembers = GetAdditionalKeyMembers(keySections[1]);


            return new Token
            {
                Key = keySections[0],
                AdditionalKeyMembers = additionalKeyMembers,
                Values = entry.Value.Trim().UnEscape().Split(';').Select(x => x.Trim('"').Trim('\'')).ToArray()
            };
        }

        public static IEnumerable<Token> Parse(string contents)
        {
            var tokens = new List<Token>();
            if (string.IsNullOrWhiteSpace(contents))
            {
                return tokens;
            }

            var reader = new StringReader(contents);
            string line;
            while (null != (line = reader.ReadLine()))
            {
                tokens.Add(GetToken(line));
            }

            return tokens;
        }
    }
}