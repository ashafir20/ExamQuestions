using System;
using System.Collections.Generic;
using System.Linq;

namespace MessageProgram
{
    class Program
    {
        public static void Main(string[] args)
        {
            var messageHandler = new MessageHandler();
            messageHandler.RecieveMessage(new Message { SenderUrl = "www.google.co.il" });
            messageHandler.RecieveMessage(new Message { SenderUrl = "www.google.co.il" });
            messageHandler.RecieveMessage(new Message { SenderUrl = "www.stam1.co.il" });
            messageHandler.RecieveMessage(new Message { SenderUrl = "www.stam2.co.il" });
            messageHandler.RecieveMessage(new Message { SenderUrl = "www.stam3.co.il" });
            messageHandler.RecieveMessage(new Message { SenderUrl = "www.stam4.co.il" });
            messageHandler.RecieveMessage(new Message { SenderUrl = "www.stam5.co.il" });
            messageHandler.RecieveMessage(new Message { SenderUrl = "www.stam6.co.il" });
            messageHandler.RecieveMessage(new Message { SenderUrl = "www.stam7.co.il" });
            messageHandler.RecieveMessage(new Message { SenderUrl = "www.stam8.co.il" });

            var results =  messageHandler.GetActiveMessages();

            //check results
            Console.WriteLine(results.Count);
            Console.WriteLine(results.ElementAt(0));

            Console.ReadLine();
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

        public ISet<string> GetActiveMessages()
        {
            var results = new HashSet<string>();
            foreach (var pair in _dictionary)
            {
                decimal percent = (decimal)pair.Value / (decimal)_messageCount;
                if (percent > 0.1M)
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
                    if (!_dictionary.ContainsKey(message.SenderUrl))
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
