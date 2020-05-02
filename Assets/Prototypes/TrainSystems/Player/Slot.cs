using System.Linq;
using Prototypes.TrainSystems.LargeFuel;
using Prototypes.TrainSystems.Scrap;
using Prototypes.TrainSystems.SmallFuel;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Prototypes.TrainSystems.Player
{
    public class Slot : MonoBehaviour, IDropHandler, IItemHolder, IHandle<BeginDragEvent>, IHandle<EndDragEvent>
    {
        [SerializeField] private Image _image;

        private void Awake()
        {
            EventAggregator.Instance.Subscribe(this);
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (GetComponentsInChildren<SmallFuelItem>().Any() || GetComponentsInChildren<LargeFuelItem>().Any() || GetComponentsInChildren<ScrapItem>().Any())
            {
                return;
            }
            
            if (eventData.pointerDrag != null)
            {
                var smallFuelItem = eventData.pointerDrag.GetComponent<SmallFuelItem>();
                if (smallFuelItem != null)
                {
                    smallFuelItem.MoveTo(this);
                }

                var largeFuelItem = eventData.pointerDrag.GetComponent<LargeFuelItem>();
                if (largeFuelItem != null)
                {
                    largeFuelItem.MoveTo(this);
                }

                var scrapItem = eventData.pointerDrag.GetComponent<ScrapItem>();
                if (scrapItem != null)
                {
                    scrapItem.MoveTo(this);
                }
            }
        }

        public void RemoveItem()
        {
        }

        public void Handle(BeginDragEvent @event)
        {
            if (!GetComponentsInChildren<SmallFuelItem>().Any() && !GetComponentsInChildren<LargeFuelItem>().Any() && !GetComponentsInChildren<ScrapItem>().Any())
            {
                Color.RGBToHSV(_image.color, out var h, out var s, out _);
                _image.color = Color.HSVToRGB(h, s, 1);
            }
        }

        public void Handle(EndDragEvent @event)
        {
            Color.RGBToHSV(_image.color, out var h, out var s, out _);
            _image.color = Color.HSVToRGB(h, s, 0.8f);
        }
    }
}
