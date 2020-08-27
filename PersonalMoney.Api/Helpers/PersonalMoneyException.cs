using System;

namespace PersonalMoney.Api.Helpers
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="Exception" />
    public class PersonalMoneyException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonalMoneyException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public PersonalMoneyException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonalMoneyException"/> class.
        /// </summary>
        public PersonalMoneyException() : this(string.Empty)
        {
        }
    }
}