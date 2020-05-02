using UnityEngine;

namespace Prototypes.TrainSystems
{
    public interface IItemHolder
    {
        Transform transform { get; }
        void RemoveItem();
    }
}