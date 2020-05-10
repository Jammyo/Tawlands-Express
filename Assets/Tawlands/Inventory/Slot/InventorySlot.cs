using JetBrains.Annotations;
using UnityEngine;

namespace Tawlands.Inventory.Slot
{
    public class InventorySlot : MonoBehaviour
    {
        [CanBeNull] private object _storedItem;
        
        public bool IsEmpty()
        {
            return _storedItem == null;
        }

        public void AddItem(object item)
        {
            _storedItem = item;
        }
    }
}
