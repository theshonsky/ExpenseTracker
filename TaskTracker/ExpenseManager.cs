using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker
{
    internal class ExpenseManager
    {
        public List<Expense> expenses = new List<Expense>();
        public ExpenseManager() 
        { 
            expenses = FileService.LoadExpensesFromCsv();
        }
        

        public void Add(Expense.Category category, string description, decimal amount, Expense.Currency currency) 
        {
            int lastId;
            if (expenses.Count > 0)
                 lastId = expenses.Max(e => e.Id);
            else
                lastId = 0;

            expenses.Add(new Expense 
            { 
                Id = lastId + 1,
                ExpenseCategory = category, 
                Description = description, 
                Amount = amount, 
                ExpenseCurrency = currency 
            });
        }

        public void Edit(int id, int changer, decimal amount) 
        {
            Expense? expense = expenses.FirstOrDefault(s => s.Id == id);
            if (expense != null)
            {
                expense.Amount = amount;
                Console.WriteLine("Изменения внесены");
            }
            else
            {
                Console.WriteLine("Задачи с таким ID нет");
            }
        }

        public void Edit(int id, int changer, string description = "")
        {
            Expense? expense = expenses.FirstOrDefault(s => s.Id == id);
            if (expense != null)
            {
                expense.Description = description;
                Console.WriteLine("Изменения внесены");
            }
            else
            {
                Console.WriteLine("Задачи с таким ID нет");
            }
        }

        public void Edit(int id, int changer, Expense.Category category)
        {
            Expense? expense = expenses.FirstOrDefault(s => s.Id == id);
            if (expense != null)
            {
                expense.ExpenseCategory = category;
                Console.WriteLine("Изменения внесены");
            }
            else
            {
                Console.WriteLine("Задачи с таким ID нет");
            }
        }

        public void Edit(int id, int changer, Expense.Currency currency)
        {
            Expense? expense = expenses.FirstOrDefault(s => s.Id == id);
            if (expense != null)
            {
                expense.ExpenseCurrency = currency;
                Console.WriteLine("Изменения внесены");
            }
            else
            {
                Console.WriteLine("Задачи с таким ID нет");
            }
        }




        public void Delete(int id) 
        {
            Expense? expense = expenses.FirstOrDefault(s => s.Id == id);
            if (expense != null)
            {
                expenses.RemoveAll(t => t.Id == id);
            }
        }

        public void ShowAll() 
        {
            if (expenses.Count == 0)
            {
                Console.WriteLine("Нет расходов для отображения.");
                return;
            }
            View(expenses);
        }
        public void View(List<Expense> expensestoshow) 
        {
            Console.WriteLine("{0,-5} | {1,-15} | {2,-10} | {3,-50} | {4,-10} | {5,-15}", "ID", "Дата", "Категория", "Описание", "Сумма", "Валюта");
            Console.WriteLine(new string('-', 120));

            foreach (var expense in expensestoshow)
            {
                Console.WriteLine($"{expense.Id,-5} | {expense.Date.ToShortDateString(),-15} | {expense.ExpenseCategory,-10} | {expense.Description,-50} | {expense.Amount,-10} | {expense.ExpenseCurrency,-15}");
            }
        }

        public void ViewSorted(int sortby) 
        {
            var sortedexpenses = new List<Expense>();
            switch (sortby)
            {
                case 1:
                    sortedexpenses = expenses.OrderBy(e => e.Date).ToList();
                    break;
                case 2:
                    sortedexpenses = expenses.OrderBy(e => e.ExpenseCategory).ToList();
                    break;
                case 3:
                    sortedexpenses = expenses.OrderBy(e => e.Amount).ToList();
                    break;
                case 4:
                    sortedexpenses = expenses.OrderBy(e => e.ExpenseCurrency).ToList();
                    break;
                default:
                    Console.WriteLine("Неверный выбор сортировки.");
                    return;
            }
            View(sortedexpenses);
            Console.WriteLine("Searching for expenses.");
        }
    }
}
