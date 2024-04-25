using UnityEngine;

public class GetKey : MonoBehaviour
{
    [SerializeField] private GameObject key; // Ceci est l'objet de la clé
    [SerializeField] private KeyCode activationKey = KeyCode.E;
    [SerializeField] private float activationRadius = 1.5f; // Rayon d'activation
    [SerializeField] private AudioManager audioManager;

    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (Input.GetKeyDown(activationKey))
        {
            // Vérifiez la distance entre le joueur et la clé
            float distance = Vector3.Distance(player.transform.position, transform.position);

            if (distance <= activationRadius)
            {
                // Assurez-vous que PlayerManager est attaché au joueur
                PlayerManager playerManager = player.GetComponent<PlayerManager>();
                if (playerManager != null)
                {
                    // Ajouter la clé au PlayerManager

                    audioManager.PlaySFX(audioManager.cleSFX);
                    playerManager.AddKey();

                    // Détruire l'objet de la clé après qu'il a été récupéré
                    Destroy(gameObject); // Supprime cet objet de la scène
                }
                else
                {
                    Debug.LogError("PlayerManager script is not attached to the player.");
                }
            }
        }
    }
}
