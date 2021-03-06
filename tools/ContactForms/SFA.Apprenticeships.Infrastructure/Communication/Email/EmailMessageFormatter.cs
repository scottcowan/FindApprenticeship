﻿namespace SFA.Apprenticeships.Infrastructure.Communication.Email
{
    using Application.Interfaces.Communications;
    using Domain.Entities;
    using SendGrid;

    public abstract class EmailMessageFormatter
    {
        public abstract void PopulateMessage(EmailRequest request, ISendGrid message);
    }
}