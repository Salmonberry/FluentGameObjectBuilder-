using UnityEngine;

namespace QFramework
{
    public static partial class Fluent
    {
        public static SphereBuilder Sphere(string name)
        {
            return new SphereBuilder(name);
        }
    }
    public class SphereBuilder :FluentBuilder
    {
        public SphereBuilder(string name) : base(new GameObject())
        {
            
        }

        public override void Build()
        {
            base.Build();
            
            //创建Mesh Filter
            var meshFilter = mGameObject.AddComponent<MeshFilter>();
            
            //加载网格
            meshFilter.sharedMesh = Resources.GetBuiltinResource<Mesh>("New-Sphere.fbx");
            
            //创建 网格碰撞器
            var meshCollider = mGameObject.AddComponent<MeshCollider>();
            
            //设置网格
            meshCollider.sharedMesh = meshFilter.sharedMesh;
            
            //添加 网格渲染组件
            var meshRenderer = mGameObject.AddComponent<MeshRenderer>();
            
            //设置默认的材质
            meshRenderer.materials[0]=new Material(Shader.Find("standard"));

        }
    }
}