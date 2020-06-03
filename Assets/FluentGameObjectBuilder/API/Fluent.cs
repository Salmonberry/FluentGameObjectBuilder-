using UnityEngine;

namespace QFramework
{
    public static partial class Fluent 
    {
        public static GameObjectBuilder GameObject()
        {
            return new GameObjectBuilder();
        }

        public static MonoBehaviourBuilder MonoBehaviour(GameObject gameObject)
        {
            return new MonoBehaviourBuilder(gameObject);
        }

        public static CameraBuilder Camera(GameObject gameObject)
        {
            return new CameraBuilder(gameObject);
        }

//        public static LightBuilder Light(GameObject gameObject)
//        {
//            return new LightBuilder(gameObject);
//        }

        public static PlaneBuilder Plane(string name)
        {
            return new PlaneBuilder(name);
        }

    }
}

