using System.Collections;
using System.Collections.Generic;
using Articy.Stygian_Crossing.GlobalVariables;
using UnityEngine;
using UnityEngine.UI;

// public class Key : InspectableObject
// {
//
//     protected override void ObjectInteraction(string arg1, object arg2)
//     {
//         base.ObjectInteraction("GlobalVariables.StorageKey", true);
//     }
// }

public class Key : MonoBehaviour
{

    [SerializeField]
    private Texture2D _magnifyCursor;

    [SerializeField]
    private GlobalVariableListener _listener;

    [SerializeField]
    private string _name;

    [SerializeField]
    private GameObject _objectContainer;

    [SerializeField]
    private Sprite _iconSprite;

    [SerializeField]
    private GameObject _UIIconPrefab;

    private bool _canBeClicked = false;

    private void OnEnable()
    {
        _listener.GlobalVariableChanged += ObjectInteraction;
    }

    private void OnDisable()
    {
        _listener.GlobalVariableChanged -= ObjectInteraction;
    }

    protected virtual void ObjectInteraction(string arg1, object arg2)
    {
        if (arg1 == $"GlobalVariables.StorageKey" && (bool)arg2)
        {
            _canBeClicked = true;
            print("Variable" + "key" + "checked");
        }
    }

    private void OnMouseDown()
    {
        if (_canBeClicked == true)
        {
            print($"picking up {_name}");
            gameObject.SetActive(false);

            var UIObject = Instantiate(_UIIconPrefab);
            UIObject.transform.parent = _objectContainer.transform;
            var imageRenderer = UIObject.GetComponent<Image>();
            imageRenderer.sprite = _iconSprite;
        }
    }

    private void OnMouseEnter()
    {
        Cursor.SetCursor(_magnifyCursor, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}