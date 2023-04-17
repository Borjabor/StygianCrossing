
// public class NewsPaper : InspectableObject
// {
//
//     protected override void ObjectInteraction(string arg1, object arg2)
//     {
//         base.ObjectInteraction("GlobalVariables.newsPaper", true);
//     }
// }

using UnityEngine;
using UnityEngine.UI;

public class NewsPaper : MonoBehaviour
{

    [SerializeField]
    private Texture2D _magnifyCursor;
    
    [SerializeField]
    private Texture2D _regularCursor;

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
        if (arg1 == $"GlobalVariables.MargaretConvo2" && (bool)arg2)
        {
            _canBeClicked = true;
            gameObject.GetComponent<BoxCollider>().enabled = true;
            print("Variable" + "newspaper" + "checked");
        }
    }

    private void OnMouseDown()
    {
        if (_canBeClicked == true)
        {
            print($"picking up {_name}");
            Cursor.SetCursor(_regularCursor, Vector2.zero, CursorMode.ForceSoftware);
            var UIObject = Instantiate(_UIIconPrefab);
            UIObject.transform.parent = _objectContainer.transform;
            var imageRenderer = UIObject.GetComponent<Image>();
            imageRenderer.sprite = _iconSprite;
            
            gameObject.SetActive(false);
        }
    }

    private void OnMouseEnter()
    {
        Cursor.SetCursor(_magnifyCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(_regularCursor, Vector2.zero, CursorMode.ForceSoftware);
    }
}