using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public GameObject player;

    float newX;
    float newY;
    // Update is called once per frame
    void LateUpdate()
    {
        newX = player.transform.position.x;
        if (newX < -3.5f)
        {
            newX = -3.7f;
        }
        if (newX > 6f)
        {
            newX = 6.2f;
        }
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

}
