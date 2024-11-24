
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Scorpio
{
    /// <summary>
    /// 
    /// </summary>
    [DebuggerStepThrough]
    public static class Check
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argument"></param>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public static T NotNull<T>(T argument, string parameterName = null) => argument == null ? throw new ArgumentNullException(parameterName) : argument;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="parameterName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static T NotNull<T>(T value, string parameterName, string message) => value == null ? throw new ArgumentNullException(parameterName, message) : value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public static string NotNullOrWhiteSpace(string value, string parameterName)
        {
            return value.IsNullOrWhiteSpace()
                ? throw new ArgumentException($"{parameterName} can not be null, empty or white space!", parameterName)
                : value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public static string NotNullOrEmpty(string value, string parameterName) => value.IsNullOrEmpty() ? throw new ArgumentException($"{parameterName} can not be null or empty!", parameterName) : value;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public static ICollection<T> NotNullOrEmpty<T>(ICollection<T> value, string parameterName) => value.IsNullOrEmpty() ? throw new ArgumentException(parameterName + " can not be null or empty!", parameterName) : value;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TBaseType"></typeparam>
        /// <param name="type"></param>
        /// <param name="parameterName"></param>
        public static Type AssignableTo<TBaseType>(
                    Type type,
                    string parameterName)
        {
            NotNull(type, parameterName);

            return !type.IsAssignableTo<TBaseType>()
                ? throw new ArgumentException($"{parameterName} (type of {type.AssemblyQualifiedName}) should be assignable to the {typeof(TBaseType).GetFullNameWithAssemblyName()}!", parameterName)
                : type;
        }
    }
}
