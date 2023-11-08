using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;

namespace MyRI.Mechanics.LoopCycle
{
    /// <summary>
    /// provider for update cycle
    /// </summary>
    public class UpdateProvider : IUpdateProvider
    {
        /// <summary>
        /// update loop token
        /// </summary>
        private readonly IDisposable _token;
        
        /// <summary>
        /// registered update listeners
        /// </summary>
        private readonly List<IUpdateListener> _updateListeners = new();
        
        public UpdateProvider()
        {
            _token = Observable.EveryUpdate().Subscribe(_ =>
            {
                if (_updateListeners == null)
                    return;
                foreach (var listener in _updateListeners)
                {
                    listener.Update();
                }
            });
        }

        public void RegisterUpdateListener(IUpdateListener obj)
        {
            if (_updateListeners.Contains(obj))
                return;
            _updateListeners.Add(obj);
        }
        public void RemoveUpdateListener(IUpdateListener listener)
        {
            var index = _updateListeners.IndexOf(listener);
            if (index == -1)
                return;
            _updateListeners[index] = _updateListeners.Last();
            _updateListeners.RemoveAt(_updateListeners.Count - 1);
        }
        public void Dispose()
        {
            _token?.Dispose();
            foreach (var listener in _updateListeners)
            {
                RemoveUpdateListener(listener);
            }
            _updateListeners.Clear();
        }
    }
}
