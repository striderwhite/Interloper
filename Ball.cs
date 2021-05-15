using System;
using SFML.System;
using SFML.Graphics;
class Ball : CircleShape
{

    private RenderWindow window;
    //private float radius { get; set; }
    //private float position { get; set; }
    private Vector2f velocity { get; set; }
    private SFML.Graphics.Color color { get; set; }


    public Ball(RenderWindow window, Vector2f velocity, float radius)
    {
        this.window = window;
        this.velocity = velocity;
        this.Radius = radius;
    }

    //  "Moves" the ball in the given velocity vector
    public void Move()
    {
        //  Calculate a new position
        float newX = this.Position.X + this.velocity.X;
        float newY = this.Position.Y + this.velocity.Y;

        //  Collision detection
        float maxX = (float)this.window.Size.X;
        float maxY = (float)this.window.Size.Y;

        Console.WriteLine("New: " + newX + "," + newY);
        Console.WriteLine("Max: " + maxX + "," + maxY);

        if (newX >= maxX)
        {
            this.velocity = new Vector2f(-this.velocity.X, this.velocity.Y);
        }
        else if (newX <= 0)
        {
            this.velocity = new Vector2f(-this.velocity.X, this.velocity.Y);
        }

        if (newY >= maxY)
        {
            this.velocity = new Vector2f(this.velocity.X, -this.velocity.Y);
        }
        else if (newY <= 0)
        {
            this.velocity = new Vector2f(this.velocity.X, -this.velocity.Y);
        }

        //  Actually move the position
        this.Position = new Vector2f(this.Position.X + this.velocity.X, this.Position.Y + this.velocity.Y);
    }
}