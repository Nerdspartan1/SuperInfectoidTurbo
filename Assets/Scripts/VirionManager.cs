﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirionManager : MonoBehaviour
{
    public List<Virion> virions;
    public int maxVirions = 20;

    private bool _isTargeting = false;
    private Virion _targetingVirion;
    private bool _hasFired = false;

    private PlayerController _playerController;

    private void Start()
    {
        _playerController = GameManager.instance.player.GetComponent<PlayerController>();
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
                    _hasFired = false;
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
            if (!_hasFired && Input.GetAxis("Shoot") != 0 && (Input.GetAxis("Horizontal2") != 0 || Input.GetAxis("Vertical2") != 0))
            {
                _playerController.PlayShootSound();
                _targetingVirion.Fire(new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2")).normalized);
                virions.Remove(_targetingVirion);
                _targetingVirion = null;
                _isTargeting = false;
                _hasFired = true;
            }
        }
    }


	public void ClearVirions()
	{
		foreach(var v in virions)
		{
			Destroy(v.gameObject);
		}
		virions.Clear();
	}
}
