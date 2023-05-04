using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkbenchBehaviour : MonoBehaviour
{
    public GameObject useText;
    bool canUse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            useText.SetActive(true);
            canUse = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            useText.SetActive(false);
            canUse = false;
        }
    }
}
