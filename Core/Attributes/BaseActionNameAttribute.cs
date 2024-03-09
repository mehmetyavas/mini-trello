using Core.Data.Enum;

namespace Core.Attributes;

public class BaseActionNameAttribute:Attribute
{
    public BaseActionNameAttribute(ActionName actionName)
    {
        ActionName = actionName;
    }
        
    public ActionName ActionName { get; init; }
}