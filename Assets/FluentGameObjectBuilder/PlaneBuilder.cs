using UnityEngine;

namespace QFramework
{
    public class PlaneBuilder
    {
        private string mName { get; set; }

        public PlaneBuilder(string name)
        {
            mName = name;
        }

        public void Build()
        {
            //地面创建 节点
            var groundGameObj = Fluent.GameObject()
                .Name(mName)
                .Build();
            
            //创建 Mesh Filter
            var meshFilter = groundGameObj.AddComponent<MeshFilter>();
            
            //加载网格
            meshFilter.sharedMesh = Resources.GetBuiltinResource<Mesh>("New-Plane.fbx");
            
            //创建 网格碰撞器
            var meshCollider = groundGameObj.AddComponent<MeshCollider>();
            
            //设置网格
            meshCollider.sharedMesh = meshFilter.sharedMesh;
            
            //添加 网格渲染组件
            var meshRenderer = groundGameObj.AddComponent<MeshRenderer>();
            
            //设置默认得材质
            meshRenderer.materials[0]=new Material(Shader.Find("Standard"));
        }
    }
}