using System.Drawing;

namespace Animation
{
    class MeSprite : Sprite
    {
        private bool right = true;
        private Image image;
        public Image Image
        {
            get {return image;}
            set { image = value;} 
        }

        public override void paint(Graphics g)
        {
            g.DrawImage(image, this.X, this.Y);
        }

        public override void act()
        {
            base.act();
            if (right)
            {
                if (this.X < 100)
                {
                    this.X++;
                }
                else
                {
                    right = false;
                    this.image.RotateFlip(RotateFlipType.Rotate180FlipY);
                }
            }
            else
            {
                if (this.X > -22)
                {
                    this.X--;
                }
                else
                {
                    right = true;
                    this.image.RotateFlip(RotateFlipType.Rotate180FlipY);
                }
            }
        }
    }
}
