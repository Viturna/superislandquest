using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuvertureCoffre : MonoBehaviour
{
    [SerializeField] private GameObject Key;
    [SerializeField] private GameObject chest;
    [SerializeField] private float offsetY = -1.0f;
    [SerializeField] private KeyCode activationKey = KeyCode.E; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(activationKey))
        {
            SpawnKey();
        }
    }
    private void SpawnKey()
    {
        if (Key != null && chest != null)
        {
            Vector3 spawnPosition = chest.transform.position + new Vector3(0, offsetY, 0); // Décalage sous le coffre
            Instantiate(Key, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("key ou chest n'est pas défini.");
        }
    }
}
