﻿namespace Cake.Apprenda.ACS.RemoveApplication
{
    /// <summary>
    /// Contains settings used by <see cref="RemoveApplication"/>
    /// </summary>
    public sealed class RemoveApplicationSettings : ACSSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveApplicationSettings"/> class.
        /// </summary>
        /// <param name="appAlias">The application alias.</param>
        public RemoveApplicationSettings(string appAlias)
        {
            this.AppAlias = appAlias;
        }

        /// <summary>
        /// Gets the application alias.
        /// </summary>
        /// <value>
        /// The application alias.
        /// </value>
        public string AppAlias { get; }
    }
}