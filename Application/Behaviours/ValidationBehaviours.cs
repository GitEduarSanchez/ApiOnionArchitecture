namespace Application.Behaviours
{
    using AutoMapper.Execution;
    using FluentValidation;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class ValidationBehaviours<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehaviours(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(this.validators.Any())
            {
                var context  = new FluentValidation.ValidationContext<TRequest>(request);
                var validattionResults = await Task.WhenAll(this.validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validattionResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
                if(failures.Count() != 0) throw new Exceptions.ValidationException(failures);
              
            }
            return await next();
        }
    }
}
