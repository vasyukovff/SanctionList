using System.Runtime.Serialization;

namespace SanctionList
{
    public enum ActionTypeEnum
    {
        [EnumMember(Value = "Person")]
        SearchByPeople = 1,

        [EnumMember(Value = "Organization")]
        SerachByCompanies = 2,
    }
}
