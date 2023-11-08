using System;
using MyRI.Configs.Collectables;

namespace MyRI.Mechanics.Effects
{
    /// <summary>
    /// data for character buff
    /// </summary>
    public class BuffData
    {
        /// <summary>
        /// time when buff expired
        /// </summary>
        public DateTime BuffEnd { get; }

        /// <summary>
        /// buff settings cofig
        /// </summary>
        public BuffCollectable Config { get; }

        
        /// <summary>
        /// is true if buff time not expired
        /// </summary>
        public bool IsActive => BuffEnd > DateTime.Now;

        
        /// <summary>
        /// remaining time to expire buff
        /// </summary>
        public TimeSpan Remaining => BuffEnd - DateTime.Now;

        /// <summary>
        /// buff start time
        /// </summary>
        public DateTime StartTime { get; }

        public BuffData(BuffCollectable config)
        {
            Config = config;
            StartTime = DateTime.Now;
            BuffEnd = StartTime + TimeSpan.FromSeconds(Config.Time);
        }
    }
}
