namespace TddBudget;

public class BudgetService
{
    private readonly IBudgetRepo _budgetRepo;

    public BudgetService(IBudgetRepo budgetRepo)
    {
        _budgetRepo = budgetRepo;
    }

    public decimal Query(DateTime start, DateTime end)
    {
        if (start > end)
        {
            return 0;
        }

        return _budgetRepo.GetAll()
            .Where(budget => budget.IsWithInPeriod(start, end))
            .Sum(budget => budget.AmountWithinPeriod(start, end));
    }
}