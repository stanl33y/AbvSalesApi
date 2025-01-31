using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class SaleTests
    {
        private readonly Sale _saleFixture;

        public SaleTests()
        {
            _saleFixture = new Sale(
                saleNumber: "TEST-001",
                saleDate: DateTime.UtcNow,
                customerId: Guid.NewGuid(),
                branchId: Guid.NewGuid(),
                items: new List<SaleItem>()
            );
        }

        [Fact]
        public void AddItem_ValidItem_ShouldAddToItems()
        {
            // Arrange
            var item = new SaleItem(
                productId: Guid.NewGuid(),
                quantity: 2,
                unitPrice: 10.0m
            );

            // Act
            _saleFixture.AddItem(item);

            // Assert
            _saleFixture.Items.Should().ContainSingle();
            _saleFixture.Items.Should().Contain(item);
        }

        [Fact]
        public void CalculateTotalAmount_WithMultipleItems_ShouldReturnCorrectTotal()
        {
            // Arrange
            var item1 = new SaleItem(
                productId: Guid.NewGuid(),
                quantity: 2,
                unitPrice: 10.0m
            );

            var item2 = new SaleItem(
                productId: Guid.NewGuid(),
                quantity: 5,  // 5 itens terão 10% de desconto
                unitPrice: 20.0m
            );

            _saleFixture.AddItem(item1);
            _saleFixture.AddItem(item2);

            // Act
            var totalAmount = _saleFixture.TotalAmount;

            // Assert
            // Item1 total: 10 * 2 = 20 (sem desconto)
            // Item2 total: (20 * 5) - 10% = 90
            // Expected total: 110
            totalAmount.Should().Be(110.0m);
        }

        [Fact]
        public void Cancel_ValidSale_ShouldSetStatusToCancelled()
        {
            // Act
            _saleFixture.Cancel();

            // Assert
            _saleFixture.IsCancelled.Should().BeTrue();
        }

        [Fact]
        public void AddItem_ExceedingMaxQuantityThroughMultipleItems_ShouldThrowException()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var item1 = new SaleItem(
                productId: productId,
                quantity: 15,
                unitPrice: 10.0m
            );

            var item2 = new SaleItem(
                productId: productId,
                quantity: 10,
                unitPrice: 10.0m
            );

            // Adiciona o primeiro item (15 unidades)
            _saleFixture.AddItem(item1);

            // Act & Assert
            // Tentar adicionar mais 10 unidades (total seria 25) deve falhar
            var act = () => _saleFixture.AddItem(item2);
            act.Should().Throw<InvalidOperationException>()
                .WithMessage($"Cannot add more than 20 items for the product {productId}.");
        }
    }
}
