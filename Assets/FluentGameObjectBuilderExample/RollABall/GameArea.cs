using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.RollABall
{
    public class GameArea
    {
        public  GameArea()
        {
            // 方向光的创建
            var directionLightGameObj = Fluent.GameObject()
                .Name("Direction Light")
                .Build();

            Fluent.Light(directionLightGameObj)
                .Type(LightType.Directional)
                .EulerAngles(new Vector3(50, 60, 0)) //
                .Build();

            // 创建 地面
            var groundGameObject = Fluent.Plane("Ground")
                .LocalScale(new Vector3(2, 1, 2))
                .Build();

            groundGameObject
                .GetComponent<MeshRenderer>()
                .materials[0].color = Color.blue;

            // 四面墙
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
        }
    }

}

