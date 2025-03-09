using TMPro;
using Unity.Cinemachine;
using UnityEngine;

namespace TopDownView.Player
{
    public class PlayerChange : MonoBehaviour
    {
        [SerializeField] private GameObject player1;
        [SerializeField] private GameObject player2;
        [SerializeField] private TextMeshProUGUI text1;
        [SerializeField] private TextMeshProUGUI text2;

        private void Start()
        {
            player1.gameObject.SetActive(true);
            player2.gameObject.SetActive(false);
            text1.gameObject.SetActive(true);
            text2.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                player1.gameObject.SetActive(true);
                player2.gameObject.SetActive(false);
                text1.gameObject.SetActive(true);
                text2.gameObject.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                player1.gameObject.SetActive(false);
                player2.gameObject.SetActive(true);
                text1.gameObject.SetActive(false);
                text2.gameObject.SetActive(true);
            }

        }

    }
}
