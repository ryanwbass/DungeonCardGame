using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform target;

    public float smoothTime = 0.5f;
    public Vector3 offset;
    public Vector3 velocity = Vector3.zero;

    //List of all objects that we have hidden.
    public List<Transform> hiddenObjects;
    //Layers to hide
    public LayerMask layerMask;

    public void SetTarget(Transform target)
    {
        this.target = target;
        hiddenObjects = new List<Transform>();
    }

    private void FixedUpdate ()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        Vector3 direction = target.position - transform.position;
        float distance = direction.magnitude;

        RaycastHit[] hits = Physics.RaycastAll(transform.position, direction, distance, layerMask);

        for(int i = 0; i < hits.Length; i++)
        {
            Transform currentHit = hits[i].transform;

            if (!hiddenObjects.Contains(currentHit))
            {
                hiddenObjects.Add(currentHit);
                currentHit.gameObject.SetActive(false);
            }
        }

        for(int i = 0; i < hiddenObjects.Count; i++)
        {
            bool isHit = false;
            for(int j = 0; j < hits.Length; j++)
            {
                if(hits[j].transform == hiddenObjects[i])
                {
                    isHit = true;
                    break;
                }
            }

            if (!isHit)
            {
                Transform wasHidden = hiddenObjects[i];
                wasHidden.gameObject.SetActive(true);
                hiddenObjects.RemoveAt(i);
                i--;
            }
        }
    }
}
