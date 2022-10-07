using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PopupLogic : MonoBehaviour
{
    public Text text;
    public GameObject panel;

    private void OnEnable()
    {
        UIEvents.OnShowMessage += Show;
    }
    private void OnDisable()
    {
        UIEvents.OnShowMessage -= Show;
    }

    public void Show(PopupInfo info)
    {
        StopAllCoroutines();
        StartCoroutine(ShowCoroutine(info));
    }

    public IEnumerator ShowCoroutine(PopupInfo info)
    {
        panel.SetActive(true);
        text.text = info.message;

        yield return new WaitForSeconds(info.delayInSeconds);

        panel.SetActive(false);
    }
}

public class PopupInfo
{
    public PopupInfo(string message, float delayInSeconds)
    {
        this.message = message;
        this.delayInSeconds = delayInSeconds;
    }

    public string message = "No message";
    public float delayInSeconds = 2;
}