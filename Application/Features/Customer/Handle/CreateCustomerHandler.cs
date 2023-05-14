namespace Application.Features.Customer.Handle
{
    using Application.Features.Customer.Commands.Create;
    using Application.Wrappers;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Response<int>>
    {
        public async Task<Response<int>> Handle(
            CreateCustomerCommand request, 
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
