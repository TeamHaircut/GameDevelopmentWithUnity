// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Asteroid.cs" company="Exit Games GmbH">
//   Part of: Asteroid Demo
// </copyright>
// <summary>
//  Asteroid Component
// </summary>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;

using Random = UnityEngine.Random;
using Photon.Pun.UtilityScripts;

namespace Photon.Pun.Demo.Asteroids
{
    public class Puck : MonoBehaviour
    {
        public bool isLargeAsteroid;

        private bool isDestroyed;

        private PhotonView photonView;

#pragma warning disable 0109
#pragma warning restore 0109

        #region UNITY

        public void Awake()
        {
            photonView = GetComponent<PhotonView>();
        }

        public void Update()
        {
            if (!photonView.IsMine)
            {
                return;
            }

            if (Mathf.Abs(transform.position.x) > Camera.main.orthographicSize * Camera.main.aspect || Mathf.Abs(transform.position.z) > Camera.main.orthographicSize)
            {
                // Out of the screen
                PhotonNetwork.Destroy(gameObject);
            }
        }

        public void OnCollisionEnter(Collision collision)
        {
            Debug.Log(collision.gameObject);

            if (collision.gameObject.CompareTag("GoalZone1"))
            {
                    DestroyAsteroidGlobally();
                PhotonNetwork.InstantiateRoomObject("Puck", new Vector3(0.0f, 5.6f, 0.0f),Quaternion.Euler(0.0f, 0.0f, 0.0f), 0);
            }
        }

        #endregion

        private void DestroyAsteroidGlobally()
        {
            isDestroyed = true;
            PhotonNetwork.Destroy(gameObject);
        }

        private void DestroyAsteroidLocally()
        {
            isDestroyed = true;
            GetComponent<Renderer>().enabled = false;
        }
    }
}