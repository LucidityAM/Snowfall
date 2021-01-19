using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemActionTrigger : MonoBehaviour
{
    private string gameobjectName;
    private GameObject ActionController;
    public GameObject keyItem;
    private Vector2 velocity = Vector2.zero;

    void Start()
    {
        ActionController = GameObject.FindGameObjectWithTag("Action Controller");
        keyItem = ActionController.GetComponent<SnowballThrow>().keyItem;
    }

    void Update()
    {
        gameObject.transform.position = Vector2.SmoothDamp(gameObject.transform.position, keyItem.transform.position, ref velocity, .15f, Mathf.Infinity, Time.deltaTime);
        if(keyItem.gameObject.name == "Huh")
        {
            gameObject.transform.position = Vector2.SmoothDamp(gameObject.transform.position, new Vector2(keyItem.transform.position.x, 3f), ref velocity, .15f, Mathf.Infinity, Time.deltaTime);
        }
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Key Item"))
        {
            gameobjectName = collision.gameObject.name.ToString();
            ActionController.GetComponent<KeyItemActionList>().StartCoroutine(gameobjectName + "Action");
            Destroy(this.gameObject);
        }
    }
}
