using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour
{
    [SerializeField] private TableauReinit tableauReinit = null; // Pour réinitialiser des obstacles
    [SerializeField] private DalleDrop dalleDrop = null; // Pour valider si l'objet est détruit
    [SerializeField] private float delayBeforeAction = 2f; // Délai avant de déclencher l'action
    private Coroutine currentCoroutine = null; // Pour suivre la coroutine active

    void OnTriggerEnter2D(Collider2D col)
    {
        // Si l'obstacle entre en collision avec le joueur (objet avec le tag "Player")
        if (col.gameObject.CompareTag("Player"))
        {
            bool isDropped = dalleDrop.IsDropped();
            if (isDropped == true)
            {
                ExecuteAction(col);
            }
            // Si aucune coroutine n'est active, démarrez une nouvelle
            if (currentCoroutine == null)
            {
                currentCoroutine = StartCoroutine(ExecuteAfterDelay(col));
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        // Si le joueur quitte la collision, annulez la coroutine
        if (col.gameObject.CompareTag("Player") && currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
            currentCoroutine = null; // Réinitialiser la référence à la coroutine
        }
    }

    IEnumerator ExecuteAfterDelay(Collider2D col)
    {
        // Attendre le délai spécifié
        yield return new WaitForSeconds(delayBeforeAction);

        // Si le joueur est toujours en collision, exécuter l'action
        if (col != null && col.gameObject.CompareTag("Player"))
        {
            ExecuteAction(col);
        }
    }

    void ExecuteAction(Collider2D col)
    {
        if (tableauReinit != null)
        {
            tableauReinit.Reinit(); // Réinitialiser les obstacles
        }

        // Changer la position du joueur et le téléporter au checkpoint
        col.gameObject.transform.position = TableauManager.GetCheckpointPosition();

        // Augmenter le compteur de morts
        col.gameObject.GetComponent<PlayerManagerAnimated>().AddDeath(); // Ajouter une mort au joueur

        // Immobiliser le joueur pendant 0.5 s
        PlayerManager.SetFreeze(0.5f);
    }
}
