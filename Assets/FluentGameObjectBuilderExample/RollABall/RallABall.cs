using System.Collections;
using System.Collections.Generic;
using QFramework.RollABall;
using UnityEngine;

namespace QFramework.Example
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
        
        /*游戏区域（场景设置）*/
        private GameArea mGameArea { get; set; }
        
        /*游戏摄像机*/
        private GameCamera mGameCamera { get; set; }
        
        ///设置
        private void Setup()
        {
            //创建 GameArea
            mGameArea=new GameArea();
            
            mGameCamera=new GameCamera();

            //创建player
            mPlayerGameobj = Fluent.Sphere("Player")
                .Position(new Vector3(0, 0.5f, 0))
                .Build();
            
            mPlayerRigidBody = mPlayerGameobj.AddComponent<Rigidbody>();

            //半径
            var radius = 5;

            //间隔角度
            var deltaAngle = 30 * Mathf.Deg2Rad;

            for (var i = 0; i < 12; i++)
            {
                var currentAngle = deltaAngle * i;

                var x = Mathf.Cos(currentAngle) * radius;
                var y = Mathf.Sin(currentAngle) * radius;

                var cubeGameObj = Fluent.Cube("Pick up")
                    .Color(Color.yellow)
                    .Position(new Vector3(x, 0.5f, y))
                    .LocalScale(new Vector3(0.5f, 0.5f, 0.5f))
                    .EulerAngles(new Vector3(45, 45, 45))
                    .Build();

                cubeGameObj.GetComponent<BoxCollider>().isTrigger = true;

                Fluent.MonoBehaviour(cubeGameObj).OnUpdate(() =>
                {
                    cubeGameObj.transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
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

            

            Fluent.OnTriggerEnterBuilder(mPlayerGameobj).OnTriggerEnter(other =>
            {
                if (other.gameObject.name == "Pick up")
                {
                    Destroy(other.gameObject);
                }
            }).Build();
            
            //开始跟随
            mGameCamera.StartFollowPlayer(mPlayerGameobj);
        }
    }
}