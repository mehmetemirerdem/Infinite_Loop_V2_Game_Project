using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_sc : MonoBehaviour
{
    public float speed;
    public float horizontalInput, verticalInput;

    Rigidbody rbody;

    public bool isGrounded;

    [SerializeField]
    private int lives = 3;

    //[SerializeField]
    //private spawn_manager_sc spawnmanager;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(direction * speed * Time.deltaTime);

        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -5)
        {
            Damage();
        }
    }

    private void FixedUpdate()
    {
        calculateMovement();
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    void calculateMovement()
    {
        speed = 20.0f;

        float speed_v = Input.GetAxis("Vertical");
        float speed_h = Input.GetAxis("Horizontal");
        Vector3 speed_vector = transform.forward * speed_v + transform.right * speed_h;
        speed_vector = speed_vector.normalized * speed;
        rbody.AddForce(speed_vector);

        if(Input.GetAxis("Jump") > 0.0f && isGrounded)
        {
            rbody.AddForce(new Vector3(0, 1.0f, 0), ForceMode.Impulse);
            isGrounded = false;
        }
    }

    public void Damage()
    {
        --lives;

        if (lives == 1)
        {
            StartCoroutine(GoNextLevel());
        }

        if (lives < 1)
        {
            //spawnmanager.OnPlayerDeath();
            Destroy(this.gameObject);
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator GoNextLevel()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(2);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
