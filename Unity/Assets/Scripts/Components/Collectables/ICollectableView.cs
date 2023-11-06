using MyRI.Configs.Collectables;
using MyRI.Mechanics;
using MyRI.Mechanics.Effects;

namespace MyRI.Components.Collectables
{
    public interface ICollectableView
    {
        void ShowCarPart(CarPartType part, int count);
        void ApplyBuff(BuffData buff);
    }
}
