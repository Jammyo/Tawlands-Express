using UnityEngine;
using UnityEngine.EventSystems;

namespace Prototypes.TrainSystems.LargeFuel
{
    public class LargeFuelItem : MonoBehaviour, IItem, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        private Canvas _canvas;
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private CanvasGroup _canvasGroup;

        private IItemHolder _owner;

        private void Awake()
        {
            _canvas = FindObjectOfType<Canvas>();
            _owner = GetComponentInParent<IItemHolder>();
        }

        public void MoveTo(IItemHolder parent)
        {
            _owner.RemoveItem();
            _owner = parent;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.alpha = 0.75f;
        
            transform.SetParent(_canvas.transform, true);
            EventAggregator.Instance.Publish(new BeginDragEvent(this, _owner));
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.alpha = 1;

            transform.SetParent(_owner.transform);
            gameObject.transform.localPosition = Vector3.zero;
            
            EventAggregator.Instance.Publish(new EndDragEvent());
        }

        public void Delete()
        {
            Destroy(gameObject);
        }
    }
}
