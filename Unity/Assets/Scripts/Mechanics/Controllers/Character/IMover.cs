using System;

namespace MyRI.Mechanics.Controllers.Character
{
    public interface IMover : IDisposable
    {
        float CurrentSpeed { get; }
        void ApplySpeedModifier(float maxSpeed);
    }
}
