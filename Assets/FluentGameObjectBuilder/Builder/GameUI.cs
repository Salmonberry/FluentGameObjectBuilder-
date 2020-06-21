using UnityEngine;

namespace QFramework.RollABall
{
    public class GameUI
    {
        public GameUI()
        {
            //创建Canvas
            var canvasGameobj = new CanvasBuilder()
                .RenderMode(RenderMode.ScreenSpaceOverlay)
                .Build();
            
            //创建 Text
            new TextBuilder()
                .AddToParent(canvasGameobj)
                .Text("10")
                .Build();

        }
    }
}