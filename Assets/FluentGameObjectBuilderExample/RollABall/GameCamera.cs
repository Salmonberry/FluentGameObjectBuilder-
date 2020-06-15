using UnityEngine;

namespace QFramework.RollABall
{
    public class GameCamera 
    {
        private  GameObject mCameraobj { get; set; }

        public GameCamera()
        {
            //默认摄像机的创建
            mCameraobj = Fluent.GameObject()
                .Name("Main Camera")
                .Build();


            //设置camera位置
            Fluent.Camera(mCameraobj)
                .Position(new Vector3(0, 10, -10))
                .EulerAngles(new Vector3(45, 0, 0))
                .Build();
        }

        public void StartFollowPlayer(GameObject playerobj)
        {
            //计算 摄像机和玩家的偏移值
            var offset = mCameraobj.transform.position - playerobj.transform.position;

            Fluent.MonoBehaviour(mCameraobj).onLateUpdate(() =>
            {
                //每一帧都去设置偏移值，保证Camera永远与player的相对位置不变
                mCameraobj.transform.position =playerobj.transform.position + offset;
            }).Build();
        }
        
        
    }
}