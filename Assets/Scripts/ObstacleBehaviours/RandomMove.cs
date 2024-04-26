using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Vitesse de l'objet, modifiable
    [SerializeField] private Rigidbody2D rb; // Le rigidbody pour bouger l'obstacle
    [SerializeField] private float delay = 0f;
    [SerializeField] private float pause = 0f;
    [SerializeField] private int maxAttempts = 10; // Nombre maximal de tentatives pour générer une direction valide
    [SerializeField] private float raycastDistance = 2.0f; // Distance du rayon de détection de collision avec les murs

    private float pauseTimer = 0f;
    private Vector2 movement;

    // Au démarrage, définir la variable de mouvement aléatoire
    void Start()
    {
        // Générer une direction de mouvement aléatoire
        GenerateRandomMovement();
    }

    // À chaque frame, on bouge l'objet via son rigidbody dans le mouvement défini * la vitesse de l'objet moveSpeed * Time.fixedDeltaTime le laps de temps écoulé en 1 frame
    void FixedUpdate()
    {
        if (delay > 0)
        {
            delay = delay - Time.fixedDeltaTime;
        }
        else if (pauseTimer > 0)
        {
            pauseTimer = pauseTimer - Time.fixedDeltaTime;
        }
        else
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    // Générer une direction de mouvement aléatoire qui n'est pas vers un mur
    void GenerateRandomMovement()
    {
        for (int i = 0; i < maxAttempts; i++)
        {
            // Générer une direction de mouvement aléatoire
            Vector2 randomDirection = Random.insideUnitCircle.normalized;

            // Lancer un rayon dans la direction aléatoire pour détecter les murs
            RaycastHit2D hit = Physics2D.Raycast(transform.position, randomDirection, raycastDistance);

            // Si le rayon ne touche pas un mur, définir la direction de mouvement et sortir de la boucle
            if (hit.collider == null)
            {
                movement = randomDirection;
                return;
            }
        }

        // Si aucune direction valide n'a été trouvée après le nombre maximal de tentatives, générer une direction aléatoire par défaut
        movement = Random.insideUnitCircle.normalized;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Si l'obstacle rentre en collision avec un mur, on réfléchit le mouvement par rapport à la normale du mur
        if (col.gameObject.tag == "Wall")
        {
            Vector2 normal = col.ClosestPoint(transform.position) - (Vector2)transform.position;
            movement = Vector2.Reflect(movement, normal.normalized);
            pauseTimer = pause;
        }
    }
}
