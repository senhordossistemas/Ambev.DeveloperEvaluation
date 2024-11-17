using Ambev.DeveloperEvaluation.MessageBroker.Messages;
using MassTransit;

namespace Ambev.DeveloperEvaluation.MessageBroker.Consumers;

public class SaleUpdatedConsumer : IConsumer<ISaleUpdated>
{
    public async Task Consume(ConsumeContext<ISaleUpdated> context)
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