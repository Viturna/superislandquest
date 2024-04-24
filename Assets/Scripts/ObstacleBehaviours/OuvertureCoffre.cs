using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuvertureCoffre : MonoBehaviour
{
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject chest;
    [SerializeField] private KeyCode activationKey = KeyCode.E;
    [SerializeField] private float activationRadius = 1.5f;

    private bool keySpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        // Désactiver la clé au début
        if (key != null)
        {
            key.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (Input.GetKeyDown(activationKey))
        {
            float distance = Vector3.Distance(player.transform.position, chest.transform.position);

            // Vérifiez si le joueur est dans le rayon d'activation
            if (distance <= activationRadius)
            {
                SpawnKey(); // Appeler la fonction pour activer la clé
            }
        }
    }
    private void SpawnKey()
    {
        if (key != null)
        {
           if (keySpawned == false)
               keySpawned = true;
               key.SetActive(true);
        }
        else
        {
            Debug.LogError("key ou chest n'est pas défini.");
        }
    }
}
