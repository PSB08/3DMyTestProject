using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Nodes
{
    public class NodeMakeButton : MonoBehaviour
    {
        public GameObject rainbowBridgePrefab;
        private Dictionary<(Node, Node), GameObject> activeBridges = new();
        
        public Node nodeA;
        public Node nodeB;
        public Node nodeC;
        private bool isConnected = false;

        public GameObject uiPanel;
        public Button buttonB;
        public Button buttonC;

        private void Start()
        {
            uiPanel.SetActive(false);

            buttonB.onClick.AddListener(() => OnNodeSelected(nodeB));
            buttonC.onClick.AddListener(() => OnNodeSelected(nodeC));
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                uiPanel.SetActive(true);
            }
        }

        private void OnNodeSelected(Node targetNode)
        {
            var key = (nodeA, targetNode);

            if (nodeA.connectedNodes.Contains(targetNode))
            {
                // 연결 해제
                nodeA.DisconnectFrom(targetNode);
                Debug.Log($"{nodeA.name} ↔ {targetNode.name} 연결 해제됨");

                if (activeBridges.TryGetValue(key, out GameObject bridge))
                {
                    Destroy(bridge);
                    activeBridges.Remove(key);
                }
            }
            else
            {
                // 연결 생성
                nodeA.ConnectTo(targetNode);
                Debug.Log($"{nodeA.name} ↔ {targetNode.name} 연결됨");

                GameObject bridgeObj = Instantiate(rainbowBridgePrefab);
                var bridge = bridgeObj.GetComponent<NodePathBridge>();
                bridge.startPoint = nodeA.transform;
                bridge.endPoint = targetNode.transform;
                bridge.DrawCurve();

                activeBridges[key] = bridgeObj;
            }
            uiPanel.SetActive(false);
        }
        
        
    }
}