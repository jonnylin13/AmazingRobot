using UnityEngine;

public class PlayerActions : MonoBehaviour
{

    public int maxReach = 2;
    // private bool holdingItem = false;
    // private Transform itemHeld = null;
    // private string crateParent = null;
    public RoundManager roundManager;
    public SoundManager soundManager;
    public AnimationControl animationControl;
    public Battery battery;

    private float lastTriedPuzzle;

    private string answer = "";

    // Start is called before the first frame update
    void Start()
    {
        lastTriedPuzzle = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.toggleCursor();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // this.handleSwing();
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            this.handleInteract();
        }

    }

    void toggleCursor()
    {
        if (Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    void handleInteract()
    {
        
        var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.tag == "Interactable" && hit.distance < maxReach) {
                // Check which button
                Debug.Log(selection.name);
                if (selection.name == "main")
                {
                    roundManager.buttonPress();
                }
                else if (selection.name == "hatch")
                {
                    animationControl.interactHatchButton();
                    roundManager.checkDeliveredCrates();
                }
                else if (selection.name == "green" && roundManager.puzzle.HasPuzzle())
                {
                    handlePuzzle("G");
                }
                else if (selection.name == "red" && roundManager.puzzle.HasPuzzle())
                {
                    handlePuzzle("R");
                }
                else if (selection.name == "charging")
                {
                    battery.charge();
                }
                soundManager.clickButton();
            }
        }
       
    }

    void handlePuzzle(string c)
    {
        answer += c;
        if (answer.Length == roundManager.getLevel())
        {
            roundManager.puzzle.tryAnswer(answer);
            answer = "";
            lastTriedPuzzle = Time.fixedTime;
        }
    }
}
