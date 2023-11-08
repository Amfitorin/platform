using MyRI.Configs.Collectables;
using MyRI.Mechanics.Effects;

namespace MyRI.Components.Collectables
{
    /// <summary>
    /// View element for collectables
    /// </summary>
    public interface ICollectableView
    {
        
        /// <summary>
        /// Show buff item on hud
        /// </summary>
        /// <param name="buff"> Buff data for spawn</param>
        void ApplyBuff(BuffData buff);
        
        /// <summary>
        /// Show collected car part by type and count
        /// </summary>
        /// <param name="part"> Part type for car</param>
        /// <param name="count">Count of parts</param>
        void ShowCarPart(CarPartType part, int count);
    }
}
