using System;

namespace MyRI.Mechanics.Effects
{
    public interface IBuffNotify
    {
        event Action<BuffData> BuffGained;
    }
}
