using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game3
{

    class Sprite
    {
        Texture2D texture;
        Rectangle rectangle;
        public Vector2 vector = new Vector2(0, 10);
        public Sprite(Texture2D newTexture, Rectangle newRectangle)
        {
            texture = newTexture;
            rectangle = newRectangle;

        }
        public void update()
        {

        }
        public void draw(SpriteBatch spriteBatch )
        {
            spriteBatch.Draw(texture, rectangle, color: Color.White);

        }
        public void draw(SpriteBatch spriteBatch, Vector2 vector)
        { 
            spriteBatch.Draw(texture, rectangle, color: Color.Red);

        }

    }

}
