using Ambev.DeveloperEvaluation.MessageBroker.Messages;
using MassTransit;

namespace Ambev.DeveloperEvaluation.MessageBroker.Consumers;

public class SaleCreatedConsumer : IConsumer<ISaleCreated>
{
    public async Task Consume(ConsumeContext<ISaleCreated> context)
    {
        try
        {
            Console.WriteLine("Mensagem recebida no consumidor");
            await Task.CompletedTask;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}