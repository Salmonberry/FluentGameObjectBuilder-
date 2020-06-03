using UnityEngine;

namespace QFramework
{
    public class CameraBuilder:FluentBuilder
    {
        private GameObject mGameObject { get; set; }

        public CameraBuilder(GameObject gameObject) : base(gameObject)
        {
            
        }

        public override void Build()
        {
            base.Build();
            mGameObject.AddComponent<Camera>();
        }
    }
}