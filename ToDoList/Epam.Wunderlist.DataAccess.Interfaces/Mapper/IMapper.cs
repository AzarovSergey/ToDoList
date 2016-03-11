namespace Epam.Wunderlist.DataAccess.Interfaces.Mapper
{
    public interface IMapper
    {
        TTarget Map<TSource, TTarget>(TSource entity);
    }

}