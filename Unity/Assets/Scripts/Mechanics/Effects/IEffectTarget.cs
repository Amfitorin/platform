using MyRI.Configs.Collectables;

namespace MyRI.Mechanics.Effects
{
    /// <summary>
    /// Effect target
    /// </summary>
    public interface IEffectTarget
    {
    }
    
    /// <summary>
    /// Typed effect target for buff type
    /// </summary>
    public interface IEffectTarget<T> : IEffectTarget where T : BuffCollectable
    {
    }
}
