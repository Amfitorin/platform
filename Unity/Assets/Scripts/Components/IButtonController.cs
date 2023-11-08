using System;

namespace MyRI.Components
{
    public interface IButtonController
    {
        event Action OnUpEvent;
        event Action OnDownEvent;
        event Action OnClickEvent;
    }
}
