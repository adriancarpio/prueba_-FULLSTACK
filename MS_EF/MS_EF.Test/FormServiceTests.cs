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
    public class FormServiceTests
    {
        private Mock<IFormRepository> _formRepositoryMock;
        private IFormService _formService;

        [TestInitialize]
        public void Setup()
        {
            _formRepositoryMock = new Mock<IFormRepository>();
            _formService = new FormService(_formRepositoryMock.Object);
        }

        [TestMethod]
        public async Task GetAllFormsAsync_ShouldReturnAllForms()
        {
            // Arrange
            var forms = new List<Form> { new Form { Id = 1, Name = "Form1" } };
            _formRepositoryMock.Setup(repo => repo.GetFormsAsync()).ReturnsAsync(forms);

            // Act
            var result = await _formService.GetAllFormsAsync();

            // Assert
            Assert.IsTrue(result.EsValida);
            Assert.AreEqual(1, result.Resultado.Count);
        }

        [TestMethod]
        public async Task GetFormByIdAsync_ShouldReturnForm()
        {
            // Arrange
            var form = new Form { Id = 1, Name = "Form1" };
            _formRepositoryMock.Setup(repo => repo.GetFormByIdAsync(1)).ReturnsAsync(form);

            // Act
            var result = await _formService.GetFormByIdAsync(1);

            // Assert
            Assert.IsTrue(result.EsValida);
            Assert.AreEqual(1, result.Resultado.Id);
        }

        [TestMethod]
        public async Task CreateFormAsync_ShouldCreateForm()
        {
            // Arrange
            var formDto = new FormDto { Id = 1, Name = "Form1" };
            var form = new Form { Id = 1, Name = "Form1" };
            _formRepositoryMock.Setup(repo => repo.CreateFormAsync(It.IsAny<Form>())).ReturnsAsync(form);

            // Act
            var result = await _formService.CreateFormAsync(formDto);

            // Assert
            Assert.IsTrue(result.EsValida);
            Assert.AreEqual(1, result.Resultado.Id);
        }

        [TestMethod]
        public async Task UpdateFormAsync_ShouldUpdateForm()
        {
            // Arrange
            var formDto = new FormDto { Id = 1, Name = "Form1" };
            var form = new Form { Id = 1, Name = "Form1" };
            _formRepositoryMock.Setup(repo => repo.GetFormByIdAsync(1)).ReturnsAsync(form);
            _formRepositoryMock.Setup(repo => repo.UpdateFormAsync(It.IsAny<Form>())).ReturnsAsync(form);

            // Act
            var result = await _formService.UpdateFormAsync(1, formDto);

            // Assert
            Assert.IsTrue(result.EsValida);
            Assert.AreEqual(1, result.Resultado.Id);
        }

        [TestMethod]
        public async Task DeleteFormAsync_ShouldDeleteForm()
        {
            // Arrange
            _formRepositoryMock.Setup(repo => repo.DeleteFormAsync(1)).ReturnsAsync(true);

            // Act
            var result = await _formService.DeleteFormAsync(1);

            // Assert
            Assert.IsTrue(result.EsValida);
            Assert.IsTrue(result.Resultado);
        }
    }
}
