using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float thrustForce = 100f;
    public float rotationSpeed = 720f;

    public GameObject gun, bulletPrefabs;

    private Rigidbody _rigid;

    public static int SCORE = 0;

    //BONUS
    public static float xBorderLimit, yBorderLimit;
    //Vector2 thrustDirection;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();

        //BONUS
        yBorderLimit = Camera.main.orthographicSize+1;
        xBorderLimit = (Camera.main.orthographicSize+1) * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = Input.GetAxis("Horizontal") * Time.deltaTime;
        float thrust = Input.GetAxis("Vertical") * Time.deltaTime;

        Vector3 thrustDirection = transform.right;

        _rigid.AddForce(thrustDirection * thrust * thrustForce);

        transform.Rotate(Vector3.forward, angle:-rotation * rotationSpeed);

        //BONUS
        var newPos = transform.position;
        if (newPos.x > xBorderLimit)
            newPos.x = -xBorderLimit+1;
        else if (newPos.x < -xBorderLimit)
            newPos.x = xBorderLimit-1;
        else if (newPos.y > yBorderLimit)
            newPos.y = -yBorderLimit+1;
        else if (newPos.y < -yBorderLimit)
            newPos.y = yBorderLimit-1;
        transform.position = newPos;
        //BONUS

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefabs, gun.transform.position, Quaternion.identity);

            Bullet balaScript = bullet.GetComponent<Bullet>();

            balaScript.targetVector = transform.right;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if(Time.timeScale == 1){    //si la velocidad es 1
			 Time.timeScale = 0; 	//que la velocidad del juego sea 0
             GameObject go = GameObject.FindGameObjectWithTag("Pause");
             go.GetComponent<Text>().text = "Pause";
		    } else if(Time.timeScale == 0) {   // si la velocidad es 0
			 Time.timeScale = 1;  	// que la velocidad del juego regrese a 1
             GameObject go = GameObject.FindGameObjectWithTag("Pause");
             go.GetComponent<Text>().text = "";
		    }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SCORE = 0; // Reiniciar el puntaje
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reiniciar la escena actual
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SCORE = 0;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("SampleScene");
            //Application.LoadLevel("SampleScene");
            //Debug.Log(message:"SceneManager"); 
        }
        
    }
}
