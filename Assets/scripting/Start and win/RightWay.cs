using UnityEngine;

public class QuestAndAnswer: MonoBehaviour
{
    public GameObject door;
    public GameObject dung;
    public GameObject sai1;
    public GameObject sai2;
    public GameObject DeathDoor;
    public float x, y1, y2, y3;
    
    private void Start()
    {
        Vector3 spawnPosition1 = new Vector3(x, y1, DeathDoor.transform.position.z);
        Vector3 spawnPosition2 = new Vector3(x, y2, DeathDoor.transform.position.z);
        Vector3 spawnPosition3 = new Vector3(x, y3, DeathDoor.transform.position.z);
        Vector3 P1 = new Vector3(210, -50, DeathDoor.transform.position.z);
        Vector3 P2 = new Vector3(210, -80, DeathDoor.transform.position.z);
        Vector3 P3 = new Vector3(210, -110, DeathDoor.transform.position.z);
        int check = Random.Range(1, 3);
        if (check==1)
        {
            door.transform.position = spawnPosition1;
            dung.transform.position = P1;
            sai1.transform.position = P2;
            sai2.transform.position = P3;
            Instantiate(DeathDoor,spawnPosition2,Quaternion.identity);
            Instantiate(DeathDoor,spawnPosition3,Quaternion.identity);
        }else if (check == 2)
        {
            door.transform.position = spawnPosition2;
            dung.transform.position = P2;
            sai1.transform.position = P1;
            sai2.transform.position = P3;
            Instantiate(DeathDoor,spawnPosition1,Quaternion.identity);
            Instantiate(DeathDoor,spawnPosition3,Quaternion.identity);
        }else
        {
            door.transform.position = spawnPosition3;
            dung.transform.position = P3;
            sai1.transform.position = P2;
            sai2.transform.position = P1;
            Instantiate(DeathDoor,spawnPosition2,Quaternion.identity);
            Instantiate(DeathDoor,spawnPosition1,Quaternion.identity);
        }

    }
    
}
