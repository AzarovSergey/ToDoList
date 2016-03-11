namespace Epam.Wunderlist.Services.Interface.Mappers
{
    public interface IMapper
    {
        TTarget Map<TSource, TTarget>(TSource entity);
    }
}
