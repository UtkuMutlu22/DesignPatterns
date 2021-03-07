using System;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            VicePresident vicePresident = new VicePresident();
            President president = new President();

            manager.SetSuccessor(vicePresident);
            vicePresident.SetSuccessor(president);

            Expense expense = new Expense { Detail = "Traing",Amount=1110 };
            manager.HandleExpense(expense);
        }
    }
    class Expense
    {
        public string Detail { get; set; }
        public decimal Amount { get; set; }
    }
   abstract class ExpenseHandlerBase
    {
        protected ExpenseHandlerBase Successor;
        public abstract void HandleExpense(Expense expense);
        public void SetSuccessor(ExpenseHandlerBase successor)
        {
            Successor = successor;
        }
    }
    class Manager:ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount<=100)
            {
                Console.WriteLine("Handler is manager");
            }
            else if(Successor!=null)
            {
                Successor.HandleExpense(expense);
            }
        }
    }
    class VicePresident : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 100 && expense.Amount<1000)
            {
                Console.WriteLine("Handler is Vice President");
            }
            else if (Successor != null)
            {
                Successor.HandleExpense(expense);
            }
        }
    }
    class President : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 1000)
            {
                Console.WriteLine("Handler is President");
            }
            
        }
    }

}
