using UnityEngine;

namespace QFramework
{
    public class FluentBuilder
    {
        protected GameObject mGameObject { get; set; }
        protected Vector3 mPosition { get; set; }
        
        protected Vector3 mEulerAngles { get; set; }

        public FluentBuilder(GameObject gameObject)
        {
            mGameObject = gameObject;
        }

        public FluentBuilder Position(Vector3 poition)
        {
            mPosition = poition;
            return this;
        }

        public FluentBuilder EulerAngles(Vector3 angles)
        {
            mEulerAngles = angles;
            return this;
        }

        public virtual void Build()
        {
            mGameObject.transform.position = mPosition;
            mGameObject.transform.eulerAngles = mEulerAngles;
        }
        
    }
}