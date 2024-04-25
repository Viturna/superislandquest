using UnityEngine;

public class TremblementReveil : MonoBehaviour
{
    public float vitesse = 1.0f; // Vitesse de déplacement
    public float distance = 0.1f; // Distance maximale de déplacement
    private bool versLaDroite = true; // Indique si le réveil se déplace vers la droite
    private Vector2 positionActuelle;
    [SerializeField] private AudioManager audioManager;

    private void Start()
    {
        positionActuelle = new Vector2(transform.position.x, transform.position.y);
    }

    void Update()
    {
        audioManager.PlaySFX(audioManager.clockSFX);
        // Déplace le réveil de gauche à droite
        if (versLaDroite)
        {
            transform.Translate(Vector3.right * Time.deltaTime * vitesse);
        }
        else
        {
            transform.Translate(Vector3.left * Time.deltaTime * vitesse);
        }

        // Change de direction lorsque la distance maximale est atteinte
        if (transform.position.x >= positionActuelle.x + distance && versLaDroite)
        {
            versLaDroite = false;
        }
        else if (transform.position.x <= positionActuelle.x - distance && !versLaDroite)
        {
            versLaDroite = true;
        }
    }
}   
