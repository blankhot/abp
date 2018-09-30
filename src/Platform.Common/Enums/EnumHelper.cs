using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Platform.Enums
{
    public static class EnumHelper
    {
        /// <summary>
        /// 获取枚举值的描述文本
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>      
        public static string GetEnumDescription(object e)
        {
            FieldInfo[] ms = e.GetType().GetFields();
            Type t = e.GetType();

            foreach (FieldInfo f in ms)
            {
                if (f.Name != e.ToString()) continue;
                foreach (Attribute attr in f.GetCustomAttributes(true))
                {
                    DescriptionAttribute dscript = attr as DescriptionAttribute;
                    if (dscript != null)
                        return dscript.Description;
                }
            }
            return e.ToString();
        }
        /// <summary>
        /// 获取枚举值的描述获得枚举对象
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>    
        public static object GetEnumObject(object e, Type type, string description)
        {
            FieldInfo[] ms = e.GetType().GetFields();

            string enumName = string.Empty;

            foreach (FieldInfo f in ms)
            {

                foreach (Attribute attr in f.GetCustomAttributes(true))
                {
                    DescriptionAttribute dscript = attr as DescriptionAttribute;
                    if (dscript != null)
                    {
                        if (dscript.Description == description)
                        {
                            enumName = f.Name;
                            break;
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(enumName))
            {
                return Enum.Parse(type, enumName);
            }
            return null;
        }

        /// <summary>
        ///把枚举转化成 字典类型（key:描述，value：值）
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>    
        public static Dictionary<string, string> ToDictionary(Enum e)
        {
            Dictionary<string, string> list = new Dictionary<string, string>();

            FieldInfo[] ms = e.GetType().GetFields();
            foreach (FieldInfo f in ms)
            {
                foreach (Attribute attr in f.GetCustomAttributes(true))
                {
                    DescriptionAttribute dscript = attr as DescriptionAttribute;
                    if (dscript != null)
                    {
                        if (f.Name != "value_")
                        {
                            list.Add(dscript.Description
                                , ((int)GetEnumObject(e, e.GetType(), dscript.Description)).ToString());
                        }
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 根据枚举项 获取 枚举的描述
        /// </summary>
        /// <param name="e"></param>
        /// <param name="selectValue">选中的值：字符串类型</param>
        /// <returns></returns>
        public static string GetEnumDescriptionText(this Enum e, object selectValue)
        {
            if (selectValue == null) return string.Empty;


            FieldInfo[] ms = e.GetType().GetFields();
            foreach (FieldInfo f in ms)
            {
                foreach (Attribute attr in f.GetCustomAttributes(true))
                {
                    DescriptionAttribute dscript = attr as DescriptionAttribute;
                    if (dscript != null)
                    {

                        if (f.Name != "value_" && f.Name != "value__")
                        {
                            string itemText = dscript.Description;
                            string itemValue = ((int)EnumHelper.GetEnumObject(e, e.GetType(), itemText)).ToString();

                            if (itemValue.Equals(selectValue.ToString()))
                                return itemText;
                        }
                    }
                }
            }
            return string.Empty;
        }
    }
}
