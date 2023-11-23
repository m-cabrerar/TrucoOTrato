using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionScreen : MonoBehaviour
{
    public static TransitionScreen Instance {get; private set;}

    [SerializeField] private Image _image;
    [SerializeField] private float _transitionTime = 0.15f;
    private Color _color;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        _color = _image.color;
    }

    public void TransitionTo(Escena escena, int nombreEscena = -1)
    {
        if (escena == Escena.NONE)
        {
            StartCoroutine(Transition(nombreEscena));
        }
        else
        {
            StartCoroutine(Transition((int)escena));
        }
    }

    private IEnumerator Transition(int nombreEscena)
    {
        float time = 0;
        float step = 0.01f;
        Time.timeScale = 0;
        SetAlpha(0);
        while (time < _transitionTime/2)
        {
            time += step;
            SetAlpha(2*time/_transitionTime);
            yield return new WaitForSecondsRealtime(step);
        }
        SetAlpha(1);
        SceneManager.LoadScene(nombreEscena);
        while (time > 0)
        {
            time -= step;
            SetAlpha(2*time/_transitionTime);
            yield return new WaitForSecondsRealtime(step);
        }
        SetAlpha(0);
        Time.timeScale = 1;
    }

    private void SetAlpha(float value)
    {
        _color.a = value;
        _image.color = _color;
    }

    void Update()
    {
        
    }
}
