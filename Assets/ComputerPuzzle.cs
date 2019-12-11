using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPuzzle : MonoBehaviour
{

    int index = 0;
    string puzzle = "RG";
    private Renderer renderer;
    public RoundManager roundManager;
    private bool hasPuzzle = false;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startPuzzle(int level)
    {
        generatePuzzle(level);
        InvokeRepeating("flashColor", 0, 1.0f);
    }

    public bool tryAnswer(string answer)
    {
        if (answer == puzzle)
        {
            solved();
            hasPuzzle = false;
            return true;
        }
        else return false;
    }

    private void solved()
    {
        CancelInvoke("flashColor");
        index = 0;
        renderer.material.SetColor("_EmissionColor", Color.white);
        roundManager.completeLevel();
    }

    private void flashColor()
    {
        if (index > puzzle.Length - 1)
        {
            // Flash white
            renderer.material.SetColor("_EmissionColor", Color.white);
            index = 0;
        }
        else
        {
            // Flash the correct color
            Color c;
            if (puzzle[index] == 'R')
            { 
                c = Color.red;
                // Play E
                roundManager.soundManager.playE();
            }
            else {
                c = Color.green;
                // Play A
                roundManager.soundManager.playA();
            }
            renderer.material.SetColor("_EmissionColor", c);
            index++;
        }
    }

    void generatePuzzle(int level)
    {
        hasPuzzle = true;
        string puzzle = "";
        for (int i = 0; i < level; i++)
        {
            var select = Random.Range(0, 2);
            if (select == 0)
            {
                puzzle += "R";
            } else {
                puzzle += "G";
            }
        }
        this.puzzle = puzzle;
    }

    public bool HasPuzzle()
    {
        return hasPuzzle;
    }
}
