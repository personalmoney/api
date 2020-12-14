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
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string Code { get; set; } = "0001";

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