using MyRI.Components.Character;
using MyRI.Configs;
using MyRI.Mechanics.Controllers.Character.States;
using MyRI.Mechanics.Controllers.Collect;
using MyRI.Mechanics.Effects;

namespace MyRI.Mechanics.Controllers.Character
{
    
    /// <summary>
    /// character controller, control character move, states, effects and other elements
    /// </summary>
    public class CharacterController : ICharacterController, ISpeedTargetEffect, IFlyTargetEffect
    {
        
        /// <summary>
        /// collectables controller, control buffs and other collect elements
        /// </summary>
        private readonly CollectablesController _collectables;
        
        /// <summary>
        /// working with effects, attached on character
        /// </summary>
        private readonly IEffector _effector;
        
        /// <summary>
        /// state controller
        /// </summary>
        private readonly CharacterStateController _stateController;
        
        /// <summary>
        /// current character state
        /// </summary>
        private ICharacterState _currentState;

        public ICollectablesController Collectables => _collectables;
        public IMover Mover => _currentState.Mover;

        public CharacterController(ICharacterView characterView, CharacterConfig config)
        {
            _collectables = new CollectablesController(SceneStarter.Instance.MapSpawner);
            _stateController = new CharacterStateController(this, characterView, config, _collectables, _collectables);
            _effector = new Effector(_collectables);
            _effector.RegisterTarget(this as IFlyTargetEffect);
            _effector.RegisterTarget(this as ISpeedTargetEffect);
        }
        public void Destroy()
        {

            _effector.RemoveTarget(this as IFlyTargetEffect);
            _effector.RemoveTarget(this as ISpeedTargetEffect);
            _effector.Dispose();
            _collectables.Dispose();
            _stateController.Dispose();

        }
        public void SetState(ICharacterState state)
        {
            _currentState = state;
        }
    }
}
