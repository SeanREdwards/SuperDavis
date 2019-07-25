using SuperDavis.Interfaces;
using SuperDavis.Factory;

namespace SuperDavis.Object.Block
{
    class Door
    {
        private bool isClosed;
        private bool isLocked;
        ISprite doorSprite;

        public Door()
        {
            isClosed = true;
            isLocked = false;
            doorSprite = ItemSpriteFactory.Instance.CreateCastleDoorClosed();
        }

        public void Open()
        {
            isClosed = false;
            doorSprite = ItemSpriteFactory.Instance.CreateCastleDoorOpened();
        }

        public void Close()
        {
            isClosed = true;
            doorSprite = ItemSpriteFactory.Instance.CreateCastleDoorClosed();
        }
    }
}
