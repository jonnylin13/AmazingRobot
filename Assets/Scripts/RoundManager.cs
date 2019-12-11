using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundManager : MonoBehaviour
{
    public TextMeshPro screenText;
    public SoundManager soundManager;
    public ComputerPuzzle puzzle;

    private int tutorialIndex = 0;

    private float delay = 1;
    private bool buttonStopped = false;
    private List<string> cratesToDeliver = new List<string>();
    private List<string> deliveredCrates = new List<string>();
    private int level = 1;
    private float levelStarted;
    private int score = 0;

    private string[] tutorial = {
        "\nPRESS BUTTON",
        "GREETINGS\nWORKER #4CF9AE\nPRESS BUTTON",
        "YOU ARE A\nVALUED EMPLOYEE\nHERE AT AMAZING, INC",
        "YOUR MISSION IS TO\nMOVE MARKED CRATES\nTO THE DELIVERY HATCH",
        "WHEN YOU ARE DONE\nCONFIRM USING THE\nCOMPUTER TO YOUR LEFT",
        "BE SURE TO\nMONITOR YOUR\nBATTERY USAGE",
        "THERE IS A\nCHARGING STATION TO\nTHE LEFT OF THE SCREEN",
        "IF YOU ARE READY\nCONFIRM ON THE\nCOMPUTER"
    };

    // Update is called once per frame
    void Update()
    {
        if (delay >= 0) delay -= Time.deltaTime;
        else
        {
            if (level >= 2)
            {
                // Set the normal game text
                int delivery = level - 1;
                screenText.SetText("\nDELIVERY " + delivery);
            }
            else
            {
                screenText.SetText(tutorial[tutorialIndex]);
                delay = Random.Range(2, 3);
                buttonStopped = false;
            }
        }
    }

    public void buttonPress()
    {
        if (buttonStopped) return;

        buttonStopped = true;
        screenText.SetText("");

        if (level >= 2)
        {
            // Switch status screen

            return;
        }
        else {
            if (tutorialIndex >= tutorial.Length - 1) return;
            tutorialIndex++;
            if (tutorialIndex == 7)
            {
                puzzle.startPuzzle(level);
            }
        }
        
    }

    public void highlightRandomCrates() {
        var crates = GameObject.FindGameObjectsWithTag("Crate");
        // cratesToDeliver.Clear();
        for (int i = 0; i < level; i++)
        {
            var selectionIndex = Random.Range(0, crates.Length);
            var selection = crates[selectionIndex];
            highlight(selection);
            cratesToDeliver.Add(selection.name);
        }
       
    }

    private void highlight(GameObject obj) {
        foreach (Renderer renderer in obj.GetComponentsInChildren<Renderer>()) {
            foreach (Material mat in renderer.materials) {
                mat.color = Color.yellow;
            }
        }
    }

    public void completeLevel()
    {
        levelStarted = Time.fixedTime;
        deliveredCrates.Clear();
        highlightRandomCrates();
        level++;
    }

    public int getLevel()
    {
        return level;
    }

    public void deliverObject(string name) {
        deliveredCrates.Add(name);
    }

    public void checkDeliveredCrates()
    {
        if (level == 1) return;
        if (deliveredCrates.Count == cratesToDeliver.Count)
        {
            foreach (string crateName in deliveredCrates)
            {
                if (cratesToDeliver.Contains(crateName))
                {
                    cratesToDeliver.Remove(crateName);
                    score++;
                }
            }
            puzzle.startPuzzle(level);
        }
    }


}
