using System;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework
{

    public static partial class Fluent
    {
        public static CubeBuilder Cube(string name)
        {
            return new CubeBuilder(name);
        }
    }
    public class CubeBuilder:FluentBuilder
    {
        public CubeBuilder(GameObject gameObject) : base(gameObject)
        {
            
        }

        public CubeBuilder(string name) : base(new GameObject(name))
        {
            
        }
        
        
        List<Action<MeshRenderer>> mMeshRendererOperations = new List<Action<MeshRenderer>>();

        public CubeBuilder Color(Color color)
        {
            mMeshRendererOperations.Add(MeshRenderer => MeshRenderer.material.color = color);
            return this;
        }

        public override GameObject Build()
        {
            base.Build();
            
            //创建Mesh Filter
            var meshFilter = mGameObject.AddComponent<MeshFilter>();
            //加载网格
            meshFilter.sharedMesh = Resources.GetBuiltinResource<Mesh>("Cube.fbx");
            //创建盒子碰撞器
            mGameObject.AddComponent<BoxCollider>();
            //添加 网格渲染组件
            var meshRender = mGameObject.AddComponent<MeshRenderer>();
            //设置默认的材质
            meshRender.materials[0]=new Material(Shader.Find("Standard"));

            //遍历所有的操作
            mMeshRendererOperations.ForEach(operation => operation(meshRender));
            return base.Build();
        }
    }
}