using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpellCast : MonoBehaviour
{
    [SerializeField] private GameObject preview;
    public LayerMask layerMask;
    public LayerMask LayerMaskWithObstacles;

    private LineDraw _lineDraw;
    private CircleDraw _circleDraw;

    private Spell currentSpell;
    private Camera _mainCamera;
    private GameObject _holdingItem;

    private void Awake()
    {
        _mainCamera = Camera.main;

        _lineDraw = GetComponentInChildren<LineDraw>();
        _circleDraw = GetComponentInChildren<CircleDraw>();
        preview.SetActive(false);
    }

    public void CastASpell(Spell s)
    {
        _lineDraw.ChangeRange(s.range);
        _circleDraw.ChangeRadius(s.range);
        currentSpell = s;
        preview.SetActive(!preview.activeSelf);
    }

    private void Update()
    {


        if (preview.activeSelf && !_holdingItem) {
            if (!Input.GetButton("Fire1")) return;
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out var hitData, 1000, layerMask)) return;
            var hitTag = hitData.transform.tag;
            if (!_lineDraw.IsInRange()) return;
            if (!currentSpell.tags.Contains(hitTag)) return;
            switch (currentSpell.name)
            {
                case "Alohomora":
                    Unlock(hitData.transform.gameObject);
                    break;
                case "Wingardium Leviosa":
                    Lift(hitData.transform.gameObject);
                    break;
            }
            Input.ResetInputAxes();
        } else if (_holdingItem)
        {
            var pos = _lineDraw.GetLastPosition();
            pos.y = _holdingItem.transform.position.y;
            _holdingItem.transform.position = pos;
            if (!Input.GetButton("Fire1")) return;
            _holdingItem = null;
            preview.SetActive(false);
        }
    }

    private void Unlock(GameObject go)
    {
        go.SetActive(false);
        preview.SetActive(false);
    }

    private void Lift(GameObject go)
    {
        if (!Physics.Linecast(_lineDraw.GetFirstPosition(), _lineDraw.GetLastPosition(), 
            out var hitData, LayerMaskWithObstacles)) return;
        if (hitData.transform.gameObject == go)
        {
            _holdingItem = go;
        }
    }
}
