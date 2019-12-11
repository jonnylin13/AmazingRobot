using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateEntity : MonoBehaviour
{

    public GameObject plank;
    private RoundManager roundManager;
    private int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        roundManager = FindObjectOfType<RoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hitCrate(int damage) {
        this.health -= damage;
        if (this.health <= 0)
        {
            // Destroy the crate
            var pos = gameObject.transform.position;
            Destroy(gameObject);
            // Spawn planks with explosion force
            for (int i = 0; i < Mathf.FloorToInt(Random.Range(3, 6)); i++)
            {
                Instantiate(plank, pos, Random.rotation);
                plank.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1, 1), Random.Range(1, 2), Random.Range(-1, 1)) * 3, ForceMode.Impulse);
            }
            // roundManager.startDestroyCrateStory();
        }
    }

}
