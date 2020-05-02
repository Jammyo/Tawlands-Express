using UnityEngine;

namespace Prototypes.TrainSystems.SmallFuel
{
    public class SmallFuelStorage : MonoBehaviour, IItemHolder
    {
        [SerializeField] private GameObject _smallFuelPrefab;

        public void RemoveItem()
        {
            Instantiate(_smallFuelPrefab, transform);
        }
    }
}
