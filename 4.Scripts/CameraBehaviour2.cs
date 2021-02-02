using UnityEngine;

public class CameraBehaviour2 : MonoBehaviour
{
    public GameObject player;

    float newX;
    float newY;
    // Update is called once per frame
    void LateUpdate()
    {
        newX = player.transform.position.x;
        if (newX < -2.8f)
        {
            newX = -2.9f;
        }
        if (newX > 37)
        {
            newX = 38.25f;
        }
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

}
