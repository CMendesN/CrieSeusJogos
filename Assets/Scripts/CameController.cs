using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    public GameObject limite;
    private Vector3 cam;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        Vector3 cam = new(Input.GetAxis("Horizontal"), 0f, 0f);
        limite.transform.position += 5f  * Time.deltaTime * cam;
    }
}
