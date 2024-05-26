﻿using System;
#if !NET8_0_OR_GREATER
using System.Runtime.Serialization;
#endif

namespace Scorpio
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class ScorpioException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScorpioException"/> class.
        /// </summary>
        public ScorpioException() : base() { }
        /// <summary>
        ///  Initializes a new instance of the <see cref="ScorpioException"/> class with a specified error message.
        ///  </summary>
        /// <param name="message">The message that describes the error.</param>
        public ScorpioException(string message) : base(message) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ScorpioException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public ScorpioException(string message, Exception innerException) : base(message, innerException) { }
#if !NET8_0_OR_GREATER
        /// <summary>
        /// Initializes a new instance of the <see cref="ScorpioException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationException"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException">The info parameter is null.</exception>
        /// <exception cref="SerializationException">The class name is null or <see cref="System.Exception.HResult"/> is zero (0).</exception>
        protected ScorpioException(SerializationInfo info, StreamingContext context) : base(info, context) { }

#endif   
    }
}
