﻿using UnityEngine;
using System.Collections;

public class NetworkGUI : MonoBehaviour {

	public dfButton BackButton;
   
	public dfPanel Slot1, Slot2, Slot3, Slot4, CountdownPanel;
	public BattleController MyRobot, OpponentRobot;
	public dfLabel OwnHealth, OpponentHealth;

	BrainPanelState activePanel;
    dfLabel countdownLabel, countdownTitle, countdownFraction;

    public float ownHealth = 1.456f;
    public float opponentHealth = 0.43f;

	// Use this for initialization
	void Start () {
		BackButton.Click += BackButton_Click;     

		Slot1.Click += Slot1_Click;
		Slot2.Click += Slot2_Click;
		Slot3.Click += new MouseEventHandler(Slot3_Click);
		Slot4.Click += new MouseEventHandler(Slot4_Click);

		activePanel = Slot1.GetComponent<BrainPanelState>();

        countdownLabel = CountdownPanel.transform.Find("Countdown Label").GetComponent<dfLabel>();
        countdownTitle = CountdownPanel.transform.Find("Title Part").GetComponent<dfLabel>();
        countdownFraction = CountdownPanel.transform.Find("Fraction Part").GetComponent<dfLabel>();
	}

    public void UpdateCountdownPanel(float time)
    {
        if (time < 0)
        {
            time = 0;
        }
        int i = (int)time;
        float frac = time % 1;
        countdownLabel.Text = string.Format("{0}", i);
        countdownFraction.Text = string.Format("{0:.000}", frac);
    }

    public void SetCountdownVisibility(bool visible)
    {
        if (visible)
        {
            CountdownPanel.Show();
            countdownTitle.Text = "Match starts in";
        }
        else
        {
            CountdownPanel.Hide();
        }
    }

	void Slot4_Click(dfControl control, dfMouseEventArgs mouseEvent)
	{
		PerformSlotClick(4, control as dfPanel);
	}

	void Slot3_Click(dfControl control, dfMouseEventArgs mouseEvent)
	{
		PerformSlotClick(3, control as dfPanel);
	}

	void Slot2_Click(dfControl control, dfMouseEventArgs mouseEvent)
	{
		PerformSlotClick(2, control as dfPanel);
	}

	void Slot1_Click(dfControl control, dfMouseEventArgs mouseEvent)
	{
		PerformSlotClick(1, control as dfPanel);
	}

	void PerformSlotClick(int slot, dfPanel panel)
	{
		if (MyRobot != null)
		{
			activePanel.DeactivatePanel();
			MyRobot.SwitchBrain(slot);

			switch (slot)
			{
				case 1:
					activePanel = Slot1.GetComponent<BrainPanelState>();
					break;
				case 2:
					activePanel = Slot2.GetComponent<BrainPanelState>();
					break;
				case 3:
					activePanel = Slot3.GetComponent<BrainPanelState>();
					break;
				case 4:
					activePanel = Slot4.GetComponent<BrainPanelState>();
					break;
			}
			activePanel.ActivatePanel();
		}
	}

	void BackButton_Click(dfControl control, dfMouseEventArgs mouseEvent)
	{
		PhotonNetwork.Disconnect();
	  //  PhotonNetwork.LeaveLobby();
		Application.LoadLevel("Start Menu");
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PerformSlotClick(1, Slot1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PerformSlotClick(2, Slot2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PerformSlotClick(3, Slot3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            PerformSlotClick(4, Slot4);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            // Bloom

        }

        if (MyRobot != null)
        {
            if (MyRobot.Health.Health != ownHealth)
            {
                ownHealth = MyRobot.Health.Health;
                OwnHealth.Text = string.Format("{0:0.00}", ownHealth);
            }
        }
        if (OpponentRobot != null)
        {
            if (OpponentRobot.Health.Health != opponentHealth)
            {
                opponentHealth = OpponentRobot.Health.Health;
                OpponentHealth.Text = string.Format("{0:0.00}", opponentHealth);
            }
        }
    }
}