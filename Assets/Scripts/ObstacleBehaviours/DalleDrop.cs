using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DalleDrop : MonoBehaviour
{
    [SerializeField] private float delay = 0.5f;
    [SerializeField] private float shakeMagnitude = 0.1f;
    [SerializeField] private float shakeDuration = 0.1f;

    void OnTriggerEnter2D(Collider2D col)
    {
        // Si le joueur entre en collision avec l'objet
        if (col.gameObject.CompareTag("Player"))
        {
            Invoke("DestroyObject", delay);

            Shake();
        }
    }

    void DestroyObject()
    {
        Destroy(gameObject);
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
}
