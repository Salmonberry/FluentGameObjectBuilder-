using UnityEngine;

namespace QFramework
{
    public static partial class Fluent
    {
        public static LightBuilder Light(GameObject gameObject)
        {
            return new LightBuilder(gameObject);
        }
    }

    public class LightBuilder:FluentBuilder
    {
//        private GameObject mGameObject { get; set; }
        private LightType mType { get; set; }

        public LightBuilder(GameObject gameObject) : base(gameObject)
        {
            
        }

        public LightBuilder Type(LightType type)
        {
            mType = type;
            return this;
        }

        public override void Build()
        {
            base.Build();
            var light = mGameObject.AddComponent<Light>();
            light.type = mType;
        }
        
    }
}