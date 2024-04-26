using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMoney : MonoBehaviour
{
    [SerializeField] private GameObject money;
    public int moneyAmount = 1; // Montant d'argent à ajouter
    public float collectDistance = 1f; // Distance à laquelle l'objet peut être collecté

    private bool collected = false; // Indique si l'objet a été collecté
    [SerializeField] private AudioManager audioManager;
    // Fonction pour collecter l'argent
    void CollectMoney()
    {
        if (!collected)
        {
            // Recherche du joueur par tag
            GameObject player = GameObject.FindWithTag("Player");

            // Vérification si le joueur existe et qu'il a un composant PlayerManager
            if (player != null)
            {
                PlayerManager playerManager = player.GetComponent<PlayerManager>();

                if (playerManager != null)
                {
                    // Ajouter de l'argent à la variable nbMoney dans HUD.cs
                    playerManager.AddMoney(moneyAmount);
                }
            }

            collected = true;

            // Faire disparaître l'objet
            gameObject.SetActive(false);
        }
    }


    // Vérifier si le joueur est à portée de collecte
    void CheckCollectDistance()
    {
        GameObject player = GameObject.FindWithTag("Player");
        // Calculer la distance entre cet objet et le joueur
        float distanceToPlayer = Vector3.Distance(player.transform.position, money.transform.position);

        // Si la distance est inférieure ou égale à la distance de collecte
        if (distanceToPlayer <= collectDistance)
        {
            // Collecter l'argent
            audioManager.PlaySFX(audioManager.coinsSFX);
            CollectMoney();
        }
    }

    // Appelé à chaque frame
    void Update()
    {
        // Vérifier si le joueur est à portée de collecte à chaque frame
        CheckCollectDistance();
    }
}