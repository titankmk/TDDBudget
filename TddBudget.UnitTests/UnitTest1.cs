using FluentAssertions;
using NSubstitute;

namespace TddBudget.UnitTests;

public class Tests
{
    private IBudgetRepo _budgetRepo = null!;
    private BudgetService _budgetService = null!;

    [SetUp]
    public void Setup()
    {
        _budgetRepo = Substitute.For<IBudgetRepo>();
       
        _budgetService = new BudgetService(_budgetRepo);
    }

    [Test]
    public void Query_BetweenStartEnd()
    {
        _budgetRepo.GetAll().Returns(new List<Budget>()
        {
            new()
            {
                YearMonth = "202211",
                Amount = 3000
            }, 
            new()
            {
                YearMonth = "202212",
                Amount = 3100
            },
            new()
            {
                YearMonth = "202301",
                Amount = 3100
            },
            new()
            {
                YearMonth = "202302",
                Amount = 280
            },
            new()
            {
                YearMonth = "202303",
                Amount = 310
            }
        });
        _budgetService = new BudgetService(_budgetRepo);

        var totalBudget = _budgetService.Query(new DateTime(2022,12,21), new DateTime(2023,2,10));
        totalBudget.Should().Be(4300);
    }
    
    [Test]
    public void Query_StartGreaterThanEnd()
    {
        _budgetRepo.GetAll().Returns(new List<Budget>()
        {
            new()
            {
                YearMonth = "202212",
                Amount = 3100
            },
            new()
            {
                YearMonth = "202301",
                Amount = 3100
            },
            new()
            {
                YearMonth = "202302",
                Amount = 280
            }
        });

        var totalBudget = _budgetService.Query(new DateTime(2024,12,21), new DateTime(2023,2,10));
        totalBudget.Should().Be(0);
    }
}