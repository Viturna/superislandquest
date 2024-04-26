using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    void OnTriggerEnter2D(Collider2D col)
    {
        // Si le joueur entre en collision avec l'objet
        if (col.gameObject.CompareTag("Player"))
        {
          
            if (col.gameObject.GetComponent<PlayerManager>().hasKey)
            {
                audioManager.PlaySFX(audioManager.doorSFX);
                col.gameObject.GetComponent<PlayerManager>().UseKey();
                Destroy(gameObject);
            }
        }
    }
}
