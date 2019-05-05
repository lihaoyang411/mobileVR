using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class ChangeScene : MonoBehaviour
{
    public int sceneindex;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddListener(EventTriggerType.PointerDown, Hold);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Hold() {
        SceneManager.LoadScene(sceneindex);
    }

    }

public static class EventExtensions
{

    public static void AddListener(this GameObject gameObject, EventTriggerType eventTriggerType, UnityAction action)
    {
        EventTrigger eventTrigger = gameObject.GetComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = eventTriggerType;
        entry.callback.AddListener(_ => action());

        eventTrigger.triggers.Add(entry);
    }

}
