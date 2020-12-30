using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoveredButtonScript : MonoBehaviour
{
    public GameObject bgBox;
    private Vector2 velocity;
    public float smoothTimeY;
    private float posY;

    public float strength;
    private float count;
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        posY = Mathf.SmoothDamp(bgBox.transform.position.y, transform.position.y, ref velocity.y, smoothTimeY);
    }

    public void Open()
    {
        while(count <= strength)
        {
            bgBox.transform.position = new Vector3(bgBox.transform.position.x, posY, bgBox.transform.position.z);
            count++;
        }
        
    }
}
