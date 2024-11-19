// See https://aka.ms/new-console-template for more information
using DesignPatternCourse.Abstraction;

EmailService emailService = new EmailService();
emailService.SendEmail();


//after making private all the data are hidden from the user
// emailService.Connect();
// emailService.Autthenticate();
// emailService.SendEmail();
// emailService.Disocnnect();

