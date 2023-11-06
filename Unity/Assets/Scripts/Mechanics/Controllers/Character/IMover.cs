using System;

namespace MyRI.Mechanics.Controllers.Character
{
    public interface IMover : IDisposable
    {
        void Update();
        void ApplySpeedModifier(float maxSpeed);
    }
}
