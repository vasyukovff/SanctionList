using SanctionList.Dto;

namespace SanctionList
{
    public static class Finder
    {
        public static List<ObjectDto> Find(ActionTypeEnum actionType, List<ObjectDto> objects, string value, bool isExactMatch = false)
        {
            var schema = actionType.GetEnumMemberValue();

            objects = objects.Where(x => x.Schema == schema).ToList();

            if(isExactMatch == false)
                objects = objects.Where(x => x.Caption.Contains(value)).ToList();
            else
                objects = objects.Where(x => x.Caption == value).ToList();

            return objects;
        }
    }
}
