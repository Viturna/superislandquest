using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        // Si le joueur entre en collision avec l'objet
        if (col.gameObject.CompareTag("Player"))
        {
          
            if (col.gameObject.GetComponent<PlayerManager>().hasKey)
            {
                col.gameObject.GetComponent<PlayerManager>().UseKey();
                Destroy(gameObject);
            }
        }
    }
}
