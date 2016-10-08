using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class StartGame : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text StartTheGame; // add an image as child to your button object and set its image type to Filled. Assign it to this field in inspector.
    public bool isEntered = false;
    RectTransform rt;
    Button _button;
    float timeElapsed;
    Image cursor;
    public GameObject myObject;
    // Use this for initialization
    void Awake()
    {
        _button = GetComponent<Button>();
        rt = GetComponent<RectTransform>();

    }

    float GazeActivationTime = 3;

    void Update()
    {
        if (isEntered)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= GazeActivationTime)
            {
                timeElapsed = 0;
                _button.onClick.Invoke();
                myObject.transform.position = new Vector3(0, 3, 0);
                isEntered = false;
            }
        }
        else
        {
            timeElapsed = 0;
        }
    }

    #region IPointerEnterHandler implementation

    public void OnPointerEnter(PointerEventData eventData)
    {
        isEntered = true;
    }

    #endregion

    #region IPointerExitHandler implementation

    public void OnPointerExit(PointerEventData eventData)
    {
        isEntered = false;
    }
}
    #endregion