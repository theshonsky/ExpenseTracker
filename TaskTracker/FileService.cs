    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker
{
    internal class FileService
    {

        public static void SaveExpensesToCsv(List<Expense> expenses)
        {
            using (StreamWriter writer = new StreamWriter(@"C:\Users\shonk\source\repos\TaskTracker\TaskTracker\bin\Debug\net8.0\File.csv", false)) 
            {
                writer.WriteLine("Id,Date,Category,Description,Amount,Currency");

                foreach (var expense in expenses)
                {
                    writer.WriteLine($"{expense.Id}," +
                                     $"{expense.Date:yyyy-MM-dd HH:mm:ss}," +
                                     $"{expense.ExpenseCategory}," +
                                     $"\"{expense.Description}\"," +
                                     $"{expense.Amount}," +
                                     $"{expense.ExpenseCurrency}");
                }
            }

            Console.WriteLine("Файл перезаписан с новыми данными.");
        }


        public static List<Expense> LoadExpensesFromCsv()
        {
            List<Expense> loadedExpenses = new List<Expense>();

            if (!File.Exists(@"C:\Users\shonk\source\repos\TaskTracker\TaskTracker\bin\Debug\net8.0\File.csv"))
            {
                Console.WriteLine("Файл не найден.");
                return loadedExpenses;
            }

            using (StreamReader reader = new StreamReader(@"C:\Users\shonk\source\repos\TaskTracker\TaskTracker\bin\Debug\net8.0\File.csv"))
            {
                string? line;
                reader.ReadLine(); // Пропустить заголовок

                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length >= 6)
                    {
                        int id = int.Parse(parts[0]);
                        DateTime date = DateTime.Parse(parts[1]);
                        var category = Enum.Parse<Expense.Category>(parts[2]);
                        string description = parts[3].Trim('"');
                        decimal amount = decimal.Parse(parts[4]);
                        var currency = Enum.Parse<Expense.Currency>(parts[5]);

                        loadedExpenses.Add(new Expense
                        {
                            Id = id,
                            Date = date,
                            ExpenseCategory = category,
                            Amount = amount,
                            Description = description,
                            ExpenseCurrency = currency
                        });
                    }
                }
            }

            Console.WriteLine("Файл CSV успешно загружен.");
            return loadedExpenses;
        }

    }
}
