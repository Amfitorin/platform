using MyRI.Configs.Collectables;
using MyRI.Mechanics.Controllers.Character;

namespace MyRI.Mechanics.Effects
{
    /// <summary>
    /// Target for speed change effect
    /// </summary>
    public interface ISpeedTargetEffect : IEffectTarget<SpeedBuff>
    {
        IMover Mover { get; }
    }
}
