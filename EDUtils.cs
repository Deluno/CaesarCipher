using System;
using System.Text;

namespace CaesarCipher
{
    public class EDUtils
    {
        const int ALPHABET_SIZE = 26;

        public string Encode(string str, int offset)
        {
            var result = new StringBuilder();
            if (!string.IsNullOrEmpty(str))
            {
                foreach (var symbol in str)
                {
                    if ((symbol + offset <= 'z' && symbol >= 'a') ||
                        (symbol + offset <= 'Z' && symbol >= 'A'))
                    {
                        result.Append((char)(symbol + offset));
                    }
                    else if ((symbol <= 'z' && symbol > 'z' - offset) ||
                             (symbol <= 'Z' && symbol > 'Z' - offset))
                    {
                        result.Append((char)(symbol - (ALPHABET_SIZE - offset)));
                    }
                    else
                    {
                        result.Append(symbol);
                    }
                }

                result.Insert(0, offset + Environment.NewLine);
            }

            return result.ToString();
        }

        public string Decode(string str)
        {
            var result = new StringBuilder();
            if (!string.IsNullOrEmpty(str))
            {
                int endOfFirstLine = str.LastIndexOfAny(Environment.NewLine.ToCharArray(), 5);
                if (endOfFirstLine > 0)
                {
                    int offset;
                    if (int.TryParse(str.Substring(0, endOfFirstLine), out offset))
                    {
                        str = str.Remove(0, endOfFirstLine + 1);
                        foreach (var symbol in str)
                        {
                            if ((symbol <= 'z' && symbol - offset >= 'a') ||
                                (symbol <= 'Z' && symbol - offset >= 'A'))
                            {
                                result.Append((char)(symbol - offset));
                            }
                            else if ((symbol - offset < 'a' && symbol >= 'a') ||
                                     (symbol - offset < 'A' && symbol >= 'A'))
                            {
                                result.Append((char)(symbol + (ALPHABET_SIZE - offset)));
                            }
                            else
                            {
                                result.Append(symbol);
                            }
                        }
                    }
                    else
                    {
                        result.Append("The text is not encoded");
                    }
                }
                else
                {
                    result.Append("The text is not encoded");
                }
            }

            return result.ToString();
        }

    }
}
