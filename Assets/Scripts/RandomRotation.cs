using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.eulerAngles = Vector3.forward * Random.Range(-180, 180);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
