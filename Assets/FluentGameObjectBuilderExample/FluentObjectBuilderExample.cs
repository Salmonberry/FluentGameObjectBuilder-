using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;

public class FluentObjectBuilderExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Fluent.GameObject()
            .Name("第一个GameObj")
            .Layer(1)
            .Tag("enemy")
            .Build();

        Fluent.MonoBehaviour(gameObject)
            .OnStart(() => { Debug.Log("On Satrt"); })
            .OnUpdate(()=>{Debug.Log("On Update");})
            .OnDestroy(()=>{Debug.Log("On Destory");})
            .Build();
            
    }

}
