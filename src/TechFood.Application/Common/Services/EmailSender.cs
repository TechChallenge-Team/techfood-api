using System.Threading.Tasks;
using TechFood.Application.Common.Services.Interfaces;

namespace TechFood.Application.Common.Services;

public class EmailSender : IEmailSender
{
    public Task Send(string from, string to, string message)
    {
        return Task.CompletedTask;
    }
}
