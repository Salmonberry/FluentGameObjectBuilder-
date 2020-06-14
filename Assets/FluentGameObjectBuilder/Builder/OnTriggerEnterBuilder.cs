using System;
using UnityEngine;

namespace QFramework
{
    public static partial class Fluent
    {
        public static OnTriggerEnterBuilder OnTriggerEnterBuilder(GameObject gameobject)
        {
            return new OnTriggerEnterBuilder(gameobject);
        }
    }
    public class OnTriggerEnterBuilder:FluentBuilder
    {
        
        public OnTriggerEnterBuilder(GameObject gameObject) : base(gameObject)
        {
        }

        private Action<Collider> mOnTriggerEnter;

        public OnTriggerEnterBuilder OnTriggerEnter(Action<Collider> onTriggerEnter)
        {
            mOnTriggerEnter = onTriggerEnter;
            return this;
        }

        public override GameObject Build()
        {
            var gameObject = base.Build();
            var trigger = gameObject.AddComponent<FluentOnTriggerEnterTrigger>();
            trigger.OnTriggerEnterEvent += mOnTriggerEnter;
            return gameObject;
        }
    }
}