﻿using System;
using System.Collections.Generic;

namespace Cake.Apprenda.ACS.NewUser
{
    /// <summary>
    /// Contains settings used by <see cref="NewUser"/>
    /// </summary>
    public sealed class NewUserSettings : CloudShellSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewUserSettings"/> class.
        /// </summary>
        public NewUserSettings()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewUserSettings"/> class.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="password">The password.</param>
        public NewUserSettings(string emailAddress, string firstName, string lastName, string password)
        {
            if (string.IsNullOrEmpty(emailAddress))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(emailAddress));
            }
            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(firstName));
            }
            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(lastName));
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(password));
            }

            this.EmailAddress = emailAddress;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
        }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the roles to assign to the new user
        /// </summary>
        public IEnumerable<string> Roles { get; set; } = new List<string>();
    }
}