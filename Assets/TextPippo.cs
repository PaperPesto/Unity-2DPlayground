using UnityEngine;
using UnityEngine.UI;

public class TextPippo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Un po' di log (messo qui tanto per prova) sule dimensione x e y
        var verticalsize = Camera.main.orthographicSize * 2.0;
        var horizontalsize = verticalsize * Screen.width / Screen.height;
        Debug.Log("cameraorto vertical" + verticalsize);
        Debug.Log("cameraorto horizontal" + horizontalsize);

        // Log su dimensioni schermo
        Debug.Log("Screen.width" + Screen.width);
        Debug.Log("Screen height" + Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        var input_pre = Input.mousePosition;
        var input_post = Camera.main.ScreenToWorldPoint(input_pre);

        GameObject.Find("MousePosition").GetComponent<Text>().text = input_pre.ToString();

        GameObject.Find("MousePositionTransformed").GetComponent<Text>().text = input_post.ToString();
    }
}
