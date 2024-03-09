using System.Reflection;
using Core.Data.Entity.Base;
using Core.Data.Enum;
using Core.Exceptions;

namespace Core.Extensions;

public static class BaseEntityExtensions
{
    public static bool IsSortableString(this AbstractEntiy entity, string sortBy)
    {
        return typeof(AbstractEntiy).GetProperty(sortBy,
            BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) != null;
    }
/// <summary>
/// if entity object is null this method throws a NotFoundException
/// </summary>
/// <param name="entity"></param>
/// <param name="langKey"></param>
/// <typeparam name="TEntity"></typeparam>
/// <returns></returns>
/// <exception cref="NotFoundException"></exception>
    public static TEntity CheckNull<TEntity>(this TEntity? entity, LangKeys langKey = LangKeys.NotFound)
        where TEntity : IEntity, new()
    {
        if (entity is null)
        {
            throw new NotFoundException(langKey);
        }

        return entity;
    }
}