using System.Collections.Generic;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PhotonView))]
public class InRoomChat : Photon.MonoBehaviour  {
	public static readonly string ChatRPC = "Chat";

	public List<string> messages = new List<string>();
	public Rect GuiRect = new Rect(0,0, 250,300);
    public bool IsVisible = true;
    public bool AlignBottom = false;

	private Vector2 scrollPos = Vector2.zero;
	private string inputLine = "";

    public void Start() {
        if (this.AlignBottom) {
            this.GuiRect.y = Screen.height - this.GuiRect.height;
        }
    }

    public void OnGUI() {
        if (!this.IsVisible || PhotonNetwork.connectionStateDetailed != PeerState.Joined) {
            return;
        }
        
        if (HoldingEnter() || Event.current.keyCode == KeyCode.Return) {
            FocusOnChatInput ();
        }

        CreateChatArea ();
        SetScrollView ();
        SendEnteredMessages ();
    }

	bool HoldingEnter() {
		return Event.current.type == EventType.KeyDown && (Event.current.keyCode == KeyCode.KeypadEnter);
	}

	void CreateChatArea () {
		GUI.SetNextControlName ("");
		GUILayout.BeginArea (this.GuiRect);
	}

	void SetScrollView () {
		scrollPos = GUILayout.BeginScrollView (scrollPos);
		GUILayout.FlexibleSpace ();
		for (int i = messages.Count - 1; i >= 0; i--) {
			GUILayout.Label (messages [i]);
		}
		GUILayout.EndScrollView ();
	}
	
	void SendEnteredMessages () {
		GUILayout.BeginHorizontal ();
		GUI.SetNextControlName ("ChatInput");
		inputLine = GUILayout.TextField (inputLine);
		if (GUILayout.Button ("Send", GUILayout.ExpandWidth (false))) {
			this.photonView.RPC ("Chat", PhotonTargets.All, this.inputLine);
			this.inputLine = "";
			GUI.FocusControl ("");
		}
		GUILayout.EndHorizontal ();
		GUILayout.EndArea ();
	}

	void FocusOnChatInput () {
		if (!string.IsNullOrEmpty (this.inputLine)) {
			this.photonView.RPC ("Chat", PhotonTargets.All, this.inputLine);
			this.inputLine = "";
			GUI.FocusControl ("");
			return;
			// printing the now modified list would result in an error. to avoid this, we just skip this single frame
		} else {
			GUI.FocusControl ("ChatInput");
		}
	}

    [RPC] public void Chat(string newLine, PhotonMessageInfo info) {
        string senderName = "anonymous";

        if (info != null && info.sender != null) {
            senderName = CreateSenderName (info);
        }

        this.messages.Add(senderName +": " + newLine);
    }

	static string CreateSenderName (PhotonMessageInfo info) {
		string name = "";

		if (!string.IsNullOrEmpty (info.sender.name)) {
			name = info.sender.name;
		} else {
			name = "player " + info.sender.ID;
		}
		return name;
	}

    public void AddLine(string newLine) {
        this.messages.Add(newLine);
    }
}
