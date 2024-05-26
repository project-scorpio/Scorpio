﻿using System;
#if !NET8_0_OR_GREATER
using System.Runtime.Serialization;
#endif   

namespace Scorpio.Authorization.Permissions
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class PermissionNotFondException : ScorpioException
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="permissionName"></param>
        public PermissionNotFondException(string permissionName) : base($"Undefined permission: {permissionName}") => PermissionName = permissionName;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="permissionName"></param>
        /// <param name="message"></param>
        public PermissionNotFondException(string permissionName, string message) : base(message) => PermissionName = permissionName;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="permissionName"></param>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public PermissionNotFondException(string permissionName, string message, Exception innerException) : base(message, innerException) => PermissionName = permissionName;

#if !NET8_0_OR_GREATER

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected PermissionNotFondException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
#endif   

        /// <summary>
        /// 
        /// </summary>
        public string PermissionName { get; }
    }
}
