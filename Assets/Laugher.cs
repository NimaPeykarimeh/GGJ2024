using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laugher : MonoBehaviour
{
    [SerializeField] float activationRange;

    [SerializeField] LayerMask NPCLayer;
    [SerializeField] Collider[] colliders;

    [SerializeField] GameObject[] NPCs;
    [SerializeField] GameObject curretnTargetNPC;
    public bool isPranking;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            startLaugher(true);
        }

        CheckCloseNpc();
    }

    void CheckCloseNpc()
    {
        colliders = Physics.OverlapSphere(transform.position, activationRange, NPCLayer);

        

        if (colliders.Length > 0)
        {
            float _minDist = Mathf.Infinity;
            curretnTargetNPC = colliders[0].gameObject;
            

            foreach (Collider _col in colliders)
            {
                float _currentDist = Vector3.Distance(transform.position, _col.transform.position);

                if (_currentDist < _minDist)
                {
                    _minDist = _currentDist;
                    foreach (GameObject _npc in NPCs)
                    {
                        _npc.GetComponent<MeshRenderer>().materials[1].SetInt("_IsSelected", 0);
                    }
                    curretnTargetNPC = _col.gameObject;
                    _col.GetComponent<MeshRenderer>().materials[1].SetInt("_IsSelected", 1);
                }
            }

        }
        else
        {
            curretnTargetNPC = null;
            foreach (GameObject _npc in NPCs)
            {
                _npc.GetComponent<MeshRenderer>().materials[1].SetInt("_IsSelected", 0);
            }
        }

        
    }

    public void startLaugher(bool _isPranking)
    {
        if (curretnTargetNPC)
        {
            isPranking = _isPranking;
            curretnTargetNPC.GetComponent<ControlNPC>().Laugh(_isPranking);
        }
    }
}
