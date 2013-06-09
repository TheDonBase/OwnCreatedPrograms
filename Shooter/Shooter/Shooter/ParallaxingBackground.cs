using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter
{
    class ParallaxingBackground
    {
        Texture2D texture;
        Vector2[] positions;

        int speed;

        public void Initialize(ContentManager content, String texturePath, int screenWidth, int speed)
        {
            texture = content.Load<Texture2D>(texturePath);

            this.speed = speed;

            positions = new Vector2[screenWidth / texture.Width + 1];

            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = new Vector2(i * texture.Width, 0);
            }
        }
        public void Update()
        {
            for ( int i = 0; i < positions.Length; i++)
            {
                positions[i].X += speed;

                if (speed <= 0)
                {
                    if (positions[i].X <= -texture.Width)
                    {
                        positions[i].X = texture.Width * (positions.Length - 1);
                    }
                }
                else
                {
                    if (positions[i].X >= texture.Width * (positions.Length - 1))
                    {
                        positions[i].X = -texture.Width;
                    }
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < positions.Length; i++)
            {
                spriteBatch.Draw(texture, positions[i], Color.White);
            }
        }
    }
}
