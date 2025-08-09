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
                Console.WriteLine("6. Сохранить изменения");
                Console.WriteLine("0. Сохранить и выйти из программы");
                Console.Write("Выберите действие: ");
                string? input = Console.ReadLine();

                if (input == "0") 
                {
                    FileService.SaveExpensesToCsv(expenseManager.expenses);
                    Console.WriteLine("Выход из программы...");
                    break;
                }
                
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

                        Console.WriteLine("Введите валюту:");
                        Console.WriteLine("1. KZT");
                        Console.WriteLine("2. USD");
                        Console.WriteLine("3. EUR");
                        Console.WriteLine("4. GBP");
                        Console.WriteLine("5. JPY");
                        Console.WriteLine("6. CNY");
                        string? currencyInput = Console.ReadLine();
                        Expense.Currency currency = Expense.Currency.KZT; // Default value
                        
                        switch (currencyInput)
                        {
                            case "1":
                                currency = Expense.Currency.KZT;
                                break;
                            case "2":
                                currency = Expense.Currency.USD;
                                break;
                            case "3":
                                currency = Expense.Currency.EUR;
                                break;
                            case "4":
                                currency = Expense.Currency.GBP;
                                break;
                            case "5":
                                currency = Expense.Currency.JPY;
                                break;
                            case "6":
                                currency = Expense.Currency.CNY;
                                break;
                            default:
                                Console.WriteLine("Неверный выбор валюты.");
                                continue;
                        }
                        expenseManager.Add(category, description, amount, currency);
                        Console.WriteLine("Расходы добавлены успешно.");

                        break;

                    case "2":
                        Console.WriteLine("Введите ID расхода для изменения:");
                        int editId = int.TryParse(Console.ReadLine(), out int id) ? id : 0;

                        Console.WriteLine("Выберите пункт для изменения");
                        Console.WriteLine("1. Описание");
                        Console.WriteLine("2. Сумму");
                        Console.WriteLine("3. Категорию");
                        Console.WriteLine("4. Вылюту");

                        int editInput = int.TryParse(Console.ReadLine(), out int ed) ? ed : 0;

                        switch (editInput)
                        {
                            case 1:
                                Console.WriteLine("Введите новое описание:");
                                string? newDescription = Console.ReadLine() ?? string.Empty;
                                expenseManager.Edit(editId, ExpenseManager.EditType.Description, newDescription);
                            break;

                            case 2:
                                Console.WriteLine("Введите новую сумму:");
                                string? amountInput = Console.ReadLine();
                                decimal newAmount = decimal.TryParse(amountInput, out decimal amountResult) ? amountResult : 0.0m;
                                expenseManager.Edit(editId, ExpenseManager.EditType.Amount, newAmount);
                            break;

                            case 3: 
                                Console.WriteLine("Введите новую категорию:");
                                Console.WriteLine("1. Food");
                                Console.WriteLine("2. Transport");
                                Console.WriteLine("3. Entertainment");
                                Console.WriteLine("4. Utilities");
                                Console.WriteLine("5. Health");
                                Console.WriteLine("6. Other");
                                string? newCategoryInput = Console.ReadLine();
                                Expense.Category newCategory = Expense.Category.Utilities;
                                switch (newCategoryInput)
                                {
                                    case "1":
                                        newCategory = Expense.Category.Food;
                                        break;
                                    case "2":
                                        newCategory = Expense.Category.Transport;
                                        break;
                                    case "3":
                                        newCategory = Expense.Category.Entertainment;
                                        break;
                                    case "4":
                                        newCategory = Expense.Category.Utilities;
                                        break;
                                    case "5":
                                        newCategory = Expense.Category.Health;
                                        break;
                                    case "6":
                                        newCategory = Expense.Category.Other;
                                        break;
                                    default:
                                        Console.WriteLine("Неверный выбор категории.");
                                        continue;
                                }
                                expenseManager.Edit(editId, ExpenseManager.EditType.Category,newCategory);
                            break;

                            case 4:
                                    Console.WriteLine("Введите новую валюту:");
                                    string? newCurrencyInput = Console.ReadLine();
                                    Expense.Currency newCurrency = Expense.Currency.KZT;
                                switch (newCurrencyInput)
                                {
                                    case "1":
                                        newCurrency = Expense.Currency.KZT;
                                        break;
                                    case "2":
                                        newCurrency = Expense.Currency.USD;
                                        break;
                                    case "3":
                                        newCurrency = Expense.Currency.EUR;
                                        break;
                                    case "4":
                                        newCurrency = Expense.Currency.GBP;
                                        break;
                                    case "5":
                                        newCurrency = Expense.Currency.JPY;
                                        break;
                                    case "6":
                                        newCurrency = Expense.Currency.CNY;
                                        break;
                                    default:
                                        Console.WriteLine("Неверный выбор пункта для изменения.");
                                        continue;
                                } 
                                expenseManager.Edit(editId, ExpenseManager.EditType.Currency, newCurrency);
                            break;
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

                    default:
                        Console.WriteLine("Неправильный ввод, попробуйте снова.");
                        break;
                }
                Console.WriteLine("Нажмите на любую клавишу чтоб продолжить");
                Console.ReadKey();
            }
        }
    }
}
