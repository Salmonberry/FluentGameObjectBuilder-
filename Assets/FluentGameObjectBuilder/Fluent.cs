using UnityEngine;

namespace QFramework
{
    public static class Fluent 
    {
        public static GameObjectBuilder GameObject()
        {
            return new GameObjectBuilder();
        }

        public static MonoBehaviourBuilder MonoBehaviour(GameObject gameObject)
        {
            return new MonoBehaviourBuilder(gameObject);
        }

    }
}

