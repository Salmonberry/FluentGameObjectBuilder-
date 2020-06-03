using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.Exaple
{
    public class RallABall : MonoBehaviour
    {
        private void Awake()
        {
            //创建相机
            var cameraGameObject = Fluent.GameObject()
                .Name("Main Camera")
                .Build();

           
            
            //设置camera位置
//            cameraGameObject.transform.position=Vector3.up;
            Fluent.Camera(cameraGameObject).Position(Vector3.up).Build();
            

            //创建方向光
            var directionLightGameObj = Fluent.GameObject()
                .Name("Directtion Light")
                .Build();
            
            //设置光得方向
//            directionLightGameObj.transform.eulerAngles=Vector3.right*45;
            
            //设置光的类型
            Fluent.Light(directionLightGameObj)
                .Type(LightType.Directional)
                .EulerAngles(Vector3.right*45) //设置光源的方向
                .Build();
            //var light= directionLightGameObj.AddComponent<Light>();
            //light.type = LightType.Directional;

//            //地面创建 节点
//            var groundGameObj = Fluent.GameObject().Name("Ground").Build();
//            
//            //创建Mesh Filter
//            var meshFilter = groundGameObj.AddComponent<MeshFilter>();
//            
//            //加载网格
//            meshFilter.sharedMesh = Resources.GetBuiltinResource<Mesh>("New-Plane.fbx");
//            
//            //创建 网格碰撞器
//            var meshCollider = groundGameObj.AddComponent<MeshCollider>();
//            
//            //设置网格
//            meshCollider.sharedMesh = meshFilter.sharedMesh;
//            
//            //添加 网格渲染组件
//            var meshRenderer = groundGameObj.AddComponent<MeshRenderer>();
//            
//            //设置默认材质
//            meshRenderer.materials[0]=new Material(Shader.Find("Standard"));

              //创建 地面
            Fluent.Plane("Ground").Build();

            //创建player
        }
    }
}