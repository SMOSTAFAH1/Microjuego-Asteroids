using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject smallAsteroidPrefab; // Prefab para el asteroide pequeño

    public void SplitAsteroid(Vector2 position)
    {
        // Instanciar dos asteroides pequeños en la posición del asteroide original
        Instantiate(smallAsteroidPrefab, position, Quaternion.identity);
        Instantiate(smallAsteroidPrefab, position, Quaternion.identity);
        
        // Destruir el asteroide original
        Destroy(gameObject);
    }
}
