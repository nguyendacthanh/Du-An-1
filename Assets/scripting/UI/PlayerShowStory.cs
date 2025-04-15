using UnityEngine;

public class PlayerShowStory : MonoBehaviour
{
    //Bat panel cot truyen
    public GameObject panelSign;
    public GameObject ButtonRead;
    public GameObject ButtonClose;
    public void setActiveReadWoodenSignOpen()
    {
        if (panelSign != null)
        {
            panelSign.SetActive(true);
            ButtonRead.SetActive(false);
            ButtonClose.SetActive(true);
        }
        else
        {
            Debug.Log("không có panel thông báo được ánh xạ");
        }
    }
    public void setActiveReadWoodenSignClose()
    {
        if (panelSign != null)
        {
            panelSign.SetActive(false);
            ButtonRead.SetActive(true);
            ButtonClose.SetActive(false);
        }
        else
        {
            Debug.Log("không có panel thông báo được ánh xạ");
        }
    }
}
