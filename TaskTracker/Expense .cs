using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker
{
    internal class Expense
    {
        public enum Category
        {
            Food,
            Transport,
            Entertainment,
            Utilities,
            Health,
            Other
        }

        public enum Currency
        {
            KZT,
            USD,
            EUR,
            GBP,
            JPY,
            CNY
        }

        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public Category ExpenseCategory { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public Currency ExpenseCurrency { get; set; } = Currency.KZT;

    }
}
