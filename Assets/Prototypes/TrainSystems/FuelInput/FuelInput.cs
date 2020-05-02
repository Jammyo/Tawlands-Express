using System.Linq;
using Prototypes.TrainSystems.LargeFuel;
using Prototypes.TrainSystems.Player;
using Prototypes.TrainSystems.SmallFuel;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Prototypes.TrainSystems.FuelInput
{
    public class FuelInput : MonoBehaviour, IDropHandler, IHandle<BeginDragEvent>, IHandle<EndDragEvent>
    {
        [SerializeField] private Image _image;
        [SerializeField] private Slider _power;

        public FuelInput()
        {
            EventAggregator.Instance.Subscribe(this);
        }
    
        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null)
            {
                var smallFuelItem = eventData.pointerDrag.GetComponent<SmallFuelItem>();
                if (smallFuelItem != null)
                {
                    smallFuelItem.Delete();
                    EndDrag();
                    _power.value += 2;
                }

                var largeFuelItem = eventData.pointerDrag.GetComponent<LargeFuelItem>();
                if (largeFuelItem != null)
                {
                    largeFuelItem.Delete();
                    EndDrag();
                    _power.value += 5;
                }
            }
        }

        public void Handle(BeginDragEvent @event)
        {
            if (!GetComponentsInChildren<SmallFuelItem>().Any() 
                && !GetComponentsInChildren<LargeFuelItem>().Any() 
                && (@event.Item is SmallFuelItem || @event.Item is LargeFuelItem)
                && @event.Parent is Slot)
            {
                Color.RGBToHSV(_image.color, out var h, out var s, out _);
                _image.color = Color.HSVToRGB(h, s, 1);
            }
        }

        public void Handle(EndDragEvent @event)
        {
            EndDrag();
        }

        private void EndDrag()
        {
            Color.RGBToHSV(_image.color, out var h, out var s, out _);
            _image.color = Color.HSVToRGB(h, s, 0.8f);
        }
    }
}