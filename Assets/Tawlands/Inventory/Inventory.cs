using System.Linq;
using Tawlands.Inventory.Slot;
using UnityEngine;

namespace Tawlands.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private GameObject _slotPrefab;

        public bool Add(object item)
        {
            var emptySlot = GetComponentsInChildren<InventorySlot>().FirstOrDefault(slot => slot.IsEmpty());
            if (emptySlot == null)
            {
                return false;
            }

            emptySlot.AddItem(item);
            return true;
        }

        public void AddSlot()
        {
            Instantiate(_slotPrefab, transform);
        }
    }
}
