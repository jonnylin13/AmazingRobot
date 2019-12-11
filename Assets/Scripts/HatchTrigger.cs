using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchTrigger : MonoBehaviour
{

    public ObjectDelivered objectDelivered;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Crate")
        {
            if (objectDelivered != null && objectDelivered.name == other.gameObject.name) return;
            objectDelivered.setObjectDelivered(other.gameObject);
        }
        else objectDelivered = null;
    }

    

    
}
