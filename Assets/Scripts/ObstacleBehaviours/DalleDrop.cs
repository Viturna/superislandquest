using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DalleDrop : MonoBehaviour
{
    [SerializeField] private float delay = 0.5f;
    [SerializeField] private float shakeMagnitude = 0.1f;
    [SerializeField] private float shakeDuration = 0.1f;
    private SpriteRenderer spriteRenderer;
    private bool isDropped = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Si le joueur entre en collision avec l'objet
        if (col.gameObject.CompareTag("Player"))
        {
            Invoke("FadeOutObject", delay);

            Shake();
        }
    }

    void FadeOutObject()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    void Shake()
    {
        StartCoroutine(ShakeCoroutine());
    }

    IEnumerator ShakeCoroutine()
    {
        Vector3 originalPosition = transform.position;

        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float x = originalPosition.x + Random.Range(-shakeMagnitude, shakeMagnitude);
            float y = originalPosition.y + Random.Range(-shakeMagnitude, shakeMagnitude);

            transform.position = new Vector3(x, y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = originalPosition;
    }

    IEnumerator FadeOutCoroutine()
    {
        float elapsedTime = 0f;
        while (elapsedTime < delay)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / delay);
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        isDropped = true;
        // Une fois que la transition est terminée, vous pouvez détruire l'objet
        //Destroy(gameObject);
    }
    public bool IsDropped()
    {
        return isDropped; // Retourner l'état de la propriété
    }

}
