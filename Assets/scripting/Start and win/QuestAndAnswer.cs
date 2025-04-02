using UnityEngine;

public class QuestAndAnswer: MonoBehaviour
{
    public GameObject door;
    public GameObject deadZone;
    public float x1, y1, x2, y2, x3, y3;
    private bool check;
    private void Start()
    {
        int check = Random.Range(1, 3);
        if (check==1)
        {
            door.transform.position = new Vector3(x1, y1, door.transform.position.z); 

        }else if (check == 2)
        {
            door.transform.position = new Vector3(x2, y2, door.transform.position.z); 
        }else if (check == 3)
        {
            door.transform.position = new Vector3(x3, y3, door.transform.position.z); 
        }

    }
    
}
