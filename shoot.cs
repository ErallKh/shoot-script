using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public bool isReadyShoot = true;
    public float reloadTime = 1f;
    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;
    PhotonView view;

   void Start()
    {
        view = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (view.IsMine)
        {
        if (Input.GetKeyDown(KeyCode.O))
        {
            gun1.SetActive(true);
            gun2.SetActive(false);
            gun3.SetActive(false);
            reloadTime = 1f;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            gun1.SetActive(false);
            gun2.SetActive(true);
            gun3.SetActive(false);
            reloadTime = 0.3f;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            gun1.SetActive(false);
            gun2.SetActive(false);
            gun3.SetActive(true);
            reloadTime = 0.1f;
        }
        if (Input.GetMouseButton(0) && isReadyShoot == true && view.IsMine)
        {
            GameObject newBullet = Instantiate(bulletPrefab);
            newBullet.transform.position = transform.position;
            newBullet.transform.rotation = transform.rotation;
            isReadyShoot = false;
            StartCoroutine(Reload());
        }
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        isReadyShoot = true;
    }
    }
}