using TMPro;
using Unity.Cinemachine;
using UnityEngine;

namespace TopDownView.Player
{
    public class PlayerChange : MonoBehaviour
    {
        [SerializeField] private GameObject[] players;
        [SerializeField] private TextMeshProUGUI[] texts;

        private void Start()
        {
            players[0].gameObject.SetActive(true);
            players[1].gameObject.SetActive(false);
            players[2].gameObject.SetActive(false);
            texts[0].gameObject.SetActive(true);
            texts[1].gameObject.SetActive(false);
            texts[2].gameObject.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                players[0].gameObject.SetActive(true);
                players[1].gameObject.SetActive(false);
                players[2].gameObject.SetActive(false);
                texts[0].gameObject.SetActive(true);
                texts[1].gameObject.SetActive(false);
                texts[2].gameObject.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                players[0].gameObject.SetActive(false);
                players[1].gameObject.SetActive(true);
                players[2].gameObject.SetActive(false);
                texts[0].gameObject.SetActive(false);
                texts[1].gameObject.SetActive(true);
                texts[2].gameObject.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                players[0].gameObject.SetActive(false);
                players[1].gameObject.SetActive(false);
                players[2].gameObject.SetActive(true);
                texts[0].gameObject.SetActive(false);
                texts[1].gameObject.SetActive(false);
                texts[2].gameObject.SetActive(true);
            }

        }

    }
}
