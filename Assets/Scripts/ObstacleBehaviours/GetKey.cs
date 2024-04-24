using UnityEngine;

public class GetKey : MonoBehaviour
{
    // Assurez-vous d'avoir un script qui gère le joueur, avec une méthode pour récupérer la clé.
    void OnTriggerEnter2D(Collider2D col)
    {
        // Si le joueur entre en collision avec l'objet
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerManager>().AddKey();
            Destroy(gameObject);
        }
    }
}
