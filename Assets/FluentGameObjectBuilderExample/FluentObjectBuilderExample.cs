using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;

public class FluentObjectBuilderExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //创建一个GameObject
        Fluent.GameObject()
            .Name("第一个GameObj")
            .Layer(1)
            .Tag("enemy")
            .Build();
        
        //调用生命周
        Fluent.MonoBehaviour(gameObject)
            .OnStart(() => { Debug.Log("On Satrt"); })
            .OnUpdate(()=>{Debug.Log("On Update");})
            .OnDestroy(()=>{Debug.Log("On Destory");})
            .Build();
        
        //前两个点得综合使用
        var gameObj = Fluent.GameObject()
            .Name("GameObjWithMonoBehavior")
            .Build();
        
        Fluent.MonoBehaviour(gameObj).OnStart(() =>
        {
            Debug.Log("start");
        }).Build();

    }

}
