using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserPortail : MonoBehaviour
{
    public GameObject currentTeleporter;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(currentTeleporter != null)
            {
                transform.position = currentTeleporter.GetComponent<Portail>().GetDestination().position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = null;
        }
    }
}
