//Abstraction

//reduuce complexity by hiding unnecessary services

using System;
namespace DesignPatternCourse.Abstraction
{
    public class EmailService
    {
        public void SendEmail()
        {
            Connect();
            Autthenticate();
            Console.WriteLine("Sending Email");
            Disocnnect();
        }

        private void Connect()
        {
            Console.WriteLine("Connecting to email server");
        }

        private void Autthenticate()
        {
            Console.WriteLine("Authenticating");
        }

        private void Disocnnect()
        {
            Console.WriteLine("Disconnecting from email server");
        }

    }
}

