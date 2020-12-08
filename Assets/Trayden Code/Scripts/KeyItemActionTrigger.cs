using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemActionTrigger : MonoBehaviour
{
    public string gameobjectName;
    public GameObject ActionController;
    public GameObject keyItem;
    private float speed = 1.5f;
    private Vector2 velocity = Vector2.zero;
    void Start()
    {
        ActionController = GameObject.FindGameObjectWithTag("Action Controller");
        keyItem = ActionController.GetComponent<SnowballThrow>().keyItem;
    }

    void Update()
    {
        gameObject.transform.position = Vector2.SmoothDamp(gameObject.transform.position, keyItem.transform.position, ref velocity, .15f, Mathf.Infinity, Time.deltaTime);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.CompareTag("Snowball"))
        {
            gameobjectName = collision.gameObject.name.ToString();
            ActionController.GetComponent<KeyItemActionList>().StartCoroutine(gameobjectName + "Action");
            Destroy(this.gameObject);
        }
    }
}
