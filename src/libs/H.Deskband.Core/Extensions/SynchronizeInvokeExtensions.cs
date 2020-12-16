using System;
using System.ComponentModel;

#nullable enable

namespace H.Deskband.Core.Extensions
{
    /// <summary>
    /// Extensions that allow you to access the UI thread, if necessary.
    /// <![CDATA[Version: 1.0.0.1]]> <br/>
    /// </summary>
    public static class SynchronizeInvokeExtensions
    {
        /// <summary>
        /// Executes a method in a UI thread.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="action"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void InvokeIfRequired<T>(this T? obj, Action<T> action)
            where T : class, ISynchronizeInvoke
        {
            obj = obj ?? throw new ArgumentNullException(nameof(obj));

            if (!obj.InvokeRequired)
            {
                action(obj);
                return;
            }

            obj.Invoke(action, new object[] { obj });
        }
    }
}