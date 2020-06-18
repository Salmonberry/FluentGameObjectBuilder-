using UnityEngine;

namespace QFramework.RollABall
{
    public class Player
    {
        private GameObject mPlayerobj { get; set; }
        
        private Rigidbody mRigidbody { get; set; }
        
        /*GameCamera 需要获取到Player的GameObject*/

        public GameObject GameObject
        {
            get { return mPlayerobj; }
        }

        public Player()
        {
            //创建 玩家
            mPlayerobj = Fluent.Sphere("Player")
                .Position(new Vector3(0, 0.5f, 0))
                .Build();
            
            mRigidbody = mPlayerobj.AddComponent<Rigidbody>();
        }
        
        /*开始监听用户输入*/
        public void StartListenUserInput()
        {
            Fluent.MonoBehaviour(mPlayerobj).onFixedUpdate(() =>
            {
                var moveHorizontal = Input.GetAxis("Horizontal");
                var moveVertical = Input.GetAxis("Vertical");

                var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
                mRigidbody.AddForce(movement * 5);
            }).Build();
        }
        
        /*开始检测碰撞*/
        public void StartCheckCollision()
        {
            Fluent.OnTriggerEnterBuilder(mPlayerobj).OnTriggerEnter(other =>
            {
                if (other.gameObject.name == "Pick up")
                {
                    Object.Destroy(other.gameObject);
                }
            }).Build();
        }
    }
}