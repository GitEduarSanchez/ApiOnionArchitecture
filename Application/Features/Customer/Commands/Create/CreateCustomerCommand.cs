namespace Application.Features.Customer.Commands.Create
{
    using Application.Wrappers;
    using MediatR;
    using System;

    public class CreateCustomerCommand :IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string address { get; set; }
    }
}
