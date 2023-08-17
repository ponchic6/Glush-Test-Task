using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private Ray _ray;
    private RaycastHit _hit;
    // Update is called once per frame
    private void Update()
    {
        if (Vector3.Distance(_player.transform.position, transform.position) < 4)
        {
            StartCoroutine(CoroutineRotation());
        }
    }

    private IEnumerator CoroutineRotation()
    {
        Vector3 vectorFromPlayerToNPS = new Vector3(
            transform.position.x - _player.transform.position.x,
            0f,
            transform.position.z - _player.transform.position.z)
            .normalized;
        while (ScalarProduct(transform.forward, vectorFromPlayerToNPS) > -0.99)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(-vectorFromPlayerToNPS), Time.deltaTime * 0.1f);
            yield return null;
        }
    }

    private float ScalarProduct(Vector3 a, Vector3 b)
    {
        return a.x * b.x + a.y * b.y + a.z * b.z;
    }

}
