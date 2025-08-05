using ClientCRUD.Models.Entities;
using ClientCRUD.Models.Interfaces;
using ClientCRUD.Services;
using ClientCRUD.Validations;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.Advertisement;
using Xunit;

namespace ClientCRUD_Test;
public class ClientServiceTests
{
    private readonly Mock<IClientRepository> clientRepository;
    private readonly ClientService clientService;
    private readonly IClientValidation clientValidation;

    public ClientServiceTests()
    {
        clientRepository = new Mock<IClientRepository>();
        clientValidation = new ClientValidation();
        clientService = new ClientService(clientRepository.Object, clientValidation);
    }

    [Fact]
    public void SaveClientTest()
    {
        var client = new ClientModel { Id = 1, Name = "Gerson", LastName = "Santos", Address = "Rua A", Age = 45 };
        clientService.SaveClient(client);

        clientRepository.Verify(x => x.Insert(client), Times.Once);  
    }

    [Theory]
    [InlineData(null, "Santos", "Rua A", 30, "Nome obrigatório.")]
    [InlineData("Gerson", null, "Rua A", 30, "Sobrenome obrigatório.")]
    [InlineData("Gerson", "Santos", null, 30, "Endereço obrigatório.")]
    [InlineData("Gerson", "Santos", "Rua A", -1, "Idade inválida.")]
    [InlineData("Gerson", "Santos", "Rua A", 150, "Idade inválida.")]
    public void SaveClientInvalidTest(string name, string lastName, string address, int age, string validateMessage)
    {
        var client = new ClientModel { Name = name, LastName = lastName, Address = address, Age = age };

        var ex = Assert.Throws<Exception>(() =>  clientService.SaveClient(client));

        Assert.Equal(validateMessage, ex.Message);
    }

    [Fact]
    public void UpdateClientTest()
    {
        var client = new ClientModel { Id = 1, Name = "Gerson", LastName = "Santos de souza", Address = "Rua A", Age = 45 };
        clientRepository.Setup(x => x.Exists(client.Id)).Returns(true);

        clientService.SaveClient(client);

        clientRepository.Verify(x => x.Update(client), Times.Once);  
    }

    [Fact]
    public void DeleteClientTest()
    {
        var client = new ClientModel { Id = 1, Name = "Gerson", LastName = "Santos de souza", Address = "Rua A", Age = 45 };

        clientService.DeleteClient(client);

        clientRepository.Verify(x => x.Delete(client), Times.Once);
    }
    [Fact]
    public void GetAllClientsTest()
    {
        var clientList = new List<ClientModel> { };
        clientRepository.Setup(x => x.GetAll()).Returns(clientList);

        var result = clientService.GetAllClients();

        Assert.Equal(clientList, result);
    }

    [Fact]
    public void NextIdText()
    {
        clientRepository.Setup(x => x.NextId()).Returns(1);

        var result = clientService.NextIdClient();

        Assert.Equal(1, result);
    }
}
