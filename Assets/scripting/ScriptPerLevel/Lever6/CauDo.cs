
using UnityEngine;

public class CauDo : MonoBehaviour
{
    public GameObject door;
    public GameObject dung;
    public GameObject sai1;
    public GameObject sai2;
    public GameObject DeathDoor;

    public GameObject viTri1;
    public GameObject viTri2;
    public GameObject viTri3;


    private void Start()
    {

        Vector3 spawnPosition1 = viTri1.transform.position;
        Vector3 spawnPosition2 = viTri2.transform.position;
        Vector3 spawnPosition3 = viTri3.transform.position;

        Vector3 P1 = new Vector3(viTri1.transform.position.x+70, viTri1.transform.position.y, 1);
        Vector3 P2 = new Vector3(viTri2.transform.position.x+70, viTri2.transform.position.y, 1);
        Vector3 P3 = new Vector3(viTri3.transform.position.x+70, viTri3.transform.position.y, 1);

        int check = Random.Range(1, 4); // sửa thành (1, 4) để đảm bảo có 3 trường hợp

        if (check == 1)
        {
            door.transform.position = spawnPosition1;
            dung.transform.position = P1;
            sai1.transform.position = P2;
            sai2.transform.position = P3;
            Instantiate(DeathDoor, spawnPosition2, Quaternion.identity);
            Instantiate(DeathDoor, spawnPosition3, Quaternion.identity);
        }
        else if (check == 2)
        {
            door.transform.position = spawnPosition2;
            dung.transform.position = P2;
            sai1.transform.position = P1;
            sai2.transform.position = P3;
            Instantiate(DeathDoor, spawnPosition1, Quaternion.identity);
            Instantiate(DeathDoor, spawnPosition3, Quaternion.identity);
        }
        else
        {
            door.transform.position = spawnPosition3;
            dung.transform.position = P3;
            sai1.transform.position = P2;
            sai2.transform.position = P1;
            Instantiate(DeathDoor, spawnPosition2, Quaternion.identity);
            Instantiate(DeathDoor, spawnPosition1, Quaternion.identity);
        }
    }

}
