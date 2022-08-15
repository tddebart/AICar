
public class Controls
{
    public bool forward;
    public bool backward;
    public bool left;
    public bool right;

    public void KeyDown(Keys key)
    {
        switch (key)
        {
            case Keys.W:
                forward = true;
                break;
            case Keys.S:
                backward = true;
                break;
            case Keys.A:
                left = true;
                break;
            case Keys.D:
                right = true;
                break;
        }
    }

    public void KeyUp(Keys key)
    {
        switch (key)
        {
            case Keys.W:
                forward = false;
                break;
            case Keys.S:
                backward = false;
                break;
            case Keys.A:
                left = false;
                break;
            case Keys.D:
                right = false;
                break;
        }
    }
}


