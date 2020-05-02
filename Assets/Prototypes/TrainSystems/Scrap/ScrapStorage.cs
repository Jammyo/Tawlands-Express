using UnityEngine;

namespace Prototypes.TrainSystems.Scrap
{
    public class ScrapStorage : MonoBehaviour, IItemHolder
    {
        [SerializeField] private GameObject _scrapPrefab;

        public void RemoveItem()
        {
            Instantiate(_scrapPrefab, transform);
        }
    }
}
