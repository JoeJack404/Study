using System;

namespace Bachet
{
    class BotIsNotCreatedException : Exception
    {
        public BotIsNotCreatedException(string message) : base(message)
        {

        }
    }
}
