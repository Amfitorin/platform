using MyRI.Components.Character;
using MyRI.Configs;
using MyRI.Mechanics.Controllers.Character.States;
using MyRI.Mechanics.Controllers.Collect;
using MyRI.Mechanics.Effects;

namespace MyRI.Mechanics.Controllers.Character
{
    public class CharacterController : ICharacterController, ISpeedTargetEffect, IFlyTargetEffect
    {
        private readonly IEffector _effector;
        private readonly CollectablesController _collectables;
        private ICharacterState _currentState;
        private readonly CharacterStateController _stateController;

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
