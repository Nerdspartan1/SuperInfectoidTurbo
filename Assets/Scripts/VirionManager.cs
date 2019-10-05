using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirionManager : MonoBehaviour
{
    public List<Virion> virions;

    private bool _isTargeting = false;
    private Virion _targetingVirion;

    // Start is called before the first frame update
    void Start()
    {
        virions = new List<Virion>();
        foreach (Virion v in GameObject.FindObjectsOfType<Virion>())
        {
            virions.Add(v);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (virions.Count != 0)
        {
            if (Input.GetAxis("Shoot") == 0 && (Input.GetAxis("Horizontal2") != 0 || Input.GetAxis("Vertical2") != 0))
            {
                if (!_isTargeting)
                {
                    _isTargeting = true;
                    _targetingVirion = virions[Random.Range(0, virions.Count - 1)];
                }
                else
                {
                    _targetingVirion.transform.position = GameManager.instance.player.transform.position + 3 * new Vector3(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"), 0).normalized;
                }
            }
            else
            {
                _isTargeting = false;
            }
            Debug.Log("Shoot : "+Input.GetAxis("Shoot"));
            if (Input.GetAxis("Shoot") != 0 && (Input.GetAxis("Horizontal2") != 0 || Input.GetAxis("Vertical2") != 0))
            {
                _targetingVirion.Fire(new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2")).normalized);
                virions.Remove(_targetingVirion);
                _targetingVirion = null;
                _isTargeting = false;
            }
        }
    }
}
