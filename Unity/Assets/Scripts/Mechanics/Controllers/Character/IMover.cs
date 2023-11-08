using System;

namespace MyRI.Mechanics.Controllers.Character
{
    /// <summary>
    /// character mover control character position
    /// </summary>
    public interface IMover : IDisposable
    {
        /// <summary>
        /// current character speed
        /// </summary>
        float CurrentSpeed { get; }
        
        /// <summary>
        /// applying speed modifier
        /// </summary>
        /// <param name="maxSpeed"> value for change player max speed</param>
        void ApplySpeedModifier(float maxSpeed);
    }
}
