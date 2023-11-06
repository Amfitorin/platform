namespace MyRI.Mechanics.Controllers.Character.States
{
    public class CarState : ICharacterState
    {
        private readonly ICharacterController _character;
        public CarState(ICharacterController character)
        {
            _character = character;

        }

        public IMover Mover { get; }
        public void ApplyState()
        {

        }
        public void RemoveState()
        {

        }
    }
}
