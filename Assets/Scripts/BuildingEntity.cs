using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingEntity : MonoBehaviour
{

    public int planksRequired = 3;
    private bool built = false;
    private int planksSupplied;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void supplyPlank() {
        this.planksSupplied++;
        if (this.planksSupplied >= planksRequired)
        {
            GetComponent<Renderer>().material.shader = Shader.Find("Standard");
            GetComponent<MeshCollider>().isTrigger = false;
            this.built = true;
        }
    }

    public bool isBuilt() {
        return this.built;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!this.built && other.tag == "ResourcePlank")
        {
            this.supplyPlank();
            Destroy(other.gameObject);
        }
    }
}
