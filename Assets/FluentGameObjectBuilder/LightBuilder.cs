using UnityEngine;

namespace QFramework
{
    public class LightBuilder
    {
        private GameObject mGameObject { get; set; }
        private LightType mType { get; set; }

        public LightBuilder(GameObject gameObject)
        {
            mGameObject = gameObject;
        }

        public LightBuilder Type(LightType type)
        {
            mType = type;
            return this;
        }

        public void Build()
        {
            var light = mGameObject.AddComponent<Light>();
            light.type = mType;
        }
        
    }
}