using UnityEngine;

namespace QFramework.RollABall
{
    public class PickUpManager
    {
        public PickUpManager()
        {
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
    }
}