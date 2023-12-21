namespace TddBudget;

public interface IBudgetRepo
{
    IEnumerable<Budget> GetAll();
}