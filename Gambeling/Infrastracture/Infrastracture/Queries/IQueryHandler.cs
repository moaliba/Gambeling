namespace Infrastracture.Queries;

public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult>
{
    public Task<TResult> HandelAsync(TQuery query);
}
