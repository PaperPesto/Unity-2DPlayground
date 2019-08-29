using UnityEngine;
using UnityEngine.UI;

public class ButtonUp : MonoBehaviour
{
    public Button button;

    void Start()
    {
        button = GameObject.Find("ButtonUp").GetComponent<Button>();
        Debug.Log("ButtonUp start");
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
    }
}
