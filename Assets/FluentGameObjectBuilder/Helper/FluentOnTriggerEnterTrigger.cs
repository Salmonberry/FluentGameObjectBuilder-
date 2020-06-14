using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework
{
   
    public class FluentOnTriggerEnterTrigger : MonoBehaviour
    {
        public event Action<Collider> OnTriggerEnterEvent = (other) => { };

        private void OnTriggerEnter(Collider other)
        {
            if (OnTriggerEnterEvent!=null) OnTriggerEnterEvent.Invoke(other);
        }
    }
}

