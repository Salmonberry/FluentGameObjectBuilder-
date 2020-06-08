using UnityEngine;

namespace QFramework
{
    public class FluentBuilder
    {
        protected GameObject mGameObject { get; set; }
        protected Vector3 mPosition { get; set; }
        
        protected Vector3 mEulerAngles { get; set; }
        protected Vector3 mLocalScale { get; set; }

        public FluentBuilder(GameObject gameObject)
        {
            //scale 要设置为（1，1，1）
            mLocalScale=Vector3.one;
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

        public FluentBuilder LocalScale(Vector3 scale)
        {
            mLocalScale = scale;
            return this;
        }

        public virtual GameObject Build()
        {
            mGameObject.transform.position = mPosition;
            mGameObject.transform.eulerAngles = mEulerAngles;
            mGameObject.transform.localScale = mLocalScale;

            return mGameObject;
        }
        
    }
}