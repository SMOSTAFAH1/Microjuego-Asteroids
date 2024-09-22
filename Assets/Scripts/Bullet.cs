using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed = 1f;
    public float maxLifeTime = 3f;
    public Vector3 targetVector;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, maxLifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(translation:speed * targetVector * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            IncreaseScore();
            // Llama al método de división en el asteroide
            Asteroid asteroid = collision.gameObject.GetComponent<Asteroid>();
            if (asteroid != null)
            {
                asteroid.SplitAsteroid(transform.position);
            }
            Destroy(collision.gameObject); // Esto destruirá tanto los meteoritos grandes como los pequeños
            Destroy(gameObject); // Destruye la bala
        }
    }

    private void IncreaseScore()
    {
        Player.SCORE++;
        UptateScoreText();
    }

    private void UptateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text = "Score: " + Player.SCORE;
        
    }
}
