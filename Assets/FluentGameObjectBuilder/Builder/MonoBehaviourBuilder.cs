using System;
using UnityEngine;

namespace QFramework
{
    public class MonoBehaviourBuilder
    {
        private Action mOnStart;
        private Action mOnUpdate;
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

        public MonoBehaviourBuilder OnDestroy(Action onDestroy)
        {
            mOnDestory = onDestroy;
            return this;
        }

        public void Build()
        {
            var monoBehaviour = mGameObject.AddComponent<FluentMonoBehaviour>();
            monoBehaviour.OnStartEvent += mOnStart;
            monoBehaviour.OnUpdateEvent += mOnUpdate;
            monoBehaviour.OnDestroyEvent += mOnDestory;
        }
    }
}