using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using System.Text;
using Newtonsoft.Json;


public class MyData
{
    public string clinetID;
    public string message;
    public int requestType;

}
public class SocketClient : MonoBehaviour
{
    private WebSocket webSocket;
    private bool isConnected = false;
    private int connectionAttempt = 0;  //연결 시도 횟수
    private const int maxConnectionAttempts = 3;

    MyData sendData = new MyData { message = "메세지 전송" };


    // Start is called before the first frame update
    void Start()
    {
        ConnectWebSocket();
    }

    void ConnectWebSocket()
    {
        webSocket = new WebSocket("ws://localhost:8000");
        webSocket.OnOpen += OnWebSocketOpen;
        webSocket.OnMessage += onWebSocketMessage;
        webSocket.OnClose += OnWebSocketClose;

        webSocket.ConnectAsync();
    }

    void OnWebSocketOpen(object sender, System.EventArgs e)
    {
        Debug.Log("WebSocket connected");
        isConnected = true;
        connectionAttempt = 0;
    }

    void onWebSocketMessage(object sender, MessageEventArgs e)
    {
        string jsonData = Encoding.Default.GetString(e.RawData);
        Debug.Log("Received JSON DATA : " + jsonData);

        MyData receivedData = JsonConvert.DeserializeObject<MyData>(jsonData);

        if(receivedData != null && !string.IsNullOrEmpty(receivedData.clinetID))
        {
            sendData.clinetID = receivedData.clinetID;
        }
    }

    void OnWebSocketClose(object sender, CloseEventArgs e)
    {
        Debug.Log("WebScoket connection-closed");
        isConnected = false;

        if(connectionAttempt < maxConnectionAttempts)
        {
            connectionAttempt++;
            Debug.Log("Attempting to reconnect :" + connectionAttempt);
            ConnectWebSocket();
        }
        else
        {
            Debug.Log("Failed to connect");
        }
    }

    void OnApplicationQuit()
    {
        DiscconnectWebSocket();
    }

    void DiscconnectWebSocket()
    {
        if(webSocket != null && isConnected)
        {
            webSocket.Close();
            isConnected = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (webSocket == null || !isConnected)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            sendData.requestType = 0;
            string jsonData = JsonConvert.SerializeObject(sendData);
        }
    }
}
