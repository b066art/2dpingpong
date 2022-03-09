using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] float speed;
    float height;

    void Start()
    {
        SetPosition();
    }

    void Update()
    {
        Move();
    }

        private void SetPosition()
    {
        height = transform.localScale.y;
        Vector2 pos = Vector2.zero;
        pos = new Vector2(GameManager.topRight.x, 0);
        pos -= Vector2.right * transform.localScale.x;
        transform.position = pos;
    }

        private void Move()
    {
        if (transform.position.y > Ball.ball.transform.position.y) {
            float move = -Time.deltaTime * speed;

            if (transform.position.y < GameManager.bottomLeft.y + height / 2 && move < 0) {
                move = 0; }

            if (transform.position.y > GameManager.topRight.y - height / 2 && move > 0) {
                move = 0; }

            transform.Translate (move * Vector2.up); }

        if (transform.position.y < Ball.ball.transform.position.y) {
            float move = Time.deltaTime * speed;

            if (transform.position.y < GameManager.bottomLeft.y + height / 2 && move < 0) {
                move = 0; }

            if (transform.position.y > GameManager.topRight.y - height / 2 && move > 0) {
                move = 0; }

            transform.Translate (move * Vector2.up); }
    }

}
