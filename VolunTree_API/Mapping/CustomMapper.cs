using Dapper;
using System;
using System.Linq;
using System.Reflection;

namespace SeuProjeto.Mappings
{
    public class CustomMapper : SqlMapper.ITypeMap
    {
        private readonly SqlMapper.ITypeMap _default;

        public CustomMapper(Type type)
        {
            _default = new CustomPropertyTypeMap(
                type,
                (t, columnName) => t.GetProperties().FirstOrDefault(prop => prop.Name.Equals(
                    string.Join("", columnName.Split('_').Select(word => char.ToUpper(word[0]) + word.Substring(1))),
                    StringComparison.OrdinalIgnoreCase))
            );
        }

        public ConstructorInfo FindConstructor(string[] names, Type[] types)
        {
            return _default.FindConstructor(names, types);
        }

        public ConstructorInfo FindExplicitConstructor()
        {
            return _default.FindExplicitConstructor();
        }

        public SqlMapper.IMemberMap GetConstructorParameter(ConstructorInfo constructor, string columnName)
        {
            return _default.GetConstructorParameter(constructor, columnName);
        }

        public SqlMapper.IMemberMap GetMember(string columnName)
        {
            return _default.GetMember(columnName);
        }
    }
}
