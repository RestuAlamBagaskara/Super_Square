using UnityEngine;

public class Portal : MonoBehaviour
{
    public static float position;

    private void Start() {
        position = transform.position.x;
    }
}
