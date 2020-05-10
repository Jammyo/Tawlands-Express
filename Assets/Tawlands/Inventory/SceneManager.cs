using Tawlands.Items.Fuel;
using Tawlands.Items.Scrap;
using TMPro;
using UnityEngine;

namespace Tawlands.Inventory
{
    public class SceneManager : MonoBehaviour
    {
        [SerializeField] private Inventory _inventory;
        [SerializeField] private TextMeshProUGUI _feedback;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (!_inventory.Add(new FuelItem()))
                {
                    _feedback.text = "Failed to add fuel item because the inventory was full.";
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (!_inventory.Add(new ScrapItem()))
                {
                    _feedback.text = "Failed to add scrap item because the inventory was full.";
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                _inventory.AddSlot();
            }
        }
    }
}
