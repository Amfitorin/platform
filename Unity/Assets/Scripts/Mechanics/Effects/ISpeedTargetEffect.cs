using MyRI.Configs.Collectables;
using MyRI.Mechanics.Controllers.Character;

namespace MyRI.Mechanics.Effects
{
    public interface ISpeedTargetEffect : IEffectTarget<SpeedBuff>
    {
        IMover Mover { get; }
    }
}
