using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SharedKenel.GUARD
{
    public static class Ensure
    {
        public static void NotNullOrEmpty(
                     [NotNull] string? value,
                     [CallerArgumentExpression("value")] string? paramName = default
                     )
                    {
                        if (string.IsNullOrEmpty(value))
                        {
                            throw new ArgumentNullException(paramName);
                        }
                    }
        public static void NotNullOrWhiteSpace(
                   [NotNull] string? value,
                   [CallerArgumentExpression("value")] string? paramName = default
                   )
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(paramName);
            }
        }
        public static void NotGreaterThan(
          int value, 
          int maxValue,
          string? message = null,
          [CallerArgumentExpression("value")]string? paramName = null
          )
        {
          if(value > maxValue) 
          {
           throw new ArgumentException(message, paramName);
          }

        }
    }
}
