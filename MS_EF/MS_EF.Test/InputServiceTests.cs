using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MS_EF.Application.Interface;
using MS_EF.Domain.Interface;
using MS_EF.Dto;
using MS_EF.Application.service;
using System.Collections.Generic;
using System.Threading.Tasks;
using MS_EF.Domain.Entity;

namespace MS_EF.Tests
{
    [TestClass]
    public class InputServiceTests
    {
        private Mock<IInputRepository> _inputRepositoryMock;
        private IInputService _inputService;

        [TestInitialize]
        public void Setup()
        {
            _inputRepositoryMock = new Mock<IInputRepository>();
            _inputService = new InputService(_inputRepositoryMock.Object);
        }

        [TestMethod]
        public async Task GetAllInputsAsync_ShouldReturnAllInputs()
        {
            // Arrange
            var inputs = new List<Input> { new Input { Id = 1, Name = "Input1" } };
            _inputRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(inputs);

            // Act
            var result = await _inputService.GetAllInputsAsync();

            // Assert
            Assert.IsTrue(result.EsValida);
            Assert.AreEqual(1, result.Resultado.Count);
        }

        [TestMethod]
        public async Task GetInputByIdAsync_ShouldReturnInput()
        {
            // Arrange
            var input = new Input { Id = 1, Name = "Input1" };
            _inputRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(input);

            // Act
            var result = await _inputService.GetInputByIdAsync(1);

            // Assert
            Assert.IsTrue(result.EsValida);
            Assert.AreEqual(1, result.Resultado.Id);
        }

        [TestMethod]
        public async Task AddInputAsync_ShouldAddInput()
        {
            // Arrange
            var inputDto = new InputDto { Id = 1, Name = "Input1" };
            var input = new Input { Id = 1, Name = "Input1" };
            _inputRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Input>())).Returns(Task.CompletedTask);

            // Act
            var result = await _inputService.AddInputAsync(inputDto);

            // Assert
            Assert.IsTrue(result.EsValida);
            Assert.AreEqual(1, result.Resultado.Id);
        }

        [TestMethod]
        public async Task DeleteInputAsync_ShouldDeleteInput()
        {
            // Arrange
            _inputRepositoryMock.Setup(repo => repo.DeleteAsync(1)).ReturnsAsync(true);

            // Act
            var result = await _inputService.DeleteInputAsync(1);

            // Assert
            Assert.IsTrue(result.EsValida);
            Assert.IsTrue(result.Resultado);
        }
    }
}
