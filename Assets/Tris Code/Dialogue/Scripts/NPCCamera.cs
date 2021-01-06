using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCamera : MonoBehaviour
{
    private GameObject cam;
    private GameObject player;

    public float duration;
    public float boost;

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
        // midpoint = new Vector3(player.transform.position.x + (transform.position.x - player.transform.position.x) / 2, cam.transform.position.y, cam.transform.position.z);
        // originalPos = new Vector3(player.transform.position.x, cam.transform.position.y, cam.transform.position.z);
    }

    public IEnumerator FindMidpoint()
    { 
        float timeElapsed = 0.0f;
        midpoint = new Vector3(player.transform.position.x + (transform.position.x - player.transform.position.x) / 2, cam.transform.position.y + boost, cam.transform.position.z);

        while (timeElapsed <= duration)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, midpoint, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator ResetCamera()
    {
        float timeElapsed = 0.0f;
        originalPos = new Vector3(player.transform.position.x, cam.transform.position.y - boost, cam.transform.position.z);

        while (timeElapsed <= duration)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, originalPos, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

}
