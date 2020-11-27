using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class LightningController : MonoBehaviour
{
    public VisualEffect lightning;
    public float interval = 1.0f;
    Renderer cloudRenderer;
    Transform lightningTransform;
    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        cloudRenderer = this.gameObject.GetComponent<Renderer>();
        lightningTransform = lightning.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer == 0.0f)
        {
            RandomPos(lightningTransform);
            lightning.Play();
            timer += Time.deltaTime;
        }
        else if(timer >= interval) {
            lightning.Stop();
            timer = 0.0f;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    public void RandomPos(Transform obj)
    {
        Vector3 newPos;
        Vector3 min = cloudRenderer.bounds.min;
        Vector3 max = cloudRenderer.bounds.max;
        int temp = 1;
        newPos.x = Random.Range(min.x + temp, max.x - temp);
        newPos.y = obj.position.y; // Random.Range(min.y, max.y);
        newPos.z = Random.Range(min.z + temp, max.z - temp);

        obj.position = newPos;
    }
}
