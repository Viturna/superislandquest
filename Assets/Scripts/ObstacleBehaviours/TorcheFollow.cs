using UnityEngine;

public class TorcheFollow: MonoBehaviour
{
    public Transform target; // La cible à suivre (la torche ou le joueur)
    public float radius = 3f; // Le rayon de lumière

    void Update()
    {
        if (target != null)
        {
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z); // Positionner la lumière autour de la torche
            transform.localScale = new Vector3(radius, radius, 1); // Ajuster l'échelle en fonction du rayon
        }
    }
}
