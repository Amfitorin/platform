using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;

namespace MyRI.Mechanics.LoopCycle
{
    public class UpdateProvider : IUpdateProvider
    {
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
        private List<IUpdateListener> _updateListeners = new();
        private readonly IDisposable _token;

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
