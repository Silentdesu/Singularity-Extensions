using System.Text;

namespace SingularityLab.Runtime.Extensions
{
    public static partial class StringExtension
    {
        private static readonly StringBuilder _stringBuilder = new StringBuilder();
        
        /// <summary>
        /// Convert long type to string with comma.
        /// </summary>
        public static string ToBigNumberString(this long number)
        {
            _stringBuilder.Clear();

            var result = 0f;
            
            if (number < 1000)
            {
                return number.ToString();
            }
            else if (number > 1000 && number < 10000)
            {
                result = number / 1000.0f;
                _stringBuilder.Append(result);
                
                return $"{_stringBuilder:n}K";
            }
            else if (number < 1000000)
            {
                result = number / 1000.0f;
                _stringBuilder.Append(result);
                
                return $"{_stringBuilder:0.0}K";
            }
            else if (number < 1000000000)
            {
                result = number / 1000000.0f;
                _stringBuilder.Append(result);
                
                return $"{_stringBuilder:0.0}M";
            }
            else
            {
                result = number / 1000000000.0f;
                _stringBuilder.Append(result);
                
                return $"{_stringBuilder:0.0}B";
            }
        }

        /// <summary>
        /// Convert double type to string with comma.
        /// </summary>
        public static string ToBigNumberString(this double number)
        {
            _stringBuilder.Clear();

            var result = 0.0;
            
            if (number < 1000)
            {
                return number.ToString();
            }
            if (number > 1000 && number < 10000)
            {
                result = number / 1000.0;
                _stringBuilder.Append(result);
                
                return $"{_stringBuilder:n}K";
            }
            if (number < 1000000)
            {
                result = number / 1000.0;
                _stringBuilder.Append(result);
                
                return $"{_stringBuilder:0.0}K";
            }
            if (number < 1000000000)
            {
                result = number / 1000000.0;
                _stringBuilder.Append(result);
                
                return $"{_stringBuilder:0.0}M";
            }

            result = number / 1000000000.0;
            _stringBuilder.Append(result);
            
            return $"{_stringBuilder:0.0}B";
        }

        /// <summary>
        /// Convert double type of seconds to string with suffix 's'
        /// </summary>
        public static string ToSecondsString(this double seconds)
        {
            _stringBuilder.Clear();

            _stringBuilder.Append(seconds);
            
            return $"{_stringBuilder:0.0}s";
        }
    }
}