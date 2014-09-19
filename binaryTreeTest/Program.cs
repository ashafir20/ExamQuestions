using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Collections;

// Test code
// Test performance and delete method
using BinaryTree;
using MessageProgram;

namespace binaryTreeTest
{

	public class Program {

		static TBinarySTree bt = new TBinarySTree();

		public enum MessageResult
		{
			Drop,
			Keep,  
		}

		public static MessageResult TestLegalMessage(Message message)
		{
			var node1 = bt.findSymbol(message.RecieverUrl);
			var node2 = bt.findSymbol(message.SenderUrl);

			if (node1 != null)
			{
				Console.WriteLine("Url of reciever is spam");
				return MessageResult.Drop;
			}
			if (node2 != null)
			{
				Console.WriteLine("Url of sender is spam");
				return MessageResult.Drop;
			}
			else
			{
				return MessageResult.Keep;
			}
		}

		public static void Main(string[] args) {
			Console.WriteLine ("Start Tests");

			bt.insert ("www.spam0.co.il", 50);
			bt.insert ("www.spam1.co.il", 60);
			bt.insert ("www.spam2.co.il", 40);
			bt.insert ("30", 30);
			bt.insert ("20", 20);
			bt.insert ("35", 35);
			bt.insert ("45", 45);
			bt.insert ("44", 44);
			bt.insert ("46", 46);
			Console.WriteLine ("Number of nodes in the tree = {0}\n", bt.count());

			var result = TestLegalMessage(new Message { RecieverUrl = "www.spam1.co.il", SenderUrl = "www.google.co.il" });
			if (result == MessageResult.Drop)
			{
				Console.WriteLine("message is spam and was dropped");
			}
			else
			{
				Console.WriteLine("message is ok and kept");
			}

			result = TestLegalMessage(new Message { RecieverUrl = "www.spam1.co.il", SenderUrl = "www.spam2.co.il" });
			if (result == MessageResult.Drop)
			{
				Console.WriteLine("message is spam and was dropped");
			}
			else
			{
				Console.WriteLine("message is ok and kept");
			}

			result = TestLegalMessage(new Message { RecieverUrl = "www.test1.co.il", SenderUrl = "www.test2.co.il" });
			if (result == MessageResult.Drop)
			{
				Console.WriteLine("message is spam and was dropped");
			}
			else
			{
				Console.WriteLine("message is ok and kept");
			}


/*			Console.WriteLine ("Original: " + bt.drawTree());
			bt.delete ("40");
			Console.WriteLine ("Delete node 40: " + bt.drawTree());
			bt.delete ("45");
			Console.WriteLine ("Delete node 45: " + bt.drawTree());

			Console.WriteLine ("\nSimple one layered tree");
			bt = new TBinarySTree ();
			bt.insert ("50", 50);
			bt.insert ("20", 20);
			bt.insert ("90", 90);
			Console.WriteLine ("\nOriginal: " + bt.drawTree());
			bt.delete ("50");
			Console.WriteLine ("Delete node 50: " + bt.drawTree());

			bt = new TBinarySTree ();
			bt.insert ("50", 50);
			bt.insert ("20", 20);
			bt.insert ("90", 90);
			Console.WriteLine ("\nOriginal: " + bt.drawTree());
			bt.delete ("20");
			Console.WriteLine ("Delete node 20: " + bt.drawTree());

			bt = new TBinarySTree ();
			bt.insert ("50", 50);
			bt.insert ("20", 20);
			bt.insert ("90", 90);
			Console.WriteLine ("\nOriginal: " + bt.drawTree());
			bt.delete ("90");
			Console.WriteLine ("Delete node 90: " + bt.drawTree());
			bt.delete ("20");
			Console.WriteLine ("Delete node 20: " + bt.drawTree());
			bt.delete ("50");
			Console.WriteLine ("Delete node 50: " + bt.drawTree());

			Console.WriteLine ("\n");
			bt = new TBinarySTree ();
			bt.insert ("L", 1);
			bt.insert ("D", 2);
			bt.insert ("C", 3);
			bt.insert ("A", 4);
			bt.insert ("H", 5);
			bt.insert ("F", 6);
			bt.insert ("J", 7);
			bt.insert ("P", 8);
			Console.WriteLine ("Original: " + bt.drawTree());
			bt.delete ("J");
			Console.WriteLine ("Delete J: " + bt.drawTree());
			bt.delete ("C");
			Console.WriteLine ("Delete C: " + bt.drawTree());
			bt.delete ("L");
			Console.WriteLine ("Delete L: " + bt.drawTree());
			bt.delete ("D");
			Console.WriteLine ("Delete D: " + bt.drawTree());
			bt.delete ("A");
			Console.WriteLine ("Delete A: " + bt.drawTree());*/

			Console.ReadLine();
		}

	}
}
