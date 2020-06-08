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

        ///设置
        private void Setup()
        {
             //创建相机
            var cameraGameObject = Fluent.GameObject()
                .Name("Main Camera")
                .Build();


            //设置camera位置
            Fluent.Camera(cameraGameObject)
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
        }
    }
}