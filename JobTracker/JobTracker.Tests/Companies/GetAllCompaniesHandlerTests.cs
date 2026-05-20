using JobTracker.Application.Companies.Queries;
using JobTracker.Application.Interfaces;
using JobTracker.Domain.Entities;
using Moq;

namespace JobTracker.Tests.Companies;

public class GetAllCompaniesHandlerTests
{
    [Fact]
    public async Task Handle_ReturnsAllCompanies()
    {
        var companies = new List<Company>
        {
            new() { Id=1, Name="ACME", Industry="Tech", Website="acme.com" },
            new() { Id=2, Name="Globex", Industry="Finance", Website="globex.com" }
        };

        var mock = new Mock<ICompanyRepository>();
        mock.Setup(r => r.GetAllAsync(default))
            .ReturnsAsync(companies);

        var handler = new GetAllCompaniesHandler(mock.Object);
        var result = await handler.Handle(
            new GetAllCompaniesQuery(), default);

        Assert.Equal(2, result.Count);
        Assert.Equal("ACME", result[0].Name);
    }

    [Fact]
    public async Task Handle_EmptyList_ReturnsEmpty()
    {
        var mock = new Mock<ICompanyRepository>();
        mock.Setup(r => r.GetAllAsync(default))
            .ReturnsAsync(new List<Company>());

        var handler = new GetAllCompaniesHandler(mock.Object);
        var result = await handler.Handle(
            new GetAllCompaniesQuery(), default);

        Assert.Empty(result);
    }
}