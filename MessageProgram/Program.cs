using System;
using System.Collections.Generic;
using System.Linq;

namespace MessageProgram
{
    class Program
    {
        public static void Main(string[] args)
        {

        }
    }

    public class MessageHandler
    {
        private int _messageCount;
        private readonly IDictionary<string, int> _dictionary;

        public MessageHandler()
        {
            _dictionary = new Dictionary<string, int>();
        }

        public List<string> GetActiveMessages()
        {
            var results = new List<string>();
            foreach (var pair in _dictionary)
            {
                var percent = pair.Value / _messageCount;
                if (percent > 0.1)
                {
                    results.Add(pair.Key);
                }
            }

            return results;
        }

        public void RecieveMessage(Message message)
        {
            if (message != null)
            {
                if (message.SenderUrl != null)
                {
                    _messageCount++;
                    if (_dictionary.ContainsKey(message.SenderUrl))
                    {
                        _dictionary.Add(message.SenderUrl, 1);
                    }
                    else
                    {
                        var currVal = _dictionary[message.SenderUrl];
                        _dictionary[message.SenderUrl] = currVal + 1;
                    }
                }
            }
        }
    }
}
