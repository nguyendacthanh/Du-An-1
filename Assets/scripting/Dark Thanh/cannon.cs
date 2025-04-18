using UnityEngine;

public class cannon : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform viTri;         

    public void Fire()
    {
        Instantiate(bulletPrefab, viTri.position, Quaternion.identity);
    }
}
