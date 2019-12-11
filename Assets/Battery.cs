using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery : MonoBehaviour
{

    private int batteryLife = 100;
    private float timeElapsed = 0f;
    public PlayerActions pa;
    public EntityMovement movement;
    public RawImage image;
    private bool charging = false;

    public Texture empty;
    public Texture oneBar;
    public Texture twoBars;
    public Texture threeBars;
    public Texture full;

    public AudioSource beep;
    public AudioClip beepClip;

    public GameObject chargingStand;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        image.texture = full;
        InvokeRepeating("drainBattery", 0, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
    }

    public void charge()
    {
        if (charging) return;
        charging = true;
        InvokeRepeating("repeatingCharge", 0, 0.5f);
    }

    public void cancelCharge()
    {
        charging = false;
        CancelInvoke("repeatingCharge");
    }

    private void repeatingCharge()
    {
        if (Vector3.Distance(chargingStand.transform.position, player.transform.position) > 2) cancelCharge();
        batteryLife += 5;
        beep.PlayOneShot(beepClip);
        updateBatteryImage();
        if (batteryLife >= 100)
        {
            batteryLife = 100;
            cancelCharge();
        }
    }

    public void drainBattery()
    {
        if (movement.isMoving())
        {
            batteryLife -= 5;
            updateBatteryImage();
            if (batteryLife <= 0)
            {
                // End the game
            }
        }
    }

    private void updateBatteryImage()
    {
        if (batteryLife <= 0)
        {
            image.texture = empty;
        }
        else if (batteryLife <= 25)
        {
            image.texture = oneBar;
        }
        else if (batteryLife <= 50)
        {
            image.texture = twoBars;
        } else if (batteryLife <= 75)
        {
            image.texture = threeBars;
        } else
        {
            image.texture = full;
        }
    }
}
