using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.Exaple
{
    public class RallABall : MonoBehaviour
    {
        private void Awake()
        {
            var gameObj= Fluent.GameObject()
                .Name("Main Camera")
                .Build();
            
            Fluent.Camera(gameObj).Build();
        }
    }

}

