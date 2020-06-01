using UnityEngine;

namespace QFramework
{
    public class CameraBuilder
    {
        private GameObject mGameObject { get; set; }

        public CameraBuilder(GameObject gameObject)
        {
            mGameObject = gameObject;
        }

        public void Build()
        {
            mGameObject.AddComponent<Camera>();
        }
    }
}