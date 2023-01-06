using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgColors : MonoBehaviour
{
    SpriteRenderer bgMeshRenderer;
    [SerializeField] [Range(0f, 1f)] float lerpTime;

    [SerializeField] Color[] myColors;
    int colorIndex = 0;
    float t = 0f;
    int len;
    // Start is called before the first frame update
    void Start()
    {
        bgMeshRenderer = GetComponent<SpriteRenderer>();
        len = myColors.Length;
    }

    // Update is called once per frame
    void Update()
    {
        bgMeshRenderer.material.color = Color.Lerp (bgMeshRenderer.material.color, myColors[colorIndex], lerpTime);
        t = Mathf.Lerp (t, 1f, lerpTime * Time.deltaTime);
        if (t>.9f){
            t = 0f;
            colorIndex++;
            colorIndex = (colorIndex >= len) ? 0 : colorIndex;
        }
    }
}
