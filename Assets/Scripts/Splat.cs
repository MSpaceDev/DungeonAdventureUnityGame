using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Splat : MonoBehaviour {

    SpriteRenderer sr;
    float fadeTimer;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}

    private void Update()
    {
        FadeInOut();
    }

    void FadeInOut()
    {
        fadeTimer += Time.deltaTime;

        if (fadeTimer < 100f) {
            sr.color = (sr.color.a < 1.0f) ?
                new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a + 6f * Time.deltaTime) :
                new Color(sr.color.r, sr.color.g, sr.color.b, 1.0f);
        }
        else
        {
            if (sr.color.a > 0)
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - 6f * Time.deltaTime);
            else
                Destroy(gameObject);
        }
    }
}
