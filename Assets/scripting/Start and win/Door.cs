using System;
using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject main,viTri; 
    

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
        Vector3 newPosition = viTri.transform.position;
        yield return new WaitForSeconds(1.5f);
        main.transform.position = new Vector3(newPosition.x + 5, newPosition.y, main.transform.position.z);
    
    }
}
