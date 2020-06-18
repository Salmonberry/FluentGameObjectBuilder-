using System;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework
{
    public partial class Fluent
    {
        public static CanvasBuilder Canvas()
        {
            return new CanvasBuilder();
        }
    }
    
    public class CanvasBuilder:FluentBuilder
    {
        public CanvasBuilder() : base(new GameObject("Canvas"))
        {
            
        }
        
        List<Action<Canvas>> mCanvasOperations=new List<Action<Canvas>>();

        public CanvasBuilder RenderMode(RenderMode renderMode)
        {
            mCanvasOperations.Add((canvas) => canvas.renderMode=renderMode);
            return this;
        }

        public override GameObject Build()
        {
            var gameObject = base.Build();

            var canvas = gameObject.AddComponent<Canvas>();

            mCanvasOperations.ForEach(operation => operation(canvas));

            return gameObject;
        }
    }
}