﻿using MediaBrowser.Model.Plugins;

namespace MediaBrowser.Plugins.Trailers.Configuration
{
    /// <summary>
    /// Class PluginConfiguration
    /// </summary>
    public class PluginConfiguration : BasePluginConfiguration
    {
        /// <summary>
        /// Trailers older than this will not be downloaded and deleted if already downloaded.
        /// </summary>
        /// <value>The max trailer age.</value>
        public int? MaxTrailerAge { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [enable trailer folder].
        /// </summary>
        /// <value><c>true</c> if [enable trailer folder]; otherwise, <c>false</c>.</value>
        public bool EnableTrailerFolder { get; set; }

        public PluginConfiguration()
        {
            EnableTrailerFolder = true;
        }
    }
}
