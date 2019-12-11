using UnityEngine;

public class AnimationControl : MonoBehaviour
{

    public Animator hatch;
    public HatchTrigger hatchTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interactHatchButton() {
        closeHatch();
    }

    private void closeHatch()
    {
        hatch.SetBool("hatchOpen", false);
    }
}
