using FluentAssertions;
using Moq;
using ValidacaoExcecoes.Application.Services.ProductServices;
using ValidacaoExcecoes.Application.ViewModels.ProductModels;
using ValidacaoExcecoes.Infra.Repository.productRepositories;
using ValidacaoExececoes.Core.Entities;

namespace ValidacaoExcecoes.Test
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> productRepoMock;
        private readonly ProductService service;

        public ProductServiceTests()
        {
            productRepoMock = new Mock<IProductRepository>();
            service = new ProductService(productRepoMock.Object);
        }

        [Fact]
        public async Task AdicionarProduto_Deve_ChamarRepositorio()
        {
            // Arrange
            var model = new ProductModel("Mouse", 100);

            // Act
            await service.AddProduct(model);

            // Assert
            productRepoMock.Verify(r => r.Add(It.Is<Product>(p => p.Nome == "Mouse" && p.Preco == 100)), Times.Once);
        }

        [Fact]
        public async Task ObterTodos_Deve_FiltrarPorPreco()
        {
            // Arrange
            var products = new List<Product> { new Product { Id = 1, Nome = "Notebook", Preco = 2000 } };
            productRepoMock.Setup(r => r.Get(It.IsAny<System.Linq.Expressions.Expression<System.Func<Product, bool>>>())).ReturnsAsync(products);

            // Act
            var result = await service.GetAll(preco: 2000);

            // Assert
            result.Should().ContainSingle()
                  .Which.Nome.Should().Be("Notebook");
        }

        [Fact]
        public async Task ObterTodos_Deve_FiltrarPorNom()
        {
            // Arrange
            var products = new List<Product> { new Product { Id = 2, Nome = "Teclado", Preco = 150 } };
            productRepoMock.Setup(r => r.Get(It.IsAny<System.Linq.Expressions.Expression<System.Func<Product, bool>>>())).ReturnsAsync(products);

            // Act
            var result = await service.GetAll(nome: "Teclado");

            // Assert
            result.Should().HaveCount(1);
            result.First().Preco.Should().Be(150);
        }
    }

}