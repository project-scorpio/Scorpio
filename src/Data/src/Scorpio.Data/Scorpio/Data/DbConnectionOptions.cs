﻿namespace Scorpio.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class DbConnectionOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public ConnectionStrings ConnectionStrings { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbConnectionOptions() => ConnectionStrings = new ConnectionStrings();
    }
}
