using SocketIO;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Network : MonoBehaviour
{
    public Text numText;
    string number;
    [SerializeField] GameObject winText = null;
    [SerializeField] GameObject playAgainBT = null;
    [SerializeField] Text winID_Text;
    [SerializeField] GameObject bt1, bt2, bt3, bt4, bt5, bt6;
    [SerializeField] Text btNumText;


    static SocketIOComponent socket;


    string id;
    // Start is called before the first frame update
    void Start()
    {
        socket = GetComponent<SocketIOComponent>();
        socket.On("open", OnConnected);
        socket.On("register", OnRegister);

    }

    // Update is called once per frame
    void Update()
    {
        socket.On("win", OnWinCondition);
        socket.On("winID", OnWinID);
        socket.On("lose", OnLose);
        socket.On("Wrong", Wrong);
    }

    void OnConnected(SocketIOEvent e)
    {
        Debug.Log("connected");
    }

    private void OnRegister(SocketIOEvent obj)
    {
        Debug.Log("registered id = " + obj.data);
        id = obj.data.ToString();
    }

    public void OnWinID(SocketIOEvent e)
    {
    }
    public void OnLose(SocketIOEvent e)
    {
        winID_Text.text = "You Lose";
        playAgainBT.SetActive(true);
        Debug.Log("lose");

    }

    public void OnClickSend()
    {
        number = numText.text.ToString();
        Debug.Log(number);

        socket.Emit("send", new JSONObject(number));
        socket.Emit("sendID", new JSONObject(id));
    }
    public void OnClickPlayAgain()
    {
        Debug.Log("Click");
        winID_Text.text = "";

        winText.SetActive(false);
        playAgainBT.SetActive(false);

        bt1.SetActive(true);
        bt2.SetActive(true);
        bt3.SetActive(true);
        bt4.SetActive(true);
        bt5.SetActive(true);
        bt6.SetActive(true);
    }

    void OnWinCondition(SocketIOEvent e)
    {
        winText.SetActive(true);
        playAgainBT.SetActive(true);
    }
    void Wrong(SocketIOEvent e)
    {
        StartCoroutine(WaitForTell());
    }

    IEnumerator WaitForTell()
    {

        yield return new WaitForSeconds(2.5f);
        btNumText.text = "Wrong";

        bt1.SetActive(true);
        bt2.SetActive(true);
        bt3.SetActive(true);
        bt4.SetActive(true);
        bt5.SetActive(true);
        bt6.SetActive(true);

    }

    public void BT1()
    {
        int btNum1 = Random.Range(0, 3);
        socket.Emit("send", new JSONObject(btNum1));
        Debug.Log(btNum1);

        btNumText.text = btNum1.ToString();

        bt1.SetActive(false);
        bt2.SetActive(false);
        bt3.SetActive(false);
        bt4.SetActive(false);
        bt5.SetActive(false);
        bt6.SetActive(false);
        socket.Emit("sendID", new JSONObject(id));
    }
    public void BT2()
    {
        int btNum2 = Random.Range(1, 4);
        socket.Emit("send", new JSONObject(btNum2));
        Debug.Log(btNum2);

        btNumText.text = btNum2.ToString();

        bt1.SetActive(false);
        bt2.SetActive(false);
        bt3.SetActive(false);
        bt4.SetActive(false);
        bt5.SetActive(false);
        bt6.SetActive(false);
        socket.Emit("sendID", new JSONObject(id));
    }

    public void BT3()
    {
        int btNum3 = Random.Range(2, 5);
        socket.Emit("send", new JSONObject(btNum3));
        Debug.Log(btNum3);

        btNumText.text = btNum3.ToString();

        bt1.SetActive(false);
        bt2.SetActive(false);
        bt3.SetActive(false);
        bt4.SetActive(false);
        bt5.SetActive(false);
        bt6.SetActive(false);
        socket.Emit("sendID", new JSONObject(id));
    }

    public void BT4()
    {
        int btNum4 = Random.Range(3, 6);
        socket.Emit("send", new JSONObject(btNum4));
        Debug.Log(btNum4);

        btNumText.text = btNum4.ToString();

        bt1.SetActive(false);
        bt2.SetActive(false);
        bt3.SetActive(false);
        bt4.SetActive(false);
        bt5.SetActive(false);
        bt6.SetActive(false);
        socket.Emit("sendID", new JSONObject(id));
    }

    public void BT5()
    {
        int btNum5 = Random.Range(4, 7);
        socket.Emit("send", new JSONObject(btNum5));
        Debug.Log(btNum5);

        btNumText.text = btNum5.ToString();

        bt1.SetActive(false);
        bt2.SetActive(false);
        bt3.SetActive(false);
        bt4.SetActive(false);
        bt5.SetActive(false);
        bt6.SetActive(false);
        socket.Emit("sendID", new JSONObject(id));
    }


    public void BT6()
    {
        int btNum6 = Random.Range(5, 11);
        socket.Emit("send", new JSONObject(btNum6));
        Debug.Log(btNum6);

        btNumText.text = btNum6.ToString();

        bt1.SetActive(false);
        bt2.SetActive(false);
        bt3.SetActive(false);
        bt4.SetActive(false);
        bt5.SetActive(false);
        bt6.SetActive(false);
        socket.Emit("sendID", new JSONObject(id));
    }

}
