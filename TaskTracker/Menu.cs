using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker
{
    internal class Menu
    {
        public ExpenseManager expenseManager = new ExpenseManager();
        public void Run() 
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Меню трекера расходов:");
                Console.WriteLine("1. Добавить расходы");
                Console.WriteLine("2. Изменить данные о расходах");
                Console.WriteLine("3. Удалить данные о расходах");
                Console.WriteLine("4. Показать все расходы");
                Console.WriteLine("5. Показать сортированные расходы");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");
                string? input = Console.ReadLine();
                
                if (input == "0")
                    break;
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Введите категорию расходов:");
                        Console.WriteLine("1. Food");
                        Console.WriteLine("2. Transport");
                        Console.WriteLine("3. Entertainment");
                        Console.WriteLine("4. Utilities");
                        Console.WriteLine("5. Health");
                        Console.WriteLine("6. Other");  

                        string? categoryInput = Console.ReadLine();
                        Expense.Category category = Expense.Category.Utilities; // Default value

                        switch (categoryInput)
                            {
                            case "1":
                                category = Expense.Category.Food;
                                break;
                            case "2":
                                category = Expense.Category.Transport;
                                break;
                            case "3":
                                category = Expense.Category.Entertainment;
                                break;
                            case "4":
                                category = Expense.Category.Utilities;
                                break;
                            case "5":
                                category = Expense.Category.Health;
                                break;
                            case "6":
                                category = Expense.Category.Other;
                                break;
                            default:
                                Console.WriteLine("Неверный выбор категории.");
                                continue;
                            }

                        Console.WriteLine("Введите описание расходов:");
                        string? description = Console.ReadLine() ?? string.Empty;

                        Console.WriteLine("Введите сумму расходов:");
                        string? amountinput = Console.ReadLine();
                        decimal amount = decimal.TryParse(amountinput, out decimal result) ? result : 0.0m;

                        expenseManager.Add(category, description, amount, Expense.Currency.KZT);
                        Console.WriteLine("Расходы добавлены успешно.");

                        break;
                    case "2":
                        Console.WriteLine("Введите ID расхода для изменения:");
                        int idToEdit = int.TryParse(Console.ReadLine(), out int id) ? id : 0;

                        Console.WriteLine("Выберите пункт для изменения");
                        Console.WriteLine("1. Описание");
                        Console.WriteLine("2. Сумму");

                        int toEdit = int.TryParse(Console.ReadLine(), out int ed) ? ed : 0;

                        switch (toEdit)
                        {
                            case 1:
                                Console.WriteLine("Введите новое описание:");
                                string? newDescription = Console.ReadLine() ?? string.Empty;
                                expenseManager.Edit(idToEdit, toEdit, newDescription);
                                break;
                            case 2:
                                Console.WriteLine("Введите новую сумму:");
                                string? amountInput = Console.ReadLine();
                                decimal newAmount = decimal.TryParse(amountInput, out decimal amountResult) ? amountResult : 0.0m;
                                expenseManager.Edit(idToEdit, toEdit, amount: newAmount);
                                break;
                            default:
                                Console.WriteLine("Неверный выбор пункта для изменения.");
                                continue;
                        }

                        break;
                    case "3":
                        Console.WriteLine("Введите ID для удаления:");
                        int toDelete = int.TryParse(Console.ReadLine(), out int del) ? del : 0;
                        expenseManager.Delete(toDelete);
                        Console.WriteLine("Расходы удалены успешно.");
                        break;
                    case "4":
                        Console.WriteLine("Все расходы:");
                        expenseManager.ShowAll();
                        break;
                    case "5":
                        Console.WriteLine("Выбирите тип сортировки:");
                        Console.WriteLine("1. По дате");
                        Console.WriteLine("2. По категории");
                        Console.WriteLine("3. По сумме");
                        Console.WriteLine("4. По валюте");
                        int sortOption = int.TryParse(Console.ReadLine(), out int sort) ? sort : 0;

                        expenseManager.ViewSorted(sortOption);
                        break;

                    case "0":
                        FileService.SaveExpensesToCsv(expenseManager.expenses);
                        break;

                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
