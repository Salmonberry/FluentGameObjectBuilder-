using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.Exaple
{
    public class RallABall : MonoBehaviour
    {
        private void Awake()
        {
           Setup();
           BindInput();
        }
        
        private GameObject mPlayerGameobj { get; set; }
        private Rigidbody mPlayerRigidBody { get; set; }
        private GameObject mCameraObj { get; set; }

        ///设置
        private void Setup()
        {
             //创建相机
             mCameraObj= Fluent.GameObject()
                .Name("Main Camera")
                .Build();


            //设置camera位置
            Fluent.Camera(mCameraObj)
                .Position(new Vector3(0, 10, -10))
                .EulerAngles(new Vector3(45,0,0))
                .Build();

            //创建方向光
            var directionLightGameObj = Fluent.GameObject()
                .Name("Directtion Light")
                .Build();
            
            //设置光的类型
            Fluent.Light(directionLightGameObj)
                .Type(LightType.Directional)
                .EulerAngles(new Vector3(50, 60, 0)) //设置光源的方向
                .Build();

            //创建 地面
            var groundGameObject = Fluent.Plane("Ground")
                .LocalScale(new Vector3(2, 1, 2))
                .Build();

            groundGameObject
                .GetComponent<MeshRenderer>()
                .materials[0].color = Color.blue;

            //创建player
            mPlayerGameobj = Fluent.Sphere("Player")
                .Position(new Vector3(0, 0.5f, 0))
                .Build();
            mPlayerRigidBody = mPlayerGameobj.AddComponent<Rigidbody>();
            
            //西部的墙
//            var westwall=new GameObject("westwall");
//            
//            westwall.transform.position=new Vector3(-10,0,0);
//            westwall.transform.localScale=new Vector3(0.5f,2,20.5f);
//            //创建Mesh Filter
//            var meshFilter = westwall.AddComponent<MeshFilter>();
//            //加载网格
//            meshFilter.sharedMesh = Resources.GetBuiltinResource<Mesh>("Cube.fbx");
//            //创建盒子碰撞器
//            westwall.AddComponent<BoxCollider>();
//            //添加 网格渲染组件
//            var meshRenderer = westwall.AddComponent<MeshRenderer>();
//            //设置默认的材质
//            meshRenderer.materials[0]=new Material(Shader.Find("Standard"));

            Fluent.Cube("WestWall")
                .Position(new Vector3(-10, 0, 0))
                .LocalScale(new Vector3(0.5f, 2, 20.5f))
                .Build();
            
            Fluent.Cube("EastWall")
                .Position(new Vector3(10, 0, 0))
                .LocalScale(new Vector3(0.5f, 2, 20.5f))
                .Build();
            
            Fluent.Cube("North")
                .Position(new Vector3(0, 0, 10))
                .LocalScale(new Vector3(20.5f, 2, 0.5f))
                .Build();
            
            Fluent.Cube("South")
                .Position(new Vector3(0, 0, -10))
                .LocalScale(new Vector3(20.5f, 2, 0.5f))
                .Build();
            
                //半径
                var radius = 5;
                
                //间隔角度
                var deltaAngle = 30 * Mathf.Deg2Rad;

                for (int i = 0; i < 12; i++)
                {
                    var currentAngle = deltaAngle * i;
                    var x = Mathf.Cos(currentAngle) * radius;
                    var y = Mathf.Sin(currentAngle) * radius;

                    var cubeGameObj = Fluent.Cube("Pick up")
                        .Position(new Vector3(x, 0.5f, y))
                        .LocalScale(new Vector3(0.5f, 0.5f, 0.5f))
                        .EulerAngles(new Vector3(45, 45, 45))
                        .Build();
                    
                    Fluent.MonoBehaviour(cubeGameObj).OnUpdate(() =>
                    {
                        cubeGameObj.transform.Rotate(new Vector3(15,30,45)*Time.deltaTime);
                
                    }).Build();
                }
        }

        ///绑定并处理输入
        private void BindInput()
        {
            Fluent.MonoBehaviour(mPlayerGameobj).onFixedUpdate(() =>
            {
                var moveHorizontal = Input.GetAxis("Horizontal");
                var moveVertical = Input.GetAxis("Vertical");

                var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
                mPlayerRigidBody.AddForce(movement * 5);
            }).Build();
            
            //计算 摄像机和玩家的偏移值
            var offset = mCameraObj.transform.position - mPlayerGameobj.transform.position;
            
            Fluent.MonoBehaviour(mCameraObj).onLateUpdate(() =>
            {
                //每一帧都去设置偏移值，保证Camera永远与player的相对位置不变
                mCameraObj.transform.position = mPlayerGameobj.transform.position + offset;
            }).Build();
            
//           
        }
    }
}