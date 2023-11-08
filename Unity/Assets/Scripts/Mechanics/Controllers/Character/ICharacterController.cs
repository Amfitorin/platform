using MyRI.Mechanics.Controllers.Character.States;
using MyRI.Mechanics.Controllers.Collect;

namespace MyRI.Mechanics.Controllers.Character
{
    
    /// <summary>
    /// controller for character
    /// </summary>
    public interface ICharacterController
    {
        /// <summary>
        /// controller for collectables elements
        /// </summary>
        ICollectablesController Collectables { get; }
        
        /// <summary>
        /// current character mover
        /// </summary>
        IMover Mover { get; }
        
        /// <summary>
        /// destroy character
        /// </summary>
        void Destroy();
        
        /// <summary>
        /// setup current character state
        /// </summary>
        /// <param name="state"> character state</param>
        void SetState(ICharacterState state);
    }
}
