using MyRI.Mechanics.Controllers.Character.States;
using MyRI.Mechanics.Controllers.Collect;

namespace MyRI.Mechanics.Controllers.Character
{
    public interface ICharacterController
    {
        ICollectablesController Collectables { get; }
        IMover Mover { get; }
        void Destroy();
        void SetState(ICharacterState state);
    }
}
