using MediatR;
using PT.Application.Caching;
using PT.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Application.Abstraction.Behaviours
{
    public class QueryCachingBehavior<TRequest, TResponse>(ICachedService _cachedService) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICachedQuery
        where TResponse : Result
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            TResponse cachedResult = await _cachedService.GetAsync<TResponse>(request.CacheKey,cancellationToken);
            if (cachedResult != null) 
            {
                return cachedResult;
            }
            TResponse result = await next();
            if (result.IsSuccess)
            {
                await _cachedService.SetAsync(request.CacheKey, result,request.Expiration, cancellationToken);
            }
            return result;
        }
    }
}
