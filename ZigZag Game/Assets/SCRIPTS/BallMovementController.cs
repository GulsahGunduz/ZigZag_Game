using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovementController : MonoBehaviour
{
    [SerializeField] float ballMovementSpeed;
    [SerializeField] RoadSpawner roadSpawner;
    [SerializeField] GameObject crystalEffect;

    public static bool isFloor = true;

    Vector3 ballDirection;
    GameManager gameManager;

    float addSpeed = 0.08f;

    private void Start()
    {
        ballDirection = Vector3.forward;
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (transform.position.y <= 0.3f)
        {
            isFloor = false;
            StartCoroutine(gameManager.RestartGame());
        }

        if (isFloor == false)
        {
            return;
        }

        if(Input.GetMouseButtonDown(0))
        {
            if (ballDirection.x == 0)
            {
                ballDirection = Vector3.left;
            }
            else
            {
                ballDirection = Vector3.forward;
            }
            ballMovementSpeed += addSpeed + Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        transform.position += ballDirection * Time.deltaTime * ballMovementSpeed;
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Road")
        {
            gameManager.IncreaseScore();
            StartCoroutine(roadSpawner.SpawnRoads());


            other.gameObject.AddComponent<Rigidbody>();
            StartCoroutine(DeleteRoad(other.gameObject));
        }
    }

    IEnumerator DeleteRoad(GameObject deletedRoad)
    {
        yield return new WaitForSeconds(1f);
        Destroy(deletedRoad);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Crystal")
        {
            ballMovementSpeed -= 0.5f;

            GameObject obj = Instantiate(crystalEffect, transform.position, Quaternion.identity);
            Destroy(obj,2);
            Destroy(other.gameObject);
        }
    }
}
