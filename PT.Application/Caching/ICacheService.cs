namespace PT.Application.Caching
{
    public interface ICachedService
    {
        Task<T> GetAsync<T>(string key, CancellationToken cancellationToken = default);
        Task SetAsync<T>(
         string key,
         T value,
         TimeSpan? expiration = null,
         CancellationToken cancellationToken = default);
        Task RemoveAsync(string Key, CancellationToken cancellationToken = default);
    }
}
