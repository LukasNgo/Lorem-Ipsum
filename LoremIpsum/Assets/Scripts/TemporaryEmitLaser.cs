using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// (C) Peloozoid Labs 2018
/// </summary>
public class TemporaryEmitLaser : LevelRequirement
{
    private GameObject pairedReceiver;
    [SerializeField]
    private Material inactiveMaterial;
    [SerializeField]
    private Material activeMaterial;
    public int maxReflections = 3;
    [SerializeField]
    private LineRenderer lineRenderer;
    [SerializeField]
    private bool isOn = true;

    private Renderer receiverRenderer;
    private bool active = false;

    public bool Activated
    {
        get
        {
            return active;
        }
    }

    private void Start()
    {
        receiverRenderer = pairedReceiver.GetComponent<Renderer>();
    }

    public void SetLaserActive(bool isActive)
    {
        isOn = isActive;
    }

    void FixedUpdate()
    {
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            lineRenderer.SetPosition(i, Vector3.zero);
        }

        if (isOn)
        {
            Vector3 dir = transform.right;
            Vector3 startPos = transform.position;
            int count = 1;
            List<Vector3> rendPositions = new List<Vector3>();

            RaycastHit hit;
            rendPositions.Add(startPos);

            do
            {
                count++;

                if (Physics.Raycast(startPos, dir, out hit, 50))
                {
                    if (hit.collider.gameObject == pairedReceiver)
                    {
                        rendPositions.Add(hit.point);
                        receiverRenderer.material = activeMaterial;
                        active = true;
                        break;
                    }
                    else if (hit.collider.GetComponent<MirrorReflection>() != null)
                    {
                        dir = Vector3.Reflect(dir, hit.normal);
                        startPos = hit.point;
                        Debug.DrawRay(startPos, dir * hit.distance, Color.green);
                        rendPositions.Add(startPos);
                        active = false;
                    }
                    else
                    {
                        rendPositions.Add(hit.point);
                        receiverRenderer.material = inactiveMaterial;
                        active = false;
                        break;
                    }
                }
                else
                {
                    rendPositions.Add(startPos + (dir * 50));
                    receiverRenderer.material = inactiveMaterial;
                    active = false;
                    break;
                }
            }
            while (count <= maxReflections);

            int rendPosCount = 0;
            lineRenderer.positionCount = count;
            rendPositions.ForEach(position =>
            {
                lineRenderer.SetPosition(rendPosCount, position);
                rendPosCount++;
            });

            //Debug.DrawRay(transform.position, transform.right * hit.distance, Color.green);
        }
    }

    public override bool IsComplete()
    {
        return Activated;
    }

    public void changeListener(GameObject objectToPair)
    {
        pairedReceiver = objectToPair;
    }
}
