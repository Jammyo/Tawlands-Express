using UnityEngine;

namespace Prototypes.TrainSystems.LargeFuel
{
    public class LargeFuelStorage : MonoBehaviour, IItemHolder
    {
        [SerializeField] private GameObject _largeFuelPrefab;
        
        public void RemoveItem()
        {
            Instantiate(_largeFuelPrefab, transform);
        }
    }
}
