using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movie : MonoBehaviour
{

    [SerializeField]
    float speed = 100;



    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Translate(new Vector3(-CalculateRealSpeed(), 0f, 0f));
        }

        if (Input.GetKey(KeyCode.D))
        {
            Translate(new Vector3(CalculateRealSpeed(), 0f, 0f));
        }

        if (Input.GetKey(KeyCode.W))
        {
            Translate(new Vector3(0f, 0f, CalculateRealSpeed()));
        }

        if (Input.GetKey(KeyCode.S))
        {
            Translate(new Vector3(0f, 0f, -CalculateRealSpeed()));
        }



        void Translate(Vector3 translation)
        {
            transform.position = transform.position + translation;
        }

        float CalculateRealSpeed() => (speed / 100f);
    }

    void OnCollisionEnter(Collision colisor)
    {
        if (colisor.gameObject.tag == "bola")
        {
            Debug.Log("Game Over");
            Destroy(colisor.gameObject);
        }
	}
}
