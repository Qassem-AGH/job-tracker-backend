using JobTracker.Application.Companies.Commands;
using JobTracker.Application.Interfaces;
using JobTracker.Domain.Entities;
using Moq;

namespace JobTracker.Tests.Companies;

public class CreateCompanyHandlerTests
{
    [Fact]
    public async Task Handle_ValidCommand_CallsRepositoryOnce()
    {
        var mock = new Mock<ICompanyRepository>();
        mock.Setup(r => r.AddAsync(
            It.IsAny<Company>(), default))
            .Returns(Task.CompletedTask);

        var handler = new CreateCompanyHandler(mock.Object);
        var command = new CreateCompanyCommand(
            "ACME", "Technology", "acme.com");

        await handler.Handle(command, default);

        mock.Verify(r => r.AddAsync(
            It.IsAny<Company>(), default), Times.Once);
    }

    [Fact]
    public async Task Handle_ValidCommand_ReturnsAnInt()
    {
        var mock = new Mock<ICompanyRepository>();
        mock.Setup(r => r.AddAsync(
            It.IsAny<Company>(), default))
            .Returns(Task.CompletedTask);

        var handler = new CreateCompanyHandler(mock.Object);
        var result = await handler.Handle(
            new CreateCompanyCommand("X", "Y", "z.com"), default);

        Assert.IsType<int>(result);
    }

    [Fact]
    public async Task Handle_SetsCorrectName()
    {
        Company? saved = null;
        var mock = new Mock<ICompanyRepository>();
        mock.Setup(r => r.AddAsync(
            It.IsAny<Company>(), default))
            .Callback<Company, CancellationToken>(
                (c, _) => saved = c)
            .Returns(Task.CompletedTask);

        var handler = new CreateCompanyHandler(mock.Object);
        await handler.Handle(
            new CreateCompanyCommand("Google", "Tech", "google.com"),
            default);

        Assert.Equal("Google", saved?.Name);
    }
}