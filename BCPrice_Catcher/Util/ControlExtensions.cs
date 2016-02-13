#region

using System;
using System.Reflection;
using System.Windows.Forms;

#endregion

namespace BCPrice_Catcher.Util
{
    public static class ControlExtensions
    {
        public static T Clone<T>(this T controlToClone)
            where T : Control
        {
            var controlProperties = typeof (T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var instance = Activator.CreateInstance<T>();

            foreach (var propInfo in controlProperties)
            {
                if (propInfo.CanWrite)
                {
                    if (propInfo.Name != "WindowTarget")
                        propInfo.SetValue(instance, propInfo.GetValue(controlToClone, null), null);
                }
            }

            return instance;
        }
    }
}