using NetMQ;
using NetMQ.Sockets;
using PricingWarehouse.Domain;
using PricingWarehouse.Infrastructure;
using PricingWarehouse.NETMQService;
using PricingWarehouse.Service;

using (var responseSocket = new ResponseSocket("@tcp://*:5555"))
{
    var dependencyInjector = new DependencyInjector();
    NETMQServiceRegistration.Build(dependencyInjector);

    var objectSerializer = dependencyInjector.Resolve<IObjectSerializer>();
    var optionService = dependencyInjector.Resolve<IProductService<IOption>>();

    while (true)
    {
        Console.WriteLine("service up and running");
        var message = responseSocket.ReceiveFrameString();
        Console.WriteLine($"service received: {message}");

        var priceable = objectSerializer.Deserialize<OptionPriceable>(message);
        var pricingResults = optionService.Price(priceable, dependencyInjector);

        var response = objectSerializer.Serialize(pricingResults);
        responseSocket.SendFrame(response);
    }

}