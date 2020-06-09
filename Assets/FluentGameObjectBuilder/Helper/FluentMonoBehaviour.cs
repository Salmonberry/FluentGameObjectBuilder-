using System;
using UnityEngine;

namespace QFramework
{
    public class FluentMonoBehaviour:MonoBehaviour
    {
        public event Action OnStartEvent = () => { };

        public event Action onFixedUpdateEvent = () => { };

        public event Action OnUpdateEvent = () => { };
        public event Action OnDestroyEvent = () => { };

        public event Action onLateUpdateEvent = () => { };

        private void Start()
        {
            OnStartEvent.Invoke();
        }

        private void Update()
        {
            OnUpdateEvent.Invoke();
        }

        private void FixedUpdate()
        {
            onFixedUpdateEvent.Invoke();
        }

        private void LateUpdate()
        {
            onLateUpdateEvent.Invoke();
        }

        private void OnDestroy()
        {
            OnDestroyEvent.Invoke();

            OnStartEvent = null;
            OnUpdateEvent = null;
            OnDestroyEvent = null;
            onLateUpdateEvent = null;
        }
    }
}