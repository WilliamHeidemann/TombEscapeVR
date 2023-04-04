using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    private Image _fadeScreen;
    public delegate void MoveRoomDelegate(Transform room);
    public static event MoveRoomDelegate MoveRoom;
    private void Awake()
    {
        Door.StartFade += StartFade;
    }

    private void Start()
    {
        _fadeScreen = GetComponent<Image>();
        MoveRoom?.Invoke(CurrentRoom.Instance.Current);
    }

    private void StartFade(Transform room)
    {
        StartCoroutine(Fade(room));
    }
    
    private IEnumerator Fade(Transform room)
    {
        var faded = 0f;
        while (faded < 1f)
        {
            faded += Time.deltaTime;
            _fadeScreen.color = new Color(
                _fadeScreen.color.r, 
                _fadeScreen.color.g, 
                _fadeScreen.color.b, 
                faded);
            yield return null;
        }
        MoveRoom?.Invoke(room);
        while (faded > 0f)
        {
            faded -= Time.deltaTime;
            _fadeScreen.color = new Color(
                _fadeScreen.color.r, 
                _fadeScreen.color.g, 
                _fadeScreen.color.b, 
                faded);
            yield return null;
        }
    }
}
