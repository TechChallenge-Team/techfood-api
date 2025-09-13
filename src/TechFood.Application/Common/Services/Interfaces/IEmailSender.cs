using System.Threading.Tasks;

namespace TechFood.Application.Common.Services.Interfaces;

public interface IEmailSender
{
    Task Send(string from, string to, string message);
}
