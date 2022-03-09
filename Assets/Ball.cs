using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float speed;
    public static Ball ball;
    float radius;
    Vector2 direction;

    void Awake()
    {
        ball = this;
    }

    void Start()
    {
        direction = new Vector2(0.7f * ((Random.Range(0, 2) == 1) ? 1 : -1), 0.7f * ((Random.Range(0, 2) == 1) ? 1 : -1));
        radius = transform.localScale.x / 2;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        
        if (transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0) {
            direction.y = -direction.y; }

        if (transform.position.y > GameManager.topRight.y - radius && direction.y > 0) {
            direction.y = -direction.y; }

        if (transform.position.x < GameManager.bottomLeft.x + radius && direction.x < 0) {
            Destroy(gameObject);
            Score.scoreTxt.AddEnemyPoint(); }

        if (transform.position.x > GameManager.topRight.x - radius && direction.x > 0) {
            Destroy(gameObject);
            Score.scoreTxt.AddPlayerPoint(); }
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Paddle") {
                direction.x = -direction.x;
                speed = speed + 0.5f; }
    }
}
