using System;

public class random
{
    private Random rand = new Random();

    public int x { get; set; }
    public int y { get; set; }
    public int z { get; set; }

    public random()
    {
        x = rand.Next(0, 256); // Generates a random value between 0 and 255
        y = rand.Next(0, 256);
        z = rand.Next(0, 256);
    }

    public random   (int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public void createColor()
    {
        x = rand.Next(0, 256);
        y = rand.Next(0, 256);
        z = rand.Next(0, 256);
    }
}
