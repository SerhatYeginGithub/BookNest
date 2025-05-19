namespace BookNest.Application.Services;

public interface IMailSender
{
    public Task SendEmailAsync(string toEmail, string userName, string verificationCode);
}