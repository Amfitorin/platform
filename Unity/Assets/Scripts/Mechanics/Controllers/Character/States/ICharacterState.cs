namespace MyRI.Mechanics.Controllers.Character.States
{
    public interface ICharacterState
    {
        IMover Mover { get; }
        void ApplyState();
        void RemoveState();
    }
}
