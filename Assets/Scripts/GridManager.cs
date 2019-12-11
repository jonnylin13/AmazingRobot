
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject hut;
    public GameObject serverRack;
    public GameObject transparentServerRack;

    private bool hutCreated = false;
    private Dictionary<Vector2, GameObject> buildings = new Dictionary<Vector2, GameObject>();
    private Vector2 currentSelection = Vector2.negativeInfinity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool build(string type)
    {
        if (hasBuilding(currentSelection.x, currentSelection.y)) return false;
        switch (type)
        {
            case "hut":
                if (hutCreated) return false; // Can only build 1 hut
                var hutObj = Instantiate(hut, getCenterOfCell(currentSelection.x, currentSelection.y, 2f), Quaternion.Euler(0f, -90f, 0f));
                buildings.Add(currentSelection, hutObj);
                hutCreated = true;
                break;
            case "serverRack":
                var serverRackObj = Instantiate(transparentServerRack, getCenterOfCell(currentSelection.x, currentSelection.y, 0), Quaternion.identity);
                // Rotate toward player
                buildings.Add(currentSelection, serverRackObj);
                break;
            default:
                return false;
        }
        return true;
    }

    public int getSelectedCell(int gridSize, float floorScale, float hitPoint)
    {
        var normalizedHitpoint = hitPoint + (floorScale / 2.0f);
        var floorRatio = normalizedHitpoint / floorScale;
        return gridSize - Mathf.CeilToInt(floorRatio * (float)gridSize);
    }

    public void removeSelection()
    {
        GameObject gridObj = GameObject.FindGameObjectWithTag("FloorGrid");
        var gridMat = gridObj.GetComponent<Renderer>().material;
        gridMat.SetInt("_SelectCell", 0);
        this.currentSelection = Vector2.negativeInfinity;
    }

    public void addSelection(Material gridMaterial, int xCell, int yCell)
    {
        if (this.hasBuilding(xCell, yCell)) return;
        gridMaterial.SetInt("_SelectedCellX", xCell);
        gridMaterial.SetInt("_SelectedCellY", yCell);
        gridMaterial.SetInt("_SelectCell", 1);
        this.currentSelection = new Vector2(xCell, yCell);
    }

    public void addSelection(int xCell, int yCell)
    {
        GameObject gridObj = GameObject.FindGameObjectWithTag("FloorGrid");
        var gridMaterial = gridObj.GetComponent<Renderer>().material;
        this.addSelection(gridMaterial, xCell, yCell);
    }

    public bool hasCurrentSelection()
    {
        return currentSelection != Vector2.negativeInfinity;
    }

    public Vector3 getCenterOfCell(int xCell, int yCell, float height)
    {
        var x = this.remap(xCell, 0, 14, -7, 7);
        var y = this.remap(yCell, 0, 14, -7, 7);
        var unitSize = 30f / 15f;
        return new Vector3(x * unitSize, height, y * unitSize);
    }


    public Vector3 getCenterOfCell(float xCell, float yCell, float height)
    {
        return getCenterOfCell(Mathf.RoundToInt(xCell), Mathf.RoundToInt(yCell), height);
    }

    private float remap(float from, float fromMin, float fromMax, float toMin, float toMax)
    {
        float normal = Mathf.InverseLerp(fromMin, fromMax, from);
        float bValue = Mathf.Lerp(toMin, toMax, normal);
        return -bValue;
    }
  
    private bool hasBuilding(float xCell, float yCell)
    {
        return buildings.ContainsKey(new Vector2(xCell, yCell));
    }
}
