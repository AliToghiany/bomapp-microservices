namespace Anbarbomapp.Shared.Services.Contracts
{
    public interface IDateTimeProvider
    {
        DateTimeOffset GetCurrentDateTime();
    }
}