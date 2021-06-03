using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.position = Main.Instance.mainPlayer.transform.position;
    }
}
