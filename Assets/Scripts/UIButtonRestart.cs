using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonRestart : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private string targetMessage;
    public Color highlightColor;

    private Vector3 _startSize;
    private Vector3 _clickSize;

    [SerializeField] private AudioClip click;
    void Start()
    {
        _startSize = transform.localScale;
        _clickSize = new Vector3(_startSize[0] + 0.01f, _startSize[1] + 0.01f, _startSize[2] + 0.01f);
    }


    void Update()
    {
        
    }

    public void OnMouseEnter()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = highlightColor;
        }
    }

    public void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = Color.white;
        }
    }

    public void OnMouseDown()
    {
        transform.localScale = _clickSize;
        SceneController sc = targetObject.GetComponent<SceneController>();
        if (sc != null)
        {
            sc.PlaySound(click);
        }
    }

    public void OnMouseUp()
    {
        transform.localScale = _startSize;
        if (targetObject != null)
        {
            targetObject.SendMessage(targetMessage);
        }
    }
}
