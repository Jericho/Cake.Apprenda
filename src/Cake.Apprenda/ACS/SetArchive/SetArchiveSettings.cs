﻿using System;
using Cake.Core.IO;

namespace Cake.Apprenda.ACS.SetArchive
{
    /// <summary>
    /// Contains settings used by <see cref="SetArchive"/>
    /// </summary>
    public sealed class SetArchiveSettings : CloudShellSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SetArchiveSettings"/> class.
        /// </summary>
        public SetArchiveSettings()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetArchiveSettings" /> class.
        /// </summary>
        /// <param name="appAlias">The application alias.</param>
        /// <param name="versionAlias">The version alias.</param>
        /// <exception cref="System.ArgumentException">
        /// Value cannot be null or empty. - appAlias
        /// or
        /// Value cannot be null or empty. - versionAlias
        /// </exception>
        public SetArchiveSettings(string appAlias, string versionAlias)
        {
            if (string.IsNullOrEmpty(appAlias))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(appAlias));
            }

            if (string.IsNullOrEmpty(versionAlias))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(versionAlias));
            }

            this.AppAlias = appAlias;
            this.VersionAlias = versionAlias;
        }

        /// <summary>
        /// Gets or sets the application alias.
        /// </summary>
        /// <value>
        /// The application alias.
        /// </value>
        public string AppAlias { get; set; }

        /// <summary>
        /// Gets or sets the version alias.
        /// </summary>
        /// <value>
        /// The version alias.
        /// </value>
        public string VersionAlias { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="FilePath"/> to an archive file.  Cannot be used in conjunction with <seealso cref="SolutionPath"/>
        /// </summary>
        /// <value>
        /// The package path.
        /// </value>
        public FilePath ArchivePath { get; set; }

        /// <summary>
        /// Gets or sets the solution path. Cannot be used in conjunction with <seealso cref="ArchivePath"/>
        /// </summary>
        /// <value>
        /// The solution path.
        /// </value>
        public FilePath SolutionPath { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the patch should be constructive or not.  The default is destructive patching.
        /// </summary>
        public bool IsConstructive { get; set; }

        /// <summary>
        /// Gets or sets a value for the <see cref="FilePath"/> for the archive file to be written.
        /// </summary>
        /// <value>
        /// The archive output.
        /// </value>
        public FilePath ArchiveOutput { get; set; }

        /// <summary>
        /// Gets or sets the build settings to use when creating the package
        /// </summary>
        public BuildSettings BuildSettings { get; set; } = new BuildSettings();
    }
}