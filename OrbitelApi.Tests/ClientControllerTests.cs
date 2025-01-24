using Microsoft.AspNetCore.Mvc;
using Moq;
using OrbitelApi.Controllers;
using OrbitelApi.Models.Dtos;
using OrbitelApi.Models.Entities.Clients;
using OrbitelApi.Services;

namespace OrbitelApiTests;

public class ClientControllerTests
{
    private readonly Mock<IClientService> _mockClientService;
    private readonly ClientController _controller;

    public ClientControllerTests()
    {
        _mockClientService = new Mock<IClientService>();
        _controller = new ClientController(_mockClientService.Object);
    }

    [Fact]
    public async Task GetClients_ReturnsOkResult_WithListOfClientDto()
    {
        var mockClients = new List<Client>
        {
            new Client { ClientId = 1, FullName = "John Doe", Phone = "123456789", Email = "john.doe@example.com" },
            new Client { ClientId = 2, FullName = "Jane Smith", Phone = "987654321", Email = "jane.smith@example.com" }
        };

        _mockClientService.Setup(service => service.GetAllClients()).ReturnsAsync(mockClients);

        // Act
        var result = await _controller.GetClients();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var clients = Assert.IsAssignableFrom<IEnumerable<ClientDto>>(okResult.Value); // Проверяем тип результата

  
        var expectedClients = mockClients.Select(c => new ClientDto(c.ClientId, c.FullName, c.Phone, c.Email)).ToList();

        var clientDtos = clients.ToList();
        Assert.Equal(expectedClients.Count, clientDtos.Count);
        for (int i = 0; i < clientDtos.Count; i++)
        {
            Assert.Equal(expectedClients[i].FullName, clientDtos[i].FullName);
            Assert.Equal(expectedClients[i].Phone, clientDtos[i].Phone);
            Assert.Equal(expectedClients[i].Email, clientDtos[i].Email);
        }
    }

    [Fact]
    public void METHOD()
    {
        
    }
}