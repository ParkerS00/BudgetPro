using BudgetPro.Server.DTOs;
using Shouldly;

namespace BudgetPro.Test;

public class DTOTests
{
    [Fact]
    public void CanMakeABudgetDTO()
    {
        // Arrange
        var testBudget = DefaultFactory.CreateTestBudget();

        // Act
        var testDTO = testBudget.ToDTO();

        // Assert
        testDTO.Amount.ShouldBe(testBudget.Amount);
        testDTO.Category.ShouldNotBeNull();
        testDTO.CategoryId.ShouldBe(testBudget.CategoryId);
        testDTO.Id.ShouldBe(testBudget.Id);
        testDTO.TimeFrame.ShouldBe(testBudget.Timeframe);
        testDTO.User.ShouldNotBeNull();
        testDTO.UserId.ShouldBe(testBudget.UserId);
    }

    [Fact]
    public void CanMakeUserDTO()
    {
        // Arrange
        var testUser = DefaultFactory.CreateTestUser();

        // Act
        var testDTO = testUser.ToDTO();

        // Assert
        testDTO.Email.ShouldBe(testUser.Email);
        testDTO.Id.ShouldBe(testUser.Id);
        testDTO.CreatedAt.ShouldBe(testUser.CreatedAt);
    }

    [Fact]
    public void CanMakeCategoryDTO()
    {
        // Arrange
        var testCategory = DefaultFactory.CreateTestCategory();

        // Act
        var testDTO = testCategory.ToDTO();

        // Assert
        testDTO.Id.ShouldBe(testCategory.Id);
        testDTO.IsIncome.ShouldBe(testCategory.IsIncome);
        testDTO.Name.ShouldBe(testCategory.Name);
        testDTO.User.ShouldNotBeNull();
        testDTO.UserId.ShouldBe(testCategory.UserId);
    }

    [Fact]
    public void CanMakeTransactionDTO()
    {
        // Arrange
        var testTransaction = DefaultFactory.CreateTestTransaction();

        // Act
        var testDTO = testTransaction.ToDTO();

        // Assert
        testDTO.Amount.ShouldBe(testTransaction.Amount);
        testDTO.Category.ShouldNotBeNull();
        testDTO.CategoryId.ShouldBe(testTransaction.CategoryId);
        testDTO.DateOccured.ShouldBe(testTransaction.DateOccured);
        testDTO.Description.ShouldBe(testTransaction.Description);
        testDTO.Id.ShouldBe(testTransaction.Id);
        testDTO.IsRecurring.ShouldBe(testTransaction.IsRecurring);
        testDTO.User.ShouldNotBeNull();
        testDTO.UserId.ShouldBe(testTransaction.UserId);
    }
}
