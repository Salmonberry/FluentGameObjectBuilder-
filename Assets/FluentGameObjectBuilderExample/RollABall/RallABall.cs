using System.Collections;
using System.Collections.Generic;
using QFramework.RollABall;
using UnityEngine;
using UnityEngine.UI;

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

        /*可拾取快管理器*/
        private PickUpManager mPickUpManager { get; set; }

        /*玩家*/
        private Player mPlayer { get; set; }

        ///设置
        private void Setup()
        {
            //创建 GameArea
            mGameArea = new GameArea();

            mGameCamera = new GameCamera();

            mPickUpManager = new PickUpManager();

            mPlayer = new Player();

            //创建 Canvas
//            var canvasGameobj=new GameObject("Canvas");
//            var canvas = canvasGameobj.AddComponent<Canvas>();
            var canvasGameObj = new CanvasBuilder()
                .RenderMode(RenderMode.ScreenSpaceOverlay)
                .Build();
            
            //默认值
//            canvas.renderMode = RenderMode.ScreenSpaceOverlay;

            //创建Text
            var scoreGameobj = new GameObject("Score");

            //设置canvans父子节点
            scoreGameobj.transform.SetParent(canvas.transform);
            //需要手动设置一下位置
            scoreGameobj.transform.localPosition = Vector3.zero;
            var scoreText = scoreGameobj.AddComponent<Text>();
            //需要手动设置字体
            scoreText.font = Font.CreateDynamicFontFromOSFont("Arial", 16);
            scoreText.text = "10";
        }

        /*绑定并处理输入*/
        void BindInput()
        {
            mPlayer.StartListenUserInput();
            mPlayer.StartCheckCollision();
            mGameCamera.StartFollowPlayer(mPlayer.GameObject);
        }
    }
}