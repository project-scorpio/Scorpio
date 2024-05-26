﻿using System;
#if !NET8_0_OR_GREATER
using System.Runtime.Serialization;
#endif   

using Microsoft.Extensions.Logging;

using Scorpio.Logging;

namespace Scorpio.Authorization
{
    /// <summary>
    /// This exception is thrown on an unauthorized request.
    /// </summary>
    [Serializable]
    public class AuthorizationException : ScorpioException, IHasLogLevel
    {
        /// <summary>
        /// Severity of the exception.
        /// Default: Warn.
        /// </summary>
        public LogLevel LogLevel { get; set; }

        /// <summary>
        /// Creates a new <see cref="AuthorizationException"/> object.
        /// </summary>
        public AuthorizationException() => LogLevel = LogLevel.Warning;
#if !NET8_0_OR_GREATER

        /// <summary>
        /// Creates a new <see cref="AuthorizationException"/> object.
        /// </summary>
        protected AuthorizationException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }
#endif   

        /// <summary>
        /// Creates a new <see cref="AuthorizationException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        public AuthorizationException(string message)
            : base(message) => LogLevel = LogLevel.Warning;

        /// <summary>
        /// Creates a new <see cref="AuthorizationException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public AuthorizationException(string message, Exception innerException)
            : base(message, innerException) => LogLevel = LogLevel.Warning;

    }
}
