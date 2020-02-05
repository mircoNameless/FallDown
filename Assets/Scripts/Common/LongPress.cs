using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Common
{
    public class LongPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        [SerializeField] public UnityEvent onLongPress = new UnityEvent();
        public float interval;

        private bool isPointDown = false;
        private float lastInvokeTime;

        void Update()
        {
            if (isPointDown)
            {
                if (Time.time - lastInvokeTime > interval)
                {
                    //触发点击;  
                    onLongPress.Invoke();
                    lastInvokeTime = Time.time;
                }
            }

        }

        public void OnPointerDown(PointerEventData eventData)
        {
            onLongPress.Invoke();

            isPointDown = true;

            lastInvokeTime = Time.time;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isPointDown = false;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            isPointDown = false;
        }
    }
}
