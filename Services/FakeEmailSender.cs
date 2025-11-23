using System;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Claudiu_Cojocaru_Lab2.Services;

public class FakeEmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        Debug.WriteLine($"FAKE EMAIL TO: {email}");
        Debug.WriteLine($"SUBJECT: {subject}");
        Debug.WriteLine($"BODY: {htmlMessage}");
        return Task.CompletedTask;
    }
}