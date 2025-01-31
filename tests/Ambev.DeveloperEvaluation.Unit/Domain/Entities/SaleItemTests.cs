using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class SaleItemTests
    {
        [Theory]
        [InlineData(100.0, 2, 0)]    // Sem desconto (quantidade < 4)
        [InlineData(100.0, 5, 50)]   // 10% de desconto (4 <= quantidade < 10)
        [InlineData(100.0, 15, 300)] // 20% de desconto (10 <= quantidade <= 20)
        public void CalculateTotalAmount_ShouldReturnCorrectAmount(
            decimal unitPrice, 
            int quantity,
            decimal expectedDiscount)
        {
            // Arrange
            var saleItem = new SaleItem(
                productId: Guid.NewGuid(),
                quantity: quantity,
                unitPrice: unitPrice
            );

            // Act
            var totalAmount = saleItem.TotalAmount;
            var discount = saleItem.Discount;

            // Assert
            var expectedTotal = (unitPrice * quantity) - expectedDiscount;
            totalAmount.Should().Be(expectedTotal);
            discount.Should().Be(expectedDiscount);
        }

        [Theory]
        [InlineData(1)]  // Menos que 4 itens - 0% desconto
        [InlineData(3)]  // Menos que 4 itens - 0% desconto
        [InlineData(4)]  // 4-9 itens - 10% desconto
        [InlineData(9)]  // 4-9 itens - 10% desconto
        [InlineData(10)] // 10-20 itens - 20% desconto
        [InlineData(20)] // 10-20 itens - 20% desconto
        public void CalculateDiscount_ShouldApplyCorrectDiscountRate(int quantity)
        {
            // Arrange
            var unitPrice = 100m;
            var saleItem = new SaleItem(
                productId: Guid.NewGuid(),
                quantity: quantity,
                unitPrice: unitPrice
            );

            // Act
            var discount = saleItem.Discount;

            // Assert
            var expectedDiscount = quantity switch
            {
                < 4 => 0m,
                >= 10 => unitPrice * quantity * 0.20m,
                _ => unitPrice * quantity * 0.10m
            };

            discount.Should().Be(expectedDiscount);
        }
    }
}