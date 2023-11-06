using System;
using MyRI.Configs.Collectables;

namespace MyRI.Mechanics.Effects
{
    public class BuffData
    {
        private BuffCollectable _config;

        private DateTime _buffEnd;

        private DateTime _startTime;

        public BuffCollectable Config => _config;

        public DateTime BuffEnd => _buffEnd;

        public DateTime StartTime => _startTime;

        public TimeSpan Remaining => _buffEnd - DateTime.Now;

        public bool IsActive => _buffEnd > DateTime.Now;

        public BuffData(BuffCollectable config)
        {
            _config = config;
            _startTime = DateTime.Now;
            _buffEnd = _startTime + TimeSpan.FromSeconds(_config.Time);
        }
    }
}
