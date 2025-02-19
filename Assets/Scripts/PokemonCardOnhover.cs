using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PokemonCardOnHover : MonoBehaviour
{
    private bool _ishovering;
    private Vector3 _mousePosition;
    private float _xdir;
    private float _ydir;
    private RectTransform _cardTransform;
    private bool _clicking;
    [SerializeField] private Camera camera;
    private void Start()
    {
       _ishovering = false;
       _clicking = false;
       _cardTransform = GetComponent<RectTransform>();
       //_cardTransform.transform.position = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _clicking = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _clicking = false;
            _cardTransform.rotation = Quaternion.Euler(0,0,0);
        }
        if (_ishovering&&_clicking)
        {
            _mousePosition = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,-10));
            if (Mathf.Abs(_mousePosition.x) > 1.28 || Mathf.Abs(_mousePosition.y) > 2)
            {
                _cardTransform.rotation = Quaternion.Euler(0,0,0);
            }
            else
            {
                _ydir = _mousePosition.y * 20f;
                _xdir = _mousePosition.x * 20f;
                _cardTransform.rotation = Quaternion.Euler(_ydir,_xdir,0);
            }

        }
    }
    public void OnHover()
    {
        _ishovering = true;
    }

    public void ExitHover()
    {
        _ishovering = false;
        _cardTransform.rotation = Quaternion.Euler(0,0,0);
    }
}
