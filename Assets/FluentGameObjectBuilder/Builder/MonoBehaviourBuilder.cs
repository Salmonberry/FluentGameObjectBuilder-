using System;
using UnityEngine;

namespace QFramework
{
    public class MonoBehaviourBuilder
    {
        private Action mOnStart;
        private Action mOnUpdate;
        private Action mOnFixedUpdate;
        private Action mOnDestory;

        private GameObject mGameObject;

        public MonoBehaviourBuilder(GameObject gameObject)
        {
            mGameObject = gameObject;
        }

        public MonoBehaviourBuilder OnStart(Action onstart)
        {
            mOnStart = onstart;
            return this;
        }

        public MonoBehaviourBuilder OnUpdate(Action onUpdate)
        {
            mOnUpdate = onUpdate;
            return this;
        }

        public MonoBehaviourBuilder onFixedUpdate(Action onFixedUpdate)
        {
            mOnFixedUpdate = onFixedUpdate;
            return this;
        }

        public MonoBehaviourBuilder OnDestroy(Action onDestroy)
        {
            mOnDestory = onDestroy;
            return this;
        }

        public void Build()
        {
            var monoBehaviour = mGameObject.AddComponent<FluentMonoBehaviour>();

            if (mOnStart != null) monoBehaviour.OnStartEvent += mOnStart;
            if (mOnUpdate != null) monoBehaviour.OnUpdateEvent += mOnUpdate;
            if (mOnFixedUpdate != null) monoBehaviour.onFixedUpdateEvent += mOnFixedUpdate;
            if (mOnDestory != null) monoBehaviour.OnDestroyEvent += mOnDestory;
        }
    }
}