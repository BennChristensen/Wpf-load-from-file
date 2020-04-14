using Complete.Models;
using System;

namespace Complete.Utility
{
    class UserParser
    {
        public User Parse(String stringToParse)
        {
            var L = stringToParse.Split(';');
            return new User(
                int.Parse(L[0]),
                L[1],
                int.Parse(L[2]),
                int.Parse(L[3])
            );
        }
    }
}
