
using System;

namespace MyRI.Mechanics.LoopCycle
{
    public interface IUpdateProvider : IDisposable
    {
        void RegisterUpdateListener(IUpdateListener listener);
        void RemoveUpdateListener(IUpdateListener listener);
    }
}
