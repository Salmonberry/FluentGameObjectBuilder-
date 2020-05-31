using UnityEngine;

namespace QFramework
{
    public class GameObjectBuilder
    {
        private string mName { get; set; }
        private int mLayer { get; set; }
        private string mTag { get; set; }

        public GameObjectBuilder Name(string name)
        {
            mName = name;
            return this;
        }

        public GameObjectBuilder Layer(int layer)
        {
            mLayer = layer;
            return this;
        }

        public GameObjectBuilder Tag(string tag)
        {
            mTag = tag;
            return this;
        }

        public GameObject Build()
        {
            return new GameObject
            {
                name = mName,
                layer = mLayer,
                tag = mTag
            };
        }
    }
}