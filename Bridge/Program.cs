using System;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager._messageSenderBase = new EMailSender();
            customerManager.UpdateCustomer();
        }
    }
    abstract class MessageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("Message Saved");
        }
        public abstract void Send(Body body);
    }

    public class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }

    class SMSSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via SmsSender",body.Title);
        }
    }
    class EMailSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via EmailSender", body.Title);
        }
    }
    class CustomerManager
    {
        public MessageSenderBase _messageSenderBase { get; set; }

        public void UpdateCustomer()
        {
            _messageSenderBase.Send(new Body { Title="Bridge course send"});
            Console.WriteLine("Customer Updated");
        }
    }
}
