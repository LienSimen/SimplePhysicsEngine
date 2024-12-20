public class SimplePhysicsEngine
{
    public static void Main()
    {
        // Ball properties
        float ballY = 10f; // Initial height
        float velocity = 0f; // Initial velocity
        float gravity = -9.8f; // Gravity
        float bounceFactor = 0.90f; // Energy retained after bounce (1 = no loss)

        float groundLevel = 0f; // Ground position
        float timeStep = 0.05f; // Time step (smaller = more accurate)

        Console.CursorVisible = false;
        Console.Clear();

        while (true)
        {
            // Update velocity with gravity
            velocity += gravity * timeStep;

            // Update position based on velocity
            ballY += velocity * timeStep;

            // Collision with the ground
            if (ballY <= groundLevel)
            {
                ballY = groundLevel; // Reset position to ground level
                velocity = -velocity * bounceFactor; // Reverse and reduce velocity
            }

            // Clear screen and draw ball
            Console.Clear();
            DrawBall(ballY);

            Thread.Sleep((int)(timeStep * 1000)); // Pause to simulate frame time
        }
    }

    private static void DrawBall(float yPosition)
    {
        int screenHeight = 20; // Simulated screen height
        int ballPosition = Math.Max(0, screenHeight - (int)yPosition);

        for (int i = 0; i < screenHeight; i++)
        {
            if (i == ballPosition)
            {
                Console.WriteLine(" O "); // Draw ball
            }
            else
            {
                Console.WriteLine(); // Empty space
            }
        }
    }
}
