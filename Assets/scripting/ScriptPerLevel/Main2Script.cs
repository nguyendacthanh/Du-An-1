using System.Collections;
using UnityEngine;

public class Main2Script : MonoBehaviour
{
    private int sortingOrder;
    private int order0 = 0;
    private int order4 = 4;
    public GameObject gameObjects;

    public bool checkSort = true;
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        
    }
    void Update()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (checkSort)
        {
            StartCoroutine(Sort4());
        }
        else
        {
            StartCoroutine(Sort0());

        }

    }
    private IEnumerator Sort0()
    { 
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        yield return new WaitForSeconds(1f); 
        gameObjects.sortingOrder = order0;
    }
    private IEnumerator Sort4()
    { 
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        yield return new WaitForSeconds(3f); 
        gameObjects.sortingOrder = Sort4();
    }
}
