using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Realtime;
using Photon.Pun.UtilityScripts;

using Photon.Pun;

public class GoalScored : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Puck"))
        {
            //destroy current puck
            //increase score
            //goal fx

            //start coundown for new round
            //spawn new puck

            //destory current puck
            PhotonNetwork.Destroy(other.gameObject);

            //increase score
            if(this.gameObject.tag == "GoalZone0")
            {
                PhotonNetwork.PlayerList[0].SetScore(PhotonNetwork.PlayerList[0].GetScore()+1);
            }
            if (this.gameObject.tag == "GoalZone1")
            {
                PhotonNetwork.PlayerList[1].SetScore(PhotonNetwork.PlayerList[1].GetScore() + 1);
            }

            //if player0 or player1 score is < 3
                //start coundown for new round

                //spawn new puck
                PhotonNetwork.InstantiateRoomObject("Puck", new Vector3(0.0f, 5.6f, 0.0f), Quaternion.Euler(0.0f, 0.0f, 0.0f), 0);
            //else
                //end game (show final score)
                //return to lobby or start a new game

        }

    }
}
