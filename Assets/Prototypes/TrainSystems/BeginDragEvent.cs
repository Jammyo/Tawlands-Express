using UnityEngine;

namespace Prototypes.TrainSystems
{
    public class BeginDragEvent
    {
        public object Item { get; }
        public object Parent { get; }

        public BeginDragEvent(object item, object parent)
        {
            Item = item;
            Parent = parent;
        }
    }
}