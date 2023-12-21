namespace TddBudget;

public class Budget
{
    public int Amount { get; set; }
    public string YearMonth { get; set; } = null!;

    public int GetBudgetAmount(DateTime start, DateTime end)
    {
        var firstDateInMonth = DateTime.ParseExact(YearMonth, "yyyyMM", null);
        var budgetPerMonth = Amount / DateTime.DaysInMonth(firstDateInMonth.Year, firstDateInMonth.Month);

        if (start > firstDateInMonth)
        {
            return (firstDateInMonth.AddMonths(1) - start).Days * budgetPerMonth;
        }

        if (end < firstDateInMonth.AddMonths(1))
        {
            return ((end - firstDateInMonth).Days + 1) * budgetPerMonth;
        }

        return Amount;
    }

    public bool IsBudgetPeriod(DateTime start, DateTime end)
    {
        return int.Parse(start.ToString("yyyyMM")) <= int.Parse(YearMonth) && int.Parse(end.ToString("yyyyMM")) >= int.Parse(YearMonth);
    }
}