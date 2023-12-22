namespace TddBudget;

public class Budget
{
    public int Amount { get; set; }
    public string YearMonth { get; set; } = null!;

    private DateTime FirstDateInMonth => DateTime.ParseExact(YearMonth, "yyyyMM", null);

    public int AmountWithinPeriod(DateTime start, DateTime end)
    {
        if (start > FirstDateInMonth)
        {
            return GetRemainingDaysInStartMonth(start) * GetBudgetPerDay();
        }

        if (end < FirstDateInNextMonth)
        {
            return GetRemainingDaysForEndMonth(end) * GetBudgetPerDay();
        }

        return Amount;
    }

    private int GetBudgetPerDay()
    {
        return Amount / DateTime.DaysInMonth(FirstDateInMonth.Year, FirstDateInMonth.Month);
    }

    private int GetRemainingDaysForEndMonth(DateTime end)
    {
        return ((end - FirstDateInMonth).Days + 1);
    }

    private int GetRemainingDaysInStartMonth(DateTime start)
    {
        return (FirstDateInMonth.AddMonths(1) - start).Days;
    }

    private DateTime FirstDateInNextMonth => FirstDateInMonth.AddMonths(1);

    public bool IsWithInPeriod(DateTime start, DateTime end)
    {
        return int.Parse(start.ToString("yyyyMM")) <= int.Parse(YearMonth) && int.Parse(end.ToString("yyyyMM")) >= int.Parse(YearMonth);
    }
}