using UnityEngine;

public class CameraBehaviour1 : MonoBehaviour
{
    public GameObject player;

    float newX;
    float newY;
    // Update is called once per frame
    void LateUpdate()
    {
        newX = player.transform.position.x;
        if (newX < -11.3f)
        {
            newX = -11.39f;
        }
        if (newX > 6)
        {
            newX = 6.8f;
        }
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

}
