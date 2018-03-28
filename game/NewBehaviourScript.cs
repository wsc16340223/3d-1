using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    private int player = 0;
    private int[,] form = new int[3, 3];

    private void Reset()
    {
        player = 0;
        for (int i = 0; i < 3;++i)
            for (int j = 0;j < 3;++j)
                form[i, j] = -1;

    }

    int IsWin()
    {
        for (int i = 0; i < 3; i++)
        {
            if (form[i, 0] != -1 && form[i, 1] == form[i, 2] && form[i, 2] == form[i, 0])
                return form[i, 0];
        }

        for (int i = 0; i < 3; i++)
        {
            if (form[0, i] != -1 && form[1, i] == form[2, i] && form[2, i] == form[0, i])
                return form[0, i];
        }

        if (form[1, 1] != -1 && ((form[1, 1] == form[0, 0] && form[1, 1] == form[2, 2]) || (form[1, 1] == form[0, 2] && form[1, 1] == form[2, 0])))
            return form[1, 1];

        for (int j = 0; j < 3; j++)
            for (int k = 0; k < 3; k++)
                if (form[j, k] == -1)
                    return -1;

        return 2;
    }
    // Use this for initialization
    void Start () {
        Reset();
	}

	void OnGUI()
    {
        if (GUI.Button(new Rect(330, 300, 100, 50), "Reset"))
            Reset();

        GUI.Label(new Rect(100, 100, 100, 50), "Player O");
        GUI.Label(new Rect(550, 100, 100, 50), "Player X");

        int result = IsWin();
        if (result == 0)
        {
            GUI.Label(new Rect(100, 160, 100, 50), "Winner!");
        }
        else if (result == 1)
        {
            GUI.Label(new Rect(550, 160, 100, 50), "Winner!");
        }
        
        for (int i = 0; i < 3;++i)
        {
            for (int j = 0;j < 3;++j)
            {
                if (GUI.Button(new Rect(300 + 50 * i, 100 + 50 * j, 50, 50), ""))
                {
                    if (result == -1)
                    {
                        form[i, j] = player;
                        if (player == 0)
                            player = 1;
                        else
                            player = 0;
                    }
                }
                else if (form[i, j] == 0)
                    GUI.Button(new Rect(300 + 50 * i, 100 + 50 * j, 50, 50), "O");
                else if (form[i, j] == 1)
                    GUI.Button(new Rect(300 + 50 * i, 100 + 50 * j, 50, 50), "X");
                
            }
        }
    }
	
}
