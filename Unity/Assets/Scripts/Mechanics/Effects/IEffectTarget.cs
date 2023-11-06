using MyRI.Configs.Collectables;

namespace MyRI.Mechanics.Effects
{
    public interface IEffectTarget{}
    public interface IEffectTarget<T> : IEffectTarget where T : BuffCollectable
    {
        
    }
}
