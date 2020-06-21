using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

namespace QFramework
{
    public partial class Fluent
    {
        public static TextBuilder Text()
        {
            return new TextBuilder();
        }
    }
    
    public class TextBuilder:FluentBuilder
    {
        public TextBuilder() : base(new GameObject("Text"))
        {
        }
        
        public  List<Action<Text>> mTextOperations=new List<Action<Text>>();

        public TextBuilder AddToParent(GameObject parentGameObj)
        {
            mTextOperations.Add((text) =>
            {
                text.transform.SetParent(parentGameObj.transform);
                text.transform.localPosition = Vector3.zero;
            });
            return this;
        }

        public TextBuilder Text(string text)
        {
            mTextOperations.Add((textComponent) => { textComponent.text = text;});
            return this;
        }

        public override GameObject Build()
        {
            var gameobj = base.Build();

            var text = gameobj.AddComponent<Text>();
            mTextOperations.ForEach(operation=>operation(text));
            text.font = Font.CreateDynamicFontFromOSFont("Arial", 16);
            return gameobj;
        }
    }
}