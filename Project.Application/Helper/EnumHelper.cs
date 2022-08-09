using System.ComponentModel;

namespace Project.Application.Helper
{
    /// <summary>
    /// Расширение для перечеслений
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Получить значение атрибута Description у параметра.
        /// </summary>
        /// <typeparam name="TEnum">Тип enum</typeparam>
        /// <param name="enumValue">Значение.</param>
        /// <returns>Строку значение атрибута</returns>
        public static string GetEnumDescription<TEnum>(this TEnum enumValue)
            where TEnum : struct
        {
            var t = typeof(TEnum);
            if (!t.IsEnum)
            {
                throw new ArgumentException("Тип данных не является перечислимым типом", nameof(enumValue));
            }

            var fi = t.GetField(enumValue.ToString());

            if (fi.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attributes && attributes.Length > 0)
            {
                return attributes[0].Description;
            }

            return string.Empty;
        }
    }
}
