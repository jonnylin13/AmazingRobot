
using UnityEngine;

public class CameraLook : MonoBehaviour {

    // Implement clamping for non-VR
    public float sensitivity;
    public float smoothing;

    private GameObject player;
    private Vector2 mouseLook;
    private Vector2 smoothV;

    // Use this for initialization
    void Start () {

        player = this.transform.parent.gameObject;

    }

    // Update is called once per frame
    void Update () {

        var mouseData = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        mouseData = Vector2.Scale(mouseData, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, mouseData.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, mouseData.y, 1f / smoothing);
        mouseLook += smoothV;

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);
    }
}
