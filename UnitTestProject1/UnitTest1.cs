using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MessageProgram;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{

    public class MessageComparator : IEqualityComparer<Message>
    {
        public bool Equals(Message x, Message y)
        {
            return x.SenderUrl == y.SenderUrl;
        }

        public int GetHashCode(Message obj)
        {
            return obj.SenderUrl.GetHashCode();
        }
    }


    public class MessageHandler
    {
        private int _messageCount;
        private readonly IDictionary<string, int> _dictionary;

        private KeyValuePair<string, int> _minPairInSet;
        private ISet<Message> _topSendersSet;

        public MessageHandler()
        {
            _topSendersSet = new HashSet<Message>(new MessageComparator()); //O(1) Lookups by object (hashcode)
            _dictionary = new Dictionary<string, int>(); //O(1) Lookups by index
        }

        public ISet<Message> GetActiveMessages()
        {
            return _topSendersSet;
        }

        public void RecieveMessage(Message message)
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

          
            var percent = (double) _dictionary[message.SenderUrl]/_messageCount;
            if (percent > 0.1)
            {
                if (!_topSendersSet.Contains(message))
                {
                    _topSendersSet.Add(message);
                    _minPairInSet = new KeyValuePair<string, int>(message.SenderUrl, _dictionary[message.SenderUrl]);
                }
            }

            var results = _topSendersSet.Where(m => (double)_dictionary[m.SenderUrl] / _messageCount <= 0.1).ToList();
            if (results.Any())
            {
                results.ForEach(r => _topSendersSet.Remove(r));
                UpdateNewMinimumPair();
            }

        }

        private void UpdateNewMinimumPair()
        {
            var sendersList = _topSendersSet.ToList();

            if (sendersList.Any())
            {
                var minMessage = sendersList[0];

                foreach (var message in sendersList)
                {
                    if (_dictionary[message.SenderUrl] < _dictionary[minMessage.SenderUrl])
                    {
                        minMessage = message;
                    }
                }

                _minPairInSet = new KeyValuePair<string, int>(minMessage.SenderUrl, _dictionary[minMessage.SenderUrl]);
            }
           
        }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var messageHandler = new MessageHandler();
            messageHandler.RecieveMessage(new Message { SenderUrl = "www.google.co.il" });
            messageHandler.RecieveMessage(new Message { SenderUrl = "www.google.co.il" });
            messageHandler.RecieveMessage(new Message { SenderUrl = "www.stam1.co.il" });
            messageHandler.RecieveMessage(new Message { SenderUrl = "www.stam2.co.il" });
            messageHandler.RecieveMessage(new Message { SenderUrl = "www.stam3.co.il" });

            var results = messageHandler.GetActiveMessages();

            //check results
            Assert.AreEqual(4, results.Count());

            messageHandler.RecieveMessage(new Message { SenderUrl = "www.stam4.co.il" });
            messageHandler.RecieveMessage(new Message { SenderUrl = "www.stam5.co.il" });
            messageHandler.RecieveMessage(new Message { SenderUrl = "www.stam6.co.il" });
            messageHandler.RecieveMessage(new Message { SenderUrl = "www.stam7.co.il" });
            messageHandler.RecieveMessage(new Message { SenderUrl = "www.stam8.co.il" });

            results = messageHandler.GetActiveMessages();

            //check results
            Assert.AreEqual(1, results.Count());


            messageHandler.RecieveMessage(new Message { SenderUrl = "www.stam11.co.il" });
            messageHandler.RecieveMessage(new Message { SenderUrl = "www.stam12.co.il" });
            messageHandler.RecieveMessage(new Message { SenderUrl = "www.stam13.co.il" });
            messageHandler.RecieveMessage(new Message { SenderUrl = "www.stam14.co.il" });
            messageHandler.RecieveMessage(new Message { SenderUrl = "www.stam15.co.il" });
            messageHandler.RecieveMessage(new Message { SenderUrl = "www.stam16.co.il" });
            messageHandler.RecieveMessage(new Message { SenderUrl = "www.stam17.co.il" });
            messageHandler.RecieveMessage(new Message { SenderUrl = "www.stam18.co.il" });
            messageHandler.RecieveMessage(new Message { SenderUrl = "www.stam19.co.il" });
            messageHandler.RecieveMessage(new Message { SenderUrl = "www.stam20.co.il" });

            results = messageHandler.GetActiveMessages();
            Assert.AreEqual(0, results.Count()); // www.google.co.il should be deleted at the stam20 message

        }
    }
}


