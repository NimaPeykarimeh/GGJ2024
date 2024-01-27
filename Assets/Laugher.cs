using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laugher : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] float activationRange;

    [SerializeField] LayerMask NPCLayer;
    [SerializeField] Collider[] colliders;

    [SerializeField] Collider[] NPCs;
    [SerializeField] GameObject curretnTargetNPC;
    public bool isPranking;

    int npcLaughCount;
    public bool isAllLaughing;
    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        npcLaughCount = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            startLaugher(true);
        }

        CheckCloseNpc();
    }

    public void NpcLaughed()
    {
        npcLaughCount++;
        print(npcLaughCount);
        print(NPCs.Length);
        if (npcLaughCount >= NPCs.Length)
        {
            isAllLaughing = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BankSafe") && !isAllLaughing)
        {
            gameManager.TimeOver();
        }
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
                    foreach (Collider _npc in NPCs)
                    {
                        _npc.GetComponent<SkinnedMeshRenderer>().materials[1].SetInt("_IsSelected", 0);
                    }
                    curretnTargetNPC = _col.gameObject;
                    _col.GetComponent<SkinnedMeshRenderer>().materials[1].SetInt("_IsSelected", 1);
                }
            }

        }
        else
        {
            curretnTargetNPC = null;
            foreach (Collider _npc in NPCs)
            {
                _npc.GetComponent<SkinnedMeshRenderer>().materials[1].SetInt("_IsSelected", 0);
            }
        }

        
    }

    public void startLaugher(bool _isPranking)
    {
        if (curretnTargetNPC)
        {
            isPranking = _isPranking;
            curretnTargetNPC.transform.parent.GetComponent<ControlNPC>().Laugh(_isPranking);
        }
    }
}
