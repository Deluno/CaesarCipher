using System;
using System.Text;

namespace CaesarCipher
{
    public class EDUtils
    {
        const int a_CHAR_SYMBOL = 65;
        const int z_CHAR_SYMBOL = 90;
        const int A_CHAR_SYMBOL = 97;
        const int Z_CHAR_SYMBOL = 122;
        const int ALPHABET_SIZE = 26;

        public string Encode(string str, int offset)
        {
            var result = new StringBuilder();
            if (!string.IsNullOrEmpty(str))
            {
                foreach (var symbol in str)
                {
                    if ((symbol + offset <= z_CHAR_SYMBOL && symbol >= a_CHAR_SYMBOL) ||
                        (symbol + offset <= Z_CHAR_SYMBOL && symbol >= A_CHAR_SYMBOL))
                    {
                        result.Append((char)(symbol + offset));
                    }
                    else if ((symbol <= z_CHAR_SYMBOL && symbol > z_CHAR_SYMBOL - offset) ||
                             (symbol <= Z_CHAR_SYMBOL && symbol > Z_CHAR_SYMBOL - offset))
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
                            if ((symbol <= z_CHAR_SYMBOL && symbol - offset >= a_CHAR_SYMBOL) ||
                                (symbol <= Z_CHAR_SYMBOL && symbol - offset >= A_CHAR_SYMBOL))
                            {
                                result.Append((char)(symbol - offset));
                            }
                            else if ((symbol - offset < a_CHAR_SYMBOL && symbol >= a_CHAR_SYMBOL) ||
                                     (symbol - offset < A_CHAR_SYMBOL && symbol >= A_CHAR_SYMBOL))
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
