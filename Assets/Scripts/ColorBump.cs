using System;
using UnityEngine;

public class ColorBump : MonoBehaviour
{
    private SpriteRenderer sr;
    private TrailRenderer tr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        tr = GetComponent<TrailRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Color collisionColor = collision.gameObject.GetComponent<SpriteRenderer>().color;
        Color currentColor = sr.color;
        Color newColor = new Color(
            Math.Max(Math.Min((collisionColor.r + currentColor.r) / 2, 255), 0),
            Math.Max(Math.Min((collisionColor.g + currentColor.g) / 2, 255), 0),
            Math.Max(Math.Min((collisionColor.b + currentColor.b) / 2, 255), 0)
            );

        sr.color = Color.Lerp(currentColor, newColor, Mathf.PingPong(Time.time, 1));
        if (tr)
        {
            tr.startColor = newColor;
            tr.endColor = currentColor;
        }
    }
}
