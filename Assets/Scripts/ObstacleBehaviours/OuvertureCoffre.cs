using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuvertureCoffre : MonoBehaviour
{
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject chest;
    [SerializeField] private KeyCode activationKey = KeyCode.E;
    [SerializeField] private float activationRadius = 1.5f;
    [SerializeField] private float delay = 1f;
    private bool keySpawned = false;
    [SerializeField] private AudioManager audioManager;
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
        if (key != null && chest != null)
        {
            if (!keySpawned)
            {
                // Déclencher l'animation d'ouverture du coffre
                audioManager.PlaySFX(audioManager.coffreSFX);
                Animator chestAnimator = chest.GetComponent<Animator>();
                if (chestAnimator != null)
                {
                    chestAnimator.SetTrigger("OpenChest");
                    StartCoroutine(ActivateKeyAfterDelay()); // Appeler la coroutine pour attendre 1 seconde
                }
                else
                {
                    Debug.LogError("Animator component not found on the chest object.");
                }
            }
        }
        else
        {
            Debug.LogError("Key or chest is not defined.");
        }
    }

    private IEnumerator ActivateKeyAfterDelay()
    {
        yield return new WaitForSeconds(delay); // Attendre le temps spécifié par le délai
        key.SetActive(true); // Activer la clé
        keySpawned = true; // Marquer la clé comme générée
    }

}