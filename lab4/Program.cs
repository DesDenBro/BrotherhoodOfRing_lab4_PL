using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace lab4
{
    public class Token
    {
        private string _data;
        private int _recipient;

        public string Data { get { return _data; } }
        public int Recipient { get { return _recipient; } }

        public Token(string data, int recipient)
        {
            _data = data;
            _recipient = recipient;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            NewThread(new Token("Message", 20), 0);
            Console.Read();
        }

        static void NewThread(Token token, int index)
        {
            Console.WriteLine(string.Format("Index of this thread is {0}", index));
            if (index < token.Recipient)
            {
                Thread tmpThr = new Thread(() => NewThread(token, index + 1));
                tmpThr.Start();
            }
            else
            {
                Console.WriteLine(string.Format("Thread {0} is recipient, data is {1}", index, token.Data));
            }
            Console.WriteLine(string.Format("Thread {0} is ended", index));
        }
    }
}
