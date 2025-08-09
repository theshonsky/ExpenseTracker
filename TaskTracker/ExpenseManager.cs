using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Expense_Tracker.Expense;

namespace Expense_Tracker
{
    internal class ExpenseManager
    {
        public enum EditType
        {
            Category,
            Description,
            Amount,
            Currency
        }
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

       

        public void Edit(int id, EditType type, object newValue)
        {
            Expense? expense = expenses.FirstOrDefault(s => s.Id == id);
            if (expense == null)
            {
                Console.WriteLine("Задачи с таким ID нет");
                
            }
            
            switch (type)
            {
                case EditType.Category:
                    if (newValue is Expense.Category category)
                    {
                        expense.ExpenseCategory = category;
                        Console.WriteLine("Категория изменена");
                    }
                    else
                    {
                        Console.WriteLine("Неверный тип данных для категории");
                    }
                    break;
                case EditType.Description:
                    if (newValue is string description)
                    {
                        expense.Description = description;
                        Console.WriteLine("Описание изменено");
                    }
                    else
                    {
                        Console.WriteLine("Неверный тип данных для описания");
                    }
                    break;
                case EditType.Amount:
                    if (newValue is decimal amount)
                    {
                        expense.Amount = amount;
                        Console.WriteLine("Сумма изменена");
                    }
                    else
                    {
                        Console.WriteLine("Неверный тип данных для суммы");
                    }
                    break;
                case EditType.Currency:
                    if (newValue is Expense.Currency currency)
                    {
                        expense.ExpenseCurrency = currency;
                        Console.WriteLine("Валюта изменена");
                    }
                    else
                    {
                        Console.WriteLine("Неверный тип данных для валюты");
                    }
                    break;
                default:
                    Console.WriteLine("Неверный тип редактирования");
                    break;
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
        public void View(List<Expense> expensesToShow) 
        {
            decimal totalAmount = expensesToShow.Sum(e => e.Amount);
            Console.WriteLine("{0,-5} | {1,-15} | {2,-10} | {3,-50} | {4,-10} | {5,-15}", "ID", "Дата", "Категория", "Описание", "Сумма", "Валюта");
            Console.WriteLine(new string('-', 120));

            foreach (var expense in expensesToShow)
            {
                Console.WriteLine($"{expense.Id,-5} | {expense.Date.ToShortDateString(),-15} | {expense.ExpenseCategory,-10} | {expense.Description,-50} | {expense.Amount,-10} | {expense.ExpenseCurrency,-15}");
            }
            Console.WriteLine(new string('-', 120));
            Console.WriteLine($"{"",-72}  {"Итоговая сумма: "}  {totalAmount,-11}  {Expense.Currency.KZT,-15}"); // Предполагаем, что итоговая сумма в KZT, т.к. это валюта по умолчанию и выбор не был сделан    
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
