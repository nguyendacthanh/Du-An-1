using System;
using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject main; 
    public float x, y; 

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("main"))
        {
            _animator.SetBool("open", true);
            StartCoroutine(Teleport());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("main"))
        {
            _animator.SetBool("open", false);
            
        }
    }

    private IEnumerator Teleport()
    {
        yield return new WaitForSeconds(1.5f);
        main.transform.position = new Vector3(x, y, main.transform.position.z); 
    }
}
