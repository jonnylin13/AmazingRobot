using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDelivered : MonoBehaviour
{
    private GameObject obj = null;
    public RoundManager roundManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject getObjectDelivered()
    {
        return obj;
    }

    public void setObjectDelivered(GameObject objectDelivered)
    {
        obj = objectDelivered;
        roundManager.deliverObject(obj.name);
    }

    public bool hasObject()
    {
        return obj != null;
    }
}
