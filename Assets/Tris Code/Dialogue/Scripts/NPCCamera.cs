using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCamera : MonoBehaviour
{
    private GameObject cam;
    private GameObject player;

    public float duration;

    private Vector3 midpoint;
    private Vector3 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        midpoint = new Vector3(player.transform.position.x + (transform.position.x - player.transform.position.x) / 2, cam.transform.position.y -1.5f, cam.transform.position.z);
        originalPos = new Vector3(player.transform.position.x, cam.transform.position.y + 1.5f, cam.transform.position.z);
    }

    public void FindMidpoint()
    { 
        float timeElapsed = 0.0f;

        while (timeElapsed < duration)
        {
            cam.transform.position = Vector3.Lerp(midpoint, cam.transform.position, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
        }
    }

    public void ResetCamera()
    {
        float timeElapsed = 0.0f;

        while(timeElapsed < duration)
        {
            cam.transform.position = Vector3.Lerp(originalPos, cam.transform.position, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
        }
    }
}
